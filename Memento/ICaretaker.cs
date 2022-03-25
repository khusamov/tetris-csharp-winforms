using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1.Memento
{
	internal interface ICaretaker<S>
	{
		public void Push(IMemento<S> memento);

		public IMemento<S> Pop();
	}
}
