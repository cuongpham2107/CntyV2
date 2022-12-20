using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
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
using static System.Net.Mime.MediaTypeNames;

namespace CNTYv2.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TenCoQuan))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Cơ quan quản lý")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]


    public class CoQuanQuanLy : BaseObject
    {
        public CoQuanQuanLy(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        CapQuanLy capQuanLy;
        string tenCoQuan;
        [XafDisplayName("Tên cơ quan")]
        [RuleRequiredField("Bắt buộc phải có CoQuanQuanLy.TenCoQuan", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenCoQuan
        {
            get => tenCoQuan;
            set => SetPropertyValue(nameof(TenCoQuan), ref tenCoQuan, value);
        }
        [XafDisplayName("Cấp quản lý")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public CapQuanLy CapQuanLy
        {
            get => capQuanLy;
            set => SetPropertyValue(nameof(CapQuanLy), ref capQuanLy, value);
        }
        string ghiChu;
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Cơ sở chăn nuôi")]
        [Association("CoQuanQuanLy-TrangTraiChanNuois")]
        public XPCollection<BusinessObjects.TrangTraiChanNuoi> TrangTraiChanNuois
        {
            get
            {
                return GetCollection<BusinessObjects.TrangTraiChanNuoi>(nameof(TrangTraiChanNuois));
            }
        }
        
        [XafDisplayName("Cơ sở sản xuất thức ăn")]
        [Association("CoQuanQuanLy-CoSoSanXuatThucAnChanNuois")]
        public XPCollection<CoSoSanXuatThucAnChanNuoi> CoSoSanXuatThucAnChanNuois
        {
            get
            {
                return GetCollection<CoSoSanXuatThucAnChanNuoi>(nameof(CoSoSanXuatThucAnChanNuois));
            }
        }
        [XafDisplayName("Biển pháp xử lý môi trường")]
        [Association("CoQuanQuanLy-BPXLMT_ChanNuoiNongHos")]
        public XPCollection<BPXLMT_ChanNuoiNongHo> BPXLMT_ChanNuoiNongHos
        {
            get
            {
                return GetCollection<BPXLMT_ChanNuoiNongHo>(nameof(BPXLMT_ChanNuoiNongHos));
            }
        }
        [XafDisplayName("Chất thải chăn nuôi")]
        [Association("CoQuanQuanLy-QuanLyChatThaiChanNuois")]
        public XPCollection<QuanLyChatThaiChanNuoi> QuanLyChatThaiChanNuois
        {
            get
            {
                return GetCollection<QuanLyChatThaiChanNuoi>(nameof(QuanLyChatThaiChanNuois));
            }
        }
        [XafDisplayName("Phòng chống dịch bệnh động vật")]
        [Association("CoQuanQuanLy-PhongChongDichBenhDongVats")]
        public XPCollection<PhongChongDichBenhDongVat> PhongChongDichBenhDongVats
        {
            get
            {
                return GetCollection<PhongChongDichBenhDongVat>(nameof(PhongChongDichBenhDongVats));
            }
        }
       
        [XafDisplayName("Danh sách tài khoản"), ToolTip("")]
        [Association("CoQuanQuanLy-ApplicationUsers")]
        [VisibleInDetailView(false)]
        public XPCollection<ApplicationUser> Users => GetCollection<ApplicationUser>(nameof(Users));

    }
    public enum CapQuanLy
    {
        [XafDisplayName("Cấp Tỉnh")] Tinh = 0,
        [XafDisplayName("Cấp Huyện")] Huyen = 1,
    }
}