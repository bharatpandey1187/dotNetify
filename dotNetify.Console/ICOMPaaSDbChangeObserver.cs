using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetify.Console
{
    public interface ICOMPaaSDbChangeObserver
    {
        void Observe(string name, IDbChangeObserver dbChangeObserver);
    }
}
