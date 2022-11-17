using CNTYv2.Module.BusinessObjects.CoCauDanGiong;
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
    [DefaultProperty(nameof(TenLoaiVatNuoi))]
    [NavigationItem(Menu.TrangTrai)]
    [ImageName("BO_Contact")]
    [XafDisplayName("Vật nuôi")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class LoaiVatNuoi : BaseObject
    {
        public LoaiVatNuoi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }
        protected override void OnLoaded()
        {
            base.OnLoaded();
        }

        int soHoChanNuoi;
        string tongDienTich;
        string soHo;
        string moTa;
        string tenLoaiVatNuoi;
        [XafDisplayName("Tên loại vật nuôi")]
        [RuleRequiredField("Bắt buộc phải có LoaiVatNuoi.TenLoaiVatNuoi", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenLoaiVatNuoi
        {
            get => tenLoaiVatNuoi;
            set => SetPropertyValue(nameof(TenLoaiVatNuoi), ref tenLoaiVatNuoi, value);
        }
        [XafDisplayName("Tổng số hộ chăn nuôi")]
        public int SoHoChanNuoi
        {
            get
            {
                if (!IsLoading & !IsSaving)
                {
                    if (TrangTraiChanNuois != null)
                    {
                        return TrangTraiChanNuois.Count();
                    }
                    else
                    {
                        return 0;
                    }
                }
                return 0;
            }
        }
        [XafDisplayName("Mô tả")]
        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }

        [XafDisplayName("Trang trại chăn nuôi")]
        [Association("LoaiVatNuoi-TrangTraiChanNuois")]
        public XPCollection<TrangTraiChanNuoi> TrangTraiChanNuois
        {           
            get
            {
                return GetCollection<TrangTraiChanNuoi>(nameof(TrangTraiChanNuois));
            }
        }
        [XafDisplayName("Loại đàn giống")]
        [Association("LoaiVatNuoi-LoaiDanGiongs")]
        public XPCollection<LoaiDanGiong> LoaiDanGiongs
        {
            get
            {
                return GetCollection<LoaiDanGiong>(nameof(LoaiDanGiongs));
            }
        }
    }
}