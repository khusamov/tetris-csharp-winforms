using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1
{
	internal class Brick
	{
		public SolidBrush Brush;

		public Brick(SolidBrush brush)
		{
			Brush = brush;
		}

		public Brick Clone()
		{
			return new Brick(Brush);
		}
	}
}
