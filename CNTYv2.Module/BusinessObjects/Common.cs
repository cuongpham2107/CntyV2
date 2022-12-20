using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNTYv2.Module.BusinessObjects
{
    public class Common
    {
        public enum LHChanNuoi
        {
            [XafDisplayName("Trang trại chăn nuôi quy mô lớn")] lon = 0,
            [XafDisplayName("Trang trại chăn nuôi quy mô vừa")] vua = 1,
            [XafDisplayName("Trang trại chăn nuôi quy mô nhỏ")] nho = 2,
            [XafDisplayName("Chăn nuôi nông hộ ")] cnnh = 3,
            [XafDisplayName("Chưa chọn")] chuchon = 4,
        }
         
        enum Loai_Cc
        {
            [XafDisplayName("Nái sinh sản")] nss = 1,
            [XafDisplayName("Cái hậu bị")] chb = 2,

        }

        //public enum LoaiTienDo
        //{
        //    [XafDisplayName("Năm")] n = 0,
        //    [XafDisplayName("Từ năm - đến năm")] nn = 1,
        //    [XafDisplayName("Text")] t = 2,
        //}
    }
}
