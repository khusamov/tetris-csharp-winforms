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
			this.SuspendLayout();
			// 
			// GameTimer
			// 
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(559, 49);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(149, 42);
			this.StartButton.TabIndex = 0;
			this.StartButton.Text = "Старт";
			this.StartButton.UseVisualStyleBackColor = true;
			// 
			// PauseButon
			// 
			this.PauseButon.Location = new System.Drawing.Point(559, 117);
			this.PauseButon.Name = "PauseButon";
			this.PauseButon.Size = new System.Drawing.Size(149, 42);
			this.PauseButon.TabIndex = 1;
			this.PauseButon.Text = "Пауза";
			this.PauseButon.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1058, 840);
			this.Controls.Add(this.PauseButon);
			this.Controls.Add(this.StartButton);
			this.Name = "MainForm";
			this.Text = "Тетрис";
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Timer GameTimer;
		private Button StartButton;
		private Button PauseButon;
	}
}