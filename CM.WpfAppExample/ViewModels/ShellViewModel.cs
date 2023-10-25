using Caliburn.Micro;
using CM.WpfAppExample.Views;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;

namespace CM.WpfAppExample.ViewModels
{
    class ShellViewModel: Conductor<object>
    {
        private readonly IWindowManager _windowManager;

        public ShellViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        public Task EditCategories()
        {
            var viewmodel = IoC.Get<CategoryViewModel>();
            return ActivateItemAsync(viewmodel, new CancellationToken());
        }

        protected async override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await EditCategories();
        }

        public bool CanFileMenu
        {
            get
            {
                return false;
            }
        }

        public Task About()
        {
            dynamic settings = new ExpandoObject();
            //settings.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //settings.ResizeMode = ResizeMode.NoResize;
            //settings.MinWidth = 2000;
            //settings.Title = "My New Window";
            //settings.Icon = new BitmapImage(new Uri("pack://application:,,,/MyApplication;component/Assets/myicon.ico"));

            return _windowManager.ShowDialogAsync(IoC.Get<AboutViewModel>(), null, settings); //, IoC.Get<AboutView>());
        }
    }
}
