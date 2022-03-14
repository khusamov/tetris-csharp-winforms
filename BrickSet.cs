using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1
{
	internal class BrickSet
	{
		public int Width;
		public int Height;
		public int OffsetRow = 0;
		public int OffsetCol = 0;
		public Brick?[,] BrickArray;

		/// <summary>
		/// Создать набор кирпичиков по шаблону из массива.
		/// </summary>
		public static BrickSet CreateByArray(Brick brick, int[,] templateArray)
		{

			int rows = templateArray.GetUpperBound(0) + 1;
			int columns = templateArray.Length / rows;
			BrickSet newBrickSet = new(rows, columns);

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < columns; col++)
				{
					if (templateArray[col, row] > 0)
					{
						newBrickSet.BrickArray[col, row] = brick;
					}
				}
			}

			return newBrickSet;
		}

		public BrickSet(int width, int height)
		{
			Width = width;
			Height = height;
			BrickArray = new Brick?[width, height];
			Fill(null);
		}

		/// <summary>
		/// Заполнение массива кирпичиками по умолчанию.
		/// </summary>
		private void Fill(Brick? brick)
		{
			Each((col, row, _) => BrickArray[col, row] = brick);
		}

		public BrickSet Clone()
		{
			BrickSet clone = new(Width, Height);
			Each((col, row, brick) => clone.BrickArray[col, row] = brick?.Clone());
			return clone;
		}

		public bool IsIntersection(BrickSet targetBrickSet, int colOffset, int rowOffset)
		{
			int countIntersection = 0;
			targetBrickSet.Each((col, row, targetBrick) => { 
				if (targetBrick != null && BrickArray[col + colOffset, row + rowOffset] != null)
				{
					countIntersection++;
				}
			});
			return countIntersection > 0;
		}

		public void Each(Action<int, int, Brick?> callback)
		{
			for (int col = 0; col < Width; col++)
			{
				for (int row = 0; row < Height; row++)
				{
					callback(col, row, BrickArray[col, row]);
				}
			}
		}
	}
}
