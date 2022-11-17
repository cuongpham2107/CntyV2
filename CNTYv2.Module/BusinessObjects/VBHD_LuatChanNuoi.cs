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

        string tienDo;
        string namDenNam;
        string nam;
        LoaiTienDo loaiTienDo;
        string ghiChu;
        string tenVanBan;
        [XafDisplayName("Tên văn bản")]
        public string TenVanBan
        {
            get => tenVanBan;
            set => SetPropertyValue(nameof(TenVanBan), ref tenVanBan, value);
        }
        [XafDisplayName("Loại tiến độ")]
        public LoaiTienDo LoaiTienDo
        {
            get => loaiTienDo;
            set => SetPropertyValue(nameof(LoaiTienDo), ref loaiTienDo, value);
        }
        [XafDisplayName("Năm")]
        //[Appearance("HideNam", AppearanceItemType.ViewItem, "[LoaiTienDo] <> ##Enum#CNTYv2.Module.BusinessObjects.LoaiTienDo,n#", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context ="Any")]
        public string Nam
        {
            get => nam;
            set => SetPropertyValue(nameof(Nam), ref nam, value);
        }
        [XafDisplayName("Từ năm - đến năm")]
        //[Appearance("HideNamDenNam", AppearanceItemType.ViewItem, "[LoaiTienDo] <> ##Enum#CNTYv2.Module.BusinessObjects.LoaiTienDo,nn#", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide ,Context = "Any")]
        public string NamDenNam
        {
            get => namDenNam;
            set => SetPropertyValue(nameof(NamDenNam), ref namDenNam, value);
        }
        [XafDisplayName("Tiến độ")]
        //[Appearance("HideText", AppearanceItemType.ViewItem, "[LoaiTienDo] <> ##Enum#CNTYv2.Module.BusinessObjects.LoaiTienDo,t#", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]
        public string TienDo
        {
            get => tienDo;
            set => SetPropertyValue(nameof(TienDo), ref tienDo, value);
        }
        [XafDisplayName("Ghi chú")]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
    }
    
}