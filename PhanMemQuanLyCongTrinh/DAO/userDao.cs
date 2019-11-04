using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    public class userDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public Int64 CheckLogin(string username, string password)
        {
            try{
                var user = (from u in db.ST_employees
                           where u.employee_username == username && u.employee_password == password
                           select u.employee_id).First();

                //var propertyName = user.GetType( ).GetProperty("employee_id").GetValue(user, null);
                //Int64 userID = Convert.ToInt64(propertyName);
                if ( user > 0 )
                {
                    return user;
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception ex)
            {
                return 0;
            }
            
        }

        public IEnumerable<Object> getAllUser()
        {
            var dlg = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu ...", "Thông báo");
            try{
                var users = from u in db.ST_employees
                            select u;

                return users;
            }
            catch
            {
                return null;
            }
            finally
            {
                dlg.Close( );
            }
            
        }

        public Object getUserByUserName(string userName)
        {
            var users = (from u in db.ST_employees
                        where u.employee_username == userName
                        select u).First();
            return users;
        }

        public Object getUserById(Int64 id)
        {
            var users = (from u in db.ST_employees
                         where u.employee_id == id
                         select u).First( );
            return users;
        }

        public Int64 getIDByUserName(string userName)
        {
            var users = (from u in db.ST_employees
                         where u.employee_username == userName
                         select u).First( );

            var propertyName = users.GetType( ).GetProperty("employee_id").GetValue(users, null);

            return Convert.ToInt64(propertyName);
        }

        public Int64 insertUser(ST_employee em)
        {
            try
            {
                db.ST_employees.InsertOnSubmit(em);
                db.SubmitChanges( );

                Int64 id = Int64.Parse(em.employee_id.ToString( ));
                return id;
            }
            catch{
                return 0;
            }
            
        }

        public bool updateUser(ST_employee em, Int64 id)
        {
            try{
                var user = (from b in db.ST_employees
                            where b.employee_id == id
                            select b).Single();
                if (user != null)
                {
                    user.employee_username = em.employee_username;
                    user.employee_password = em.employee_password;
                    user.employee_name = em.employee_name;
                    user.employee_phone = em.employee_phone;
                    user.employee_status = em.employee_status;
                    user.employee_image = em.employee_image;
                    user.employee_gender = em.employee_gender;
                    user.employee_date_of_birth = em.employee_date_of_birth;
                    user.employee_address = em.employee_address;
                    user.employee_bank_account_number = em.employee_bank_account_number;
                    user.department_id = em.department_id;
                    user.permission_id = em.permission_id;
                    user.employee_created_date = em.employee_created_date;


                    db.SubmitChanges( );
                    return true;
                }
                else
                {
                    return false;
                }               
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool updatePassword(string pass, Int64 id)
        {
            try
            {
                var user = (from u in db.ST_employees
                            where u.employee_id == id
                            select u).Single( );

                user.employee_password = pass;
                db.SubmitChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            
        }

        public bool deleteEmployee(Int64 id)
        {
            try
            {
                var delete = db.ST_employees.Where(p => p.employee_id.Equals(id)).SingleOrDefault( );
                db.ST_employees.DeleteOnSubmit(delete);
                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }


        public IEnumerable<Object> getAllUserByDepartment(Int64 id)
        {
            var dlg = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu ...", "Thông báo");
            try{
                db.Dispose( );
                db = new DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var data = from b in db.ST_employees
                           where b.department_id == id
                           select b;

                if ( data != null )
                {
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception)
            {
                return null;
            }
            finally{
                dlg.Close( );
            }
            
        }
    }
}
