using Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controls
{
    public class dalDoiBong
    {
        QLDoiBongDbContext db;

        public dalDoiBong()
        {
            db = new QLDoiBongDbContext();
        }

        public string GetName(int id)
        {
            return db.DoiBongs.FirstOrDefault(db => db.maDoiBong == id).tenDoiBong;
        }

        public int GetID(string name)
        {
            return db.DoiBongs.FirstOrDefault(db => db.tenDoiBong == name).maDoiBong;
        }

        public List<entDoiBong> GetEntDoiBongs()
        {
            List<entDoiBong> entDoiBongs = new List<entDoiBong>();

            foreach (DoiBong item in db.DoiBongs)
            {
                entDoiBong entDoiBong = new entDoiBong();

                entDoiBong.maDoiBong = item.maDoiBong;
                entDoiBong.tenDoiBong = item.tenDoiBong;

                entDoiBongs.Add(entDoiBong);
            }

            return entDoiBongs;
        }
    }
}
