﻿using DevExpress.Data.Filtering;
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

namespace CNTYv2.Module.BusinessObjects.ThucAnChanNuoi
{
    [DefaultClassOptions]
    [NavigationItem(Menu.TAChanNuoi)]
    [DefaultProperty(nameof(SoGiayChungNhan))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Giấy chứng nhận")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class GiayChungNhanSanXuatThucAnCN : BaseObject
    {
        public GiayChungNhanSanXuatThucAnCN(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        string tieuDe;
        DateTime ngayCap;
        string soGiayChungNhan;
        string congXuatThietKe;

        [XafDisplayName("Tiêu đề")]
        public string TieuDe
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    if (CoSoSanXuatThucAnChanNuoi != null)
                    {
                        return $"{CoSoSanXuatThucAnChanNuoi.TenCoSoSanXuat},Địa chỉ: {CoSoSanXuatThucAnChanNuoi.DiaChi},Số điện thoại: {CoSoSanXuatThucAnChanNuoi.SoDienThoai}";
                    }
                }
                return null;
            }
        }
        CoSoSanXuatThucAnChanNuoi coSoSanXuatThucAnChanNuoi;
        [XafDisplayName("Cơ sở sản xuất")]
        public CoSoSanXuatThucAnChanNuoi CoSoSanXuatThucAnChanNuoi
        {
            get => coSoSanXuatThucAnChanNuoi;
            set => SetPropertyValue(nameof(CoSoSanXuatThucAnChanNuoi), ref coSoSanXuatThucAnChanNuoi, value);
        }
        [PersistentAlias("[CoSoSanXuatThucAnChanNuoi.LoaiSanPhamChanNuoi]")]
        [XafDisplayName("Sản phẩm chăn nuôi")]
        public LoaiSanPhamChanNuoi LoaiSanPhamChanNuoi
        {
            get
            {
                var tmp = EvaluateAlias(nameof(LoaiSanPhamChanNuoi));
                if (tmp != null)
                {
                    return tmp as LoaiSanPhamChanNuoi;
                }
                else
                {
                    return null;
                }
            }
        }
        [XafDisplayName("Công xuất thiết kế")]
        public string CongXuatThietKe
        {
            get
            {
                if(!IsLoading && !IsSaving)
                {
                    if(LoaiSanPhamChanNuoi != null)
                    {
                        return $"{LoaiSanPhamChanNuoi.TenSanPhamChanNuoi}, {LoaiSanPhamChanNuoi.CongXuatThietKe}";
                    }
                }
                return null;
            }
        }
        [XafDisplayName("Số giấy chứng nhận")]
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