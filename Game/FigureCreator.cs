using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1.Game
{
	internal class FigureCreator : ICreator<BrickSet>
	{
		private readonly Game _game;
		private readonly Polyomino.TetraminoList Tetramino = new();

		public FigureCreator(Game game)
		{
			_game = game;
		}

		public BrickSet Create()
		{
			Brick figureBrick = new(new SolidBrush(Color.GreenYellow));
			BrickSet figure = new BrickSetCreatorBasedArray(Tetramino[0], figureBrick).Create();
			figure.Offset = new(3, 3);

			return figure;
		}
	}
}
