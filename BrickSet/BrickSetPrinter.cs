using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1
{
	internal class BrickSetPrinter
	{
		readonly BrickSet2[] BrickSets;
		readonly Graphics Graphics;

		public BrickSetPrinter(BrickSet2[] brickSets, Graphics graphics)
		{
			BrickSets = brickSets;
			Graphics = graphics;
		}

		public void Print()
		{
			SolidBrush emptyCellBrush = new(Color.Black);
			const int offsetX = 20;
			const int offsetY = 20;
			const int brickSize = 30;
			const int brickWidth = brickSize;
			const int brickHeight = brickSize;
			const int space = 2;

			foreach (BrickSet2 brickSet in BrickSets)
			{
				brickSet.Each((col, row, brick) => {
					if (brick != null)
					{
						int x = offsetX + (brickSet.ColOffset + col) * (brickWidth + space);
						int y = offsetY + (brickSet.RowOffset + row) * (brickHeight + space);

						Graphics.FillRectangle(brick.Brush, new Rectangle(x, y, brickWidth, brickHeight));
					}
				});
			}
		}
	}
}
