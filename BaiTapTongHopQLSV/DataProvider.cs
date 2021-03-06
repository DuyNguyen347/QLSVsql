using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace QuanLyQuanCafe.DAL
{
    public class DataProvider
    {
        private static DataProvider _Instance;
        private string s;



        public static DataProvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DataProvider();
                }
                return _Instance;
            }
            private set => _Instance = value;
        }
        public DataProvider()
        {
            s = @"Data Source=DESKTOP-KMNS09Q\SQLEXPRESS;Initial Catalog=QuanLySinhVienITF;Integrated Security=True";
        }
        public bool executeDB(string query, object[] parameter = null)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(s))
                {
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cnn.Open();
                    if (parameter != null)
                    {
                        string[] list = query.Split(' ');
                        int i = 0;
                        foreach (string item in list)
                        {
                            if (item.Contains('@'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    return true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi!");
                return false;
            }
        }
        public DataTable GetRecords(string query)
        {
            //try
            //{
            DataTable dt = new DataTable();
            using (SqlConnection cnn = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cnn.Open();
                da.Fill(dt);
                cnn.Close();
                return dt;
            }
        }
        //catch (Exception e)
        //{
        //    MessageBox.Show("Lỗi");
        //    return null;
        //}

        public DataTable setdata(string query, object[] parameter = null)
        {
            //try
            //{
            using (SqlConnection cnn = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();

                return GetRecords("select * from NhanVien");
            }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Lỗi!");
            //    return null;
            //}
        }
    }
}
