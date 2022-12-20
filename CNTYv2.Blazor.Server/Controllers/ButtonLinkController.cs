using DevExpress.Compatibility.System.Web;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNTYv2.Blazor.Server.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ButtonLinkController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public ButtonLinkController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            RemoveLinkUnlinkActions();
            // Perform various tasks depending on the target View.
        }
        private void RemoveLinkUnlinkActions()
        {
            LinkUnlinkController controller = Frame.GetController<LinkUnlinkController>();
            if (controller != null)
            {
                if (View.ObjectTypeInfo.Type != typeof(PermissionPolicyUser))
                {
                    controller.LinkAction.Active.SetItemValue("", false);
                    controller.UnlinkAction.Active.SetItemValue("", false);
                }

            }
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
    public class RemovePaddingController : ViewController<DetailView>
    {
        public RemovePaddingController()
        {
            TargetViewId = "YourDetailViewId";
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            WebControl control = (WebControl)View.LayoutManager.Container;
            control.CssClass += " PaddingLayoutControl";
        }
    }
}
