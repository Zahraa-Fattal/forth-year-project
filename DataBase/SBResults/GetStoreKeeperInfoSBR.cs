using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SBResults
{
    [Keyless]
    public class GetStoreKeeperInfoSBR
    {
        public int StoreKeeperId { get; set; }
        public string StoreKeeperName { get; set; }
        public string PhoneNumber { get; set; }
        public string unitName { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
    }
}
