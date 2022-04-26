using QuanLyQuanCafe.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapTongHopQLSV
{
    public partial class AddEditForm : Form
    {
        public delegate void MyDel(string LSH, string txt);
        public MyDel d { get; set; }
        public string MSSV { get; set; }

        public AddEditForm(string m)
        {
            InitializeComponent();
            MSSV = m;
            string query = "select * from LopSH";
            foreach (DataRow i in DataProvider.Instance.GetRecords(query).Rows)
            {
                cbbLopSH.Items.Add(new CBB_Item
                {
                    Value = Convert.ToInt32(i["ID_lop"].ToString()),
                    Text = i["NameLop"].ToString()
                });
            }

            GUI();
        }
        public void GUI()
        {
            string query = "select * from SV where MSSV = '" + MSSV + "'";
            DataTable d = DataProvider.Instance.GetRecords(query);
            tbMSSV.Enabled = false;
            tbMSSV.Text = d.Rows[0]["MSSV"].ToString();
            tBName.Text = d.Rows[0]["TenSV"].ToString();
            int id = Convert.ToInt32(d.Rows[0]["ID_Lop"].ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        

        private void btCc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
