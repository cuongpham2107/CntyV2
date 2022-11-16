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

namespace CNTYv2.Module.BusinessObjects.ThucAnChanNuoi
{
    [DefaultClassOptions]
    [NavigationItem(Menu.TAChanNuoi)]
    [DefaultProperty(nameof(TenCoSoSanXuat))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Cơ sở sản xuất")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class CoSoSanXuatThucAnChanNuoi : BaseObject
    {
        public CoSoSanXuatThucAnChanNuoi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        string soDienThoai;
        string diaChi;
        string tenCoSoSanXuat;
        [XafDisplayName("Tên cơ sở")]
        public string TenCoSoSanXuat
        {
            get => tenCoSoSanXuat;
            set => SetPropertyValue(nameof(TenCoSoSanXuat), ref tenCoSoSanXuat, value);
        }
        LoaiSanPhamChanNuoi loaiSanPhamChanNuoi;
        [XafDisplayName("Sản phẩm chăn nuôi")]
        public LoaiSanPhamChanNuoi LoaiSanPhamChanNuoi
        {
            get => loaiSanPhamChanNuoi;
            set => SetPropertyValue(nameof(LoaiSanPhamChanNuoi), ref loaiSanPhamChanNuoi, value);
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
    }
}