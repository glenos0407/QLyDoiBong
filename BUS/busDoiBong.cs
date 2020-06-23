using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Controls;
using Enitites;

namespace BUS
{
    public class busDoiBong
    {
        dalDoiBong dalDoiBong;

        public busDoiBong()
        {
            dalDoiBong = new dalDoiBong();
        }

        public string GetName(int id)
        {
            return dalDoiBong.GetName(id);
        }

        public int GetID(string name)
        {
            return dalDoiBong.GetID(name);
        }

        public List<entDoiBong> GetEntDoiBongs()
        {
            return dalDoiBong.GetEntDoiBongs();
        }
    }
}
