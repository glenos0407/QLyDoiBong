using DAL.Controls;
using Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class busCauThu
    {
        dalCauThu dalCauThu;

        public busCauThu()
        {
            dalCauThu = new dalCauThu();
        }

        public List<entCauThu> GetCauThus_IDDoiBong(int id)
        {
            return dalCauThu.GetCauThus_IDDoiBong(id);
        }

        public bool Them(entCauThu entCauThu)
        {
            return dalCauThu.Them(entCauThu);
        }

        public bool Sua(entCauThu entCauThu)
        {
            return dalCauThu.Sua(entCauThu);
        }

        public bool Xoa(int id)
        {
            return dalCauThu.Xoa(id);
        }

        public entCauThu GetCauThu_IDCauThu(int id)
        {
            return dalCauThu.GetCauThu_IDCauThu(id);
        }
    }
}
