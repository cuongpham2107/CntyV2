
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
    [DefaultProperty(nameof(TenLoaiVatNuoi))]
    [NavigationItem(Menu.TrangTrai)]
    [ImageName("BO_Contact")]
    [XafDisplayName("Loại vật nuôi")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class LoaiVatNuoi : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public LoaiVatNuoi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string moTa;
        string tenLoaiVatNuoi;
        [RuleRequiredField("Bắt buộc phải có LoaiVatNuoi.TenLoaiVatNuoi", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [XafDisplayName("Loại vật nuôi")]
        public string TenLoaiVatNuoi
        {
            get => tenLoaiVatNuoi;
            set => SetPropertyValue(nameof(TenLoaiVatNuoi), ref tenLoaiVatNuoi, value);
        }
        
        [XafDisplayName("Mô tả")]
        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }

    }
}