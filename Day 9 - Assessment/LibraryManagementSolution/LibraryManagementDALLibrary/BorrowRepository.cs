using LibraryManagmentModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementDALLibrary
{
    public class BorrowRepository : IRepository<int, Borrow>
    {
        readonly Dictionary<int, Borrow> _borrows;

        public BorrowRepository()
        {
            _borrows = new Dictionary<int, Borrow>();
        }

        public int GenerateId()
        {
            if (_borrows.Count == 0) return 0;
            int max = _borrows.Keys.Max();
            return ++max;
        }

        public Borrow Add(Borrow item)
        {
            if (_borrows.ContainsKey(item.Id)) return null;
            item.Id = GenerateId();
            _borrows.Add(item.Id, item);
            return item;
            throw new NotImplementedException();
        }

        public Borrow Delete(int Key)
        {
            if (_borrows.ContainsKey(Key))
                _borrows.Remove(Key);
            else
                return null;
            throw new NotImplementedException();
        }

        public Borrow Get(int Key)
        {
            if (_borrows.ContainsKey(Key))
                return _borrows[Key];
            return null;
            throw new NotImplementedException();
        }

        public List<Borrow> GetAll()
        {
            return _borrows.Values.ToList();
            throw new NotImplementedException();
        }

        public Borrow Update(Borrow item)
        {
            if (_borrows.ContainsKey(item.Id))
            {
                _borrows[item.Id] = item;
            }
            throw new NotImplementedException();
        }
    }
}
