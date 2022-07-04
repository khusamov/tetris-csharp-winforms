using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace WinForms_Tetris1.Game
{
	internal class Game
	{
		// Размер стакана (включая стенки).
		private readonly int rows = 20;
		private readonly int columns = 10;

		private readonly Timer GameTimer = new() { Interval = 100 };
		private readonly Timer FallingFigureTimer = new() { Interval = 1000 };

		private readonly List<BrickSet> layers;

		private readonly BrickSet Background;
		private readonly BrickSet Cup;
		private readonly BrickSet CupContent;
		private BrickSet Figure;

		private readonly Graphics Graphics;
		private readonly Size FormSize;
		private readonly Color BackColor;
		private readonly DoubleBuffer DoubleBuffer;
		private readonly Polyomino.TetraminoList Tetramino = new();

		public BrickSetSize CupSize
		{
			get { return new(rows, columns); }
		}

		public Game(Graphics graphics, Size formSize, Color backColor)
		{
			Graphics = graphics;
			FormSize = formSize;
			BackColor = backColor;
			DoubleBuffer = new(Graphics, FormSize.Width, FormSize.Height);

			layers = new();

			// Создаем фон стакана.
			Background = new BackgroundCreator(this).Create();
			layers.Add(Background);

			// Создаем стакан со стенками.
			Cup = new CupCreator(this).Create();
			layers.Add(Cup);

			// Создаем содержимое стакана.
			CupContent = new CupContentCreator(this).Create();
			layers.Add(CupContent);

			// Создать падающую фигуру.
			Figure = new FigureCreator(this).Create();
			layers.Add(Figure);

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

		public void OnKeyDown(object? sender, KeyEventArgs @event)
		{
			BrickSet figureClone = Figure.Clone();
			switch (@event.KeyCode)
			{
				case Keys.Space:
					if (!new BrickSetIntersection(Cup, new BrickSetRotator(figureClone).Clockwise()).IsIntersect())
					{
						Figure = new BrickSetRotator(figureClone).Clockwise();
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
