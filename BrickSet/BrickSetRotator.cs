using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms_Tetris1.Extension;

namespace WinForms_Tetris1
{
	internal class BrickSetRotator : Memento.ICaretaker
	{
		private readonly BrickSet _brickSet;

		public BrickSetRotator(BrickSet brickSet)
		{
			_brickSet = brickSet;
		}

		/// <summary>
		/// Создает новый BrickSet с измененным состоянием (поворот матрицы).
		/// </summary>
		public BrickSet RotateClockwise()
		{
			BrickSet result = _brickSet.Clone();

			BrickSetState brickSetState = result.SaveStateToMemento().GetState();

			BrickSetState newBrickSetState = (
				new BrickSetState(
					brickSetState.Size.Clone(),
					brickSetState.Bricks.RotateClockwise()
				)
			);

			result.RestoreStateFromMemento(new BrickSet.Memento(newBrickSetState));

			return result;
		}
	}
}
