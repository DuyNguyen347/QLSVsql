using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapTongHopQLSV
{
    public class DBSV
    {
        private static DBSV _Instance;
        public static DBSV Instance {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DBSV();
                }
                return _Instance;
            }
            private set => _Instance = value; }

        public DataTable datatableSV { get; set; }
        public DBSV()
        {
            datatableSV = new DataTable();
            datatableSV.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV",typeof(string)),
                new DataColumn("Họ và tên",typeof (string)),
                new DataColumn("Lớp sinh hoạt",typeof (string)),
                new DataColumn("Giới tính",typeof(bool)),
                new DataColumn("Ngày sinh",typeof(DateTime)),
                new DataColumn("Điểm trung bình",typeof(double)),
                new DataColumn("Ảnh",typeof(bool)),
                new DataColumn("Học bạ",typeof(bool)),
                new DataColumn ("CMND",typeof(bool)),
            }) ;
            List<SV> data = new List<SV> ();
            data.AddRange(new SV[]
            {
                new SV{MSSV = "102200374",NameSV = "Nguyen Duc Duy",Class = "20T2",Gender = true,BD = DateTime.Now,DTB = 8.8,Image  = true,HB  =  true,CMND = true},
                new SV{MSSV = "102200375",NameSV = "Nguyen Thi Thanh Thanh",Class = "20KT1",Gender = false,BD = DateTime.Now,DTB = 8.5,Image  = true,HB  =  true,CMND = false},
                new SV{MSSV = "102200399",NameSV = "Nguyen Huu Thuan",Class = "20KT2",Gender = true,BD = DateTime.Now,DTB = 8.6,Image  = false,HB  =  true,CMND = true},
                new SV{MSSV = "102200123",NameSV = "Nguyen Van A",Class = "20T2",Gender = true,BD = DateTime.Now,DTB = 10,Image  = true,HB  =  true,CMND = true},
                new SV{MSSV = "102200378",NameSV = "Nguyen Van N",Class = "20T2",Gender = true,BD = DateTime.Now,DTB = 4,Image  = true,HB  =  true,CMND = true},
                new SV{MSSV = "102200308",NameSV = "Nguyen Thi C",Class = "20T2",Gender = false,BD = DateTime.Now,DTB = 9,Image  = true,HB  =  true,CMND = true},

            });
            foreach(SV i in data)
            {
                datatableSV.Rows.Add(i.MSSV,i.NameSV,i.Class,i.Gender,i.BD,i.DTB,i.Image,i.HB,i.CMND);
            }
        }
        public  void AddRow(SV s)
        {
            datatableSV.Rows.Add(s.MSSV,s.NameSV,s.Class,s.Gender,s.BD,s.DTB,s.Image,s.HB,s.CMND);
        }
        public void UpdateRow(SV s)
        {
            foreach(DataRow dr in datatableSV.Rows)
            {
                if(dr["MSSV"].ToString() == s.MSSV)
                {
                    dr["Họ và tên"] = s.NameSV;
                    dr["Lớp sinh hoạt"] = s.Class;
                    dr["Ngày sinh"] = s.BD;
                    dr["Điểm trung bình"] = s.DTB;
                    dr["Giới tính"] = s.Gender;
                    dr["Ảnh"] = s.Image;
                    dr["Học bạ"] = s.HB;
                    dr["CMND"] = s.CMND;
                }
            }
            datatableSV.AcceptChanges();
        }
        public void DelRow(string mssv)
        {
            foreach (DataRow dr in datatableSV.Select())
            {
                if(dr["MSSV"].ToString() == mssv)
                {
                    datatableSV.Rows.Remove(dr);
                }
            }
            datatableSV.AcceptChanges();
        }
    }
}
