
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CNTYv2.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(Menu.TrangTrai)]
    [DefaultProperty(nameof(TenTrangTrai))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Giấy chứng nhận")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    [ListViewFilter("Tất cả ", "", Index = 0)]
    [ListViewFilter("Giấy chứng nhận cấp trong tháng này", "GetMonth([NgayCap]) = GetMonth(Now())", Index = 1)]
    [ListViewFilter("Giấy chứng nhận cấp trong 6 tháng đầu năm", "GetMonth([NgayCap]) <= 6 And GetYear([NgayCap]) = GetYear(Now())", Index = 2)]
    [ListViewFilter("Giấy chứng nhận cấp trong 6 tháng cuối năm", "GetMonth([NgayCap]) >= 6 And GetYear([NgayCap]) = GetYear(Now())", Index = 3)]
    [ListViewFilter("Giấy chứng nhận cấp trong năm nay", "GetMonth([NgayCap]) >= 6 And GetYear([NgayCap]) = GetYear(Now())", Index = 3)]
    [ListViewFilter("Giấy chứng nhận cấp trong quý 1", "GetMonth([NgayCap]) >= 1 And GetMonth([NgayCap]) <= 3", Index = 4)]
    [ListViewFilter("Giấy chứng nhận cấp trong quý 2", "GetMonth([NgayCap]) >= 3 And GetMonth([NgayCap]) <= 6", Index = 5)]
    [ListViewFilter("Giấy chứng nhận cấp trong quý 3", "GetMonth([NgayCap]) >= 6 And GetMonth([NgayCap]) <= 9", Index = 6)]
    [ListViewFilter("Giấy chứng nhận cấp trong quý 4", "GetMonth([NgayCap]) >= 9 And GetMonth([NgayCap]) <= 12", Index = 7)]


    [Appearance("SaphethanGCN", AppearanceItemType = "ViewItem", TargetItems = "TenTrangTrai",
    Criteria = "DateDiffMonth(Today(), [NgayHetHan]) < 6 And [NgayHetHan] Is Not Null", Context = "ListView", FontColor = "Orange", Priority = 2)]
    [Appearance("HetHanGCN", AppearanceItemType = "ViewItem", TargetItems = "TenTrangTrai",
    Criteria = "[NgayHetHan] < Now() Or [NgayHetHan] Is Null ", Context = "ListView", FontColor = "Red", Priority = 3)]

    [Appearance("HideEdit", AppearanceItemType = "ViewItem", TargetItems = "*", Criteria = "[Lock] = True Or [Close] = True", Context = "Any", Enabled = false)]


    public class GiayChungNhanChanNuoiDaCap : BaseObject
    {
        public GiayChungNhanChanNuoiDaCap(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        DateTime ngayHetHan;
        KyBaoCao kyBaoCao;
        FileData fileGCN;
        TrangTraiChanNuoi trangTraiChanNuoi;
        DateTime ngayCap;
        string soGiayChungNhan;
        string soLuongVatNuoi;
        string tenTrangTrai;
        [XafDisplayName("Tên trang trại")]
        public string TenTrangTrai
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    if (TrangTraiChanNuoi != null)
                    {
                        return $"{TrangTraiChanNuoi.TenTrangTrai},Địa chỉ, Số điện thoại: {TrangTraiChanNuoi.DiaChiSoDienThoai}";
                    }
                }
                return null;
            }
        }
        [XafDisplayName("Vùng, Cơ sở chăn nuôi")]
        [Association("TrangTraiChanNuoi-GiayChungNhanChanNuoiDaCaps")]
        [RuleRequiredField("Bắt buộc phải có GiayChungNhanChanNuoiDaCap.TrangTraiChanNuoi", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public TrangTraiChanNuoi TrangTraiChanNuoi
        {
            get => trangTraiChanNuoi;
            set => SetPropertyValue(nameof(TrangTraiChanNuoi), ref trangTraiChanNuoi, value);
        }

        [PersistentAlias("[TrangTraiChanNuoi.CoQuanQuanLy]")]
        [XafDisplayName("Cơ quan quản lý")]
        [VisibleInListView(false)]
        public CoQuanQuanLy CoQuanQuanLy
        {
            get
            {
                var tmp = EvaluateAlias(nameof(CoQuanQuanLy));
                if (tmp != null)
                {
                    return tmp as CoQuanQuanLy;
                }
                else
                    return null;
            }
        }

        [XafDisplayName("Số lượng vật nuôi")]
        [Size(SizeAttribute.Unlimited)]
        public string SoLuongVatNuoi
        {
            get => soLuongVatNuoi;
            set => SetPropertyValue(nameof(SoLuongVatNuoi), ref soLuongVatNuoi, value);
        }
        [XafDisplayName("Số chứng nhận")]
        [RuleRequiredField("Bắt buộc phải có GiayChungNhanChanNuoiDaCap.SoGiayChungNhan", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string SoGiayChungNhan
        {
            get => soGiayChungNhan;
            set => SetPropertyValue(nameof(SoGiayChungNhan), ref soGiayChungNhan, value);
        }
        [XafDisplayName("Ngày cấp")]
        [RuleRequiredField("Bắt buộc phải có GiayChungNhanChanNuoiDaCap.NgayCap", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public DateTime NgayCap
        {
            get => ngayCap;
            set => SetPropertyValue(nameof(NgayCap), ref ngayCap, value);
        }
        [XafDisplayName("Ngày hết hạn")]
        [RuleRequiredField("Bắt buộc phải có GiayChungNhanChanNuoiDaCap.NgayHetHan", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public DateTime NgayHetHan
        {
            get => ngayHetHan;
            set => SetPropertyValue(nameof(NgayHetHan), ref ngayHetHan, value);
        }
        [XafDisplayName("File Giấy chứng nhận")]
        public FileData FileGCN
        {
            get => fileGCN;
            set => SetPropertyValue(nameof(FileGCN), ref fileGCN, value);
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
        [Association("KyBaoCao-GiayChungNhanChanNuoiDaCaps")]
        public KyBaoCao KyBaoCao
        {
            get => kyBaoCao;
            set => SetPropertyValue(nameof(KyBaoCao), ref kyBaoCao, value);
        }
    }
}