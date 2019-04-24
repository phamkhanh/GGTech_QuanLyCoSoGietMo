using GGTech_Common;
using GGTech_QuanLyCoSoGietMo._Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGTech_QuanLyCoSoGietMo.QuanLyThuChi
{
    public partial class NhapDuLieuThuChiForm : Form
    {
        public NhapDuLieuThuChiForm()
        {
            InitializeComponent();
        }

        private void NhapDuLieuThuChiForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gGTech_QuanLyCoSoGietMo_Dataset.KhachHangTab' table. You can move, or remove it, as needed.
            this.khachHangTabTableAdapter.Fill(this.gGTech_QuanLyCoSoGietMo_Dataset.KhachHangTab);
            // TODO: This line of code loads data into the 'gGTech_QuanLyCoSoGietMo_Dataset.ThuChiTab' table. You can move, or remove it, as needed.
            this.thuChiTabTableAdapter.FillByNgayThangNam(this.gGTech_QuanLyCoSoGietMo_Dataset.ThuChiTab, DateTime.Parse(dtpNgayThuChi.Value.ToShortDateString()), DateTime.Parse(dtpNgayThuChi.Value.ToShortDateString()+" 11:59:59 PM"));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string mixNoiDung = "";
                if (radThu.Checked)
                {
                    mixNoiDung += string.Format("Thu tiền {0}, {1}", txtNoiDung.Text, txtGhiChu.Text);
                }
                else if (radChi.Checked)
                {
                    mixNoiDung += string.Format("Chi tiền {0}, {1}", txtNoiDung.Text, txtGhiChu.Text);
                }
                else
                {

                }
                ThuChiModel thuChiModel = new ThuChiModel();
                int.TryParse(txtSoThamChieu.Text, out thuChiModel.ParentId);
                thuChiModel.KhachHangTabId = int.Parse(cbbKhachHang.SelectedValue.ToString());
                thuChiModel.NoiDung = mixNoiDung;
                thuChiModel.Thu = radThu.Checked ? "+" : "";
                thuChiModel.Chi = radChi.Checked ? "+" : "";
                thuChiModel.SoTien = decimal.Parse(txtMaskSoTien.Text.Replace(".", ""));
                txtMaskSoTien.Text = "123456";
                thuChiModel.NgayChi = dtpNgayThuChi.Value;
                thuChiModel.GhiChu = txtGhiChu.Text;

                this.thuChiTabTableAdapter.Insert(thuChiModel.ParentId,
                    thuChiModel.KhachHangTabId,
                    thuChiModel.NoiDung,
                    thuChiModel.Thu,
                    thuChiModel.Chi,
                    thuChiModel.SoTien,
                    thuChiModel.NgayChi,
                    thuChiModel.GhiChu,
                    DateTime.Now,
                    DateTime.Now);
            }
            catch
            {
                GGTechMsg.Instance.Red(lbMsg, "Lỗi nhập dữ liệu");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.thuChiTabTableAdapter.Update(gGTech_QuanLyCoSoGietMo_Dataset.ThuChiTab);
            GGTechMsg.Instance.Green(lbMsg, "Lưu dữ liệu thành công.");
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.thuChiTabTableAdapter.FillByFull(this.gGTech_QuanLyCoSoGietMo_Dataset.ThuChiTab, DateTime.Parse(dtpNgayThuChi.Value.ToShortDateString()), DateTime.Parse(dtpNgayThuChi.Value.ToShortDateString() + " 11:59:59 PM"), txtTimHoTen.Text);
        }
    }
}
