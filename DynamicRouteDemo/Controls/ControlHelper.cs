using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Controls;

namespace DynamicRouteDemo.Controls
{
    public static class ControlHelper
    {
        public static void TransferProperty(this DotvvmControl sourceControl, DotvvmControl targetControl, DotvvmProperty targetProperty,
            DotvvmProperty sourceProperty)
        {
            IBinding binding = sourceControl.GetBinding(sourceProperty);
            if (binding != null)
            {
                targetControl.SetBinding(targetProperty, binding);
            }
            else
            {
                var value = sourceProperty.GetValue(sourceControl);
                if (value != null)
                    targetControl.SetValue(targetProperty, value);
            }
        }
    }
}
