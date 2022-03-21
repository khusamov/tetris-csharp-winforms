using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1
{
	internal class BrickSetPrinter
	{
		private readonly BrickSet[] BrickSets;
		private readonly Graphics Graphics;

		private const int offsetX = 20; //px
		private const int offsetY = 20; //px

		private const int brickDisplaySize = 30; //px
		private const int brickDisplayWidth = brickDisplaySize;
		private const int brickDisplayHeight = brickDisplaySize;

		private const int displaySpaceBetweenBricks = 2; //px

		public BrickSetPrinter(BrickSet[] layers, Graphics graphics)
		{
			BrickSets = layers;
			Graphics = graphics;
		}

		public void Print()
		{
			foreach (BrickSet brickSet in BrickSets)
				foreach (BrickPlace place in brickSet)
					PrintOneBrick(place, brickSet);
		}

		private void PrintOneBrick(BrickPlace place, BrickSet brickSet)
		{
			if (place.Brick != null)
			{
				int row = brickSet.Offset.Row + place.Position.Row;
				int column = brickSet.Offset.Column + place.Position.Column;

				int x = offsetX + column * (brickDisplayWidth + displaySpaceBetweenBricks);
				int y = offsetY + row * (brickDisplayHeight + displaySpaceBetweenBricks);

				PrintRectangle(place.Brick.Brush, x, y, brickDisplayWidth, brickDisplayHeight);
			}
		}

		private void PrintRectangle(Brush brush, int x, int y, int width, int height)
		{
			Graphics.FillRectangle(brush, new Rectangle(x, y, width, height));
		}
	}
}