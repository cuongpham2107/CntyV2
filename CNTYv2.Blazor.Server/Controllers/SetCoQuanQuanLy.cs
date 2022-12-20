using CNTYv2.Module.BusinessObjects;
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
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNTYv2.Blazor.Server.Controllers
{
    
    public partial class SetCoQuanQuanLy : ViewController
    {
        public SetCoQuanQuanLy()
        {
            InitializeComponent();
            TargetObjectType = typeof(TrangTraiChanNuoi);
            Action_SetCoQuanQuanLy();
        }
        private void Action_SetCoQuanQuanLy()
        {
            PopupWindowShowAction action = new(this, "Đặt cơ quan quản lý", "Edit")
            {
                Caption = "Đặt cơ quan quản lý",
                ImageName = "GroupByResource",
                SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects
            };
            action.CustomizePopupWindowParams += (sender, e) =>
            {
                IObjectSpace objectSpace = Application.CreateObjectSpace();
                string listViewID = Application.FindLookupListViewId(typeof(CoQuanQuanLy));
                CollectionSourceBase collectionSource = Application.CreateCollectionSource(objectSpace, typeof(CoQuanQuanLy), listViewID);
                e.View = Application.CreateListView(listViewID, collectionSource, true);
            };
            action.Execute += (s, e) => {
                var popupLoaihinh = e.PopupWindowViewCurrentObject as CoQuanQuanLy;
                var loaihinh = ObjectSpace.GetObject(popupLoaihinh);
                foreach (object item in View.SelectedObjects)
                {
                    (item as TrangTraiChanNuoi).CoQuanQuanLy = loaihinh;
                }
                ObjectSpace.CommitChanges();
            };
        }
    }
}
