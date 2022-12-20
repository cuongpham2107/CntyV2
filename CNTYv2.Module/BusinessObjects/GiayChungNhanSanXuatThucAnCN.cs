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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CNTYv2.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(Menu.TAChanNuoi)]
    [DefaultProperty(nameof(SoGiayChungNhan))]
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

    [Appearance("HideEdit", AppearanceItemType = "ViewItem", TargetItems = "*", Criteria = "[Lock] = True Or [Close] = True", Context = "Any", Enabled = false)]
    public class GiayChungNhanSanXuatThucAnCN : BaseObject
    {
        public GiayChungNhanSanXuatThucAnCN(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        KyBaoCao kyBaoCao;
        FileData fileDuLieu;
        string ghiChu;
        string tieuDe;
        DateTime ngayCap;
        string soGiayChungNhan;
        string congXuatThietKe;

        [XafDisplayName("Tiêu đề")]
        public string TieuDe
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    if (CoSoSanXuatThucAnChanNuoi != null)
                    {
                        return $"{CoSoSanXuatThucAnChanNuoi.TenCoSoSanXuat}, Địa chỉ: {CoSoSanXuatThucAnChanNuoi.DiaChi}, Số điện thoại: {CoSoSanXuatThucAnChanNuoi.SoDienThoai}";
                    }
                }
                return null;
            }
        }
        CoSoSanXuatThucAnChanNuoi coSoSanXuatThucAnChanNuoi;
        [Association("CoSoSanXuatThucAnChanNuoi-GiayChungNhanSanXuatThucAnCNs")]
        [RuleRequiredField("Bắt buộc phải có GiayChungNhanSanXuatThucAnCN.CoSoSanXuatThucAnChanNuoi", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [XafDisplayName("Cơ sở sản xuất")]
        public CoSoSanXuatThucAnChanNuoi CoSoSanXuatThucAnChanNuoi
        {
            get => coSoSanXuatThucAnChanNuoi;
            set => SetPropertyValue(nameof(CoSoSanXuatThucAnChanNuoi), ref coSoSanXuatThucAnChanNuoi, value);
        }

        [PersistentAlias("[CoSoSanXuatThucAnChanNuoi.CoQuanQuanLy]")]
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

        [XafDisplayName("Công xuất thiết kế")]
        public string CongXuatThietKe
        {
            get => congXuatThietKe;
            set => SetPropertyValue(nameof(CongXuatThietKe), ref congXuatThietKe, value);
        }
        [XafDisplayName("Số giấy chứng nhận")]
        [RuleRequiredField("Bắt buộc phải có GiayChungNhanSanXuatThucAnCN.SoGiayChungNhan", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string SoGiayChungNhan
        {
            get => soGiayChungNhan;
            set => SetPropertyValue(nameof(SoGiayChungNhan), ref soGiayChungNhan, value);
        }
        [XafDisplayName("Ngày cấp")]
        [RuleRequiredField("Bắt buộc phải có GiayChungNhanSanXuatThucAnCN.NgayCap", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public DateTime NgayCap
        {
            get => ngayCap;
            set => SetPropertyValue(nameof(NgayCap), ref ngayCap, value);
        }
        [XafDisplayName("Ghi chú")]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("File Giấy chứng nhận")]
        public FileData FileDuLieu
        {
            get => fileDuLieu;
            set => SetPropertyValue(nameof(FileDuLieu), ref fileDuLieu, value);
        }
        [XafDisplayName("Kỳ báo cáo")]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Association("KyBaoCao-GiayChungNhanSanXuatThucAnCNs")]
        public KyBaoCao KyBaoCao
        {
            get => kyBaoCao;
            set => SetPropertyValue(nameof(KyBaoCao), ref kyBaoCao, value);
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
    }
}