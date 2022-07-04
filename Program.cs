namespace WinForms_Tetris1;
internal static class Program
{
	[STAThread]
	static void Main()
	{
		// To customize application configuration such as
		// set high DPI settings or default font,
		// see https://aka.ms/applicationconfiguration.
		ApplicationConfiguration.Initialize();

		MainForm mainForm = new();

		Game.Game game = new(mainForm.CreateGraphics(), mainForm.Size, mainForm.BackColor);
		mainForm.KeyDown += new KeyEventHandler(game.OnKeyDown);

		game.Start();
		Application.Run(mainForm);
	}
}