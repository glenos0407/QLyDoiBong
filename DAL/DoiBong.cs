using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DoiBong
    {
        [Key]
        public int maDoiBong { get; set; }
        public string tenDoiBong { get; set; }

        public virtual ICollection<CauThu> CauThus { get; set; }
    }
}
