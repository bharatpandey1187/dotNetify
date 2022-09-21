using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetify.Postgres
{
    public class PostgreMessageEventArgs : EventArgs
    {
        public string Publisher { get; set; }

        public string Message { get; set; }
    }
}
