using LibraryManagmentModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementBLLibrary
{
    public interface IBorrowServices
    {
        List<Borrow> GetAllBorrows();
        Borrow AddBorrow(Borrow item);
        Borrow DeleteBorrow(int id);
        Borrow GetBorrowById(int id);
        Borrow UpdateBorrow(Borrow item);
    }
}
