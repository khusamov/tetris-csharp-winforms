using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1.Game
{
	internal class CupContentCreator : ICreator<BrickSet>
	{
		private readonly Game _game;

		public CupContentCreator(Game game)
		{
			_game = game;
		}

		public BrickSet Create()
		{
			(int rows, int columns) = _game.CupSize;

			BrickSet cupContent = new(rows - 1, columns - 2)
			{
				Offset = new(1, 0)
			};

			return cupContent;
		}
	}
}
