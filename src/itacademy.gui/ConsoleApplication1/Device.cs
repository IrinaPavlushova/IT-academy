using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class Device
	{
		#region Events

		public event EventHandler ConnectionChanged;

		private void OnConnectionChanged()
		{
			ConnectionChanged?.Invoke(this, EventArgs.Empty);
		}

		#endregion

		public bool IsConnected { get; private set; }

		public void Connect()
		{
			IsConnected = true;

			OnConnectionChanged();
		}

		public void Disconnect()
		{
			IsConnected = false;

			OnConnectionChanged();
		}
	}
}
