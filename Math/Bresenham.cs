using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1.Math
{
	/// <summary>
	/// Рисование линии.
	/// Алгоритм Брезенхе́ма.
	/// https://bit.ly/3Jh1SPy
	/// </summary>
	internal class Bresenham
	{
		/// <summary>
		/// Нарисовать прямую линию.
		/// </summary>
		/// <param name="x1">Начало линии</param>
		/// <param name="y1">Начало линии</param>
		/// <param name="x2">Конец линии</param>
		/// <param name="y2">Конец линии</param>
		/// <param name="setPixel">Обратная функция от (x, y)</param>
		static public void DrawLine(int x1, int y1, int x2, int y2, Action<int, int> setPixel)
		{
			int deltaX = System.Math.Abs(x2 - x1);
			int deltaY = System.Math.Abs(y2 - y1);
			int signX = x1 < x2 ? 1 : -1;
			int signY = y1 < y2 ? 1 : -1;
			int error = deltaX - deltaY;
			setPixel(x2, y2);
			while (x1 != x2 || y1 != y2)
			{
				setPixel(x1, y1);
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
		}
	}
}
