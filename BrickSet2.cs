using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1
{
	internal class BrickSet2
	{
		public int Width;
		public int Height;
		public int RowOffset = 0;
		public int ColOffset = 0;
		public Brick?[,] BrickArray;

		/// <summary>
		/// Создать набор кирпичиков по шаблону из массива.
		/// </summary>
		public static BrickSet2 CreateByArray(Brick brick, int[,] templateArray)
		{
			int rows = templateArray.GetUpperBound(0) + 1;
			int columns = templateArray.Length / rows;
			BrickSet2 newBrickSet = new(rows, columns);

			for (int row = 0; row < rows; row++)
				for (int col = 0; col < columns; col++)
					if (templateArray[col, row] > 0)
						newBrickSet.BrickArray[row, col] = brick;

			return newBrickSet;
		}

		/// <summary>
		/// Конструктор набора кирпичиков.
		/// </summary>
		public BrickSet2(int width, int height)
		{
			Width = width;
			Height = height;
			BrickArray = new Brick?[width, height];
			Fill(null);
		}

		/// <summary>
		/// Заполнение массива кирпичиками по умолчанию.
		/// </summary>
		public void Fill(Brick? brick)
		{
			Each((col, row, _) => BrickArray[col, row] = brick);
		}

		/// <summary>
		/// Сделать клон-копию набора кирпичиков.
		/// </summary>
		public BrickSet2 Clone()
		{
			BrickSet2 clone = new(Width, Height);
			clone.ColOffset = ColOffset;
			clone.RowOffset = RowOffset;
			Each((col, row, brick) => clone.BrickArray[col, row] = brick?.Clone());
			return clone;
		}

		/// <summary>
		/// Проверка на пересечения двух наборов кирпичиков.
		/// </summary>
		/// <param name="targetBrickSet"></param>
		/// <returns></returns>
		public bool IsIntersection(BrickSet2 targetBrickSet)
		{
			int countIntersection = 0;
			targetBrickSet.Each((col, row, targetBrick) => {
				Brick? brick = GetBrick(col + targetBrickSet.ColOffset, row + targetBrickSet.RowOffset);
				if (targetBrick != null && brick != null)
				{
					countIntersection++;
				}
			});
			return countIntersection > 0;
		}

		/// <summary>
		/// Обход всех кирпичиков из набора для применения действия к каждому кирпичику.
		/// </summary>
		public void Each(Action<int, int, Brick?> callback)
		{
			for (int col = 0; col < Width; col++)
				for (int row = 0; row < Height; row++)
					callback(col, row, BrickArray[col, row]);
		}

		/// <summary>
		/// Получить кирпичик по его координатам.
		/// </summary>
		public Brick? GetBrick(int x, int y)
		{
			return IsInternalRange(x, y) ? BrickArray[x, y] : null;
		}

		/// <summary>
		/// Заменить кирпичик по его координатам.
		/// </summary>
		public void SetBrick(int x, int y, Brick? brick)
		{
			if (IsInternalRange(x, y)) BrickArray[x, y] = brick;
		}

		/// <summary>
		/// Проверка координат, входят ли они в диапазон допустимых координат или нет.
		/// </summary>
		private bool IsInternalRange(int x, int y) => x >= 0 && y >= 0 && x < Width && y < Height;
	}
}
