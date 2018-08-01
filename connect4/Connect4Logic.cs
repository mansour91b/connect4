using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect4
{
    class Connect4Logic
    {

        public enum colors
        {
            red,
            blue,
            empty,
        }
        int turns = 0;

        public colors GetCurrentTurn()
        {
            return (turns % 2 == 0) ? colors.red : colors.blue;
        }

        colors[,] board = new colors[7,7];// first is row second is col
        public colors placepiece(int col)
        {
           
            for(int i=0; i<7; i++)
            {
                if(board[i, col] == colors.empty)
                {
                    // we found a slot for their piece
                    board[i, col] = GetCurrentTurn();

                    // now we need to check to see if that placement won this guy the game
                    for(int j=col-3; j<=col; j++)
                    {
                        if(isWinnerAt(i, j)!=colors.empty)
                        {
                            return GetCurrentTurn();
                        }
                    }

                    // if we got here, then nobody won the game this turn.
                    break;

                }
            }

            return colors.empty;
        }
        private colors isWinnerAt(int startingrow, int startingcol)
        {
            int countblue = 0;
            int countred = 0;
            for(int col = startingcol; col<startingcol+4; col++)
            {
                if(col<0 || col>=7)
                {
                    return colors.empty;
                }

                if (board[startingrow, col] == colors.blue)
                {
                    countblue++;
                }

                if (board[startingrow, col] == colors.red)
                {
                    countred++;
                }
            }

            if(countblue == 4)
            {
                return colors.blue;
            }
            if(countred == 4)
            {
                return colors.red;
            }
            return colors.empty;
        }
    }
}
