using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NVoucher.Model;

namespace NVoucher.Data
{
    public class DataResultRepository:IDataResultRepository
    {


        public IEnumerable<EntityMap> GetNewVouchers(IEnumerable<EntityMap> map)
        {
            return
                new List<EntityMap>
                {new EntityMap
                    {
                        Table = "MTN_50",
                        Count = 1,
                        Result = new [] {"wqeq0"}
                    },
                    new EntityMap
                    {
                        Table = "MTN_100",
                        Count = 2,
                        Result = new [] {"sadsdasa0", "sdasda1", "sadsda2"}
                    },

                    new EntityMap
                    {
                        Table = "MTN_1000",
                        Count = 2,
                        Result = new [] {"wwsdasdas", "sadsdaa"}
                    }
               };
        }
    }
}
