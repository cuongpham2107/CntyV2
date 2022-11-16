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

namespace CNTYv2.Module.BusinessObjects.TrangTraiChanNuoi
{
    [DefaultClassOptions]
    [NavigationItem(Menu.TrangTrai)]
    [ImageName("BO_Contact")]
    [XafDisplayName("Trang trại chăn nuôi")]
    [DefaultProperty(nameof(TenTrangTrai))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
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

        string ghiChu;
        string quyMoChanNuoi;
        string soDienThoai;
        string diaChi;
        LoaiHinhSoHuu loaiHinhSoHuu;
        string tenTrangTrai;
        [XafDisplayName("Tên trang trại")]
        public string TenTrangTrai
        {
            get => tenTrangTrai;
            set => SetPropertyValue(nameof(TenTrangTrai), ref tenTrangTrai, value);
        }
        [XafDisplayName("Loại hình sở hữu")]
        public LoaiHinhSoHuu LoaiHinhSoHuu
        {
            get => loaiHinhSoHuu;
            set => SetPropertyValue(nameof(LoaiHinhSoHuu), ref loaiHinhSoHuu, value);
        }
        [XafDisplayName("Địa chỉ")]
        public string DiaChi
        {
            get => diaChi;
            set => SetPropertyValue(nameof(DiaChi), ref diaChi, value);
        }
        [XafDisplayName("Số điện thoại")]
        public string SoDienThoai
        {
            get => soDienThoai;
            set => SetPropertyValue(nameof(SoDienThoai), ref soDienThoai, value);
        }
        
        GiayChungNhanChanNuoiDaCap giayChungNhanChanNuoiDaCap;
        [XafDisplayName("Giấy chứng nhận")]
        public GiayChungNhanChanNuoiDaCap GiayChungNhanChanNuoiDaCap
        {
            get => giayChungNhanChanNuoiDaCap;
            set => SetPropertyValue(nameof(GiayChungNhanChanNuoiDaCap), ref giayChungNhanChanNuoiDaCap, value);
        }
        [XafDisplayName("Quy mô chăn nuôi")]
        public string QuyMoChanNuoi
        {
            get => quyMoChanNuoi;
            set => SetPropertyValue(nameof(QuyMoChanNuoi), ref quyMoChanNuoi, value);
        }

       
        PhanLoaiCoSoChanNuoi phanLoaiCoSoChanNuoi;
        [XafDisplayName("Phân loại chăn nuôi")]
        public PhanLoaiCoSoChanNuoi PhanLoaiCoSoChanNuoi
        {
            get => phanLoaiCoSoChanNuoi;
            set => SetPropertyValue(nameof(PhanLoaiCoSoChanNuoi), ref phanLoaiCoSoChanNuoi, value);
        }
        LoaiVatNuoi loaiVatNuoi;
        [XafDisplayName("Loại vật nuôi")]
        [Association("LoaiVatNuoi-TrangTraiChanNuois")]
        public LoaiVatNuoi LoaiVatNuoi
        {
            get => loaiVatNuoi;
            set => SetPropertyValue(nameof(LoaiVatNuoi), ref loaiVatNuoi, value);
        }
        [XafDisplayName("Ghi chú")]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }

    }
}