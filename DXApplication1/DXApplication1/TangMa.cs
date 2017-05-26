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
            foreach (PHIEUSUACHUA psc in ma)
            {
                MangTam.Add(int.Parse(psc.MAPSC.Substring(3)));
            }
            return KiemTra(MangTam, "PSC");
        }

        public string ThemMaBBG()
        {
            ArrayList MangTam = new ArrayList();
            var ma = from bangbaogia in qltb.BANGBAOGIAs select bangbaogia;
            foreach (BANGBAOGIA bbg in ma)
            {
                MangTam.Add(int.Parse(bbg.MABG.Substring(3)));
            }
            return KiemTra(MangTam, "BBG");
        }

        public string ThemMaCTPSC()
        {
            ArrayList MangTam = new ArrayList();
            var ma = from chitietsuachua in qltb.CHITIETSUACHUAs select chitietsuachua;
            foreach (CHITIETSUACHUA ctsc in ma)
            {
                MangTam.Add(int.Parse(ctsc.MACTSC.Substring(4)));
            }
            return KiemTra(MangTam, "CTSC");
        }


        public string ThemMaHoaDon()
        {
            ArrayList MangTam = new ArrayList();
            var ma = from hoadon in qltb.HOADONs select hoadon;
            foreach (HOADON hd in ma)
            {
                MangTam.Add(int.Parse(hd.MAHOADON.Substring(2)));
            }
            return KiemTra(MangTam, "HD");
        }

        public string ThemMaPhanLoaiGia()
        {
            ArrayList MangTam = new ArrayList();
            var ma = from phanloaigia in qltb.PHANLOAIs select phanloaigia;
            foreach (PHANLOAI plg in ma)
            {
                MangTam.Add(int.Parse(plg.MAPHANLOAI.Substring(2)));
            }
            return KiemTra(MangTam, "PL");
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
