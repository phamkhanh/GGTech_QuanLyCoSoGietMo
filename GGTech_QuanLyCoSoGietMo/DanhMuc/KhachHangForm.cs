using GGTech_Common;
using GGTech_QuanLyCoSoGietMo._Dataset.GGTech_QuanLyCoSoGietMo_DatasetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGTech_QuanLyCoSoGietMo.DanhMuc
{
    public partial class KhachHangForm : Form
    {
        string _msg = "";

        public KhachHangForm()
        {
            InitializeComponent();
            if (this.khachHangTabTableAdapter == null) this.khachHangTabTableAdapter = new KhachHangTabTableAdapter();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string hoten = txtHoTen.Text;
            if (!string.IsNullOrEmpty(hoten))
            {
                if((int)this.khachHangTabTableAdapter.sp_KhachHang_SelectCountByHoTen(hoten) == 0)
                {
                    this.khachHangTabTableAdapter.Insert(hoten);
                    _msg = String.Format("Thêm khách hàng [ {0} ] thành công.", hoten);
                    GGTechMsg.Instance.Green(lbMsg, _msg);
                }
                else
                {
                    _msg = String.Format("Khách hàng có tên [ {0} ] đã tồn tại trong cơ sở dữ liệu.", hoten);
                    GGTechMsg.Instance.Red(lbMsg, _msg);
                }
            }
            else
            {
                _msg = String.Format("Vui lòng nhập Họ tên của khách hàng.");
                GGTechMsg.Instance.Red(lbMsg, _msg);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string newHoTen = txtHoTen.Text;
            if (!string.IsNullOrEmpty(newHoTen))
            {
                if ((int)this.khachHangTabTableAdapter.sp_KhachHang_SelectCountByHoTen(newHoTen) <= 1)
                {
                    //_adapter.Update(hoten);
                    _msg = String.Format("Cập nhật khách hàng [ {0} ] thành công.", newHoTen);
                    GGTechMsg.Instance.Green(lbMsg, _msg);
                }
                else
                {
                    _msg = String.Format("Khách hàng có tên [ {0} ] đã tồn tại trong cơ sở dữ liệu.", newHoTen);
                    GGTechMsg.Instance.Red(lbMsg, _msg);
                }
            }
            else
            {
                _msg = String.Format("Vui lòng nhập Họ tên của khách hàng.");
                GGTechMsg.Instance.Red(lbMsg, _msg);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {

        }

        private void KhachHangForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gGTech_QuanLyCoSoGietMo_Dataset.KhachHangTab' table. You can move, or remove it, as needed.
            this.khachHangTabTableAdapter.Fill(this.gGTech_QuanLyCoSoGietMo_Dataset.KhachHangTab);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.khachHangTabTableAdapter.Update(gGTech_QuanLyCoSoGietMo_Dataset.KhachHangTab);
            _msg = String.Format("Lưu dữ liệu thành công.");
            GGTechMsg.Instance.Green(lbMsg, _msg);
        }
    }
}
