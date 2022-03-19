using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1
{
	/// <summary>
	/// Место кирпичика в наборе кирпичиков BrickSet.
	/// </summary>
	internal record BrickPlace(BrickPosition Position, Brick? Brick)
	{
		public void Deconstruct(out int Row, out int Column, out Brick? Brick)
		{
			Row = Position.Row;
			Column = Position.Column;
			Brick = this.Brick;
		}
	}
}
