using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CNTYv2.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(Menu.TrangTrai)]
    [DefaultProperty(nameof(NoiDung))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Biện pháp xử lý môi trường")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    [Appearance("HideEdit", AppearanceItemType = "ViewItem", TargetItems = "*", Criteria = "[Lock] = True Or [Close] = True", Context = "Any", Enabled = false)]

    public class BPXLMT_ChanNuoiNongHo : BaseObject
    {
        public BPXLMT_ChanNuoiNongHo(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }


        KyBaoCao kyBaoCao;
        int chanNuoiKhac;
        int giaCam;
        int lon;
        int bo;
        int trau;
        NongHo_NongTrai nongHo_NongTrai;
        string ghiChu;
        string noiDung;
        [XafDisplayName("Nội dung")]
        [RuleRequiredField("Bắt buộc phải có BPXLMT_ChanNuoiNongHo.NoiDung", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string NoiDung
        {
            get => noiDung;
            set => SetPropertyValue(nameof(NoiDung), ref noiDung, value);
        }

        CoQuanQuanLy coQuanQuanLy;
        [XafDisplayName("Cơ quan quản lý")]
        [VisibleInListView(false)]
        [VisibleInLookupListView(true)]
        [Association("CoQuanQuanLy-BPXLMT_ChanNuoiNongHos")]
        public CoQuanQuanLy CoQuanQuanLy
        {
            get => coQuanQuanLy;
            set => SetPropertyValue(nameof(CoQuanQuanLy), ref coQuanQuanLy, value);
        }

        [XafDisplayName("Phân loại")]
        public NongHo_NongTrai NongHo_NongTrai
        {
            get => nongHo_NongTrai;
            set => SetPropertyValue(nameof(NongHo_NongTrai), ref nongHo_NongTrai, value);
        }

        [XafDisplayName("Trâu")]
        public int Trau
        {
            get => trau;
            set => SetPropertyValue(nameof(Trau), ref trau, value);
        }

        [XafDisplayName("Bò")]
        public int Bo
        {
            get => bo;
            set => SetPropertyValue(nameof(Bo), ref bo, value);
        }

        [XafDisplayName("Lợn")]
        public int Lon
        {
            get => lon;
            set => SetPropertyValue(nameof(Lon), ref lon, value);
        }

        [XafDisplayName("Gia cầm")]
        public int GiaCam
        {
            get => giaCam;
            set => SetPropertyValue(nameof(GiaCam), ref giaCam, value);
        }

        [XafDisplayName("Chăn nuôi khác")]
        public int ChanNuoiKhac
        {
            get => chanNuoiKhac;
            set => SetPropertyValue(nameof(ChanNuoiKhac), ref chanNuoiKhac, value);
        }

        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }

        private bool _lock;
        [VisibleInDetailView(false)]
        [XafDisplayName("Lock"), ToolTip(""), ModelDefault("AllowEdit", "False")]
        public bool Lock
        {
            get { return _lock; }
            set { SetPropertyValue(nameof(Lock), ref _lock, value); }
        }


        private bool _close;
        [VisibleInDetailView(false)]
        [XafDisplayName("Close"), ToolTip(""), ModelDefault("AllowEdit", "False")]
        public bool Close
        {
            get { return _close; }
            set { SetPropertyValue(nameof(Close), ref _close, value); }
        }


        #region Action

        [Action(Caption = "Lock", ConfirmationMessage = "Lock dữ liệu này? Sau khi lock sẽ KHÔNG thể sửa chữa thông tin được nữa.", ImageName = "Security_Lock", AutoCommit = true, TargetObjectsCriteria = "[Lock]=False", TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueAtLeastForOne, SelectionDependencyType = MethodActionSelectionDependencyType.RequireMultipleObjects)]
        public void LockAction()
        {
            Lock = true;
            Session.Save(this);
        }

        [Action(Caption = "UnLock", AutoCommit = true, TargetObjectsCriteria = "[Lock]=True", ImageName = "Security_Unlock")]
        public void LockActionUndo()
        {
            Lock = false;
            Session.Save(this);
        }



        [Action(Caption = "Close", ConfirmationMessage = "Đóng dữ liệu này? Sau khi đóng sẽ KHÔNG thể thay đổi dữ liệu được nữa.", AutoCommit = true, TargetObjectsCriteria = "[Close]=False", TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueAtLeastForOne, SelectionDependencyType = MethodActionSelectionDependencyType.RequireMultipleObjects, ImageName = "UnprotectDocument")]
        public void CloseAction()
        {
            Close = true;
            Lock = true;
            Session.Save(this);
        }

        [Action(Caption = "Open", AutoCommit = true, TargetObjectsCriteria = "[Close]=True", ImageName = "TrackingChanges_Accept")]
        public void CloseActionUndo()
        {
            Close = false;
            Session.Save(this);
        }




        #endregion

        [XafDisplayName("Kỳ báo cáo")]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Association("KyBaoCao-BPXLMT_ChanNuoiNongHos")]
        public KyBaoCao KyBaoCao
        {
            get => kyBaoCao;
            set => SetPropertyValue(nameof(KyBaoCao), ref kyBaoCao, value);
        }

    }
    public enum NongHo_NongTrai
    {
        [XafDisplayName("Chăn nuôi nông hộ")] CNNH = 1,
        [XafDisplayName("Chăn nuôi nông trại")] CNNT = 2,

    }
}