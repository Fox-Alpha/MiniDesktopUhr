using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Caliburn.Micro;

namespace MiniDesktopUhrWPF
{
	public class AppBootstrapper : Caliburn.Micro.BootstrapperBase
	{
		public AppBootstrapper()
		{
			Initialize ();
		}

		protected override void OnStartup (object sender, StartupEventArgs e)
		{
			Dictionary<string, object> setting = new Dictionary<string, object> ();
			setting.Add ("WindowStyle", WindowStyle.None);
			setting.Add ("ResizeMode", ResizeMode.NoResize);

			DisplayRootViewFor<AppViewModel> (setting);
		}

		protected override void OnExit (object sender, EventArgs e)
		{
			base.OnExit (sender, e);
		}

		protected override void OnUnhandledException (object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			base.OnUnhandledException (sender, e);
		}

		protected override void Configure ()
		{
			base.Configure ();
		}
	}
}
