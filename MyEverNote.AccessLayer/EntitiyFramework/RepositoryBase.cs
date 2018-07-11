using MyEverNote.AccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEverNote.AccessLayer.EntitiyFramework
{
    public class RepositoryBase
    {
        private static DataBaseContext _db;
        private static object _lockSync = new object();
        protected  RepositoryBase()
        {
            //newlenmesin diye sadece miras alan newler
        }
        public static DataBaseContext CreateContext()
        {
            if (_db == null)
            {
                lock (_lockSync)
                {
                    if (_db == null)
                    {
                        _db = new DataBaseContext();
                    }
                    
                }
               
            }
            return _db;
        }
    }
}
