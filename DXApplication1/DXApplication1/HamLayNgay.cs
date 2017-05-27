using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1
{
    public class HamLayNgay
    {
        public string madr()
        {
            string a = DateTime.Now.Day.ToString();
            string b = DateTime.Now.Month.ToString();
            string c = DateTime.Now.Year.ToString();
            string d = DateTime.Now.Hour.ToString();
            string e = DateTime.Now.Minute.ToString();
            string f = DateTime.Now.Second.ToString();
            return f + e + d + a + b + c;

        }
        public string ngay()
        {
            string day = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string gettg = year + "-" + month + "-" + day;
            return gettg;
        }
        public string thang()
        {
            string day = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string gettg = year + "-" + month;
            return gettg;
        }


    }
}
