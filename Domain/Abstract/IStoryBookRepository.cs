using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IStoryBookRepository<T> where T : class
    {
        DbSet<T> GetItems();
        void Add(T item);
        void Remove(T item);

        DbEntityEntry<T> Entry(T item);
        DbEntityEntry<T1> EntryOfOtherType<T1>(T1 item) where T1 : class;

        T1 FindItemByType<T1>(int id) where T1 : class;

        void Save();
    }
}
