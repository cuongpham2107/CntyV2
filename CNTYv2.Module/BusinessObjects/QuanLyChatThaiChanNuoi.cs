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
using static CNTYv2.Module.BusinessObjects.Common;

namespace CNTYv2.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(Menu.DataMenuItem)]
    [DefaultProperty(nameof(LHChanNuoi))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Chất thải chăn nuôi")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    [Appearance("HideEdit", AppearanceItemType = "ViewItem", TargetItems = "*", Criteria = "[Lock] = True Or [Close] = True", Context = "Any", Enabled = false)]
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

        KyBaoCao kyBaoCao;
        string khongCoBienPhap;
        string coBienPhapXuLyChatThaiChanNuoi;
        string coGiayPhepMoiTruong_KeHoachBVMT;
        string coBaoCaoDanhGiaTacDongMoiTruong;
        string tongSoCoSo;
        LHChanNuoi lHChanNuoi;
        [XafDisplayName("Loại hình chăn nuôi")]
        public LHChanNuoi LH_ChanNuoi
        {
            get => lHChanNuoi;
            set => SetPropertyValue(nameof(LH_ChanNuoi), ref lHChanNuoi, value);
        }

        CoQuanQuanLy coQuanQuanLy;
        [XafDisplayName("Cơ quan quản lý")]
        [Association("CoQuanQuanLy-QuanLyChatThaiChanNuois")]
        public CoQuanQuanLy CoQuanQuanLy
        {
            get => coQuanQuanLy;
            set => SetPropertyValue(nameof(CoQuanQuanLy), ref coQuanQuanLy, value);
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
        private bool _lock;
        [VisibleInDetailView(false)]
        [XafDisplayName("Lock"), ToolTip(""), ModelDefault("AllowEdit", "False")]
        public bool Lock
        {
            get { return _lock; }
            set { SetPropertyValue(nameof(Lock), ref _lock, value); }
        }


        private bool _close;
        [VisibleInDetailView(false)]
        [XafDisplayName("Close"), ToolTip(""), ModelDefault("AllowEdit", "False")]
        public bool Close
        {
            get { return _close; }
            set { SetPropertyValue(nameof(Close), ref _close, value); }
        }


        #region Action

        [Action(Caption = "Lock", ConfirmationMessage = "Lock dữ liệu này? Sau khi lock sẽ KHÔNG thể sửa chữa thông tin được nữa.", ImageName = "Security_Lock", AutoCommit = true, TargetObjectsCriteria = "[Lock]=False", TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueAtLeastForOne, SelectionDependencyType = MethodActionSelectionDependencyType.RequireMultipleObjects)]
        public void LockAction()
        {
            Lock = true;
            Session.Save(this);
        }

        [Action(Caption = "UnLock", AutoCommit = true, TargetObjectsCriteria = "[Lock]=True", ImageName = "Security_Unlock")]
        public void LockActionUndo()
        {
            Lock = false;
            Session.Save(this);
        }



        [Action(Caption = "Close", ConfirmationMessage = "Đóng dữ liệu này? Sau khi đóng sẽ KHÔNG thể thay đổi dữ liệu được nữa.", AutoCommit = true, TargetObjectsCriteria = "[Close]=False", TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueAtLeastForOne, SelectionDependencyType = MethodActionSelectionDependencyType.RequireMultipleObjects, ImageName = "UnprotectDocument")]
        public void CloseAction()
        {
            Close = true;
            Lock = true;
            Session.Save(this);
        }

        [Action(Caption = "Open", AutoCommit = true, TargetObjectsCriteria = "[Close]=True", ImageName = "TrackingChanges_Accept")]
        public void CloseActionUndo()
        {
            Close = false;
            Session.Save(this);
        }




        #endregion

        [XafDisplayName("Kỳ báo cáo")]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [Association("KyBaoCao-QuanLyChatThaiChanNuois")]
        public KyBaoCao KyBaoCao
        {
            get => kyBaoCao;
            set => SetPropertyValue(nameof(KyBaoCao), ref kyBaoCao, value);
        }
    }

}