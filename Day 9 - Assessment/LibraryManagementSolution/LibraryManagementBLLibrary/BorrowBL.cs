using LibraryManagementDALLibrary;
using LibraryManagmentModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLibrary
{
    public class BorrowBL : IBorrowServices
    {
        IRepository<int, Borrow> _borrowRepository;
        public BorrowBL()
        {
            _borrowRepository = new BorrowRepository();
        }
        public Borrow AddBorrow(Borrow item)
        {
            var result = _borrowRepository.Add(item);
            if(result != null) { return result; }
            return null; 
            throw new NotImplementedException();
        }

        public Borrow DeleteBorrow(int id)
        {
            var item = _borrowRepository.Get(id);
            if(item != null) {
                _borrowRepository.Delete(id);
                return item;
            }
            return null;
            throw new NotImplementedException();
        }

        public List<Borrow> GetAllBorrows()
        {
            return _borrowRepository.GetAll();
            throw new NotImplementedException();
        }

        public Borrow GetBorrowById(int id)
        {
            var result = _borrowRepository.Get(id);
            if(result != null) { return result;}
            return null;
            throw new NotImplementedException();
        }

        public Borrow UpdateBorrow(Borrow item)
        {
            var elem = _borrowRepository.Get(item.Id);
            if(elem!= null)
            {
                _borrowRepository.Update(item);
            }
            return null;
            throw new NotImplementedException();
        }
    }
}
