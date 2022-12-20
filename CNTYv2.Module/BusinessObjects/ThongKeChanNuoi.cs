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
using static CNTYv2.Module.BusinessObjects.Common;

namespace CNTYv2.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(Menu.DataMenuItem)]
    [DefaultProperty(nameof(ChiTieu))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Thống kê chăn nuôi")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    [Appearance("HideEdit", AppearanceItemType = "ViewItem", TargetItems = "*", Criteria = "[Lock] = True Or [Close] = True", Context = "Any", Enabled = false)]
    public class ThongKeChanNuoi : BaseObject
    {
        public ThongKeChanNuoi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }

        string ghiChu;
        int soLuongVatNuoi;
        int soCoSo;
        string chiTieu;
        PhanLoaiCoSoChanNuoi phanLoaiCoSoChanNuoi;
        [RuleRequiredField("Bắt buộc phải có ThongKeChanNuoi.PhanLoaiCoSoChanNuoi", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [XafDisplayName("Phân loại")]
        public PhanLoaiCoSoChanNuoi PhanLoaiCoSoChanNuoi
        {
            get => phanLoaiCoSoChanNuoi;
            set => SetPropertyValue(nameof(PhanLoaiCoSoChanNuoi), ref phanLoaiCoSoChanNuoi, value);
        }
        LHChanNuoi lHChanNuoi;
        [XafDisplayName("Quy mô chăn nuôi")]
        public LHChanNuoi LHChanNuoi
        {
            get => lHChanNuoi;
            set => SetPropertyValue(nameof(LHChanNuoi), ref lHChanNuoi, value);
        }
        [XafDisplayName("Chỉ tiêu")]
        [RuleRequiredField("Bắt buộc phải có ThongKeChanNuoi.ChiTieu", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string ChiTieu
        {
            get => chiTieu;
            set => SetPropertyValue(nameof(ChiTieu), ref chiTieu, value);
        }
        [XafDisplayName("Số cơ sở")]
        public int SoCoSo
        {
            get => soCoSo;
            set => SetPropertyValue(nameof(SoCoSo), ref soCoSo, value);
        }
        [XafDisplayName("Số lượng vật nuôi*")]
        public int SoLuongVatNuoi
        {
            get => soLuongVatNuoi;
            set => SetPropertyValue(nameof(SoLuongVatNuoi), ref soLuongVatNuoi, value);
        }
        
        [XafDisplayName("Ghi chú")]
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

        KyBaoCao kyBaoCao;
        [XafDisplayName("Kỳ báo cáo")]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [Association("KyBaoCao-ThongKeChanNuois")]
        public KyBaoCao KyBaoCao
        {
            get => kyBaoCao;
            set => SetPropertyValue(nameof(KyBaoCao), ref kyBaoCao, value);
        }

    }
}