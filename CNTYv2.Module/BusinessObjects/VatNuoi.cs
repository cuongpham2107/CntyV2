
//using DevExpress.Data.Filtering;
//using DevExpress.ExpressApp;
//using DevExpress.ExpressApp.DC;
//using DevExpress.ExpressApp.Model;
//using DevExpress.Persistent.Base;
//using DevExpress.Persistent.BaseImpl;
//using DevExpress.Persistent.Validation;
//using DevExpress.Xpo;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using DevExpress.Office.Import;

//namespace CNTYv2.Module.BusinessObjects
//{
//    [DefaultClassOptions]
//    [DefaultProperty(nameof(TenLoaiVatNuoi))]
//    [NavigationItem(Menu.CategoryMenuItem)]
//    [ImageName("BO_Contact")]
//    [XafDisplayName("Vật nuôi")]
//    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
//    [ListViewFindPanel(true)]
//    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
//    public class VatNuoi : BaseObject
//    {
//        public VatNuoi(Session session)
//            : base(session)
//        {
//        }
//        public override void AfterConstruction()
//        {
//            base.AfterConstruction();
//        }
//        protected override void OnLoaded()
//        {
//            base.OnLoaded();
//        }

//        LoaiVatNuoi loaiVatNuoi;
//        string moTa;
//        string tenLoaiVatNuoi;
//        [XafDisplayName("Tên loại vật nuôi")]
//        [RuleRequiredField("Bắt buộc phải có VatNuoi.TenLoaiVatNuoi", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
//        public string TenLoaiVatNuoi
//        {
//            get => tenLoaiVatNuoi;
//            set => SetPropertyValue(nameof(TenLoaiVatNuoi), ref tenLoaiVatNuoi, value);
//        }
//        [XafDisplayName("Loại vật nuôi")]
//        [Association("LoaiVatNuoi-VatNuois")]
//        public LoaiVatNuoi LoaiVatNuoi
//        {
//            get => loaiVatNuoi;
//            set => SetPropertyValue(nameof(LoaiVatNuoi), ref loaiVatNuoi, value);
//        }
       
//        [XafDisplayName("Mô tả")]
//        public string MoTa
//        {
//            get => moTa;
//            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
//        }

//        //[XafDisplayName("Trang trại chăn nuôi")]
//        //[Association("VatNuoi-TrangTraiChanNuois")]
//        //public XPCollection<TrangTraiChanNuoi> TrangTraiChanNuois
//        //{
//        //    get
//        //    {
//        //        return GetCollection<TrangTraiChanNuoi>(nameof(TrangTraiChanNuois));
//        //    }
//        //}
//        //[XafDisplayName("Trang trại chăn nuôi")]
//        //[Association("VatNuoi-TrangTrai_VatNuois")]
//        //public XPCollection<TrangTrai_VatNuoi> TrangTrai_VatNuois
//        //{
//        //    get
//        //    {
//        //        return GetCollection<TrangTrai_VatNuoi>(nameof(TrangTrai_VatNuois));
//        //    }
//        //}
//        [XafDisplayName("Loại đàn giống")]
//        [Association("VatNuoi-LoaiDanGiongs")]
//        public XPCollection<LoaiDanGiong> LoaiDanGiongs
//        {
//            get
//            {
//                return GetCollection<LoaiDanGiong>(nameof(LoaiDanGiongs));
//            }
//        }
//    }
//}