using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms_Tetris1.Memento;
//using WinForms_Tetris1.Extension;

namespace WinForms_Tetris1
{
	internal partial class BrickSet : IEnumerable<BrickPlace>, IOriginator<BrickSetState>
	{
		public int Rows { get; private set; }

		public int Columns { get; private set; }

		public BrickPosition Offset = new(0, 0);

		private Brick?[,] Bricks;

		private readonly Enumerator _enumerator;

		public BrickSet(int rows, int columns)
		{
			Rows = rows;
			Columns = columns;
			Bricks = new Brick?[rows, columns];
			_enumerator = new(this);
		}

		public BrickSet Clone()
		{
			BrickSet clone = new(Rows, Columns) { Offset = Offset.Clone() };
			foreach ((int Row, int Column, Brick? Brick) in this)
				clone[Row, Column] = Brick?.Clone();
			return clone;
		}

		public Brick? this[int row, int column]
		{
			get => IsValidIndex(row, column) ? Bricks[row, column] : null;
			set { if (IsValidIndex(row, column)) Bricks[row, column] = value; }
		}

		public Brick? this[BrickPosition position]
		{
			get => IsValidPosition(position) ? Bricks[position.Row, position.Column] : null;
			set { if (IsValidPosition(position)) Bricks[position.Row, position.Column] = value; }
		}

		private bool IsValidIndex(int row, int column) =>
			0 <= row && row < Rows
			&& 0 <= column && column < Columns;

		private bool IsValidPosition(BrickPosition position) =>
			0 <= position.Row && position.Row < Rows
			&& 0 <= position.Column && position.Column < Columns;

		public IEnumerator<BrickPlace> GetEnumerator() => _enumerator;

		IEnumerator IEnumerable.GetEnumerator() => _enumerator;

		public IMemento<BrickSetState> SaveStateToMemento() =>
			// TODO Изучить клонирование двумерных массивов. Возможно тут клонируется лишь первый уровень, а на второй будут ссылки.
			new BrickSetMemento(new BrickSetState(new(Rows, Columns), (Brick?[,]) Bricks.Clone()));

		public void RestoreStateFromMemento(IMemento<BrickSetState> memento)
		{
			Rows = memento.GetState().Size.Rows;
			Columns = memento.GetState().Size.Columns;
			Bricks = memento.GetState().Bricks;
		}
	}
}