using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BaiTapTongHopQLSV
{
    public class SV
    {
        private string _MSSV;
        private string _NameSV;
        private string _Class;
        private bool _Gender;
        private DateTime _BD;
        private double _DTB;
        private bool _Image;
        private bool _HB;
        private bool _CMND;

        public string MSSV { get => _MSSV; set => _MSSV = value; }
        public string NameSV { get => _NameSV; set => _NameSV = value; }
        public string Class { get => _Class; set => _Class = value; }
        public bool Gender { get => _Gender; set => _Gender = value; }
        public DateTime BD { get => _BD; set => _BD = value; }
        public double DTB { get => _DTB; set => _DTB = value; }
        public bool Image { get => _Image; set => _Image = value; }
        public bool HB { get => _HB; set => _HB = value; }
        public bool CMND { get => _CMND; set => _CMND = value; }
        
        
    }
    
}
