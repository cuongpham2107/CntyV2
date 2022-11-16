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

namespace CNTYv2.Module.BusinessObjects.QuanlyChatThai
{
    [DefaultClassOptions]
    [NavigationItem(Menu.ChatThai)]
    [DefaultProperty(nameof(TenLoaiHinhChanNuoi))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Loại hình chăn nuôi")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class LoaiHinhChanNuoi : BaseObject
    { 
        public LoaiHinhChanNuoi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        string moTa;
        string tenLoaiHinhChanNuoi;
        [XafDisplayName("Tên loại hình")]
        public string TenLoaiHinhChanNuoi
        {
            get => tenLoaiHinhChanNuoi;
            set => SetPropertyValue(nameof(TenLoaiHinhChanNuoi), ref tenLoaiHinhChanNuoi, value);
        }
        [XafDisplayName("Mô tả")]
        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }
    }
}