using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;

namespace DynamicRouteDemo.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        public string Title { get; set; }
        public string RouteName { get; set; } = "A";
        public DefaultViewModel()
        {
            Title = "Hello from DotVVM!";
        }

        public void SetRouteToA()
        {
            RouteName = "A";
        }

        public void SetRouteToB()
        {
            RouteName = "B";
        }
    }
}
