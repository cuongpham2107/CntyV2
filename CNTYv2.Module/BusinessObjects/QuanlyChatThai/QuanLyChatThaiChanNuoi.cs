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

namespace CNTYv2.Module.BusinessObjects.QuanlyChatThai
{
    [DefaultClassOptions]
    [NavigationItem(Menu.ChatThai)]
    [DefaultProperty(nameof(LoaiHinhChanNuoi))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Chất thải chăn nuôi")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class QuanLyChatThaiChanNuoi : BaseObject
    {
        public QuanLyChatThaiChanNuoi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        string khongCoBienPhap;
        string coBienPhapXuLyChatThaiChanNuoi;
        string coGiayPhepMoiTruong_KeHoachBVMT;
        string coBaoCaoDanhGiaTacDongMoiTruong;
        string tongSoCoSo;
        LoaiHinhChanNuoi loaiHinhChanNuoi;
        [XafDisplayName("Loại hình chăn nuôi")]
        public LoaiHinhChanNuoi LoaiHinhChanNuoi
        {
            get => loaiHinhChanNuoi;
            set => SetPropertyValue(nameof(LoaiHinhChanNuoi), ref loaiHinhChanNuoi, value);
        }
        [XafDisplayName("Tổng số cơ sở")]
        public string TongSoCoSo
        {
            get => tongSoCoSo;
            set => SetPropertyValue(nameof(TongSoCoSo), ref tongSoCoSo, value);
        }
        [XafDisplayName("Có báo cáo đánh giá tác động môi trường")]
        public string CoBaoCaoDanhGiaTacDongMoiTruong
        {
            get => coBaoCaoDanhGiaTacDongMoiTruong;
            set => SetPropertyValue(nameof(CoBaoCaoDanhGiaTacDongMoiTruong), ref coBaoCaoDanhGiaTacDongMoiTruong, value);
        }
        [XafDisplayName("Có giấy phép môi trường/ Kế hoặch bảo vệ môi trường")]
        public string CoGiayPhepMoiTruong_KeHoachBVMT
        {
            get => coGiayPhepMoiTruong_KeHoachBVMT;
            set => SetPropertyValue(nameof(CoGiayPhepMoiTruong_KeHoachBVMT), ref coGiayPhepMoiTruong_KeHoachBVMT, value);
        }
        [XafDisplayName("Có biện phát xử lý chất thải chăn nuôi")]
        public string CoBienPhapXuLyChatThaiChanNuoi
        {
            get => coBienPhapXuLyChatThaiChanNuoi;
            set => SetPropertyValue(nameof(CoBienPhapXuLyChatThaiChanNuoi), ref coBienPhapXuLyChatThaiChanNuoi, value);
        }
        [XafDisplayName("Không có biện pháp")]
        public string KhongCoBienPhap
        {
            get => khongCoBienPhap;
            set => SetPropertyValue(nameof(KhongCoBienPhap), ref khongCoBienPhap, value);
        }
    }
}