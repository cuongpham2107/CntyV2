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

namespace CNTYv2.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(Menu.DataMenuItem)]
    [DefaultProperty(nameof(TenVung_CoSo))]
    [ImageName("BO_Contact")]
    [XafDisplayName("Vùng chăn nuôi an toàn")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    [Appearance("HideEdit", AppearanceItemType = "ViewItem", TargetItems = "*", Criteria = "[Lock] = True Or [Close] = True", Context = "Any", Enabled = false)]
    public class VungChanNuoiAnToanDichBenh : BaseObject
    { 
        public VungChanNuoiAnToanDichBenh(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        KyBaoCao kyBaoCao;
        FileData fileDuLieu;
        string ghiChu;
        string loaiBenhDuocChungNhanAnToan;
        string quyMoChanNuoi;
        string doiTuongVatNuoi;
        TrangTraiChanNuoi tenVung_CoSo;

        [XafDisplayName("Vùng, cơ sở")]
        [RuleRequiredField("Bắt buộc phải có VungChanNuoiAnToanDichBenh.TenVung_CoSo", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [Association("TrangTraiChanNuoi-VungChanNuoiAnToanDichBenhs")]
        public TrangTraiChanNuoi TenVung_CoSo
        {
            get => tenVung_CoSo;
            set => SetPropertyValue(nameof(TenVung_CoSo), ref tenVung_CoSo, value);
        }

        [PersistentAlias("[TenVung_CoSo.CoQuanQuanLy]")]
        [XafDisplayName("Cơ quan quản lý")]
        [VisibleInListView(false)]
        public CoQuanQuanLy CoQuanQuanLy
        {
            get
            {
                var tmp = EvaluateAlias(nameof(CoQuanQuanLy));
                if (tmp != null)
                {
                    return tmp as CoQuanQuanLy;
                }
                else
                    return null;
            }
        }

        [XafDisplayName("Địa chỉ")]
        [ModelDefault("AllowEdit","False")]
        public string DiaChi
        {
            get
            {
                if(!IsLoading && !IsSaving)
                {
                    if(TenVung_CoSo != null)
                    {
                        return TenVung_CoSo.DiaChiSoDienThoai;
                    }
                }
                return null;
            }
        }
        [XafDisplayName("Đối tượng vật nuôi")]
        [RuleRequiredField("Bắt buộc phải có VungChanNuoiAnToanDichBenh.DoiTuongVatNuoi", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string DoiTuongVatNuoi
        {
            get => doiTuongVatNuoi;
            set => SetPropertyValue(nameof(DoiTuongVatNuoi), ref doiTuongVatNuoi, value);
        }
        [XafDisplayName("Quy mô chăn nuôi")]
        [RuleRequiredField("Bắt buộc phải có VungChanNuoiAnToanDichBenh.QuyMoChanNuoi", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string QuyMoChanNuoi
        {
            get => quyMoChanNuoi;
            set => SetPropertyValue(nameof(QuyMoChanNuoi), ref quyMoChanNuoi, value);
        }
        [XafDisplayName("Loại bệnh được chứng nhận an toàn")]
        [RuleRequiredField("Bắt buộc phải có VungChanNuoiAnToanDichBenh.LoaiBenhDuocChungNhanAnToan", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string LoaiBenhDuocChungNhanAnToan
        {
            get => loaiBenhDuocChungNhanAnToan;
            set => SetPropertyValue(nameof(LoaiBenhDuocChungNhanAnToan), ref loaiBenhDuocChungNhanAnToan, value);
        }
        [XafDisplayName("Số giấy chứng nhận")]
        [ModelDefault("AllowEdit", "False")]
        public string SoGiayChungNhan
        {
            get
            {
                if(!IsLoading && !IsSaving)
                {
                    if(TenVung_CoSo != null)
                    {
                        return TenVung_CoSo.SoGCN;
                    }
                }
                return null;
            }
        }
        [XafDisplayName("Ngày cấp giấy chứng nhận")]
        [ModelDefault("AllowEdit", "False")]
        public DateTime? NgayCapGiayChungNhan
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    if (TenVung_CoSo != null)
                    {
                       
                        return TenVung_CoSo.NgayCap;
                    }
                }
                return null;
            }
        }
        [XafDisplayName("Ngày hết hạn/hết hiệu lực/thu hồi giấy chứng nhận")]
        public DateTime? NgayHetHanGCN
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    if (TenVung_CoSo != null)
                    {
                        return TenVung_CoSo.NgayHetHan;
                    }
                }
                return null;
            }
        }
      

        [XafDisplayName("Ghi chú")]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("File dữ liệu")]
        public FileData FileDuLieu
        {
            get => fileDuLieu;
            set => SetPropertyValue(nameof(FileDuLieu), ref fileDuLieu, value);
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
        [Association("KyBaoCao-VungChanNuoiAnToanDichBenhs")]
        public KyBaoCao KyBaoCao
        {
            get => kyBaoCao;
            set => SetPropertyValue(nameof(KyBaoCao), ref kyBaoCao, value);
        }
    }
}