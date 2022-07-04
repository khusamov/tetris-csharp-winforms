using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1.Command
{
	internal class MoveFigureToLeftCommand : ICommand
	{
		private readonly BrickSet _figure;
		private readonly BrickSet _cup;
		public MoveFigureToLeftCommand(BrickSet figure, BrickSet cup)
		{
			_figure = figure;
			_cup = cup;
		}

		public void Execute()
		{
			BrickSet figureClone = _figure.Clone();

			figureClone.Offset.Column--;

			BrickSetIntersection intersection = new BrickSetIntersection(_cup, figureClone);

			if (!intersection.IsIntersect())
			{
				_figure.Offset.Column--;
			}
			
		}
	}
}
