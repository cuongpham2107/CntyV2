using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
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
    [NavigationItem(Menu.DanGiong)]
    [DefaultProperty(nameof(NoiDung))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Cơ cấu đàn giống")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class CoCauDanGiong : BaseObject
    {
        public CoCauDanGiong(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        LoaiDanGiong loaiDanGiong;
        int soLuongThoiDiemBaoCao;
        string dTV;
        string noiDung;
        [XafDisplayName("Nội dung")]
        [RuleRequiredField("Bắt buộc phải có CoCauDanGiong.NoiDung", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string NoiDung
        {
            get => noiDung;
            set => SetPropertyValue(nameof(NoiDung), ref noiDung, value);
        }
        [XafDisplayName("Loại đàn giống")]
        [RuleRequiredField("Bắt buộc phải có CoCauDanGiong.LoaiDanGiong", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [Association("LoaiDanGiong-CoCauDanGiongs")]
        public LoaiDanGiong LoaiDanGiong
        {
            get => loaiDanGiong;
            set => SetPropertyValue(nameof(LoaiDanGiong), ref loaiDanGiong, value);
        }
        [XafDisplayName("Đơn vị tính")]
        public string DTV
        {
            get => dTV;
            set => SetPropertyValue(nameof(DTV), ref dTV, value);
        }
        [XafDisplayName("Số lượng thời điểm báo cáo")]
        public int SoLuongThoiDiemBaoCao
        {
            get => soLuongThoiDiemBaoCao;
            set => SetPropertyValue(nameof(SoLuongThoiDiemBaoCao), ref soLuongThoiDiemBaoCao, value);
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
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Association("KyBaoCao-CoCauDanGiongs")]
        public KyBaoCao KyBaoCao
        {
            get => kyBaoCao;
            set => SetPropertyValue(nameof(KyBaoCao), ref kyBaoCao, value);
        }

    }

}