using CommunityToolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeNotes
{
    public class AppProvider : Microsoft.Maui.Controls.Application
    {
        public AppProvider(IServiceProvider provider)
        {
            Ioc.Default.ConfigureServices(provider);
        }
    }
}
