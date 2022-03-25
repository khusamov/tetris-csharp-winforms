using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms_Tetris1.Memento;

namespace WinForms_Tetris1;

internal record BrickSetState(BrickSetSize Size, Brick?[,] Bricks);

internal partial class BrickSet
{

	internal class BrickSetMemento : IMemento<BrickSetState>
	{
		public BrickSetSize Size;

		public Brick?[,] Bricks;

		public BrickSetMemento(BrickSetState state)
		{
			Size = state.Size;
			Bricks = state.Bricks;
		}

		public BrickSetState GetState()
		{
			return new BrickSetState(Size, Bricks);
		}
	}
}