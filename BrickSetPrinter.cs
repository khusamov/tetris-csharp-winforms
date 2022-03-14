﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1
{
	internal class BrickSetPrinter
	{
		readonly BrickSet[] BrickSets;
		readonly Graphics Graphics;

		public BrickSetPrinter(BrickSet[] brickSets, Graphics graphics)
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
			const int space = 3;

			foreach (BrickSet brickSet in BrickSets)
			{
				brickSet.Each((col, row, brick) => {
					SolidBrush brush = brick == null ? emptyCellBrush : brick.Brush;

					int x = offsetX + (brickSet.OffsetCol + col) * (brickWidth + space);
					int y = offsetY + (brickSet.OffsetRow + row) * (brickHeight + space);

					Graphics.FillRectangle(brush, new Rectangle(x, y, brickWidth, brickHeight));
				});
			}
		}
	}
}