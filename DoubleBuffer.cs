using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1
{
	/// <summary>
	/// https://docs.microsoft.com/ru-ru/dotnet/api/system.drawing.bufferedgraphics?view=windowsdesktop-3.1
	/// </summary>
	internal class DoubleBuffer
	{
		private readonly BufferedGraphicsContext bufferedGraphicsContext;
		private readonly BufferedGraphics bufferedGraphics;
		private readonly Graphics graphics;

		public DoubleBuffer(Graphics graphics, int width, int height)
		{
			this.graphics = graphics;
			bufferedGraphicsContext = BufferedGraphicsManager.Current;
			bufferedGraphicsContext.MaximumBuffer = new Size(width + 1, height + 1);
			bufferedGraphics = bufferedGraphicsContext.Allocate(graphics, new Rectangle(0, 0, width, height));		
		}

		public Graphics GetBufferedGraphics()
		{
			return bufferedGraphics.Graphics;
		}

		public void Render()
		{
			bufferedGraphics.Render(graphics);
		}
	}
}
