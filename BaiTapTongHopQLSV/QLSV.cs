using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapTongHopQLSV
{
    public class QLSV
    {
        private static QLSV _Instance;
        public static QLSV Instance
        {
            get
            {
                // Nham dong bo du lieu
                if (_Instance == null)
                {
                    _Instance = new QLSV();
                }
                return _Instance;
            }
            private set => _Instance = value;
        }

        public QLSV()
        {
            //createDB();
        }
        
        public List<SV> GetAllSV()
        {
            List<SV> list = new List<SV>();
            foreach (DataRow dataRow in DBSV.Instance.datatableSV.Rows)
            {
                list.Add(GetSVByDataRow(dataRow));
            }
            return list;
        }
        public List<SV> GetSVbyLopSH(string lsh,string txt = "")
        {
            List<SV> data = new List<SV>();
            if(lsh == "All")
            {
                foreach(SV i in GetAllSV())
                {
                    if (i.NameSV.Contains(txt))
                    {
                        data.Add(i);
                    }
                }
            }
            else
            {
                foreach(SV i in GetAllSV())
                {
                    if(i.Class == lsh && i.NameSV.Contains(txt) )
                    {
                        data.Add(i);
                    }
                }
            }
            return data;
        }
        public List<string> GetAllLSH()
        {
            List<string> list = new List<string>();
            foreach(SV i in GetAllSV())
            {
                list.Add(i.Class);
            }
            return list;
        }
        public SV GetSVByDataRow(DataRow i)
        {
            return new SV
            {
                MSSV = i["MSSV"].ToString(),
                NameSV = i["Họ và tên"].ToString(),
                Class = i["Lớp sinh hoạt"].ToString(),
                Gender = Convert.ToBoolean(i["Giới tính"].ToString()),
                BD = Convert.ToDateTime(i["Ngày sinh"].ToString()),
                DTB = Convert.ToDouble(i["Điểm trung bình"].ToString()),
                Image = Convert.ToBoolean(i["Ảnh"].ToString()),
                HB = Convert.ToBoolean(i["Học bạ"].ToString()),
                CMND = Convert.ToBoolean(i["CMND"].ToString())
            };
        }
        public SV GetSVbyMSSV(string mssv)
        {
            SV s = new SV();
            foreach(SV i in GetAllSV())
            {
                if(i.MSSV == mssv)
                {
                    s = i;
                    break;
                }
            }
            return s;
        }
        public  bool AddUpdate(string mssv)
        {
            bool check = true;
            foreach(SV i in GetAllSV())
            {
                if(i.MSSV == mssv)
                {
                    check = false;
                }
            }
            return check;
        }
        public void ExecuteDB(SV s)
        {
            if(AddUpdate(s.MSSV))
            {
                DBSV.Instance.AddRow(s);
            }
            else
            {
                DBSV.Instance.UpdateRow(s);
            }
        }
        public void DelSV(List<string> del)
        {
            foreach(string s in del)
            {
                DBSV.Instance.DelRow(s);
            }
        }
        public List<SV> ListSVNow(List<string> now)
        {
            List<SV> list = new List<SV>();
            foreach(string i in now)
            {
                foreach(SV j in GetAllSV())
                {
                    if(i == j.MSSV)
                    {
                        list.Add(j);
                    }
                }
            }
            return list;
        }
        public List<SV> Sort(string s,List<SV> sv)
        {
            switch (s)
            {
                case "MSSV":
                    sv = sv.OrderBy(SV => SV.MSSV).ToList();
                    break;
                case "DTB":
                    sv = sv.OrderBy(SV => SV.DTB).ToList();
                    break;
                default:
                    break;
            }
            return sv;
            //SV t = new SV();
            //switch (s)
            //{
            //    case "MSSV":
            //        for (int i = 0; i < list.Count - 1; i++)
            //        {
            //            for (int j = i + 1; j < list.Count; j++)
            //            {
            //                if (Int32.Parse(list[i].MSSV) < Int32.Parse(list[j].MSSV))
            //                {
            //                    t = list[i];
            //                    list[i] = list[j];
            //                    list[j] = t;
            //                }
            //            }
            //        }
            //        break;
            //    case "DTB":
            //        for (int i = 0; i < list.Count - 1; i++)
            //        {
            //            for (int j = i + 1; j < list.Count; j++)
            //            {
            //                if (list[i].DTB < list[j].DTB)
            //                {
            //                    t = list[i];
            //                    list[i] = list[j];
            //                    list[j] = t;
            //                }
            //            }
            //        }
            //        break;
            //    default:
            //        break;
            //}
            //return;
        }

    }
}
