using CNTYv2.Module.BusinessObjects;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Blazor.SystemModule;
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

namespace CNTYv2.Module.Controllers
{

    public partial class PhanQuyenController : ViewController
    {
       
        public PhanQuyenController()
        {
            InitializeComponent();
            TargetViewNesting = Nesting.Any;
            TargetViewType = ViewType.Any;
            Activated += PhanquyenController_Activated;
        }
        private void PhanquyenController_Activated(object sender, EventArgs e)
        {
            var os = Application.CreateObjectSpace(typeof(TrangTraiChanNuoi));
            var account = os.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);

            if (account.Roles.Any(r => r.Name == "Administrators" || r.Name == "Managers")) return;

            if (View is ListView view)
            {
                var criteria = view.CollectionSource.Criteria;
                if(View.ObjectTypeInfo.Type == typeof(CoQuanQuanLy))
                    criteria.Add("crit0", new BinaryOperator("Oid", account.CoquanQuanly.Oid, BinaryOperatorType.Equal));

                if (View.ObjectTypeInfo.Type == typeof(TrangTraiChanNuoi))
                    criteria.Add("crit1", new BinaryOperator("CoQuanQuanLy.Oid", account.CoquanQuanly.Oid, BinaryOperatorType.Equal));

                if (View.ObjectTypeInfo.Type == typeof(CoSoSanXuatThucAnChanNuoi))
                    criteria.Add("crit3", new BinaryOperator("CoQuanQuanLy.Oid", account.CoquanQuanly.Oid, BinaryOperatorType.Equal));

                if (View.ObjectTypeInfo.Type == typeof(BPXLMT_ChanNuoiNongHo))
                    criteria.Add("crit4", new BinaryOperator("CoQuanQuanLy.Oid", account.CoquanQuanly.Oid, BinaryOperatorType.Equal));

                if (View.ObjectTypeInfo.Type == typeof(QuanLyChatThaiChanNuoi))
                    criteria.Add("crit4-1", new BinaryOperator("CoQuanQuanLy.Oid", account.CoquanQuanly.Oid, BinaryOperatorType.Equal));

                if (View.ObjectTypeInfo.Type == typeof(PhongChongDichBenhDongVat))
                    criteria.Add("crit5", new BinaryOperator("CoQuanQuanLy.Oid", account.CoquanQuanly.Oid, BinaryOperatorType.Equal));

                if (View.ObjectTypeInfo.Type == typeof(VungChanNuoiAnToanDichBenh))
                    criteria.Add("crit6", new BinaryOperator("CoQuanQuanLy.Oid", account.CoquanQuanly.Oid, BinaryOperatorType.Equal));

                if (View.ObjectTypeInfo.Type == typeof(GiayChungNhanChanNuoiDaCap))
                    criteria.Add("crit7", new BinaryOperator("CoQuanQuanLy.Oid", account.CoquanQuanly.Oid, BinaryOperatorType.Equal));

                if (View.ObjectTypeInfo.Type == typeof(GiayChungNhanSanXuatThucAnCN))
                    criteria.Add("crit7", new BinaryOperator("CoQuanQuanLy.Oid", account.CoquanQuanly.Oid, BinaryOperatorType.Equal));
            }
        }

    }
    public class CustomizeInlinePropertyEditorController : ViewController<ListView>
    {
        protected override void OnActivated()
        {
            base.OnActivated();
            if (View.Editor.Model is IModelListViewBlazor model) 
                model.InlineEditMode = InlineEditMode.EditForm;
        }
      
    }
    public partial class DisableValidatedCoCauDanGiong : ObjectViewController<DetailView, CoCauDanGiong>
    {
        protected override void OnActivated()
        {
            base.OnActivated();

            var os = Application.CreateObjectSpace(typeof(CoCauDanGiong));
            var account = os.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);
            if (account.Roles.Any(r => r.Name == "Administrators" || r.Name == "Managers"))
            {

                if (ViewCurrentObject?.Close == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
            else
            {
                if (ViewCurrentObject?.Lock == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
        }
    }
    public partial class DisableValidatedThongKeChanNuoi : ObjectViewController<DetailView, ThongKeChanNuoi>
    {
        protected override void OnActivated()
        {
            base.OnActivated();

            var os = Application.CreateObjectSpace(typeof(ThongKeChanNuoi));
            var account = os.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);
            if (account.Roles.Any(r => r.Name == "Administrators" || r.Name == "Managers"))
            {

                if (ViewCurrentObject?.Close == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
            else
            {
                if (ViewCurrentObject?.Lock == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
        }
    }
    public partial class DisableValidatedTrangTraiChanNuoi : ObjectViewController<DetailView, TrangTraiChanNuoi>
    {
        protected override void OnActivated()
        {
            base.OnActivated();

            var os = Application.CreateObjectSpace(typeof(TrangTraiChanNuoi));
            var account = os.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);
            if (account.Roles.Any(r => r.Name == "Administrators" || r.Name == "Managers"))
            {

                if (ViewCurrentObject?.Close == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
            else
            {
                if (ViewCurrentObject?.Lock == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
        }
    }
    public partial class DisableValidatedGiayChungNhanChanNuoiDaCap : ObjectViewController<DetailView, GiayChungNhanChanNuoiDaCap>
    {
        protected override void OnActivated()
        {
            base.OnActivated();

            var os = Application.CreateObjectSpace(typeof(GiayChungNhanChanNuoiDaCap));
            var account = os.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);
            if (account.Roles.Any(r => r.Name == "Administrators" || r.Name == "Managers"))
            {

                if (ViewCurrentObject?.Close == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
            else
            {
                if (ViewCurrentObject?.Lock == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
        }
    }
    public partial class DisableValidatedVungChanNuoiAnToanDichBenh : ObjectViewController<DetailView, VungChanNuoiAnToanDichBenh>
    {
        protected override void OnActivated()
        {
            base.OnActivated();

            var os = Application.CreateObjectSpace(typeof(VungChanNuoiAnToanDichBenh));
            var account = os.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);
            if (account.Roles.Any(r => r.Name == "Administrators" || r.Name == "Managers"))
            {

                if (ViewCurrentObject?.Close == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
            else
            {
                if (ViewCurrentObject?.Lock == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
        }
    }
    public partial class DisableValidatedCoSoSanXuatThucAnChanNuoi : ObjectViewController<DetailView, CoSoSanXuatThucAnChanNuoi>
    {
        protected override void OnActivated()
        {
            base.OnActivated();

            var os = Application.CreateObjectSpace(typeof(CoSoSanXuatThucAnChanNuoi));
            var account = os.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);
            if (account.Roles.Any(r => r.Name == "Administrators" || r.Name == "Managers"))
            {

                if (ViewCurrentObject?.Close == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
            else
            {
                if (ViewCurrentObject?.Lock == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
        }
    }
    public partial class DisableValidatedGiayChungNhanSanXuatThucAnCN : ObjectViewController<DetailView, GiayChungNhanSanXuatThucAnCN>
    {
        protected override void OnActivated()
        {
            base.OnActivated();

            var os = Application.CreateObjectSpace(typeof(GiayChungNhanSanXuatThucAnCN));
            var account = os.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);
            if (account.Roles.Any(r => r.Name == "Administrators" || r.Name == "Managers"))
            {

                if (ViewCurrentObject?.Close == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
            else
            {
                if (ViewCurrentObject?.Lock == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
        }
    }
    public partial class DisableValidatedQuanLyChatThaiChanNuoi : ObjectViewController<DetailView, QuanLyChatThaiChanNuoi>
    {
        protected override void OnActivated()
        {
            base.OnActivated();

            var os = Application.CreateObjectSpace(typeof(QuanLyChatThaiChanNuoi));
            var account = os.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);
            if (account.Roles.Any(r => r.Name == "Administrators" || r.Name == "Managers"))
            {

                if (ViewCurrentObject?.Close == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
            else
            {
                if (ViewCurrentObject?.Lock == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
        }
    }
    public partial class DisableValidatedBPXLMT_ChanNuoiNongHo : ObjectViewController<DetailView, BPXLMT_ChanNuoiNongHo>
    {
        protected override void OnActivated()
        {
            base.OnActivated();

            var os = Application.CreateObjectSpace(typeof(BPXLMT_ChanNuoiNongHo));
            var account = os.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);
            if (account.Roles.Any(r => r.Name == "Administrators" || r.Name == "Managers"))
            {

                if (ViewCurrentObject?.Close == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
            else
            {
                if (ViewCurrentObject?.Lock == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
        }
    }
    public partial class DisableValidatedPhongChongDichBenhDongVat : ObjectViewController<DetailView, PhongChongDichBenhDongVat>
    {
        protected override void OnActivated()
        {
            base.OnActivated();

            var os = Application.CreateObjectSpace(typeof(PhongChongDichBenhDongVat));
            var account = os.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);
            if (account.Roles.Any(r => r.Name == "Administrators" || r.Name == "Managers"))
            {

                if (ViewCurrentObject?.Close == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
            else
            {
                if (ViewCurrentObject?.Lock == true)
                {
                    var editors = View.GetItems<PropertyEditor>();
                    foreach (var item in editors)
                    {
                        item.AllowEdit["hihi"] = false;
                    }
                }
            }
        }
    }
}
