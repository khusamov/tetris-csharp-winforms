using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1
{
	internal class BrickSetFactory
	{
		/// <summary>
		/// Заполняет набор кирпичиков по массиву-шаблонов. 
		/// Кирпичики ставим там где нет нулей.
		/// </summary>
		public static BrickSet CreateByArray(uint[,] templateArray, Brick brick)
		{
			int rows = templateArray.GetUpperBound(0) + 1;
			int columns = templateArray.Length / rows;

			BrickSet result = new(rows, columns);

			for (int row = 0; row < rows; row++)
				for (int col = 0; col < columns; col++)
					if (templateArray[col, row] > 0)
						result[row, col] = brick;

			return result;
		}
	}
}
