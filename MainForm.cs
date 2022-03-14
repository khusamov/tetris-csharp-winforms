namespace WinForms_Tetris1
{
	public partial class MainForm : Form
	{
		BrickSet Cup;
		BrickSet Figure;

		public MainForm()
		{
			InitializeComponent();
			Cup = new BrickSet(10, 20);
			FillCupWithWalls(Cup);

			Brick FigureBrick = new Brick(new SolidBrush(Color.GreenYellow));
			Figure = BrickSet.CreateByArray(FigureBrick, new int[,] {
				{ 0, 1, 0 },
				{ 0, 1, 0 },
				{ 1, 1, 1 },
			});
			Figure.OffsetCol = 3;
			Figure.OffsetRow = 3;


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
			new BrickSetPrinter(new BrickSet[] { Cup, Figure }, GetGraphics()).Print();
		}

		private void FillCupWithWalls(BrickSet cup)
		{
			Func<int, int, Brick> getBrick = (x, y) => new Brick(new SolidBrush(Color.Red));

			new BrickSetPainter(cup)
				.DrawLine(0, 0, 0, cup.Height - 1, getBrick)
				.DrawLine(cup.Width - 1, 0, cup.Width - 1, cup.Height - 1, getBrick)
				.DrawLine(0, cup.Height - 1, cup.Width - 1, cup.Height - 1, getBrick);
		}
	}
}