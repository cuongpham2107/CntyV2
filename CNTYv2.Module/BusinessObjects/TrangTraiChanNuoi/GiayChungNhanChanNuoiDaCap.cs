using CNTYv2.Module.BusinessObjects.ThucAnChanNuoi;
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
    [DefaultProperty(nameof(TenTrangTrai))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Giấy chứng nhận")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    public class GiayChungNhanChanNuoiDaCap : BaseObject
    {
        public GiayChungNhanChanNuoiDaCap(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        TrangTraiChanNuoi trangTraiChanNuoi;
        DateTime ngayCap;
        string soGiayChungNhan;
        string soLuongVatNuoi;
        string tenTrangTrai;
        [XafDisplayName("Tên trang trại")]
        public string TenTrangTrai
        {
            
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    if (TrangTraiChanNuoi != null)
                    {
                        return $"{TrangTraiChanNuoi.TenTrangTrai},Địa chỉ: {TrangTraiChanNuoi.DiaChi},Số điện thoại: {TrangTraiChanNuoi.SoDienThoai}";
                    }
                }
                return null;
            }
           
        }

        public TrangTraiChanNuoi TrangTraiChanNuoi
        {
            get => trangTraiChanNuoi;
            set => SetPropertyValue(nameof(TrangTraiChanNuoi), ref trangTraiChanNuoi, value);
        }
        [XafDisplayName("Số lượng vật nuôi")]
        public string SoLuongVatNuoi
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    if (TrangTraiChanNuoi != null)
                    {
                        return $"{TrangTraiChanNuoi.QuyMoChanNuoi}";
                    }
                }
                return null; 
            }
        }
        [XafDisplayName("Số chứng nhận")]
        public string SoGiayChungNhan
        {
            get => soGiayChungNhan;
            set => SetPropertyValue(nameof(SoGiayChungNhan), ref soGiayChungNhan, value);
        }
        [XafDisplayName("Ngày cấp")]
        public DateTime NgayCap
        {
            get => ngayCap;
            set => SetPropertyValue(nameof(NgayCap), ref ngayCap, value);
        }
    }
}