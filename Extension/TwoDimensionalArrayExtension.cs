using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1.Extension
{
	internal static class TwoDimensionalArrayExtension
	{
		/// <summary>
		/// Вычисление количества строк и колонок в многомерном массиве
		/// взято из статьи https://metanit.com/sharp/tutorial/2.4.php 
		/// </summary>
		public static (int, int) GetSize<T>(this T[,] array)
		{
			int rows = array.GetUpperBound(0) + 1;
			int columns = array.Length / rows;
			return (rows, columns);
		}

		// counterclockwise
		public static T[,] RotateClockwise<T>(this T[,] array)
		{
			(int rows, int columns) = array.GetSize();

			T[,] result = new T[columns, rows];

			for (int row = 0; row < rows; row++)
				for (int col = 0; col < columns; col++)
					result[col, rows - row - 1] = array[row, col];

			return result;
		}

		/*public static T[,] Clone<T>(this T[,] array)
		{
			(int rows, int columns) = array.GetSize();

			T[,] result = new T[columns, rows];

			for (int row = 0; row < rows; row++)
				for (int col = 0; col < columns; col++)
					result[row, col] = array[row, col];

			return result;
		}*/
	}
}
