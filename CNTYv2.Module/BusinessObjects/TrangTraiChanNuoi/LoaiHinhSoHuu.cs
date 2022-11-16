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
    [DefaultProperty(nameof(TenLoaiHinh))]
    [NavigationItem(Menu.TrangTrai)]
    [ImageName("BO_Contact")]
    [XafDisplayName("Loại hình sở hữu")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class LoaiHinhSoHuu : BaseObject
    { 
        public LoaiHinhSoHuu(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string mota;
        string tenLoaiHinh;
        [XafDisplayName("Tên loại hình")]
        public string TenLoaiHinh
        {
            get => tenLoaiHinh;
            set => SetPropertyValue(nameof(TenLoaiHinh), ref tenLoaiHinh, value);
        }
        [XafDisplayName("Mô tả")]
        public string Mota
        {
            get => mota;
            set => SetPropertyValue(nameof(Mota), ref mota, value);
        }
    }
}