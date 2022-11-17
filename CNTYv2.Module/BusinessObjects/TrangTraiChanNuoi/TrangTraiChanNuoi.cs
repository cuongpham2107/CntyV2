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
using static CNTYv2.Module.BusinessObjects.Common;

namespace CNTYv2.Module.BusinessObjects.TrangTraiChanNuoi
{
    [DefaultClassOptions]
    [NavigationItem(Menu.TrangTrai)]
    [ImageName("BO_Contact")]
    [XafDisplayName("Trang trại chăn nuôi")]
    [DefaultProperty(nameof(TenTrangTrai))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class TrangTraiChanNuoi : BaseObject
    {
        public TrangTraiChanNuoi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        LHChanNuoi lHChanNuoi;
        string ghiChu;
        int soLuongVatNuoi;
        string soDienThoai;
        string diaChi;
        LoaiHinhSoHuu loaiHinhSoHuu;
        string tenTrangTrai;
        [XafDisplayName("Tên trang trại")]
        [RuleRequiredField("Bắt buộc phải có TrangTraiChanNuoi.TenTrangTrai", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenTrangTrai
        {
            get => tenTrangTrai;
            set => SetPropertyValue(nameof(TenTrangTrai), ref tenTrangTrai, value);
        }
        [XafDisplayName("Loại hình sở hữu")]
        [RuleRequiredField("Bắt buộc phải có TrangTraiChanNuoi.LoaiHinhSoHuu", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public LoaiHinhSoHuu LoaiHinhSoHuu
        {
            get => loaiHinhSoHuu;
            set => SetPropertyValue(nameof(LoaiHinhSoHuu), ref loaiHinhSoHuu, value);
        }
        [XafDisplayName("Địa chỉ")]
        [RuleRequiredField("Bắt buộc phải có TrangTraiChanNuoi.DiaChi", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string DiaChi
        {
            get => diaChi;
            set => SetPropertyValue(nameof(DiaChi), ref diaChi, value);
        }
        [XafDisplayName("Số điện thoại")]
        public string SoDienThoai
        {
            get => soDienThoai;
            set => SetPropertyValue(nameof(SoDienThoai), ref soDienThoai, value);
        }

        GiayChungNhanChanNuoiDaCap giayChungNhanChanNuoiDaCap;
        [XafDisplayName("Giấy chứng nhận")]
        public GiayChungNhanChanNuoiDaCap GiayChungNhanChanNuoiDaCap
        {
            get => giayChungNhanChanNuoiDaCap;
            set => SetPropertyValue(nameof(GiayChungNhanChanNuoiDaCap), ref giayChungNhanChanNuoiDaCap, value);
        }
        [XafDisplayName("Số lượng vật nuôi")]
        public int SoLuongVatNuoi
        {
            get => soLuongVatNuoi;
            set => SetPropertyValue(nameof(SoLuongVatNuoi), ref soLuongVatNuoi, value);
        }
        [XafDisplayName("Quy mô chăn nuôi")]
        [ModelDefault("AllowEdit","False")]
        public LHChanNuoi LHChanNuoi
        {
            get
            {
                if(!IsLoading && !IsSaving)
                {
                    
                    if(SoLuongVatNuoi >= 10000)
                    {
                        return LHChanNuoi.lon;
                    }
                    else if (SoLuongVatNuoi >= 5000 && SoLuongVatNuoi <= 10000)
                    {
                        return LHChanNuoi.vua;
                    }
                    else if (SoLuongVatNuoi >= 1000 && SoLuongVatNuoi <= 5000)
                    {
                        return LHChanNuoi.nho;
                    }
                    else
                    {
                        return LHChanNuoi.cnnh;
                    }


                }
                return LHChanNuoi.chuchon;
            }
        }

        PhanLoaiCoSoChanNuoi phanLoaiCoSoChanNuoi;
        [Association("PhanLoaiCoSoChanNuoi-TrangTraiChanNuois")]
        [RuleRequiredField("Bắt buộc phải có TrangTraiChanNuoi.PhanLoaiCoSoChanNuoi", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [XafDisplayName("Phân loại chăn nuôi")]
        public PhanLoaiCoSoChanNuoi PhanLoaiCoSoChanNuoi
        {
            get => phanLoaiCoSoChanNuoi;
            set => SetPropertyValue(nameof(PhanLoaiCoSoChanNuoi), ref phanLoaiCoSoChanNuoi, value);
        }
        LoaiVatNuoi loaiVatNuoi;
        [XafDisplayName("Loại vật nuôi")]
        [RuleRequiredField("Bắt buộc phải có TrangTraiChanNuoi.LoaiVatNuoi", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [Association("LoaiVatNuoi-TrangTraiChanNuois")]
        public LoaiVatNuoi LoaiVatNuoi
        {
            get => loaiVatNuoi;
            set => SetPropertyValue(nameof(LoaiVatNuoi), ref loaiVatNuoi, value);
        }
        [XafDisplayName("Ghi chú")]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Biện pháp xử lý môi trường")]
        [Association("TrangTraiChanNuoi-BPXLMT_ChanNuoiNongHos")]
        public XPCollection<BPXLMT_ChanNuoiNongHo> BPXLMT_ChanNuoiNongHos
        {
            get
            {
                return GetCollection<BPXLMT_ChanNuoiNongHo>(nameof(BPXLMT_ChanNuoiNongHos));
            }
        }
    }
}