namespace WinForms_Tetris1
{
	public partial class MainForm : Form
	{
		readonly BrickSet2 Background;
		readonly BrickSet2 Cup;
		readonly BrickSet2 CupContent;
		readonly BrickSet2 Figure;

		public MainForm()
		{
			InitializeComponent();

			int width = 10;
			int height = 20;

			Background = new BrickSet2(width, height);
			Background.Fill(new Brick(new SolidBrush(Color.Black)));

			Cup = new BrickSet2(width, height);
			FillCupWithWalls(Cup);

			CupContent = new BrickSet2(width, height);

			Polyomino.TetraminoList tetramino = new();

			Brick FigureBrick = new(new SolidBrush(Color.GreenYellow));
			Figure = BrickSet2.CreateByArray(FigureBrick, tetramino[0]);
			Figure.ColOffset = 3;
			Figure.RowOffset = 3;


			MainTimer.Start();
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
			BrickSet2[] objects = new BrickSet2[] {
				Background,
				Cup,
				CupContent,
				Figure
			};
			new BrickSetPrinter(objects, GetGraphics()).Print();
		}

		private void FillCupWithWalls(BrickSet2 cup)
		{
			Func<int, int, Brick> getBrick = (x, y) => new Brick(new SolidBrush(Color.Red));

			new BrickSetPainter(cup)
				.DrawLine(0, 0, 0, cup.Height - 1, getBrick)
				.DrawLine(cup.Width - 1, 0, cup.Width - 1, cup.Height - 1, getBrick)
				.DrawLine(0, cup.Height - 1, cup.Width - 1, cup.Height - 1, getBrick);
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			BrickSet2 figureClone = Figure.Clone();
			switch (e.KeyCode)
			{
				case Keys.Up:
					figureClone.RowOffset--;
					if (!Cup.IsIntersection(figureClone)) Figure.RowOffset--; 
					break;
				case Keys.Down:
					figureClone.RowOffset++;
					if (!Cup.IsIntersection(figureClone)) Figure.RowOffset++; 
					break;
				case Keys.Left:
					figureClone.ColOffset--;
					if (!Cup.IsIntersection(figureClone)) Figure.ColOffset--;
					break;
				case Keys.Right:
					figureClone.ColOffset++;
					if (!Cup.IsIntersection(figureClone)) Figure.ColOffset++; 
					break;
			} 
		}
	}
}