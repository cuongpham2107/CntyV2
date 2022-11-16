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
    [DefaultProperty(nameof(Tieude))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Tiến độ văn bản luật")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class TienDoVanBanLuat : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public TienDoVanBanLuat(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string moTa;
        LoaiTienDo loaiTienDo;
        string tieude;
        [XafDisplayName("Tiêu đề")]
        public string Tieude
        {
            get => tieude;
            set => SetPropertyValue(nameof(Tieude), ref tieude, value);
        }
        [XafDisplayName("Loại tiến độ")]
        public LoaiTienDo LoaiTienDo
        {
            get => loaiTienDo;
            set => SetPropertyValue(nameof(LoaiTienDo), ref loaiTienDo, value);
        }
        [XafDisplayName("Mô tả")]
        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }
    }
    public enum LoaiTienDo
    {
        [XafDisplayName("Năm")] n =0,
        [XafDisplayName("Từ năm - đến năm")] nn = 1,
        [XafDisplayName("Text")]t =2,
    }
}