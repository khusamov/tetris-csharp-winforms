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
		BrickSet BrickSet;

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
			// За пределами поля точки не рисуем.
			if (x >= 0 && y >= 0 && x < BrickSet.Width && y < BrickSet.Height)
			{
				BrickSet.BrickArray[x, y] = brick;
			}
		}

		/// <summary>
		/// Рисование линии из кирпичиков.
		/// Алгоритм Брезенхе́ма.
		/// https://bit.ly/3Jh1SPy
		/// </summary>
		public BrickSetPainter DrawLine(int x1, int y1, int x2, int y2, Func<int, int, Brick>? getBrick = null)
		{
			getBrick ??= ((x, y) => new Brick(new SolidBrush(Color.Cyan)));
			int deltaX = Math.Abs(x2 - x1);
			int deltaY = Math.Abs(y2 - y1);
			int signX = x1 < x2 ? 1 : -1;
			int signY = y1 < y2 ? 1 : -1;
			int error = deltaX - deltaY;
			SetPixel(x2, y2, getBrick(x2, y2));
			while (x1 != x2 || y1 != y2)
			{
				SetPixel(x1, y1, getBrick(x1, y1));
				int error2 = error * 2;
				if (error2 > -deltaY)
				{
					error -= deltaY;
					x1 += signX;
				}
				if (error2 < deltaX)
				{
					error += deltaX;
					y1 += signY;
				}
			}
			return this;
		}
	}
}
