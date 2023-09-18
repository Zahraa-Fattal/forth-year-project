using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SBResults
{
    [Keyless]
    public class GetFreeStoreKeeperSBR
    {
        public int StoreKeeperId { get; set; }
        public string StoreKeeperName { get; set; }
    }
}
