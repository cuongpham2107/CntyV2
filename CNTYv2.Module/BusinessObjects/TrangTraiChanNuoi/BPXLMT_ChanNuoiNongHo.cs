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
    [DefaultProperty(nameof(NoiDung))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Biện pháp xử lý môi trường")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    public class BPXLMT_ChanNuoiNongHo : BaseObject
    {
        public BPXLMT_ChanNuoiNongHo(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }


        NongHo_NongTrai nongHo_NongTrai;
        string ghiChu;
        string noiDung;
        [XafDisplayName("Nội dung")]
        public string NoiDung
        {
            get => noiDung;
            set => SetPropertyValue(nameof(NoiDung), ref noiDung, value);
        }
        [XafDisplayName("Ghi chú")]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Phân loại chăn nuôi")]
        public NongHo_NongTrai NongHo_NongTrai
        {
            get => nongHo_NongTrai;
            set => SetPropertyValue(nameof(NongHo_NongTrai), ref nongHo_NongTrai, value);
        }
        [Association("BPXLMT_ChanNuoiNongHo-LoaiVatNuois")]
        public XPCollection<LoaiVatNuoi> LoaiVatNuois
        {
            get
            {
                return GetCollection<LoaiVatNuoi>(nameof(LoaiVatNuois));
            }
        }

    }
    public enum NongHo_NongTrai
    {
        [XafDisplayName("Chăn nuôi nông hộ")] CNNH = 1,
        [XafDisplayName("Chăn nuôi nông trại")] CNNT = 2,

    }
}