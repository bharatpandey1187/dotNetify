using dotNetfiy.Subscriber.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace dotNetfiy.Subscriber
{
    public class UserPersonaDbChangeObserver : ICOMPaaSDbChangeObserver //BaseVM,ICOMPaaSDbChangeObserver
    {

        private IDbChangeObserver dbChangeObserver;
        public UserPersonaDbChangeObserver(IEnumerable<IDbChangeObserver> dbChangeObservers)
        {
            dbChangeObserver = dbChangeObservers.FirstOrDefault(x => x.Name == "waltojson_pub_userpersona");
            //this.ObserveList<User>(nameof(Users), dbChangeObserver);
            //this.ObserveList<Address>(nameof(Addresses), dbChangeObserver);
        }
    }
}
