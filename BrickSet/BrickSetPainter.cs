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
		/// Заполнение ячейки кирпичиком.
		/// </summary>
		private void SetPixel(int x, int y, Brick? brick = null)
		{
			brick ??= new Brick(new SolidBrush(Color.Cyan));
			BrickSet[x, y] = brick;
		}

		/// <summary>
		/// Рисование линии из кирпичиков.
		/// </summary>
		public BrickSetPainter DrawLine(int x1, int y1, int x2, int y2, Func<int, int, Brick>? getBrick = null)
		{
			getBrick ??= ((x, y) => new Brick(new SolidBrush(Color.Cyan)));
			Math.Bresenham.DrawLine(x1, y1, x2, y2, (x, y) => SetPixel(x, y, getBrick(x, y)));
			return this;
		}
	}
}
