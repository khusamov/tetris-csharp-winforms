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

	internal class Memento : IMemento<BrickSetState>
	{
		private readonly BrickSetState _state;

		public BrickSetState State {
			get
			{
				return _state;
			}
		}

		public Memento(BrickSetState state)
		{
			_state = state;
		}
	}
}