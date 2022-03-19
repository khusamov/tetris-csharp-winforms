using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1;

internal partial class BrickSet
{

	internal struct Enumerator : IEnumerator<BrickPlace>
	{
		private static readonly BrickPosition _startPosition = new(-1, 0);
		private BrickPosition _position = _startPosition;
		private readonly BrickSet _targetBrickSet;

		public Enumerator(BrickSet brickSet) => _targetBrickSet = brickSet;

		public BrickPlace Current => new(
			Position: _position,
			Brick: _targetBrickSet[_position.Row, _position.Column]
		);

		object IEnumerator.Current => Current;

		public bool MoveNext()
		{
			if (_position.Row < _targetBrickSet.Rows)
			{
				_position = new(_position.Row + 1, _position.Column);
				return true;
			}
			else if (_position.Column < _targetBrickSet.Columns)
			{
				_position = new(0, _position.Column + 1);
				return true;
			}
			else return false;
		}

		public void Reset() => _position = _startPosition;

		public void Dispose() {}
	}
}
