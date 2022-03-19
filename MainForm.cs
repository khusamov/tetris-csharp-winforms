namespace WinForms_Tetris1
{
	public partial class MainForm : Form
	{
		readonly Polyomino.TetraminoList Tetramino = new();
		readonly BrickSet Background;
		readonly BrickSet Cup;
		readonly BrickSet CupContent;
		readonly BrickSet Figure;

		public MainForm()
		{
			InitializeComponent();

			// Размер стакана (включая стенки).
			int rows = 10;
			int columns = 20;

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
				Offset = (1, 0)
			};

			// Создать падающую фигуру.
			Brick figureBrick = new(new SolidBrush(Color.GreenYellow));
			Figure = BrickSetFactory.CreateByArray(Tetramino[0], figureBrick);
			Figure.Offset = (3, 3);

			// Запускаем игровой таймер.
			GameTimer.Start();
		}

		private void MainForm_Paint(object sender, PaintEventArgs e)
		{
			
		}

		private Graphics GetGraphics()
		{
			return Graphics.FromHwnd(this.Handle);
		}

		private void MainTimer_Tick(object sender, EventArgs e)
		{
			Draw();
		}

		private void Draw()
		{
			BrickSet[] layers = { Background, Cup, CupContent, Figure };
			new BrickSetPrinter(layers, GetGraphics()).Print();
		}

		private static void FillCupWithWalls(BrickSet cup)
		{
			Func<int, int, Brick> getBrick = (x, y) => new Brick(new SolidBrush(Color.Red));

			new BrickSetPainter(cup)
				.DrawLine(0, 0, 0, cup.Rows - 1, getBrick)
				.DrawLine(cup.Columns - 1, 0, cup.Columns - 1, cup.Rows - 1, getBrick)
				.DrawLine(0, cup.Rows - 1, cup.Columns - 1, cup.Rows - 1, getBrick);
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs @event)
		{
			BrickSet figureClone = Figure.Clone();
			switch (@event.KeyCode)
			{
				case Keys.Up:
					figureClone.Offset.Row--;
					if (new BrickSetIntersection(Cup, figureClone).IsIntersect()) Figure.Offset.Row--; 
					break;
				case Keys.Down:
					figureClone.Offset.Row++;
					if (new BrickSetIntersection(Cup, figureClone).IsIntersect()) Figure.Offset.Row++; 
					break;
				case Keys.Left:
					figureClone.Offset.Column--;
					if (new BrickSetIntersection(Cup, figureClone).IsIntersect()) Figure.Offset.Column--;
					break;
				case Keys.Right:
					figureClone.Offset.Column++;
					if (new BrickSetIntersection(Cup, figureClone).IsIntersect()) Figure.Offset.Column++; 
					break;
			} 
		}

		private void MainForm_Load(object sender, EventArgs @event)
		{

		}
	}
}