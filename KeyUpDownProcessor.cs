using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Tetris1
{
	internal class KeyUpDownProcessor
	{
		private bool _eventHandled;

		/// <summary>
		/// Данный словарь хранит информацию о том, была ли нажата клавиша.
		/// В качестве ключа выступает номер клавиши, 
		/// а значение это флаг (была или не была нажата клавиша).
		/// </summary>
		Dictionary<int, bool> _theKeyWasDown = new();

		public KeyUpDownProcessor(bool eventHandled = false)
		{
			_eventHandled = eventHandled;
		}

		public void OnKeyDown(KeyEventArgs @event, Action action)
		{
			@event.Handled = _eventHandled;

			// Из события извлекаем номер нажатой клавиши.
			int keyCode = @event.KeyValue;

			if (!_theKeyWasDown.ContainsKey(keyCode))
			{
				// Если такой клавиши нет в словаре,
				// то добавляем ее с информацией, что ранее она еще не была нажата,
				_theKeyWasDown.Add(keyCode, false);
			}

			// Если клавиша ранее не была нажата, то:
			if (!_theKeyWasDown[keyCode])
			{
				// Помечаем что она нажата.
				_theKeyWasDown[keyCode] = true;
				// И выполняем действие при нажатии на эту клавишу.
				action(); 
			}
		}

		public void OnKeyUp(KeyEventArgs @event, Action action)
		{
			@event.Handled = _eventHandled;

			// Из события извлекаем номер нажатой клавиши.
			int keyCode = @event.KeyValue;

			// Помечаем что она уже не нажата.
			_theKeyWasDown[keyCode] = false;

			// Выполняем действие при отжатии клавиши.
			action();
		}

	}
}
