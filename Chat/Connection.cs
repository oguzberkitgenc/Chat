using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    public class Connection
    {
        public string Adres = System.IO.File.ReadAllText(@"C:\Chat\Connection.txt"); 
    }
}
