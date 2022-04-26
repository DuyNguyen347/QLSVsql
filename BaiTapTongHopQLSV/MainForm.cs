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
    public partial class MainForm : Form
    {
        

        //DBSV db = new DBSV();
        //DataTable d = new QLSV();

        public MainForm()
        {
            InitializeComponent();
            SetCBB();
        }
        public void SetCBB()
        {
            cbbLopHP.Items.Add(new CBB_Item { Value = 0,Text = "All" });
            string query = "select * from LopSH";
            foreach(DataRow i in DataProvider.Instance.GetRecords(query).Rows)
            {
                cbbLopHP.Items.Add(new CBB_Item
                {
                    Value = Convert.ToInt32(i["ID_lop"].ToString()),
                    Text = i["NameLop"].ToString()
                }); 
            }
        }
        public void showSV(int id)
        {
            string query = "";
            if(id == 0)
            {
                query = "select * from SV";
            }
            else
            {
                query = "select * from SV where ID_Lop = " + id;
            }
            dataGridView1.DataSource = DataProvider.Instance.GetRecords(query);
        }
        private void show_Click(object sender, EventArgs e)
        {
            int id = ((CBB_Item)cbbLopHP.SelectedItem).Value;
            showSV(id);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            
        }


        private void btSort_Click(object sender, EventArgs e)
        {
           
                
        }


        
            
        
        private void btUpdate_Click(object sender, EventArgs e)
        {
            
        }
        public void ShowDTG(string lsh,string txt = "")
        {

        }

        private void cbbLopHP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //private void cbbSort_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //string s = cbbLopHP.SelectedItem.ToString();
        //    List<string> list = new List<string>();
        //    foreach(DataGridViewRow row in dataGridView1.Rows)
        //    {
        //        list.Add(row.Cells["MSSV"].Value.ToString());
        //    }
        //    listSV = QLSV.Instance.ListSVNow(list);
        //    List<SV> newSv = new List<SV>();    
        //    switch(int.Parse(cbbLopHP.SelectedIndex.ToString()))
        //    {
        //        case 0:
        //            QLSV.Instance.sort(listSV);
        //            break;
        //        case 1:
        //            QLSV.Instance.sort(listSV);
        //            break;
        //    }
        //    string test = "";
        //    foreach(SV i in listSV)
        //    {
        //        test += i.DTB.ToString() + " ";
        //    }
        //    MessageBox.Show(test);
        //    dataGridView1.DataSource = listSV;
        //}


    }
}
