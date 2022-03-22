namespace WinForms_Tetris1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.GameTimer = new System.Windows.Forms.Timer(this.components);
			this.StartButton = new System.Windows.Forms.Button();
			this.PauseButon = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.ClearButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(714, 41);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(149, 42);
			this.StartButton.TabIndex = 0;
			this.StartButton.Text = "Старт";
			this.StartButton.UseVisualStyleBackColor = true;
			// 
			// PauseButon
			// 
			this.PauseButon.Location = new System.Drawing.Point(714, 109);
			this.PauseButon.Name = "PauseButon";
			this.PauseButon.Size = new System.Drawing.Size(149, 42);
			this.PauseButon.TabIndex = 1;
			this.PauseButon.Text = "Пауза";
			this.PauseButon.UseVisualStyleBackColor = true;
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 20;
			this.listBox1.Location = new System.Drawing.Point(714, 351);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(259, 384);
			this.listBox1.TabIndex = 2;
			// 
			// ClearButton
			// 
			this.ClearButton.Location = new System.Drawing.Point(714, 284);
			this.ClearButton.Name = "ClearButton";
			this.ClearButton.Size = new System.Drawing.Size(149, 42);
			this.ClearButton.TabIndex = 0;
			this.ClearButton.Text = "Очистить";
			this.ClearButton.UseVisualStyleBackColor = true;
			this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1058, 840);
			this.Controls.Add(this.ClearButton);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.PauseButon);
			this.Controls.Add(this.StartButton);
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.Text = "Тетрис";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Timer GameTimer;
		private Button StartButton;
		private Button PauseButon;
		private ListBox listBox1;
		private Button ClearButton;
	}
}