
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
    [NavigationItem(Menu.DanGiong)]
    [DefaultProperty(nameof(TenLoaiDanGiong))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Loại đàn giống")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class LoaiDanGiong : BaseObject
    {
        public LoaiDanGiong(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string moTa;
        string tenLoaiDanGiong;
        [XafDisplayName("Tên loại đàn giống")]
        [RuleRequiredField("Bắt buộc phải có LoaiDanGiong.TenLoaiDanGiong", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenLoaiDanGiong
        {
            get => tenLoaiDanGiong;
            set => SetPropertyValue(nameof(TenLoaiDanGiong), ref tenLoaiDanGiong, value);
        }
      
        LoaiVatNuoi loaiVatNuoi;
        [XafDisplayName("Loại vật chăn nuôi")]
        public LoaiVatNuoi LoaiVatNuoi
        {
            get => loaiVatNuoi;
            set => SetPropertyValue(nameof(LoaiVatNuoi), ref loaiVatNuoi, value);
        }
        [XafDisplayName("Mô tả")]
        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }
        [XafDisplayName("Cơ cấu đàn giống")]
        [Association("LoaiDanGiong-CoCauDanGiongs")]
        public XPCollection<CoCauDanGiong> CoCauDanGiongs
        {
            get
            {
                return GetCollection<CoCauDanGiong>(nameof(CoCauDanGiongs));
            }
        }
    }
}