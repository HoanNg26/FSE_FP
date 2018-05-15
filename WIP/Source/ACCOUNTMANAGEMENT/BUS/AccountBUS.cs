using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class AccountBUS
    {
        private AccountDAL accDal;

        public AccountBUS()
        {
            accDal = new AccountDAL();
        }
        public bool isValidFullname(AccountDTO acc)
        {
            if (acc.Fullname == null || acc.Fullname.Length < 1)
                return false;

            return true;
        }
        public bool insert(AccountDTO acc)
        {
            return accDal.insert(acc);
        }
        public bool update(AccountDTO acc)
        {
            return accDal.update(acc);
        }

        public bool delete(AccountDTO acc)
        {
            return accDal.delete(acc);
        }
        public bool selectAll(List<AccountDTO> accountList)
        {
            return accDal.selectAll(accountList);
        }
    }
}
