using ChessGameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChessGameLibrary
{


    public abstract class Piece
    {
        public Cell position;
        public Color  color;
        public Type type;
        public bool hasMoved = false;
       
        public void HasMoved()
        {
            hasMoved = true;
        }
       
        public abstract List<Cell> CalculateMoves(Cell move, Board board);
        public List<Cell> moves = new List<Cell>();



        public bool IsNull(Cell move, Board board, int i, int j)
        {

            if (board.pieces[move.GetX() + i, move.GetY() + j] != null)
            {
               
                    return false;
                              
            }
            return true;
        }

        public bool IsCapture(Cell move, Board board, int i, int j)
        {

            if (!IsNull(move,board,i,j) && board.pieces[move.GetX() + i,move.GetY() + j].color != board.pieces[move.GetX(),move.GetY()].color)
            {

                return true;                

            }
            return false;
        }

        public abstract Piece Copy();
      


    }

    

   

   


    
  

  

   












}

