using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1
{
	internal class BrickSetSize
	{
		public int Rows;
		public int Columns;

		public BrickSetSize(int rows, int columns)
		{
			Rows = rows;
			Columns = columns;
		}

		public BrickSetSize Clone() => new(Rows, Columns);
	}
}
