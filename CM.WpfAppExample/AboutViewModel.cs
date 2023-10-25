using Caliburn.Micro;
using CM.WpfAppExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.WpfAppExample
{
    public class AboutViewModel : Screen
    {
        private AboutModel _aboutData = new AboutModel();

        public AboutModel AboutData
        {
            get { return _aboutData; }
        }

        public Task CloseForm()
        {
            return TryCloseAsync();
        }
    }
}
