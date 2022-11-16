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
    [DefaultProperty(nameof(TenLoaiHinh))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Phân loại cơ sở")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    public class PhanLoaiCoSoChanNuoi : BaseObject
    {
        public PhanLoaiCoSoChanNuoi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        string moTa;
        string tenLoaiHinh;
        [XafDisplayName("Loại hình chăn nuôi")]
        public string TenLoaiHinh
        {
            get => tenLoaiHinh;
            set => SetPropertyValue(nameof(TenLoaiHinh), ref tenLoaiHinh, value);
        }
        [XafDisplayName("Mô tả")]
        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }


    }
}