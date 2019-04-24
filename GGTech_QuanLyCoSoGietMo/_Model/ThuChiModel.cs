using System;

namespace GGTech_QuanLyCoSoGietMo._Model
{
    public class ThuChiModel
    {
        public int Id;
        public int ParentId;

        private int khachHangTabId;

        public string NoiDung;
        public string Thu;
        public string Chi;
        public decimal SoTien;
        public DateTime NgayChi;
        public string GhiChu;
        public DateTime NgayTao;
        public DateTime NgayCapNhat;

        public int KhachHangTabId
        {
            get => khachHangTabId;
            set => khachHangTabId = value;
        }
    }
}