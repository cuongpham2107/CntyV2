using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static CNTYv2.Module.BusinessObjects.Common;

namespace CNTYv2.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(Menu.DataMenuItem)]
    [DefaultProperty(nameof(TenVanBan))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Văn bản luật chăn nuôi")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    public class VBHD_LuatChanNuoi : BaseObject
    { 
        public VBHD_LuatChanNuoi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }


        FileData fileData;
        string tienDoThucHien;
        string ghiChu;
        string tenVanBan;
        [XafDisplayName("Tên văn bản")]
        [RuleRequiredField("Bắt buộc phải có VBHD_LuatChanNuoi.TenVanBan", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [Size(SizeAttribute.Unlimited)]
        public string TenVanBan
        {
            get => tenVanBan;
            set => SetPropertyValue(nameof(TenVanBan), ref tenVanBan, value);
        }
        [XafDisplayName("Tiến độ thực hiện")]
        [RuleRequiredField("Bắt buộc phải có VBHD_LuatChanNuoi.TienDoThucHien", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [Size(SizeAttribute.Unlimited)]
        public string TienDoThucHien
        {
            get => tienDoThucHien;
            set => SetPropertyValue(nameof(TienDoThucHien), ref tienDoThucHien, value);
        }
        [XafDisplayName("Ghi chú")]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("File dữ liệu")]
        public FileData FileData
        {
            get => fileData;
            set => SetPropertyValue(nameof(FileData), ref fileData, value);
        }

    }
    
}