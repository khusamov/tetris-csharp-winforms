using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms_Tetris1.Extension;

namespace WinForms_Tetris1
{
	internal class BrickSetRotator
	{
		private readonly BrickSet _brickSet;

		public BrickSetRotator(BrickSet brickSet)
		{
			_brickSet = brickSet;
		}

		/// <summary>
		/// Поворот матрицы по часовой стрелке.
		/// Создает новый BrickSet с измененным состоянием.
		/// </summary>
		public BrickSet Clockwise()
		{
			BrickSet result = _brickSet.Clone();

			BrickSetState brickSetState = result.CreateMemento().State;

			BrickSetState newBrickSetState = (
				new BrickSetState(
					brickSetState.Size.Clone(),
					brickSetState.Bricks.RotateClockwise()
				)
			);

			result.RestoreFromMemento(new BrickSet.Memento(newBrickSetState));

			return result;
		}

		/// <summary>
		/// Поворот матрицы против часовой стрелки.
		/// Создает новый BrickSet с измененным состоянием.
		/// </summary>
		public BrickSet CounterClockwise()
		{
			throw new NotImplementedException();
		}
	}
}
