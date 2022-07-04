using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1
{
	internal class BrickPosition
	{
		public int Row;
		public int Column;

		public BrickPosition(int row, int column)
		{
			Row = row;
			Column = column;
		}

		public static BrickPosition operator +(BrickPosition position1, BrickPosition position2)
		{
			return new(
				position1.Row + position2.Row, 
				position1.Column + position2.Row
			);
		}

		public BrickPosition Clone()
		{
			return new(Row, Column);
		}

		public void Deconstruct(out int row, out int column)
		{
			row = Row;
			column = Column;
		}
	}
}
