using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace WinForms_Tetris1
{
	internal class Game
	{
		private readonly Timer GameTimer = new() { Interval = 100 };
		private readonly Timer FallingFigureTimer = new() { Interval = 1000 };

		private readonly BrickSet Background;
		private readonly BrickSet Cup;
		private readonly BrickSet CupContent;
		private BrickSet Figure;

		private readonly Graphics Graphics;
		private readonly Size FormSize;
		private readonly Color BackColor;
		private readonly DoubleBuffer DoubleBuffer;
		private readonly Polyomino.TetraminoList Tetramino = new();

		public Game(Graphics graphics, Size formSize, Color backColor)
		{
			Graphics = graphics;
			FormSize = formSize;
			BackColor = backColor;
			DoubleBuffer = new(Graphics, FormSize.Width, FormSize.Height);

			// Размер стакана (включая стенки).
			int rows = 20;
			int columns = 10;

			// Создаем фон стакана.
			Background = new BrickSet(rows, columns);
			foreach (BrickPlace place in Background)
				Background[place.Position.Row, place.Position.Column] = new Brick(new SolidBrush(Color.Black));

			// Создаем стакан со стенками.
			Cup = new BrickSet(rows, columns);
			FillCupWithWalls(Cup);

			// Создаем содержимое стакана.
			CupContent = new(rows - 1, columns - 2)
			{
				Offset = new(1, 0)
			};

			// Создать падающую фигуру.
			Brick figureBrick = new(new SolidBrush(Color.GreenYellow));
			Figure = new BrickSetCreatorBasedArray(Tetramino[0], figureBrick).Create();
			Figure.Offset = new(3, 3);

			FallingFigureTimer.Tick += new EventHandler(
				(object? sender, EventArgs @event) => {
					BrickSet figureClone = Figure.Clone();
					figureClone.Offset.Row++;
					if (
						!new BrickSetIntersection(figureClone, CupContent).IsIntersect()
						&& !new BrickSetIntersection(figureClone, Cup).IsIntersect()
					)
					{
						Figure.Offset.Row++;
					}
				}
			);
			FallingFigureTimer.Start();
		}

		public void Start()
		{
			GameTimer.Tick += new EventHandler(Tick);
			GameTimer.Start();
		}

		private void Tick(object? sender, EventArgs e)
		{
			Draw();
		}

		private void Draw()
		{
			Graphics bufferedGraphics = DoubleBuffer.GetBufferedGraphics();

			bufferedGraphics.Clear(BackColor);
			BrickSet[] layers = { Background, Cup, CupContent, Figure };
			new BrickSetPrinter(layers, bufferedGraphics).Print();

			DoubleBuffer.Render();
		}

		private static void FillCupWithWalls(BrickSet cup)
		{
			Func<int, int, Brick> getBrick = (row, column) => new Brick(new SolidBrush(Color.Red));

			new BrickSetPainter(cup)
				.DrawLine(0, 0, cup.Rows - 1, 0, getBrick)
				.DrawLine(0, cup.Columns - 1, cup.Rows - 1, cup.Columns - 1, getBrick)
				.DrawLine(cup.Rows - 1, 0, cup.Rows - 1, cup.Columns - 1, getBrick);
		}

		public void OnKeyDown(object? sender, KeyEventArgs @event)
		{
			BrickSet figureClone = Figure.Clone();
			switch (@event.KeyCode)
			{
				case Keys.Space:
					if (!new BrickSetIntersection(Cup, new BrickSetRotator(figureClone).RotateClockwise()).IsIntersect())
					{
						Figure = new BrickSetRotator(figureClone).RotateClockwise();
					}
					break;
				case Keys.Up:
					figureClone.Offset.Row--;
					if (!new BrickSetIntersection(Cup, figureClone).IsIntersect()) Figure.Offset.Row--;
					break;
				case Keys.Down:
					figureClone.Offset.Row++;
					if (!new BrickSetIntersection(Cup, figureClone).IsIntersect()) Figure.Offset.Row++;
					break;
				case Keys.Left:
					figureClone.Offset.Column--;
					if (!new BrickSetIntersection(Cup, figureClone).IsIntersect()) Figure.Offset.Column--;
					break;
				case Keys.Right:
					figureClone.Offset.Column++;
					if (!new BrickSetIntersection(Cup, figureClone).IsIntersect()) Figure.Offset.Column++;
					break;
			}
		}
	}
}
