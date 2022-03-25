using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1
{
	internal interface ICreator<T>
	{
		T Create();
	}
}
