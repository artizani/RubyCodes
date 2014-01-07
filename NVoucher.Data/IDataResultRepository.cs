using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NVoucher.Model;

namespace NVoucher.Data
{
    interface IDataResultRepository
    {
       IEnumerable<EntityMap> GetNewVouchers(IEnumerable<EntityMap> map);
    }
}
