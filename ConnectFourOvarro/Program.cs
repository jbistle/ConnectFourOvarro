

using ConnectFourOvarro;


int WinLen = Interface.SelectInt(3, 7, "Select length needed to win the game.");

int BoardH = Interface.SelectInt(7, 30, "Select height of the board");
int BoardW = Interface.SelectInt(7, 30, "Select width of the board");

int[,] Board = new int[BoardH, BoardW];


int turn = 0;

int player = 0;

bool win = false;

while ( win == false)
{
    turn++;
    player++;

    if (player == 3)
    {
        player = 1;
    }

    Interface.DisplayBoard(Board);
    Interface.TurnText(player, turn);

    int column = 0;

    while(column == 0)
    {

        column = Interface.SelectInt(1, BoardW, "Select column to drop token");
        if (Board[0, column-1] != 0)
        {
            Interface.FullColumn(Board,player,turn);
            column = 0;
        }
    }

    


    for (int i = BoardH - 1; i >= 0; i = i - 1) //placing token
    {
        if (Board[i, column-1] == 0)
        {
            Board[i, column-1] = player;
            break;
        }
    }

    //Check if win

    for (int i = 0; i < Board.GetLength(0); i++)
    {
        

        for (int j = 0; j < Board.GetLength(1); j++)
        { 

            

            bool check = false;
            int colour = Board[i, j];
            if (colour == 0) { continue; } //skip if selected is blank

            if (!(j + WinLen > Board.GetLength(1))) // if currentw + lenofwin isn't the end of the board, check for horizontal win
            {
                
                check = true;

                for (int k = 1; k < WinLen; k++)
                {
                    if (Board[i,j+k] != colour)
                    {
                        check = false;
                        break;
                    }
                }


                if (check) 
                {
                    win = true;
                    break; 
                }
            }


            if (!(i + WinLen > Board.GetLength(0))) // if currenth + lenofwin isn't the end of the board, check for vertical win
            {
                check = true;

                for (int k = 1; k < WinLen; k++)
                {
                    if (Board[i+k, j] != colour)
                    {
                        check = false;
                        break;
                    }
                }


                if (check)
                {
                    win = true;
                    break;
                }
            }

            if (!(i + WinLen > Board.GetLength(0)) && !(j + WinLen > Board.GetLength(1))) // if currenth + lenofwin isn't the end of the board, and currentw + lenofwin isn't the end of the board check for diag win NE to SW
            {
                check = true;

                for (int k = 1; k < WinLen; k++)
                {
                    if (Board[i+k, j+k] != colour)
                    {
                        check = false;
                        break;
                    }
                }


                if (check)
                {
                    win = true;
                    break;
                }
            }

            if (!(i + WinLen > Board.GetLength(0)) && !(j - WinLen + 1 < 0)) // if currenth + lenofwin isn't the end of the board, and currentw - lenofwin isn't the end of the board check for diag win NW to SE
            {
                check = true;

                for (int k = 1; k < WinLen; k++)
                {
                    if (Board[i + k, j - k] != colour)
                    {
                        check = false;
                        break;
                    }
                }


                if (check)
                {
                    win = true;
                    break;
                }
            }



            if (win)
            {
                break;
            }
            
        
        }

        if (win)
        {
            break;
        }

    }



    

}

Interface.DisplayBoard(Board);

Interface.WinText(player);

