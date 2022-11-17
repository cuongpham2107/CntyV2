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
    [DefaultProperty(nameof(TenSanPhamChanNuoi))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Sản phẩm chăn nuôi")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class LoaiSanPhamChanNuoi : BaseObject
    {
        public LoaiSanPhamChanNuoi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        string ghiChu;
        string congXuatThietKe;
        string tenLoaiThucAn;
        [XafDisplayName("Sản phẩm chăn nuôi")]
        [RuleRequiredField("Bắt buộc phải có LoaiSanPhamChanNuoi.TenSanPhamChanNuoi", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenSanPhamChanNuoi
        {
            get => tenLoaiThucAn;
            set => SetPropertyValue(nameof(TenSanPhamChanNuoi), ref tenLoaiThucAn, value);
        }
        [XafDisplayName("Công xuất thiết kế")]
        [RuleRequiredField("Bắt buộc phải có LoaiSanPhamChanNuoi.CongXuatThietKe", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string CongXuatThietKe
        {
            get => congXuatThietKe;
            set => SetPropertyValue(nameof(CongXuatThietKe), ref congXuatThietKe, value);
        }
        [XafDisplayName("Ghi chú")]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
    }
}