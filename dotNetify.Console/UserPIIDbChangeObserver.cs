using dotNetify.Console.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetify.Console
{
    public class UserPIIDbChangeObserver : BaseVM, ICOMPaaSDbChangeObserver
    {
        public void Observe(string name, IDbChangeObserver dbChangeObserver)
        {
            this.ObserveList<User>("Users", dbChangeObserver);
        }
    }
}
