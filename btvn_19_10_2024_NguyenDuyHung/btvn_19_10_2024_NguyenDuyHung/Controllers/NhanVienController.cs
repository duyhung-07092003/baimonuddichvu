using btvn_19_10_2024_NguyenDuyHung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace btvn_19_10_2024_NguyenDuyHung.Controllers
{
    public class NhanVienController : Controller
    {
        public static List<NhanVien> nhanViens = new List<NhanVien>()
        {
            new NhanVien{maNhanVien="M01",hoTen="Nguyen Duy Hung",ngaySinh = new DateTime(2003,09,07), gioiTinh = "Nam",sdt="0964065203",heSoLuong=2.5,luong=1500000,tenPhong="IT"}
        };

        // GET: NhanVien
        public ActionResult Index()
        {
            return View(nhanViens);
        }

        // GET: NhanVien/Details/5
        public ActionResult Details(string id)
        {
            var nhanVien = nhanViens.FirstOrDefault(nv => nv.maNhanVien == id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: NhanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVien/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // Lấy dữ liệu từ form và tạo nhân viên mới
                NhanVien newNhanVien = new NhanVien
                {
                    maNhanVien = collection["maNhanVien"],
                    hoTen = collection["hoTen"],
                    ngaySinh = DateTime.Parse(collection["ngaySinh"]),
                    gioiTinh = collection["gioiTinh"],
                    sdt = collection["sdt"],
                    heSoLuong = double.Parse(collection["heSoLuong"]),
                    luong = double.Parse(collection["luong"]),
                    tenPhong = collection["tenPhong"]
                };

                // Thêm nhân viên mới vào danh sách
                nhanViens.Add(newNhanVien);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/Edit/5
        public ActionResult Edit(string id)
        {
            var nhanVien = nhanViens.FirstOrDefault(nv => nv.maNhanVien == id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanVien/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                var nhanVien = nhanViens.FirstOrDefault(nv => nv.maNhanVien == id);
                if (nhanVien != null)
                {
                    nhanVien.hoTen = collection["hoTen"];
                    nhanVien.ngaySinh = DateTime.Parse(collection["ngaySinh"]);
                    nhanVien.gioiTinh = collection["gioiTinh"];
                    nhanVien.sdt = collection["sdt"];
                    nhanVien.heSoLuong = double.Parse(collection["heSoLuong"]);
                    nhanVien.luong = double.Parse(collection["luong"]);
                    nhanVien.tenPhong = collection["tenPhong"];
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/Delete/5
        public ActionResult Delete(string id)
        {
            var nhanVien = nhanViens.FirstOrDefault(nv => nv.maNhanVien == id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanVien/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                var nhanVien = nhanViens.FirstOrDefault(nv => nv.maNhanVien == id);
                if (nhanVien != null)
                {
                    nhanViens.Remove(nhanVien);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult NhanVienNu()
        {
            // Lọc danh sách nhân viên có giới tính là Nữ
            var nhanVienNu = nhanViens.Where(nv => nv.gioiTinh == "nữ").ToList();
            return View("Index", nhanVienNu); // Trả về View hiển thị nhân viên nữ
        }


        public ActionResult TongLuongTheoPhong(string tenPhong)
        {
            // Lọc nhân viên theo tên phòng và tính tổng lương
            var tongLuong = nhanViens.Where(nv => nv.tenPhong == tenPhong).Sum(nv => nv.luong);

            ViewBag.TongLuong = tongLuong;
            return View("Index", nhanViens); // Hiển thị tổng lương và danh sách nhân viên
        }


        public ActionResult TimKiemTheoPhong(string tenPhong)
        {
            // Lọc danh sách nhân viên theo tên phòng
            var nhanVienPhong = nhanViens.Where(nv => nv.tenPhong == tenPhong).ToList();

            if (nhanVienPhong.Count == 0)
            {
                ViewBag.Message = "Không tìm thấy nhân viên nào trong phòng này.";
            }

            return View("Index", nhanVienPhong); // Hiển thị danh sách nhân viên tìm thấy
        }
    }
}
