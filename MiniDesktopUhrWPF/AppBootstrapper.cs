using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
			DisplayRootViewFor<AppViewModel> ();
		}
	}
}
