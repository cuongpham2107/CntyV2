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
    [NavigationItem(Menu.DataMenuItem)]
    [DefaultProperty(nameof(TenDichBenh))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Phòng, chống dịch bệnh")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    [Appearance("HideEdit", AppearanceItemType = "ViewItem", TargetItems = "*", Criteria = "[Lock] = True Or [Close] = True", Context = "Any", Enabled = false)]
    public class PhongChongDichBenhDongVat : BaseObject
    { 
        public PhongChongDichBenhDongVat(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }

        KyBaoCao kyBaoCao;
        string ghiChu;
        string trongLuongTieuHuy;
        string soDongVatChetHuy;
        string soDongVatMacBenh;
        string soHoCoDich;
        DateTime ngayXuLyCuoiCung;
        DateTime ngayPhatHienCaBenhDau;
        string noiXayRaDichBenh;
        string loaiVatNuoi;
        string tenDichBenh;
        CoQuanQuanLy coQuanQuanLy;
        [XafDisplayName("Cơ quan quản lý")]
        [VisibleInLookupListView(true)]
        [Association("CoQuanQuanLy-PhongChongDichBenhDongVats")]
        public CoQuanQuanLy CoQuanQuanLy
        {
            get => coQuanQuanLy;
            set => SetPropertyValue(nameof(CoQuanQuanLy), ref coQuanQuanLy, value);
        }

        [XafDisplayName("Tên dịch bệnh")]
        public string TenDichBenh
        {
            get => tenDichBenh;
            set => SetPropertyValue(nameof(TenDichBenh), ref tenDichBenh, value);
        }
        [XafDisplayName("Loài vật mắc bệnh")]
        public string LoaiVatNuoi
        {
            get => loaiVatNuoi;
            set => SetPropertyValue(nameof(LoaiVatNuoi), ref loaiVatNuoi, value);
        }
        [XafDisplayName("Nơi xảy ra dịch bệnh")]
        public string NoiXayRaDichBenh
        {
            get => noiXayRaDichBenh;
            set => SetPropertyValue(nameof(NoiXayRaDichBenh), ref noiXayRaDichBenh, value);
        }
        [XafDisplayName("Ngày phát hiện ca bệnh đầu tiên")]
        public DateTime NgayPhatHienCaBenhDau
        {
            get => ngayPhatHienCaBenhDau;
            set => SetPropertyValue(nameof(NgayPhatHienCaBenhDau), ref ngayPhatHienCaBenhDau, value);
        }
        [XafDisplayName("Ngày xử lý cuối cùng")]
        public DateTime NgayXuLyCuoiCung
        {
            get => ngayXuLyCuoiCung;
            set => SetPropertyValue(nameof(NgayXuLyCuoiCung), ref ngayXuLyCuoiCung, value);
        }
        [XafDisplayName("Số hộ có dịch")]
        public string SoHoCoDich
        {
            get => soHoCoDich;
            set => SetPropertyValue(nameof(SoHoCoDich), ref soHoCoDich, value);
        }
        [XafDisplayName("Số động vật mắc bệnh")]
        public string SoDongVatMacBenh
        {
            get => soDongVatMacBenh;
            set => SetPropertyValue(nameof(SoDongVatMacBenh), ref soDongVatMacBenh, value);
        }
        [XafDisplayName("Số động vật chết, huỷ")]
        public string SoDongVatChetHuy
        {
            get => soDongVatChetHuy;
            set => SetPropertyValue(nameof(SoDongVatChetHuy), ref soDongVatChetHuy, value);
        }
        [XafDisplayName("Trọng lượng tiêu huỷ ")]
        public string TrongLuongTieuHuy
        {
            get => trongLuongTieuHuy;
            set => SetPropertyValue(nameof(TrongLuongTieuHuy), ref trongLuongTieuHuy, value);
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
        [XafDisplayName("Kỳ báo cáo")]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Association("KyBaoCao-PhongChongDichBenhDongVats")]
        public KyBaoCao KyBaoCao
        {
            get => kyBaoCao;
            set => SetPropertyValue(nameof(KyBaoCao), ref kyBaoCao, value);
        }
    }
}