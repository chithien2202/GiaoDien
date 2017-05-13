using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1
{
    public class TangMa
    {
        QLTBDataContext qltb = new QLTBDataContext();
        //public static string ATTangMa3(string ma, string tenbang)
        //{
        //    string sql = "select * from " + tenbang;

        //    SqlDataAdapter da = new SqlDataAdapter(sql, Properties.Resources.cn);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    string Ma = "";
        //    if (dt.Rows.Count <= 0)
        //    {
        //        Ma = ma + "001";
        //    }
        //    else
        //    {
        //        int k;
        //        Ma = ma;
        //        k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Trim().Substring(3, 3));
        //        k = k + 1;
        //        if (k < 10)
        //        {
        //            Ma = Ma + "00";
        //        }
        //        else
        //            if (k < 100)
        //        {
        //            Ma = Ma + "0";
        //        }
        //        Ma = Ma + k.ToString();

        //    }
        //    return Ma;
        //}

        //public static string ATTangMa2(string ma, string tenbang)
        //{
        //    string sql = "select * from " + tenbang;

        //    SqlDataAdapter da = new SqlDataAdapter(sql, Properties.Resources.cn);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    string Ma = "";
        //    if (dt.Rows.Count <= 0)
        //    {
        //        Ma = ma + "001";
        //    }
        //    else
        //    {
        //        int k;
        //        Ma = ma;
        //        k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Trim().Substring(2, 3));
        //        k = k + 1;
        //        if (k < 10)
        //        {
        //            Ma = Ma + "00";
        //        }
        //        else
        //            if (k < 100)
        //        {
        //            Ma = Ma + "0";
        //        }
        //        Ma = Ma + k.ToString();

        //    }
        //    return Ma;
        //}

        public string ThemMaBoPhan()
        {
            ArrayList MangTam = new ArrayList();
            var ma = from bophan in qltb.BOPHANs select bophan;
            foreach(BOPHAN bp in ma)
            {
                MangTam.Add(int.Parse(bp.MABOPHAN.Substring(2)));
            }
            return KiemTra(MangTam, "BP");
        }

        public string ThemMaKhachHang()
        {
            ArrayList MangTam = new ArrayList();
            var ma = from khachhang in qltb.KHACHHANGs select khachhang;
            foreach (KHACHHANG kh in ma)
            {
                MangTam.Add(int.Parse(kh.MAKHACHKHACH.Substring(2)));
            }
            return KiemTra(MangTam, "KH");
        }

        public string ThemMaLinhKien()
        {
            ArrayList MangTam = new ArrayList();
            var ma = from linhkien in qltb.LINHKIENs select linhkien;
            foreach (LINHKIEN lk in ma)
            {
                MangTam.Add(int.Parse(lk.MALINHKIEN.Substring(2)));
            }
            return KiemTra(MangTam, "LK");
        }

        public string ThemMaModel()
        {
            ArrayList MangTam = new ArrayList();
            var ma = from model in qltb.MODELs select model;
            foreach (MODEL md in ma)
            {
                MangTam.Add(int.Parse(md.MAMODEL.Substring(2)));
            }
            return KiemTra(MangTam, "MD");
        }

        public string ThemMaNhanVien()
        {
            ArrayList MangTam = new ArrayList();
            var ma = from nhanvien in qltb.NHANVIENs select nhanvien;
            foreach (NHANVIEN nv in ma)
            {
                MangTam.Add(int.Parse(nv.MANHANVIEN.Substring(2)));
            }
            return KiemTra(MangTam, "NV");
        }

        public string ThemMaNSX()
        {
            ArrayList MangTam = new ArrayList();
            var ma = from nhasanxuat in qltb.NHASANXUATs select nhasanxuat;
            foreach (NHASANXUAT nsx in ma)
            {
                MangTam.Add(int.Parse(nsx.MANSX.Substring(3)));
            }
            return KiemTra(MangTam, "NSX");
        }

        public string ThemMaThietBi()
        {
            ArrayList MangTam = new ArrayList();
            var ma = from thietbi in qltb.THIETBIs select thietbi;
            foreach (THIETBI tb in ma)
            {
                MangTam.Add(int.Parse(tb.MATHIETBI.Substring(2)));
            }
            return KiemTra(MangTam, "TB");
        }

        public string ThemMaMangHinh()
        {
            ArrayList MangTam = new ArrayList();
            var ma = from manghinh in qltb.MANHINHs select manghinh;
            foreach (MANHINH mh in ma)
            {
                MangTam.Add(int.Parse(mh.MaManHinh.Substring(2)));
            }
            return KiemTra(MangTam, "MH");
        }

        public string ThemMaNhomNguoiDung()
        {
            ArrayList MangTam = new ArrayList();
            var ma = from nhomnguoidung in qltb.NHOMNGUOIDUNGs select nhomnguoidung;
            foreach (NHOMNGUOIDUNG nnd in ma)
            {
                MangTam.Add(int.Parse(nnd.MANHOM.Substring(3)));
            }
            return KiemTra(MangTam, "NND");
        }


        public string ThemMaPTN()
        {
            ArrayList MangTam = new ArrayList();
            var ma = from phieutiepnhan in qltb.PHIEUTIEPNHANs select phieutiepnhan;
            foreach (PHIEUTIEPNHAN ptn in ma)
            {
                MangTam.Add(int.Parse(ptn.MAPHIEUTN.Substring(3)));
            }
            return KiemTra(MangTam, "PTN");
        }

        public string ThemMaPSC()
        {
            ArrayList MangTam = new ArrayList();
            var ma = from phieusuachua in qltb.PHIEUSUACHUAs select phieusuachua;
            foreach (PHIEUSUACHUA ptn in ma)
            {
                MangTam.Add(int.Parse(ptn.MAPSC.Substring(3)));
            }
            return KiemTra(MangTam, "PSC");
        }











        private string KiemTra(ArrayList _MangMa, string _ma)
        {
            if (_MangMa.Count <= 0)//chua co ma cam do nao
            {
                return _ma + "001";
            }
            else
            {
                int max = TimMax(_MangMa);

                ArrayList _machuaco = new ArrayList();
                for (int i = 1; i <= max; i++)
                {
                    _machuaco.Add(i);
                }

                foreach (Object x in _MangMa)
                {
                    for (int i = 1; i <= max; i++)
                    {
                        if (i == int.Parse(x.ToString()))
                        {
                            _machuaco.Remove(x);
                            break;
                        }
                    }

                }

                if (_machuaco.Count > 0)
                {
                    int min = TimMin(_machuaco);
                    return _ma + min.ToString("000");//lap day ma cam do con trong khoang tu 1-->cuoi
                }
                else
                {
                    return _ma + (max + 1).ToString("000");
                }
            }
        }
        private int TimMax(ArrayList mang)
        {
            int max = int.Parse(mang[0].ToString());
            for (int i = 0; i < mang.Count; i++)
            {
                if (int.Parse(mang[i].ToString()) > max)
                    max = int.Parse(mang[i].ToString());
            }
            return max;
        }
        private int TimMin(ArrayList mang)
        {
            int min = int.Parse(mang[0].ToString());
            for (int i = 0; i < mang.Count; i++)
            {
                if (int.Parse(mang[i].ToString()) < min)
                    min = int.Parse(mang[i].ToString());
            }
            return min;
        }

    }
}
