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
    [DefaultProperty(nameof(TenVanBan))]
    [ImageName("BO_Contact")]
    [XafDisplayName("VB Luật chăn nuôi")]
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

        TienDoVanBanLuat tienDoThucHien;
        string ghiChu;
        string tenVanBan;
        [XafDisplayName("Tên văn bản")]
        public string TenVanBan
        {
            get => tenVanBan;
            set => SetPropertyValue(nameof(TenVanBan), ref tenVanBan, value);
        }
        [XafDisplayName("Tiến độ thực hiện")]
        public TienDoVanBanLuat TienDoThucHien
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
    }
}