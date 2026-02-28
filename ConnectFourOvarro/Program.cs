

using ConnectFourOvarro;


int WinLen = Interface.SelectInt(3, 7, "Select length needed to win the game.");

int BoardH = Interface.SelectInt(7, 30, "Select height of the board");
int BoardW = Interface.SelectInt(7, 30, "Select width of the board");

int[,] Board = new int[BoardH, BoardW];

Board[0,1] = 1;
Board[0,2] = 2;

Interface.DisplayBoard(Board);