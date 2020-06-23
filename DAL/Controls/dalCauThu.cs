using Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controls
{
    public class dalCauThu
    {
        QLDoiBongDbContext db;

        public dalCauThu()
        {
            db = new QLDoiBongDbContext();
        }

        public List<entCauThu> GetCauThus_IDDoiBong(int id)
        {
            List<entCauThu> entCauThus = new List<entCauThu>();
            dalDoiBong dal_db = new dalDoiBong();

            foreach (CauThu cauThu in db.CauThus.Where(ct => ct.maDoiBong == id))
            {
                entCauThu entCauThu = new entCauThu();

                entCauThu.maCauThu = cauThu.maCauThu;
                entCauThu.tenCauThu = cauThu.hoTen;
                entCauThu.diaChi = cauThu.diaChi;
                entCauThu.tenDoiBong = dal_db.GetName(cauThu.maDoiBong);

                entCauThus.Add(entCauThu);
            }

            return entCauThus;
        }

        public bool Them(entCauThu entCauThu)
        {
            dalDoiBong dalDoiBong = new dalDoiBong();

            try
            {
                CauThu cauThu = new CauThu();

                cauThu.hoTen = entCauThu.tenCauThu;
                cauThu.diaChi = entCauThu.diaChi;
                cauThu.maDoiBong = dalDoiBong.GetID(entCauThu.tenDoiBong);

                db.CauThus.Add(cauThu);
                db.SaveChanges();
            }

            catch { return false; }
        
            return true;
        }

        public bool Sua(entCauThu entCauThu)
        {
            dalDoiBong dalDoiBong = new dalDoiBong();

            try
            {
                CauThu cauThu = db.CauThus.FirstOrDefault(ct => ct.maCauThu == entCauThu.maCauThu);

                cauThu.hoTen = entCauThu.tenCauThu;
                cauThu.diaChi = entCauThu.diaChi;
                cauThu.maDoiBong = dalDoiBong.GetID(entCauThu.tenDoiBong);

                db.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool Xoa(int id)
        {
            try
            {
                var cauThu = db.CauThus.FirstOrDefault(ct => ct.maCauThu == id);

                db.CauThus.Remove(cauThu);
                db.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public entCauThu GetCauThu_IDCauThu(int id)
        {
            CauThu cauThu = db.CauThus.FirstOrDefault(ct => ct.maCauThu == id);
            dalDoiBong dalDoiBong = new dalDoiBong();

            entCauThu entCauThu = new entCauThu();

            entCauThu.maCauThu = cauThu.maCauThu;
            entCauThu.tenCauThu = cauThu.hoTen;
            entCauThu.diaChi = cauThu.diaChi;
            entCauThu.tenDoiBong = dalDoiBong.GetName(cauThu.maDoiBong);

            return entCauThu;
        }
    }
}
