using GGTech_Common;
using GGTech_QuanLyCoSoGietMo.DanhMuc;
using GGTech_Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGTech_QuanLyCoSoGietMo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            _FInitSettingAppFile();
            DataAdapterSql._FSetConnectionString();
        }

        private void _FInitSettingAppFile()
        {
            AppCommon.AppSettingFileXml = Application.StartupPath + "\\_setting\\app.xml";
            if (!File.Exists(AppCommon.AppSettingFileXml))
            {
                if (!Directory.Exists(Path.GetDirectoryName(AppCommon.AppSettingFileXml)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(AppCommon.AppSettingFileXml));
                }
                File.Create(AppCommon.AppSettingFileXml).Close();
                AppCommon._FSaveSettingApp("ADMIN\\SQLEXPRESS2012", "GGTech_QuanLyCoSoGietMo", "10");
            }
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppCommon.AddFormToMdiParent(new KhachHangForm(), this);
        }

        private void nhậpDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
