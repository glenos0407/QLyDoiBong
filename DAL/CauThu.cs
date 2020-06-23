using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CauThu
    {
        [Key]
        public int maCauThu { get; set; }
        public string hoTen { get; set; }
        public string diaChi { get; set; }

        public int maDoiBong { get; set; }
        public virtual DoiBong DoiBong { get; set; }
    }
}
