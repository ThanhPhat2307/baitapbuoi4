using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitaptuan4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                
                dgvNhanVien.Rows.Add(frm.MSNV, frm.TenNV, frm.LuongCB);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dgvNhanVien.Refresh();
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvNhanVien.SelectedRows[0];
                try
                {
                    string msnv = row.Cells["Column1"].Value?.ToString() ?? string.Empty;
                    string tenNV = row.Cells["Column2"].Value?.ToString() ?? string.Empty;
                    string luongCB = row.Cells["Column3"].Value?.ToString() ?? string.Empty;
                    

                    frmNhanVien frm = new frmNhanVien
                    {
                        MSNV = msnv,
                        TenNV = tenNV,
                        LuongCB = luongCB
                    };
                   

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        row.Cells["Column1"].Value = frm.MSNV;
                        row.Cells["Column2"].Value = frm.TenNV;
                        row.Cells["Column3"].Value = frm.LuongCB;
                    }
                 

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi chỉnh sửa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {            
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                dgvNhanVien.Rows.RemoveAt(dgvNhanVien.SelectedRows[0].Index);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvNhanVien.Rows[e.RowIndex].Selected = true;
            }
        }
    }
}
