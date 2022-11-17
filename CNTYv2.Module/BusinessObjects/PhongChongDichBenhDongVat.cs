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
    [DefaultProperty(nameof(TenDichBenh))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Phòng, chống dịch bệnh động vật")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

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
        [XafDisplayName("Nơi xảy ra dịch bệnh (thôn, xã, huyện) ")]
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
    }
}