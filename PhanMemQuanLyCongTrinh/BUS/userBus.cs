using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DAO;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.BUS
{
    public class userBus
    {
        userDao _userDao = new userDao();

       public Int64 checkLogin(string userName, string passWord)
       {
           Int64 IntCheck = _userDao.CheckLogin(userName, passWord);

           if ( IntCheck > 0)
           {
               return IntCheck;
           }
           else
               return 0;
       }

       public Object getUserByID(Int64 id)
       {
            var user = _userDao.getUserById(id);

            return user;
       }

       public Int64 insertUser(ST_employee em)
       {
            return _userDao.insertUser(em);
       }

       public bool updateUser(ST_employee em, Int64 id)
       {
           var boolUpdate = _userDao.updateUser(em, id);
           if (boolUpdate)
           {
            return true;
           }
           else
           {
            return false;
           }
       }

       public bool upatePass(string pass, Int64 id)
       {
            return _userDao.updatePassword(pass, id);
       }

       public bool deleteUser(Int64 id)
       {
            return _userDao.deleteEmployee(id);
       }

       public IEnumerable<Object> getAll( )
       {
            return _userDao.getAllUser();
       }

       public IEnumerable<Object> getAllUserByDepartment(Int64 id)
       {
           return _userDao.getAllUserByDepartment(id);
       }
    }
}
