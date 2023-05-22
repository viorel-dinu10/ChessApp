using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    class King : Piece
    {

        public King(Color color, Cell position)
        {
            this.color = color;
            this.position = position;
            this.type = Type.King;
        }

     

        

        public override List<Cell> CalculateMoves(Cell position, Board board)
        {
            List<Cell> moves = new List<Cell>();

            if (position.GetX() + 1 <= 7 && (IsNull(position, board, 1, 0) || IsCapture(position, board ,1 ,0)))
            {
                Cell move = new Cell(position.GetX()+1, position.GetY());
                moves.Add(move);
            }
            if (position.GetX() - 1 >= 0 && (IsNull(position, board, -1, 0) || IsCapture(position, board, -1, 0)))
            {
                Cell move = new Cell(position.GetX() - 1, position.GetY());
                moves.Add(move);
            }
            if (position.GetY() + 1 <= 7 && (IsNull(position, board, 0, 1) || IsCapture(position, board, 0, 1)))
            {
                Cell move = new Cell(position.GetX(), position.GetY()+1);
                moves.Add(move);
            }
            if (position.GetY() - 1 >= 0 && (IsNull(position, board, 0, -1) || IsCapture(position, board, 0, -1)))
            {
                Cell move = new Cell(position.GetX(), position.GetY() - 1);
                moves.Add(move);
            }
            if (position.GetX() + 1 <= 7 && position.GetY() - 1 >= 0 && (IsNull(position, board, 1, -1) || IsCapture(position, board, 1,-1)))
            {
                Cell move = new Cell(position.GetX() + 1, position.GetY() - 1);
                moves.Add(move);
            }
            if (position.GetX() + 1 <= 7 && position.GetY() + 1 <= 7 && (IsNull(position, board, 1, 1) || IsCapture(position, board, 1, 1)))
            {
                Cell move = new Cell(position.GetX() + 1, position.GetY() + 1);
                moves.Add(move);
            }
            if (position.GetX() - 1 >= 0 && position.GetY() + 1 <= 7 && (IsNull(position, board, -1, 1) || IsCapture(position, board, -1, 1)))
            {
                Cell move = new Cell(position.GetX() - 1, position.GetY() + 1);
                moves.Add(move);

            }
            if (position.GetX() - 1 >= 0 && position.GetY() - 1 >= 0 && (IsNull(position, board, -1, -1) || IsCapture(position, board, -1, -1)))
            {
                Cell move = new Cell(position.GetX() - 1, position.GetY() - 1);
                moves.Add(move);
            }
            return moves;
        }

        public override Piece Copy()
        {
            King copy = new King(this.color, null)
            {
                color = this.color,
                type = this.type
            };
            copy.position = new Cell(this.position.GetX(), this.position.GetY());

            return copy;
        }

    }
}
