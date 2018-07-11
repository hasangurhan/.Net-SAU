using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Evernote.Common;
using MyEverNote.Core.DataAccess;
using MyEverNote.Entities;

namespace MyEverNote.AccessLayer.EntitiyFramework
{
    public class Repository<T> : IDataAccess<T> where T:class
    {
        private DataBaseContext db;//= new DataBaseContext();
        private DbSet<T> _objectset;
        public Repository()
        {
            db = RepositoryBase.CreateContext();
            _objectset = db.Set<T>();
        }
        public IQueryable<T> ListQueryable()
        {
            return _objectset.AsQueryable<T>();
        }
        public List<T> List()
        {
            return _objectset.ToList(); // t int olabilir o yüzden t class olmak zorundua
        }
        public List<T> List(Expression<Func<T,bool>>where)
        {
          return _objectset.Where(where).ToList();
        }
        public int Insert(T obj)
        {
            _objectset.Add(obj); //db.Set<T>() yerine _onj kullandım
            if (obj is MyEntitiyBase)
            {
                MyEntitiyBase o = obj as MyEntitiyBase;
                DateTime now = DateTime.Now;
                o.CreatedOn = now;
                o.ModifiedOn =now;
                o.ModifiedUsername = App.Common.GetCurrentUsername();
            }       
            return Save();
        }
        public int Update(T obj)
        {
            if (obj is MyEntitiyBase)
            {
                MyEntitiyBase o = obj as MyEntitiyBase;
                
                    
                o.ModifiedOn = DateTime.Now;
                o.ModifiedUsername = App.Common.GetCurrentUsername();
            }
            return Save();
        }
        public int Delete (T obj)
        {
            _objectset.Remove(obj);
            return Save();
        }
        public int Save ()
        {
            return db.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectset.FirstOrDefault(where);
        }
    }
}
