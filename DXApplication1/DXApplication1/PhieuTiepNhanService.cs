using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication1
{
    public class PhieuTiepNhanService
    {
        QLTBDataContext qltb = new QLTBDataContext();

        public bool AddPhieuNhan(
               string maPhieuNhan,
               string maThietBi,
               string maNhanVien,
               string maHanhKhach,
               DateTime ngayNhan,
               DateTime ngayTra,
               string tinhTrangHuHong,
               string phuKienKemTheo,
               bool hinhThuc,
               string ghiChu)
        {
            try
            {
               
                PHIEUTIEPNHAN ptn = new PHIEUTIEPNHAN();
                ptn.MAPHIEUTN = maPhieuNhan;
                ptn.MATHIETBI = maThietBi;
                ptn.MANHANVIEN = maNhanVien;
                ptn.MAKHACHKHACH = maHanhKhach;
                ptn.NGAYNHAN = ngayNhan;
                ptn.NGAYHENTRA = ngayTra;
                ptn.TINHHINHHUHONG = tinhTrangHuHong;
                ptn.PHUKIENKEMTHEO = phuKienKemTheo;
                ptn.HINHTHUC = hinhThuc;
                ptn.GHICHUPTN = ghiChu;
                qltb.PHIEUTIEPNHANs.InsertOnSubmit(ptn);
                qltb.SubmitChanges();
                XtraMessageBox.Show("Thêm thành công", "Thông báo");
                return true;
            }
            catch (Exception ex)
            {
                //PHIEUTIEPNHAN ptn = new PHIEUTIEPNHAN();
                //ptn.MAPHIEUTN = maPhieuNhan;
                //ptn.MATHIETBI = maThietBi;
                //ptn.MANHANVIEN = maNhanVien;
                //ptn.MAKHACHKHACH = maHanhKhach;
                //ptn.NGAYNHAN = ngayNhan;
                //ptn.NGAYHENTRA = ngayTra;
                //ptn.TINHHINHHUHONG = tinhTrangHuHong;
                //ptn.PHUKIENKEMTHEO = phuKienKemTheo;
                //ptn.HINHTHUC = hinhThuc;
                //ptn.GHICHUPTN = ghiChu;
                //qltb.PHIEUTIEPNHANs.InsertOnSubmit(ptn);
                //qltb.SubmitChanges();
                //XtraMessageBox.Show("Thêm thành công", "Thông báo");
                XtraMessageBox.Show("âs");
                return false;
            }
        }
    }
}
