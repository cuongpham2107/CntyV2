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

namespace CNTYv2.Module.BusinessObjects.CoCauDanGiong
{
    [DefaultClassOptions]
    [NavigationItem(Menu.DanGiong)]
    [DefaultProperty(nameof(NoiDung))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Cơ cấu đàn giống")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class CoCauDanGiong : BaseObject
    { 
        public CoCauDanGiong(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        LoaiDanGiong loaiDanGiong;
        string soLuongThoiDiemBaoCao;
        string dTV;
        string noiDung;
        [XafDisplayName("Nội dung")]
        public string NoiDung
        {
            get => noiDung;
            set => SetPropertyValue(nameof(NoiDung), ref noiDung, value);
        }
        [XafDisplayName("Loại đàn giống")]
        [Association("LoaiDanGiong-CoCauDanGiongs")]
        public LoaiDanGiong LoaiDanGiong
        {
            get => loaiDanGiong;
            set => SetPropertyValue(nameof(LoaiDanGiong), ref loaiDanGiong, value);
        }
        [XafDisplayName("Đơn vị tính")]
        public string DTV
        {
            get => dTV;
            set => SetPropertyValue(nameof(DTV), ref dTV, value);
        }
        [XafDisplayName("Số lượng thời điểm báo cáo")]
        public string SoLuongThoiDiemBaoCao
        {
            get => soLuongThoiDiemBaoCao;
            set => SetPropertyValue(nameof(SoLuongThoiDiemBaoCao), ref soLuongThoiDiemBaoCao, value);
        }
       
    }
    enum Loai_Cc
    {
        [XafDisplayName("Nái sinh sản")] nss = 1,
        [XafDisplayName("Cái hậu bị")] chb = 2,

    }
}