using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bd_connection_teste_fase2
{
    public class ConfigJSON
    {

        public class Rootobject
        {
            public string DBname { get; set; }
            public string dataSource { get; set; }
            public string userID { get; set; }
            public string password { get; set; }
            public Tablenames tableNames { get; set; }
        }

        public class Tablenames
        {
            public string table1 { get; set; }
            public string table2 { get; set; }
        }

    }
}
