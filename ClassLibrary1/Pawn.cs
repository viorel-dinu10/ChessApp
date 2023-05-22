using ChessGameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    class Pawn : Piece
    {
        bool isEnPassantPossible = false;

        public Pawn(Color color, Cell position)
        {
            this.color = color;
            this.position = position;
            this.type = Type.Pawn;
            
        }

        private bool PawnCapture(Cell position,Board board, int i, int j )
        {
            if (board.pieces[position.GetX() + i, position.GetY() + j] != null && board.pieces[position.GetX() + i, position.GetY() + j].color != board.pieces[position.GetX(), position.GetY()].color)
            {
                return true;
            }
            return false;

        }



        public override List<Cell> CalculateMoves(Cell position, Board board)
        {
            List<Cell> moves = new List<Cell>();

            if (this.color == Color.black)
            {
                if (IsNull(position, board, 0, 1) && position.GetY() + 1 <= 7)
                {
                    Cell move = new Cell(position.GetX(), position.GetY() + 1);
                    moves.Add(move);
                }

                if (!hasMoved && IsNull(position, board, 0, 2))
                {
                    Cell move = new Cell(position.GetX(), position.GetY() + 2);
                    moves.Add(move);
                }

                if (position.GetX() + 1 <= 7 && position.GetY() + 1 <= 7 && PawnCapture(position, board, 1, 1))
                {
                    Cell move = new Cell(position.GetX() + 1, position.GetY() + 1);
                    moves.Add(move);
                }

                if (position.GetX() - 1 >= 0 && position.GetY() - 1 >= 0 && PawnCapture(position, board, -1, 1))
                {
                    Cell move = new Cell(position.GetX() - 1, position.GetY() + 1);
                    moves.Add(move);
                }
            }
            else if (this.color == Color.white)
            {
                if (IsNull(position, board, 0, -1) && position.GetY() - 1 >=0)
                {
                    Cell move = new Cell(position.GetX(), position.GetY() - 1);
                    moves.Add(move);
                }

                if (!hasMoved && IsNull(position, board, 0, -2))
                {
                    Cell move = new Cell(position.GetX(), position.GetY() - 2);
                    moves.Add(move);
                }

                if (position.GetX() + 1 <= 7 && position.GetY() - 1 >= 0 && PawnCapture(position, board, +1, -1))
                {
                    Cell move = new Cell(position.GetX() + 1, position.GetY() - 1);
                    moves.Add(move);
                }

                if (position.GetX() - 1 >= 0 && position.GetY() - 1 >= 0 && PawnCapture(position, board, -1, -1) )
                {
                    Cell move = new Cell(position.GetX() - 1, position.GetY() - 1);
                    moves.Add(move);
                }
            }

            return moves;
        }

        public override Piece Copy()
        {
            Pawn copy = new Pawn(this.color, null)
            {
                color = this.color,
                type = this.type
            };
            copy.position = new Cell(this.position.GetX(), this.position.GetY());

            return copy;
        }

    }
}
