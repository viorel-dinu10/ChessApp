using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    class Knight : Piece
    {
        public Knight(Color color, Cell position)
        {
            this.color = color;
            this.position = position;
            this.type = Type.Knight;
        }


        public override List<Cell> CalculateMoves(Cell position, Board board)
        {
            List<Cell> moves = new List<Cell>();
                
            if (position.GetX() + 1 <= 7 && position.GetY() - 2  >= 0 && (IsNull(position, board, 1, -2) || IsCapture(position,board,1,-2)))
            {
                Cell move = new Cell(0, 0);
                move.SetX(position.GetX() + 1);
                move.SetY(position.GetY() - 2);
                moves.Add(move);
            }
            if (position.GetX() + 2 <= 7 && position.GetY() - 1 >= 0 && (IsNull(position, board, 2, -1) || IsCapture(position, board,2,-1)))
            {
                Cell move = new Cell(0, 0);
                move.SetX(position.GetX() + 2);
                move.SetY(position.GetY() - 1);
                moves.Add(move);
                
            }
            if (position.GetX() + 2 <= 7 && position.GetY() + 1 <= 7 &&(IsNull(position, board, 2, 1) || IsCapture(position, board, 2, 1)))
            {
                Cell move = new Cell(0, 0);
                move.SetX(position.GetX() + 2);
                move.SetY(position.GetY() + 1);
                moves.Add(move);
            }
            if (position.GetX() + 1 <= 7 && position.GetY() + 2 <= 7 && (IsNull(position, board, 1, 2) || IsCapture(position, board, 1, 2)))
            {
                Cell move = new Cell(0, 0);
                move.SetX(position.GetX() + 1);
                move.SetY(position.GetY() + 2);
                moves.Add(move);
            }
            if (position.GetX() - 1 >= 0 && position.GetY() + 2 <= 7 && (IsNull(position, board, -1, 2) || IsCapture(position, board, -1, 2)))
            {
                Cell move = new Cell(0, 0);
                move.SetX(position.GetX() - 1);
                move.SetY(position.GetY() + 2);
                moves.Add(move);
            }
            if (position.GetX() - 2 >= 0 && position.GetY() + 1 <= 7 && (IsNull(position, board, -2, 1) || IsCapture(position, board, -2, 1)))
            {
                Cell move = new Cell(0, 0);
                move.SetX(position.GetX() - 2);
                move.SetY(position.GetY() + 1);
                moves.Add(move);
            }
            if (position.GetX() - 2 >= 0 && position.GetY() - 1 >= 0 && (IsNull(position, board, -2, -1) || IsCapture(position, board, -2, -1)))
            {
                Cell move = new Cell(0, 0);
                move.SetX(position.GetX() - 2);
                move.SetY(position.GetY() - 1);
                moves.Add(move);
            }
            if (position.GetX() - 1 >= 0 && position.GetY() - 2 >= 0 && (IsNull(position, board, -1, -2) || IsCapture(position, board, -1, -2)))
            {
                Cell move = new Cell(0, 0);
                move.SetX(position.GetX() - 1);
                move.SetY(position.GetY() - 2);
                moves.Add(move);
            }
            return moves;
        }

        public override Piece Copy()
        {
            Knight copy = new Knight(this.color, null)
            {
                color = this.color,
                type = this.type
            };
            copy.position = new Cell(this.position.GetX(), this.position.GetY());

            return copy;
        }

    }

}
