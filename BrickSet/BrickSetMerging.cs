using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1
{
	/// <summary>
	/// Слияние двух наборов кирпичиков.
	/// На выходе образуется набор размером target, куда переносятся кирпичики из двух исходных наборов.
	/// </summary>
	internal class BrickSetMerging
	{
		private readonly BrickSet _target;
		private readonly BrickSet _source;

		public BrickSetMerging(BrickSet target, BrickSet source)
		{
			_target = target;
			_source = source;
		}

		public BrickSet Merge()
		{
			BrickSet result = _target.Clone();
			foreach (BrickPlace placeFromSource in _source)
			{
				BrickPosition position = placeFromSource.Position + _target.Offset + _source.Offset;
				if (placeFromSource.Brick is not null)
				{
					result[position] = placeFromSource.Brick;
				}
			}
			return result;
		}
	}
}
