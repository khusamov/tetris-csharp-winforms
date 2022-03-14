using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1
{
	internal class Brick
	{
		public SolidBrush Brush = new SolidBrush(Color.Black);

		public Brick(SolidBrush? brush = null)
		{
			if (brush == null) brush = new SolidBrush(Color.Black);
			Brush = brush;
		}

		public Brick Clone()
		{
			return new Brick(Brush);
		}
	}
}
