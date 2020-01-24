using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Compilation.ControlTree;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;

namespace DynamicRouteDemo.Controls
{
    public class DynamicRouteLink : DotvvmControl
    {
        /// <summary>
        /// Gets or sets the name of the route in the route table.
        /// </summary>
        [MarkupOptions(AllowBinding = true, Required = true)]
        public string RouteName
        {
            get { return (string)GetValue(RouteNameProperty); }
            set { SetValue(RouteNameProperty, value); }
        }
        public static readonly DotvvmProperty RouteNameProperty =
            DotvvmProperty.Register<string, DynamicRouteLink>(c => c.RouteName);

        public bool Enabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }
        public static readonly DotvvmProperty EnabledProperty =
            DotvvmProperty.Register<bool, DynamicRouteLink>(t => t.Enabled, true);

        /// <summary>
        /// Gets or sets the suffix that will be appended to the generated URL (e.g. query string or URL fragment).
        /// </summary>
        public string UrlSuffix
        {
            get { return (string)GetValue(UrlSuffixProperty); }
            set { SetValue(UrlSuffixProperty, value); }
        }
        public static readonly DotvvmProperty UrlSuffixProperty
            = DotvvmProperty.Register<string, DynamicRouteLink>(c => c.UrlSuffix, null);


        /// <summary>
        /// Gets or sets the text of the hyperlink.
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DotvvmProperty TextProperty =
            DotvvmProperty.Register<string, DynamicRouteLink>(c => c.Text, "");


        public override bool RenderOnServer => true;

        protected override void OnPreRender(IDotvvmRequestContext context)
        {

            var routeLink = new RouteLink();
            Children.Add(routeLink);
            this.TransferProperty(routeLink, RouteLink.RouteNameProperty, RouteNameProperty);
            this.TransferProperty(routeLink, RouteLink.EnabledProperty, EnabledProperty);
            this.TransferProperty(routeLink, RouteLink.UrlSuffixProperty, UrlSuffixProperty);
            this.TransferProperty(routeLink, RouteLink.TextProperty, TextProperty);

            routeLink.SetValue(PostBack.UpdateProperty, true);
            base.OnPreRender(context);
        }
    }
}
