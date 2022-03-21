using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1
{
	/// <summary>
	/// Рисование на массиве кирпичиков.
	/// </summary>
	internal class BrickSetPainter
	{
		readonly BrickSet BrickSet;

		public BrickSetPainter(BrickSet set)
		{
			BrickSet = set;
		}

		/// <summary>
		/// Рисование линии из кирпичиков.
		/// </summary>
		public BrickSetPainter DrawLine(int row1, int col1, int row2, int col2, Func<int, int, Brick> getBrick)
		{
			Math.Bresenham.DrawLine(
				col1, row1, col2, row2, 
				(x, y) => FillBrickPlace(y, x, getBrick(y, x))
			);
			return this;
		}

		/// <summary>
		/// Заполнение ячейки кирпичиком.
		/// </summary>
		private void FillBrickPlace(int row, int column, Brick? brick = null)
		{
			brick ??= new Brick(new SolidBrush(Color.Cyan));
			BrickSet[row, column] = brick;
		}
	}
}
