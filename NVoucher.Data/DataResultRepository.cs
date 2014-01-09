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
                    },
                     new EntityMap
                    {
                        Table = "MTN_200",
                        Count = 2,
                        Result = new [] {"wwsdasdas", "sadsdaa"}
                    },
                     new EntityMap
                    {
                        Table = "GLO_50",
                        Count = 2,
                        Result = new [] {"wwsdasdas", "sadsdaa"}
                    }
               };
        }

        public IEnumerable<TransactionDetail> GetFundHistory()
        {
          
        return
                new List<TransactionDetail>
                {
                        new TransactionDetail
                        {
                            Date = DateTime.UtcNow.ToLongDateString(),
                            Credit = (decimal) 100.00,
                            Debit = (decimal) 50.01,
                            Balance = 320,
                            OrderId = 145456

                        },
                        new TransactionDetail
                        {
                            Date = DateTime.UtcNow.ToLongDateString(),
                            Credit = (decimal) 110.00,
                            Debit = (decimal) 56.00,
                            Balance = 320,
                            OrderId = 123999
                        },

                        new TransactionDetail
                        {
                            Date = DateTime.UtcNow.ToLongDateString(),
                            Credit = (decimal) 101.00,
                            Debit = (decimal) 55.00,
                            Balance = 307,
                            OrderId = 173456
                        },

                        new TransactionDetail
                        {
                            Date = DateTime.UtcNow.ToLongDateString(),
                            Credit = (decimal) 100.00,
                            Debit = (decimal) 150.00,
                            Balance = 210,
                            OrderId = 12356
                        }


                };
            

        }

    }
}
