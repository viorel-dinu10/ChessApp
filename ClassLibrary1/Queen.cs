using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    class Queen : Piece
    {
        public Queen(Color color, Cell position)
        {
            this.color = color;
            this.position = position;
            this.type = Type.Queen;
        }


        public override List<Cell> CalculateMoves(Cell position, Board board)
        {
            List<Cell> moves = new List<Cell>();

            for (int i = 1; position.GetX() + i <= 7; i++)
            {
                Cell move = new Cell(position.GetX() + i, position.GetY());

                if (!IsNull(position, board, i, 0))
                {
                    if (IsCapture(position, board, i, 0))
                    {
                        moves.Add(move);
                    }
                    break;
                }
                else
                {

                    moves.Add(move);
                }
            }
            for (int i = 1; position.GetX() - i >= 0; i++)
            {
                Cell move = new Cell(position.GetX() - i, position.GetY());
                if (!IsNull(position, board, -i, 0))
                {
                    if (IsCapture(position, board, -i, 0))
                    {
                        moves.Add(move);
                    }
                    break;
                }

                else
                {
                    moves.Add(move);
                }
            }
            for (int i = 1; position.GetY() + i <= 7; i++)
            {
                Cell move = new Cell(position.GetX(), position.GetY() + i);
                if (!IsNull(position, board, 0, i))
                {
                    if (IsCapture(position, board, 0, i))
                    {
                        moves.Add(move);
                    }
                    break;
                }

                else
                {
                    moves.Add(move);
                }
            }
            for (int i = 1; position.GetY() - i >= 0; i++)
            {
                Cell move = new Cell(position.GetX(), position.GetY() - i);
                if (!IsNull(position, board, 0, -i))
                {
                    if (IsCapture(position, board, 0, -i))
                    {
                        moves.Add(move);
                    }
                    break;
                }

                else
                {
                    moves.Add(move);
                }

            }

            for (int i = 1; position.GetX() + i <= 7 && position.GetY() + i <= 7; i++)
            {
                Cell move = new Cell(position.GetX() + i, position.GetY() + i);

                if (!IsNull(position, board, i, i))
                {
                    if (IsCapture(position, board, i, i))
                    {
                        moves.Add(move);
                    }
                    break;
                }
                else
                {
                    moves.Add(move);
                }
            }

            for (int i = 1; position.GetX() + i <= 7 && position.GetY() - i >= 0; i++)
            {
                Cell move = new Cell(position.GetX() + i, position.GetY() - i);


                if (!IsNull(position, board, i, -i))
                {
                    if (IsCapture(position, board, i, -i))
                    {
                        moves.Add(move);
                    }
                    break;
                }

                else
                {
                    moves.Add(move);
                }
            }

            for (int i = 1; position.GetX() - i >= 0 && position.GetY() - i >= 0; i++)
            {
                Cell move = new Cell(position.GetX() - i, position.GetY() - i);

                if (!IsNull(position, board, -i, -i))
                {
                    if (IsCapture(position, board, -i, -i))
                    {
                        moves.Add(move);
                    }
                    break;
                }

                else
                {
                    moves.Add(move);
                }
            }

            for (int i = 1; position.GetX() - i >= 0 && position.GetY() + i <= 7; i++)
            {
                Cell move = new Cell(position.GetX() - i, position.GetY() + i);


                if (!IsNull(position, board, -i, i))
                {
                    if (IsCapture(position, board, -i, i))
                    {
                        moves.Add(move);
                    }
                    break;
                }

                else
                {
                    moves.Add(move);
                }
            }

            return moves;
        }
        public override Piece Copy()
        {
            Queen copy = new Queen(this.color, null)
            {
                color = this.color,
                type = this.type
            };
            copy.position = new Cell(this.position.GetX(), this.position.GetY());
   
            return copy;
        }

    }

}


