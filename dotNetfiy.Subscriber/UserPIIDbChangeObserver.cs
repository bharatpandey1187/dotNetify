using dotNetfiy.Subscriber.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace dotNetfiy.Subscriber
{
    public class UserPIIDbChangeObserver : ICOMPaaSDbChangeObserver //BaseVM,ICOMPaaSDbChangeObserver
    {

        private IPostgresReplicationSubscriber _replicationSubscriber;
        public UserPIIDbChangeObserver(IEnumerable<IPostgresReplicationSubscriber> replicationSubscribers)
        {
            _replicationSubscriber = replicationSubscribers.FirstOrDefault(x => x.PublicationName == "poc_logicaldecoding_pub");
            //this.ObserveList<User>(nameof(Users), dbChangeObserver);
            _replicationSubscriber.OnEventEmitted += OnMessageReceived;
            //this.ObserveList<Address>(nameof(Addresses), dbChangeObserver);
        }

        private void OnMessageReceived(object? sender, PostgreMessageEventArgs e)
        {
            using (FileStream fileStream = File.Open("user.json", FileMode.Append))
            {
                fileStream.Write(Encoding.UTF8.GetBytes(e.Message + Environment.NewLine));
            }
        }
    }
}
