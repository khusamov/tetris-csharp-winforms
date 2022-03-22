namespace WinForms_Tetris1
{
	public partial class MainForm : Form
	{
		KeyUpDownProcessor _keyUpDownProcessor = new(eventHandled: true);

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			// Из события извлекаем номер нажатой клавиши.
			int keyCode = e.KeyValue;

			_keyUpDownProcessor.OnKeyDown(e, () => {
				listBox1.Items.Add("KeyDown " + keyCode);
			});
		}

		private void MainForm_KeyUp(object sender, KeyEventArgs e)
		{
			// Из события извлекаем номер нажатой клавиши.
			int keyCode = e.KeyValue;

			_keyUpDownProcessor.OnKeyUp(e, () => {
				listBox1.Items.Add("KeyUp " + keyCode);
			});
		}

		private void ClearButton_Click(object sender, EventArgs e)
		{
			listBox1.Items.Clear();
		}
	}
}