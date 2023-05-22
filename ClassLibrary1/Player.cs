using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    internal class Player
    {
        Color color;
        private bool isInCheck;

        public Player(bool check,Color color) {

            this.color = color;
            isInCheck = check;
        
        }
        public Color GetColor()
        {
            return this.color;
        }

        public void SetColor(Color color)
        {
            this.color = color;
        }
        public bool GetCheckState()
        {
            return isInCheck;
        }
        public void SetCheckState(bool isInCheck)
        {
            this.isInCheck = isInCheck;
        }
    }
}
