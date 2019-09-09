using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Caliburn.Micro;
using MiniDesktopUhrWPF.ViewModels;

namespace MiniDesktopUhrWPF
{
	public class AppBootstrapper : BootstrapperBase
	{
        private SimpleContainer _container = new SimpleContainer();

        public AppBootstrapper()
		{
			Initialize ();
		}

        protected override void Configure()
        {
            _container.Instance(_container);

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));

            Dictionary<string, object> setting = new Dictionary<string, object>();
            setting.Add("WindowStyle", WindowStyle.None);
            setting.Add("ResizeMode", ResizeMode.NoResize);
        }

        protected override void OnStartup (object sender, StartupEventArgs e)
		{
			DisplayRootViewFor<ShellViewModel>();
		}

		protected override void OnExit (object sender, EventArgs e)
		{
			base.OnExit (sender, e);
		}

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void OnUnhandledException (object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			base.OnUnhandledException (sender, e);
		}
	}
}
