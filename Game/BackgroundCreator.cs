using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1.Game
{
	internal class BackgroundCreator : ICreator<BrickSet>
	{
		private readonly Game _game;

		public BackgroundCreator(Game game)
		{
			_game = game;
		}

		public BrickSet Create()
		{
			(int rows, int columns) = _game.CupSize;

			BrickSet background = new(rows, columns);
			foreach ((int row, int column, _) in background)
			{
				background[row, column] = new Brick(new SolidBrush(Color.Black));
			}
			
			return background;
		}
	}
}
