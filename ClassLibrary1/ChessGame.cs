using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    public class ChessGame
    {
        public Board board = new Board();
        public bool isWhiteTurn = true;
        public Cell[] lastMove = new Cell[2];

        public ChessGame()
        {



        }





        private bool IsCheck(Color color,Board board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board.pieces[i, j] != null && board.pieces[i, j].color != color)
                    {
                        if (color == Color.white && ContainsCell(board.GetWKingPosition(), board.pieces[i, j].CalculateMoves(board.pieces[i, j].position, board)))
                        {
                            return true;
                        }
                        else if (color == Color.black && ContainsCell(board.GetBKingPosition(), board.pieces[i, j].CalculateMoves(board.pieces[i,j].position,board)))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private void ChangeTurn(ref Color turn)
        {
            if (turn == Color.white)
            {
                turn = Color.black;
            }
            else
                turn = Color.white;
        }


        private bool IsCastling(Piece king, Cell target, Color turn)
        {
            Piece tempRook;
            if (king.type == Type.King && !king.hasMoved && king.color == Color.white)
            {
                if (target == board.pieces[2, 7].position && board.pieces[1, 7] == null && board.pieces[2, 7] == null && board.pieces[3, 7] == null && !board.pieces[0, 7].hasMoved)
                {
                    king.position = target;
                    board.pieces[2, 7] = king;
                    board.pieces[3, 7] = board.pieces[0, 7];
                    board.pieces[3, 7].position.SetX(3);
                    board.pieces[0, 7] = null;
                    return true;
                }
                if (target == board.pieces[6, 7].position && board.pieces[5, 7] == null && board.pieces[6, 7] == null && !board.pieces[7, 7].hasMoved)
                {
                    king.position = target;
                    board.pieces[6, 7] = king;
                    board.pieces[5, 7] = board.pieces[7, 7];
                    board.pieces[5, 7].position.SetX(5);
                    board.pieces[7, 7] = null;
                    return true;
                }
                if (!king.hasMoved && king.color == Color.black)
                {
                    if (target == board.pieces[2, 0].position && board.pieces[1, 0] == null && board.pieces[2, 0] == null && board.pieces[3, 0] == null && !board.pieces[0, 0].hasMoved)
                    {
                        king.position = target;
                        board.pieces[2, 0] = king;
                        board.pieces[3, 0] = board.pieces[0, 0];
                        board.pieces[3, 0].position.SetX(3);
                        board.pieces[0, 0] = null;
                    }
                    if (target == board.pieces[6, 0].position && board.pieces[5, 0] == null && board.pieces[6, 0] == null && !board.pieces[7, 0].hasMoved)
                    {
                        king.position = target;
                        board.pieces[6, 0] = king;
                        board.pieces[5, 0] = board.pieces[7, 0];
                        board.pieces[5, 7].position.SetX(5);
                        board.pieces[7, 0] = null;
                    }
                }
            }
            return false;
        }

        public bool ContainsCell(Cell toCompare, List<Cell> ListOfCells)
        {

            foreach (var move in ListOfCells)
            {

                if (move.GetX() == toCompare.GetX() && move.GetY() == toCompare.GetY())
                {
                    return true;
                }
            }
            return false;
        }

        private bool Move(Piece piece, Cell target, ref Color turn, ref Board board)
        {
            Cell initial = new Cell(piece.position.GetX(), piece.position.GetY());
            Board lastBoardState = new Board();


            if (ContainsCell(target, piece.CalculateMoves(piece.position, board)) && piece.color == turn && !IsCastling(piece, target, turn))
            {

                BoardClone(ref lastBoardState, board);

                board.pieces[target.GetX(), target.GetY()] = piece;
                piece.position.SetX(target.GetX());
                piece.position.SetY(target.GetY());
                board.pieces[initial.GetX(), initial.GetY()] = null;
                if (IsCheck(turn,board))
                {   
                    Console.WriteLine("Check!!");
                    BoardClone(ref board,lastBoardState);
                    return false;
                }

                piece.HasMoved();
                ChangeTurn(ref turn);
                return true;
            }
            else { return false; }
        }



        private void BoardClone(ref Board actualBoard, Board lastBoardState)
        {
            

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (lastBoardState.pieces[i, j] == null)
                    {
                        actualBoard.pieces[i, j] =  null;
                    }
                    else
                    {
                        actualBoard.pieces[i, j] = lastBoardState.pieces[i, j].Copy();
                    }
                }
            }
            
        }

     

        private bool IsCheckMate(Board board,Player player)
        {
            Color color = player.GetColor();
            if (player.GetCheckState())
            {
                for (int i = 0; i < 8; i++)
                {
                    Board lastBoardState = new Board();

                    BoardClone(ref lastBoardState, board);
                    for (int j = 0; j < 8; j++) 
                    {
                        if (board.pieces[i, j] != null && board.pieces[i, j].color != color)
                        {
                            foreach (var move in board.pieces[i, j].CalculateMoves(board.pieces[i,j].position,board))
                            {
                               

                                Move(board.pieces[i, j], move, ref color, ref board);

                                if (!IsCheck(color, board)) 
                                {
                                    BoardClone(ref board, lastBoardState); 
                                    return false;
                                }

                                BoardClone(ref board, lastBoardState); 
                            }
                        }
                    }
                }
                Color winner;
                if(color == Color.white)
                {
                    winner = Color.black;
                }else { winner = Color.white; }
                Console.WriteLine(winner + " wins.");
                return true; 
            }

            return false; 
        }

        private bool IsStaleMate()
        {

            //ToDO
            return false;
        }

        public void StartChessGame(Board board)
        {
            Console.WriteLine("CHESS GAME");
            Console.Write("All pieces are represented with letters, white with capital letters, black sith lowercase.\nThe game asks for two integers from 0 to 8 to select a piece. \nAfter that it will ask for another two integers to select the cell where the move is to be made.\n Each int has to be entered one by one.\n");

            Player player1 = new Player(false,Color.white);
            Player player2 = new Player(false, Color.black);

           
            Color turn = Color.white;
            do
            {
                
            
                    int x, y, a, b;

                    Cell target = new Cell(4, 4);

                do
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if ((i + j) % 2 == 0)
                            {

                                Console.BackgroundColor = ConsoleColor.Gray;
                                Console.ForegroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            if (board.pieces[j, i] == null)
                            {
                                Console.Write("   ");
                            }
                            else
                            {
                                switch (board.pieces[j, i].type)
                                {
                                    case Type.Pawn when board.pieces[j, i].color == Color.white:
                                        Console.Write(" P ");
                                        break;

                                    case Type.Rook when board.pieces[j, i].color == Color.white:
                                        Console.Write(" R ");
                                        break;

                                    case Type.King when board.pieces[j, i].color == Color.white:
                                        Console.Write(" K ");
                                        break;

                                    case Type.Knight when board.pieces[j, i].color == Color.white:
                                        Console.Write(" N");
                                        break;

                                    case Type.Bishop when board.pieces[j, i].color == Color.white:
                                        Console.Write(" B ");
                                        break;

                                    case Type.Queen when board.pieces[j, i].color == Color.white:
                                        Console.Write(" Q ");
                                        break;

                                    case Type.Pawn when board.pieces[j, i].color == Color.black:
                                        Console.Write(" p ");
                                        break;

                                    case Type.Rook when board.pieces[j, i].color == Color.black:
                                        Console.Write(" r ");
                                        break;

                                    case Type.King when board.pieces[j, i].color == Color.black:
                                        Console.Write(" k ");
                                        break;

                                    case Type.Knight when board.pieces[j, i].color == Color.black:
                                        Console.Write(" n ");
                                        break;

                                    case Type.Bishop when board.pieces[j, i].color == Color.black:
                                        Console.Write(" b ");
                                        break;

                                    case Type.Queen when board.pieces[j, i].color == Color.black:
                                        Console.Write(" q ");
                                        break;

                                    default:
                                        Console.Write("error");
                                        break;
                                }
                            }
                            Console.ResetColor();
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine(turn + " is to turn");
                    do
                    {
                        Console.WriteLine("Enter the x for the piece you want to move");
                        x = Convert.ToInt32(System.Console.ReadLine());
                        Console.WriteLine("Enter the y for the piece you want to move");
                        y = Convert.ToInt32(System.Console.ReadLine());

                    } while (x >= 7 && y >= 7 && x <= 0 && y <= 0 && board.pieces[x, y] == null);

                    do
                    {
                        Console.WriteLine("Enter the x for the cell where you want to move");
                        a = Convert.ToInt32(System.Console.ReadLine());
                        Console.WriteLine("Enter the y for the cell where you want to move");
                        b = Convert.ToInt32(System.Console.ReadLine());

                    } while (a >= 7 && b >= 7 && a <= 0 && b <= 0);

                    target.SetX(a); target.SetY(b);

                } while (!Move(board.pieces[x, y], target, ref turn, ref board));

          
                if (IsCheck(turn, board)){
                    if(player1.GetColor() == turn)
                    {
                        player1.SetCheckState(true);
                    }
                    if (player2.GetColor() == turn)
                    {
                        player2.SetCheckState(true);
                    }
                }
            } while (!EndGame(board));

            bool EndGame(Board _board)
            {
                if (IsCheckMate(_board,player1) || IsCheckMate(_board, player2))
                {
                    System.Console.WriteLine("Mate");
                    return true;
                }
                if (IsStaleMate())
                {
                    return true;
                }
                return false;
            }

        }
    }
}
