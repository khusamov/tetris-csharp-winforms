using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1.Game
{
	internal class CupCreator : ICreator<BrickSet>
	{
		private readonly Game _game;

		public CupCreator(Game game)
		{
			_game = game;
		}

		public BrickSet Create()
		{
			(int rows, int columns) = _game.CupSize;

			BrickSet cup = new(rows, columns);
			FillCupWithWalls(cup);

			return cup;
		}

		private static void FillCupWithWalls(BrickSet cup)
		{
			static Brick getBrick(int row, int column) => new(new SolidBrush(Color.Red));

			new BrickSetPainter(cup)
				.DrawLine(0, 0, cup.Rows - 1, 0, getBrick)
				.DrawLine(0, cup.Columns - 1, cup.Rows - 1, cup.Columns - 1, getBrick)
				.DrawLine(cup.Rows - 1, 0, cup.Rows - 1, cup.Columns - 1, getBrick);
		}
	}
}
