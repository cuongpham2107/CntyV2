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
    [NavigationItem(Menu.DataMenuItem)]
    [DefaultProperty(nameof(TenVung_CoSo))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Vùng chăn nuôi an toàn dịch bệnh")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    public class VungChanNuoiAnToanDichBenh : BaseObject
    { 
        public VungChanNuoiAnToanDichBenh(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        FileData fileDuLieu;
        string ghiChu;
        DateTime ngayHetHanGCN;
        DateTime ngayCapGiayChungNhan;
        string soGiayChungNhan;
        string loaiBenhDuocChungNhanAnToan;
        string quyMoChanNuoi;
        string doiTuongVatNuoi;
        string diaChi;
        string tenVung_CoSo;
        [XafDisplayName("Vùng, cơ sở")]
        public string TenVung_CoSo
        {
            get => tenVung_CoSo;
            set => SetPropertyValue(nameof(TenVung_CoSo), ref tenVung_CoSo, value);
        }
        [XafDisplayName("Địa chỉ")]
        public string DiaChi
        {
            get => diaChi;
            set => SetPropertyValue(nameof(DiaChi), ref diaChi, value);
        }
        [XafDisplayName("Đối tượng vật nuôi")]
        public string DoiTuongVatNuoi
        {
            get => doiTuongVatNuoi;
            set => SetPropertyValue(nameof(DoiTuongVatNuoi), ref doiTuongVatNuoi, value);
        }
        [XafDisplayName("Quy mô chăn nuôi")]
        public string QuyMoChanNuoi
        {
            get => quyMoChanNuoi;
            set => SetPropertyValue(nameof(QuyMoChanNuoi), ref quyMoChanNuoi, value);
        }
        [XafDisplayName("Loại bệnh được chứng nhận an toàn")]
        public string LoaiBenhDuocChungNhanAnToan
        {
            get => loaiBenhDuocChungNhanAnToan;
            set => SetPropertyValue(nameof(LoaiBenhDuocChungNhanAnToan), ref loaiBenhDuocChungNhanAnToan, value);
        }
        [XafDisplayName("Số giấy chứng nhận")]
        public string SoGiayChungNhan
        {
            get => soGiayChungNhan;
            set => SetPropertyValue(nameof(SoGiayChungNhan), ref soGiayChungNhan, value);
        }
        [XafDisplayName("Ngày cấp giấy chứng nhận")]
        public DateTime NgayCapGiayChungNhan
        {
            get => ngayCapGiayChungNhan;
            set => SetPropertyValue(nameof(NgayCapGiayChungNhan), ref ngayCapGiayChungNhan, value);
        }
        [XafDisplayName("Ngày hết hạn/hết hiệu lực/thu hồi giấy chứng nhận")]
        public DateTime NgayHetHanGCN
        {
            get => ngayHetHanGCN;
            set => SetPropertyValue(nameof(NgayHetHanGCN), ref ngayHetHanGCN, value);
        }
        [XafDisplayName("Ghi chú")]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("File dữ liệu")]
        public FileData FileDuLieu
        {
            get => fileDuLieu;
            set => SetPropertyValue(nameof(FileDuLieu), ref fileDuLieu, value);
        }
    }
}