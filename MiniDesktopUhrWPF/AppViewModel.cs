using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace MiniDesktopUhrWPF
{
	class AppViewModel : PropertyChangedBase
	{
		private bool _bShowDate = false;
		public bool bShowDate
		{
			get { return _bShowDate; }
			set
			{
				_bShowDate = value;
				NotifyOfPropertyChange (() => bShowDate);
			}
		}
		const string strWithDate = "{0:dddd dd MMM, HH:mm:ss}";
		const string strWithOutDate = "{0:HH:mm:ss}";
		private string _strUhrzeit ="";
		public string StrUhrzeit
		{
			get { return _strUhrzeit; }
			set
			{
				_strUhrzeit = value;
				NotifyOfPropertyChange (() => StrUhrzeit);
			}
		}



		int activeDisplay = 0;
		//DisplayEdge Edge = DisplayEdge.TopLeft;
		//AppSettings setting;
		System.Windows.Threading.DispatcherTimer dispatcherTimer;


		public AppViewModel ()
		{
			dispatcherTimer = new System.Windows.Threading.DispatcherTimer ();
			dispatcherTimer.Tick += dispatcherTimer_Tick;
			dispatcherTimer.Interval = new TimeSpan (0, 0, 1);
			StrUhrzeit = string.Format (bShowDate ? strWithDate : strWithOutDate, DateTime.Now);
			dispatcherTimer.Start ();
		}


		void dispatcherTimer_Tick(object sender, EventArgs e)
		{
			StrUhrzeit = string.Format (bShowDate ? strWithDate : strWithOutDate, DateTime.Now);
		}

		public void AppExit()
		{
			Application.Current.Shutdown ();
		}

		public void ShowDate()
		{
			bShowDate = !bShowDate;
		}
	}
}
