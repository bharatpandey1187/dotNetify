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

        private IPostgresReplicationSubscriber _replicationSubscriber;
        public UserPersonaDbChangeObserver(IEnumerable<IPostgresReplicationSubscriber> replicationSubscribers)
        {
            _replicationSubscriber = replicationSubscribers.FirstOrDefault(x => x.PublicationName == "waltojson_pub_userpersona");
            //this.ObserveList<User>(nameof(Users), dbChangeObserver);
            _replicationSubscriber.OnEventEmitted += OnMessageReceived;
            //this.ObserveList<Address>(nameof(Addresses), dbChangeObserver);
        }

        private void OnMessageReceived(object? sender, PostgreMessageEventArgs e)
        {
            Console.WriteLine("-".PadRight(140, '-'));
            Console.WriteLine("Hello From Subscriber Event:- UserPersona, Message Body Is:{0}, Message Publisher-{1}", e.Message, e.Publisher);
            Console.WriteLine("-".PadRight(140, '-'));
        }
    }
}
