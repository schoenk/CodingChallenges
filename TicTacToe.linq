<Query Kind="Program" />

// Tic Tac Toe

class TicTacToe
{
	// 0 = empty / 1 = player1 / 2 = player2
	public int[,] board { get; set; }
	int boardSize { get; set;}

	public TicTacToe(int boardSize)
	{
		board = new int[boardSize, boardSize];
		this.boardSize = boardSize;
	}

	public void Play(int row, int column, int player)
	{
		if (player < 1 || player > 2)
		{
			Console.WriteLine("This is a two player game, only player 1 and 2 are allowed");
		}
		else if (board[row, column] != 0)
		{
			Console.WriteLine("This spot is already occupy, choose a different spot");
		}
		else
		{
			board[row, column] = player;
			if (HasWon(row, column, player))
			{
				Console.WriteLine("Player " + player + " has won!");
			}
		}
	}
	
	public bool HasWon(int row, int column, int player)
	{
		if (row + column == boardSize - 1)
		{
			return HasWonVertical(0, column, player) || HasWonHorizontal(row, 0, player) || 
			HasWonDiagonalLtoR(0, 0, player) || HasWonDiagonalRtoL(0, boardSize - 1, player);;
		}
		return HasWonVertical(0, column, player) || HasWonHorizontal(row, 0, player);
	}
	
	public bool HasWonVertical(int row, int column, int player)
	{
		if (IsWithinMargin(row, column))
		{
			if (board[row, column] == player)
			{
				if(row == boardSize - 1) return true;
				if(HasWonVertical(row + 1, column, player)) return true;				
			}
		}
		return false;
	}

	public bool HasWonHorizontal(int row, int column, int player)
	{
		if (IsWithinMargin(row, column))
		{
			if (board[row, column] == player)
			{
				if(column == boardSize - 1) return true;
				if(HasWonHorizontal(row, column + 1, player)) return true;
			}
		}
		return false;
	}

	public bool HasWonDiagonalLtoR(int row, int column, int player)
	{
		if (IsWithinMargin(row, column))
		{
			if (board[row, column] == player)
			{
				if(row == boardSize - 1 && column == boardSize - 1) return true;
				if(HasWonDiagonalLtoR(row + 1, column + 1, player)) return true;
			}
		}
		return false;
	}

	public bool HasWonDiagonalRtoL(int row, int column, int player)
	{
		if (IsWithinMargin(row, column))
		{
			if (board[row, column] == player)
			{
				if (row == boardSize - 1 && column == 0) return true;
				if (HasWonDiagonalRtoL(row + 1, column - 1, player)) return true;
			}
		}
		return false;
	}

	public bool IsWithinMargin(int row, int column)
	{
		return (row >= 0 && row < boardSize && column >= 0 && column < boardSize);
	}
}

void Main()
{
	TicTacToe myGame = new TicTacToe(3);
	myGame.Dump();
	myGame.Play(0, 0, 1);
	myGame.Dump();
	myGame.Play(1, 1, 2);
	myGame.Dump();
	myGame.Play(2, 2, 1);
	myGame.Dump();

	myGame.Play(0, 2, 2);
	myGame.Dump();
	myGame.Play(1, 0, 1);
	myGame.Dump();
	myGame.Play(2, 0, 2);
	myGame.Dump();

	myGame.Play(0, 1, 2);
	myGame.Dump();
	myGame.Play(2, 1, 2);
	myGame.Dump();
}
