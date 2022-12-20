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
using static System.Net.Mime.MediaTypeNames;

namespace CNTYv2.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(Menu.TrangTrai)]
    [ImageName("BO_Contact")]
    [XafDisplayName("Vùng, Cơ sở chăn nuôi")]
    [DefaultProperty(nameof(TenTrangTrai))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [Appearance("HideEdit", AppearanceItemType = "ViewItem", TargetItems = "*", Criteria = "[Lock] = True Or [Close] = True", Context = "Any", Enabled = false)]
    public class TrangTraiChanNuoi : BaseObject
    {
        public TrangTraiChanNuoi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        int quyMoChanNuoi;
        DateTime? ngayCap;
        string soGCN;
        KyBaoCao kyBaoCao;
        string ghiChu;
        int soLuongVatNuoi;
        string diaChiSoDienThoai;
        string loaiHinhSoHuu;
        string tenTrangTrai;
        [XafDisplayName("Trang trại chăn nuôi")]
        [RuleRequiredField("Bắt buộc phải có TrangTraiChanNuoi.TenTrangTrai", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenTrangTrai
        {
            get => tenTrangTrai;
            set => SetPropertyValue(nameof(TenTrangTrai), ref tenTrangTrai, value);
        }
        [XafDisplayName("Loại hình sở hữu")]
        [RuleRequiredField("Bắt buộc phải có TrangTraiChanNuoi.LoaiHinhSoHuu", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string LoaiHinhSoHuu
        {
            get => loaiHinhSoHuu;
            set => SetPropertyValue(nameof(LoaiHinhSoHuu), ref loaiHinhSoHuu, value);
        }
        [XafDisplayName("Địa chỉ, Số ĐT liên hệ")]
        [RuleRequiredField("Bắt buộc phải có TrangTraiChanNuoi.DiaChi", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string DiaChiSoDienThoai
        {
            get => diaChiSoDienThoai;
            set => SetPropertyValue(nameof(DiaChiSoDienThoai), ref diaChiSoDienThoai, value);
        }

        GiayChungNhanChanNuoiDaCap giayChungNhanChanNuoiDaCap;
        [VisibleInListView(false)]
        [XafDisplayName("Giấy chứng nhận")]
        public GiayChungNhanChanNuoiDaCap GiayChungNhanChanNuoiDaCap
        {
            get => giayChungNhanChanNuoiDaCap;
            set => SetPropertyValue(nameof(GiayChungNhanChanNuoiDaCap), ref giayChungNhanChanNuoiDaCap, value);
        }

        PhanLoaiCoSoChanNuoi phanLoaiCoSoChanNuoi;
        [Association("PhanLoaiCoSoChanNuoi-TrangTraiChanNuois")]
        [RuleRequiredField("Bắt buộc phải có TrangTraiChanNuoi.PhanLoaiCoSoChanNuoi", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [XafDisplayName("Phân loại chăn nuôi")]
        public PhanLoaiCoSoChanNuoi PhanLoaiCoSoChanNuoi
        {
            get => phanLoaiCoSoChanNuoi;
            set => SetPropertyValue(nameof(PhanLoaiCoSoChanNuoi), ref phanLoaiCoSoChanNuoi, value);
        }


        CoQuanQuanLy coQuanQuanLy;
        [XafDisplayName("Cơ quan quản lý")]
        [Association("CoQuanQuanLy-TrangTraiChanNuois")]
        public CoQuanQuanLy CoQuanQuanLy
        {
            get
            {
                return coQuanQuanLy;
            }
            set => SetPropertyValue(nameof(CoQuanQuanLy), ref coQuanQuanLy, value);
        }
        [XafDisplayName("Số giấy chứng nhận")]
        [VisibleInListView(false)]
        [ModelDefault("AllowEdit", "False")]
        public string SoGCN
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {

                    var sgcn = GiayChungNhanChanNuoiDaCaps.OrderByDescending(i => i.Oid).FirstOrDefault();
                    if (sgcn != null)
                    {
                        return sgcn.SoGiayChungNhan;
                    }

                }
                return null;
            }
        }
        [XafDisplayName("Ngày cấp giấy chứng nhận")]
        [VisibleInListView(false)]
        [ModelDefault("AllowEdit", "False")]
        public DateTime? NgayCap
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    var nc = GiayChungNhanChanNuoiDaCaps.OrderByDescending(i => i.Oid).FirstOrDefault();
                    if (nc != null)
                    {
                        return nc.NgayCap;
                    }
                }
                return null;

            }
        }
        [XafDisplayName("Ngày hết hạn giấy chứng nhận")]
        [VisibleInListView(false)]
        [ModelDefault("AllowEdit", "False")]
        public DateTime? NgayHetHan
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {

                    var nhn = GiayChungNhanChanNuoiDaCaps.OrderByDescending(i => i.Oid).FirstOrDefault();
                    if (nhn != null)
                    {
                        return nhn.NgayHetHan;
                    }
                }
                return null;

            }
        }
        LoaiVatNuoi loaiVatNuoi;
        [XafDisplayName("Loại vật nuôi")]
        public LoaiVatNuoi LoaiVatNuoi
        {
            get => loaiVatNuoi;
            set => SetPropertyValue(nameof(LoaiVatNuoi), ref loaiVatNuoi, value);
        }
        [XafDisplayName("Quy mô chăn nuôi")]
        public int QuyMoChanNuoi
        {
            get
            {
                return quyMoChanNuoi;
            }
            set => SetPropertyValue(nameof(QuyMoChanNuoi), ref quyMoChanNuoi, value);
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
        [Association("KyBaoCao-TrangTraiChanNuois")]
        public KyBaoCao KyBaoCao
        {
            get => kyBaoCao;
            set => SetPropertyValue(nameof(KyBaoCao), ref kyBaoCao, value);
        }
        #region Association
        //[XafDisplayName("Vật nuôi")]
        //[Association("TrangTraiChanNuoi-TrangTrai_VatNuois")]
        //public XPCollection<TrangTrai_VatNuoi> TrangTrai_VatNuois
        //{
        //    get
        //    {
        //        return GetCollection<TrangTrai_VatNuoi>(nameof(TrangTrai_VatNuois));
        //    }
        //}
        [XafDisplayName("Giấy chứng nhận của cơ sở")]
        [Association("TrangTraiChanNuoi-GiayChungNhanChanNuoiDaCaps")]
        public XPCollection<GiayChungNhanChanNuoiDaCap> GiayChungNhanChanNuoiDaCaps
        {
            get
            {
                return GetCollection<GiayChungNhanChanNuoiDaCap>(nameof(GiayChungNhanChanNuoiDaCaps));
            }
        }

        [XafDisplayName("Chăn nuôi an toàn dịch bệnh")]
        [Association("TrangTraiChanNuoi-VungChanNuoiAnToanDichBenhs")]
        public XPCollection<VungChanNuoiAnToanDichBenh> VungChanNuoiAnToanDichBenhs
        {
            get
            {
                return GetCollection<VungChanNuoiAnToanDichBenh>(nameof(VungChanNuoiAnToanDichBenhs));
            }
        }
        #endregion

    }
}