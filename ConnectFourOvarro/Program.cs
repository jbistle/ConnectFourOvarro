

using ConnectFourOvarro;


int WinLen = Interface.SelectInt(3, 7, "Select length needed to win the game.");

int BoardH = Interface.SelectInt(7, 30, "Select height of the board");
int BoardW = Interface.SelectInt(7, 30, "Select width of the board");

int[,] Board = new int[BoardH, BoardW];


int turn = 0;

int player = 1;

bool win = false;

while ( win == false)
{
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

    


    for (int i = BoardH - 1; i >= 0; i = i - 1)
    {
        if (Board[i, column-1] == 0)
        {
            Board[i, column-1] = player;
            break;
        }
    }

    turn++;
    player++;

    if (player == 3)
    {
        player = 1;
    }

}

