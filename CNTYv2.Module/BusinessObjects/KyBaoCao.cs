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
    [DefaultProperty(nameof(TenKyBaoCao))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Kỳ báo cáo")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class KyBaoCao : BaseObject
    { 
        public KyBaoCao(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Nam = DateTime.Today.Year;
            var thang = DateTime.Today.Month;
            if (thang >= 1 && thang <= 3)
            {
                Quy = 1;
            }
            else if(thang >= 4 && thang <= 6)
            {
                Quy = 2;
            }
            else if(thang >= 7 && thang <= 9)
            {
                Quy = 3;
            }
            else if(thang >= 10 && thang <= 12)
            {
                Quy = 4;
            }
           
            //var account = Session.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);
            //if (account.Roles.Any(r => r.Name == "Administrators" || r.Name == "Managers"))
            //{
            //    CoQuanQuanLy = null;
            //}
            //CoQuanQuanLy = account.CoquanQuanly;

        }
        int nam;
        [XafDisplayName("Năm")]
        public int Nam
        {
            get => nam;
            set
            {
                SetPropertyValue(nameof(Nam), ref nam, value);
                if (!IsLoading)
                    TenKyBaoCao = $"Báo cáo quý {Quy} năm {Nam}";
            }
        }

        int quy;
        [XafDisplayName("Quý")]
        public int Quy
        {
            get => quy;
            set
            {
                SetPropertyValue(nameof(Quy), ref quy, value);
                if (!IsLoading)
                    TenKyBaoCao = $"Báo cáo quý {Quy} năm {Nam}";
            }
        }

        string tenKyBaoCao;
        [XafDisplayName("Tên báo cáo")]
        public string TenKyBaoCao
        {
            get => tenKyBaoCao;
            set => SetPropertyValue(nameof(TenKyBaoCao), ref tenKyBaoCao, value);
        }
        //CoQuanQuanLy coQuanQuanLy;
        //[XafDisplayName("Cơ quan quản lý")]
        //[VisibleInLookupListView(true)]
        //[Association("CoQuanQuanLy-KyBaoCaos")]
        //public CoQuanQuanLy CoQuanQuanLy
        //{
        //    get => coQuanQuanLy;
        //    set => SetPropertyValue(nameof(CoQuanQuanLy), ref coQuanQuanLy, value);
        //}

        #region Associations
        [XafDisplayName("Trang trại chăn nuôi")]
        [Association("KyBaoCao-TrangTraiChanNuois")]
        public XPCollection<BusinessObjects.TrangTraiChanNuoi> TrangTraiChanNuois
        {
            get
            {
                return GetCollection<BusinessObjects.TrangTraiChanNuoi>(nameof(TrangTraiChanNuois));
            }
        }

        [XafDisplayName("Giấy chứng nhận trang trại chăn nuôi")]
        [Association("KyBaoCao-GiayChungNhanChanNuoiDaCaps")]
        public XPCollection<GiayChungNhanChanNuoiDaCap> GiayChungNhanChanNuoiDaCaps
        {
            get
            {
                return GetCollection<GiayChungNhanChanNuoiDaCap>(nameof(GiayChungNhanChanNuoiDaCaps));
            }
        }
        [XafDisplayName("Cơ sở sản xuất thức ăn")]
        [Association("KyBaoCao-CoSoSanXuatChanNuoiChanNuois")]
        public XPCollection<CoSoSanXuatThucAnChanNuoi> CoSoSanXuatChanNuoiChanNuois
        {
            get
            {
                return GetCollection<CoSoSanXuatThucAnChanNuoi>(nameof(CoSoSanXuatChanNuoiChanNuois));
            }
        }

        [XafDisplayName("Giấy chứng nhận sản xuất thức ăn")]
        [Association("KyBaoCao-GiayChungNhanSanXuatThucAnCNs")]
        public XPCollection<GiayChungNhanSanXuatThucAnCN> GiayChungNhanSanXuatThucAnCNs
        {
            get
            {
                return GetCollection<GiayChungNhanSanXuatThucAnCN>(nameof(GiayChungNhanSanXuatThucAnCNs));
            }
        }

        [XafDisplayName("Chất thải chăn nuôi")]
        [Association("KyBaoCao-QuanLyChatThaiChanNuois")]
        public XPCollection<QuanLyChatThaiChanNuoi> QuanLyChatThaiChanNuois
        {
            get
            {
                return GetCollection<QuanLyChatThaiChanNuoi>(nameof(QuanLyChatThaiChanNuois));
            }
        }

        [XafDisplayName("Biện pháp xử lý môi trường")]
        [Association("KyBaoCao-BPXLMT_ChanNuoiNongHos")]
        public XPCollection<BPXLMT_ChanNuoiNongHo> BPXLMT_ChanNuoiNongHos
        {
            get
            {
                return GetCollection<BPXLMT_ChanNuoiNongHo>(nameof(BPXLMT_ChanNuoiNongHos));
            }
        }

        [XafDisplayName("Phòng chống dịch bệnh")]
        [Association("KyBaoCao-PhongChongDichBenhDongVats")]
        public XPCollection<PhongChongDichBenhDongVat> PhongChongDichBenhDongVats
        {
            get
            {
                return GetCollection<PhongChongDichBenhDongVat>(nameof(PhongChongDichBenhDongVats));
            }
        }
        [XafDisplayName("Vùng chăn nuôi an toàn")]
        [Association("KyBaoCao-VungChanNuoiAnToanDichBenhs")]
        public XPCollection<VungChanNuoiAnToanDichBenh> VungChanNuoiAnToanDichBenhs
        {
            get
            {
                return GetCollection<VungChanNuoiAnToanDichBenh>(nameof(VungChanNuoiAnToanDichBenhs));
            }
        }
        [XafDisplayName("Thông kê chăn nuôi")]
        [Association("KyBaoCao-ThongKeChanNuois")]
        public XPCollection<ThongKeChanNuoi> ThongKeChanNuois
        { 
            get
            {
                return GetCollection<ThongKeChanNuoi>(nameof(ThongKeChanNuois));
            }
        }
        [XafDisplayName("Cơ cấu đàn giống")]
        [Association("KyBaoCao-CoCauDanGiongs")]
        public XPCollection<CoCauDanGiong> CoCauDanGiongs
        {
            get
            {
                return GetCollection<CoCauDanGiong>(nameof(CoCauDanGiongs));
            }
        }
        #endregion
    }
}