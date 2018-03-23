using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticketprice3
{
    public class DistinstEqualityComparer : IEqualityComparer<MyPrice>
    {

        public bool Equals(MyPrice x, MyPrice y)
        {
            return x.startstation == y.startstation;
        }

        public int GetHashCode(MyPrice price)
        {
            return price.startstation.GetHashCode();
        }
    }
}
