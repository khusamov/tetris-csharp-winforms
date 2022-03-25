﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1.Memento
{
	internal interface IOriginator<S>
	{
		public IMemento<S> SaveStateToMemento();

		public void RestoreStateFromMemento(IMemento<S> memento);
	}
}