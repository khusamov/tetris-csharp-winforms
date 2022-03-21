namespace WinForms_Tetris1
{
	public partial class MainForm : Form
	{
		private readonly Game Game;

		public MainForm()
		{
			InitializeComponent();
			Game = new(CreateGraphics(), this.Size, this.BackColor);
			GameTimer.Start();
		}

		private void MainTimer_Tick(object sender, EventArgs e)
		{
			Game.Tick();
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs @event)
		{
			Game.OnKeyDown(sender, @event);
		}
	}
}