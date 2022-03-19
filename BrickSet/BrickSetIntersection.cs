using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1
{
	internal class BrickSetIntersection
	{
		private readonly BrickSet BrickSet1;
		private readonly BrickSet BrickSet2;

		public BrickSetIntersection(BrickSet brickSet1, BrickSet brickSet2)
		{
			BrickSet1 = brickSet1;
			BrickSet2 = brickSet2;
		}

		public bool Check() => Count() > 0;

		private int Count()
		{
			int result = 0;

			(int row, int column) offset = (
				BrickSet1.Offset.Row - BrickSet2.Offset.Row,
				BrickSet1.Offset.Column - BrickSet2.Offset.Column
			);

			foreach ((int row1, int column1, Brick? brick1) in BrickSet1)
			{
				Brick? brick2 = BrickSet2[row1 + offset.row, column1 + offset.column];
				if (brick1 is not null && brick2 is not null)
				{
					result++;
				}
			}

			return result;
		}
	}
}
