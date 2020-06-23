using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enitites;
using BUS;

namespace QLDoiBong
{
    public partial class QLDoiBong : System.Web.UI.Page
    {
        busDoiBong busDoiBong;
        busCauThu busCauThu;

        protected void Page_Load(object sender, EventArgs e)
        {
            busCauThu = new busCauThu();
            busDoiBong = new busDoiBong();

            if (!IsPostBack)
            {
                init_dropdown();
            }
        }

        private void init_dropdown()
        {
            List<entDoiBong> entDoiBongs = busDoiBong.GetEntDoiBongs();
            List<string> dsName = new List<string>();

            foreach (entDoiBong item in entDoiBongs)
            {
                dsName.Add(item.tenDoiBong);
            }

            dropDownDSDoiBong.DataSource = dsName;
            dropDownDSDoiBong2.DataSource = dsName;
            dropDownDSDoiBong.DataBind();
            dropDownDSDoiBong2.DataBind();
        }

        private void load(int id)
        {
            gvwDSCauThu.DataSource = busCauThu.GetCauThus_IDDoiBong(id);
            gvwDSCauThu.DataBind();
        }

        private void clear_all()
        {
            txtMaCauThu.Text = "";
            txtTenCauThu.Text = "";
            txtDiaChi.Text = "";
            dropDownDSDoiBong2.SelectedIndex = 1;
        }

        protected void btnHienThiDSCauThu_Click(object sender, EventArgs e)
        {
            btnLuuSua.Enabled = false;
            btnXoa.Visible = false;
            clear_all();

            if (dropDownDSDoiBong.Text.Trim() != "")
            {
                int id_DB = busDoiBong.GetID(dropDownDSDoiBong.Text);
                load(id_DB);
            }
        }

        protected void btnThemCauThu_Click(object sender, EventArgs e)
        {
            if (txtTenCauThu.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Chưa Nhập Tên Cầu Thủ')", true);
                return;
            }

            if (txtDiaChi.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Chưa Nhập Địa Chỉ')", true);
                return;
            }

            entCauThu entCauThu = new entCauThu();

            entCauThu.tenCauThu = txtTenCauThu.Text.Trim();
            entCauThu.diaChi = txtDiaChi.Text.Trim();
            entCauThu.tenDoiBong = dropDownDSDoiBong2.Text;

            if (busCauThu.Them(entCauThu))
            {
                int id_DB = busDoiBong.GetID(dropDownDSDoiBong2.Text);
                load(id_DB);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Thêm Thành Công !')", true);
            }
        }

       
        protected void btnSuaCauThu_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Sua: " + (sender as LinkButton).CommandArgument + "')", true);
            btnLuuSua.Enabled = true;
            btnXoa.Visible = true;

            busCauThu busCauThu = new busCauThu();
            int id_cauthu = Convert.ToInt32((sender as LinkButton).CommandArgument);

            //Hiển thị cầu thủ được chọn lên text box
            entCauThu current = busCauThu.GetCauThu_IDCauThu(id_cauthu);

            txtMaCauThu.Text = current.maCauThu.ToString();
            txtTenCauThu.Text = current.tenCauThu;
            txtDiaChi.Text = current.diaChi;
            dropDownDSDoiBong2.Text = current.tenDoiBong;
        }

        protected void btnXoaCauThu_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnLuuSua_Click(object sender, EventArgs e)
        {
            //Sửa Cầu Thủ
            entCauThu entCauThu = new entCauThu();

            entCauThu.maCauThu = Convert.ToInt32(txtMaCauThu.Text);
            entCauThu.tenCauThu = txtTenCauThu.Text;
            entCauThu.diaChi = txtDiaChi.Text;
            entCauThu.tenDoiBong = dropDownDSDoiBong2.Text;

            if (busCauThu.Sua(entCauThu))
            {
                load(busDoiBong.GetID(entCauThu.tenDoiBong));    
            }

            btnLuuSua.Enabled = false;
        }

        protected void btnChapNhanXoa_Click(object sender, EventArgs e)
        {
            busCauThu busCauThu = new busCauThu();

            if(txtMaCauThu.Text == "") {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Chọn Cầu Thủ Để Xoá !')", true);
                return; }

            if (busCauThu.Xoa(Convert.ToInt32(txtMaCauThu.Text)))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Xoá Thành Công !')", true);
                load(busDoiBong.GetID(dropDownDSDoiBong.Text));
            }
        }
    }
}