using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    public class Board
    {
        public Piece[,] pieces = new Piece[8, 8];
        King bKing = new King(Color.black, new Cell(4, 0));
        King wKing = new King(Color.white, new Cell(4, 7));

        public Board()
        {
            pieces[0, 1] = new Pawn(Color.black, new Cell(0, 1));
            pieces[1, 1] = new Pawn(Color.black, new Cell(1, 1));
            pieces[2, 1] = new Pawn(Color.black, new Cell(2, 1));
            pieces[3, 1] = new Pawn(Color.black, new Cell(3, 1));
            pieces[4, 1] = new Pawn(Color.black, new Cell(4, 1));
            pieces[5, 1] = new Pawn(Color.black, new Cell(5, 1));
            pieces[6, 1] = new Pawn(Color.black, new Cell(6, 1));
            pieces[7, 1] = new Pawn(Color.black, new Cell(7, 1));
            pieces[0, 0] = new Rook(Color.black, new Cell(0, 0));
            pieces[1, 0] = new Knight(Color.black, new Cell(1, 0));
            pieces[2, 0] = new Bishop(Color.black, new Cell(2, 0));
            pieces[3, 0] = new Queen(Color.black, new Cell(3, 0));
            pieces[4, 0] = bKing;
            pieces[5, 0] = new Bishop(Color.black, new Cell(5, 0));
            pieces[6, 0] = new Knight(Color.black, new Cell(6, 0));
            pieces[7, 0] = new Rook(Color.black, new Cell(7,0));

            pieces[0, 6] = new Pawn(Color.white, new Cell(0, 6));
            pieces[1, 6] = new Pawn(Color.white, new Cell(1, 6));
            pieces[2, 6] = new Pawn(Color.white, new Cell(2, 6));
            pieces[3, 6] = new Pawn(Color.white, new Cell(3, 6));
            pieces[4, 6] = new Pawn(Color.white, new Cell(4, 6));
            pieces[5, 6] = new Pawn(Color.white, new Cell(5, 6));
            pieces[6, 6] = new Pawn(Color.white, new Cell(6, 6));
            pieces[7, 6] = new Pawn(Color.white, new Cell(7, 6));
            pieces[0, 7] = new Rook(Color.white, new Cell(0, 7));
            pieces[1, 7] = new Knight(Color.white, new Cell(1, 7));
            pieces[2, 7] = new Bishop(Color.white, new Cell(2, 7));
            pieces[3, 7] = new Queen(Color.white, new Cell(3, 7));
            pieces[4, 7] = wKing;
            pieces[5, 7] = new Bishop(Color.white, new Cell(5, 7));
            pieces[6, 7] = new Knight(Color.white, new Cell(6, 7));
            pieces[7, 7] = new Rook(Color.white, new Cell(7, 7));

        }
        public Cell GetBKingPosition()
        {
            return bKing.position;

        }

        public Cell GetWKingPosition()
        {
            return wKing.position;
        }

        public void SetBKingPosition(Cell position)
        {
            bKing.position = position;
        }

        public void SetWKingPosition(Cell position)
        {
            wKing.position = position;
        }
    }





}
