using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1.Polyomino
{
	/// <summary>
	/// Полимино https://bit.ly/3KVqcH7
	/// </summary>
	internal class TetraminoList : List<uint[,]>
	{
		public TetraminoList()
		{
			Add(new uint[,]
			{
				{ 0, 0, 0 },
				{ 1, 1, 1 },
				{ 0, 1, 0 },
			});
			Add(new uint[,]
			{
				{ 0, 1, 0 },
				{ 0, 1, 0 },
				{ 0, 1, 1 },
			});
			Add(new uint[,]
			{
				{ 0, 1, 0 },
				{ 0, 1, 0 },
				{ 1, 1, 0 },
			});
			Add(new uint[,]
			{
				{ 0, 0, 0 },
				{ 1, 1, 0 },
				{ 0, 1, 1 },
			});
			Add(new uint[,]
			{
				{ 0, 0, 0 },
				{ 0, 1, 1 },
				{ 1, 1, 0 },
			});
			Add(new uint[,]
			{
				{ 1, 1 },
				{ 1, 1 },
			});
			Add(new uint[,]
			{
				{ 0, 1, 0, 0 },
				{ 0, 1, 0, 0 },
				{ 0, 1, 0, 0 },
				{ 0, 1, 0, 0 },
			});
		}
	}
}
