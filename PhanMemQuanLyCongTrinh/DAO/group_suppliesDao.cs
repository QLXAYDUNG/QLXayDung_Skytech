using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    public class group_suppliesDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public IEnumerable<Object> getAllGroupSupplies()
        {
            try{
                db.Dispose( );
                db = new DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var listAll = from g in db.ST_group_supplies
                              select g;
                return listAll;
            }
            catch(Exception)
            {
                return null;
            }
            
        }

        public Object getGroupSupplie(Int64 id)
        {
            try{
                db.Dispose( );
                db = new DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var item = (from b in db.ST_group_supplies
                            where b.group_supplies_id == id
                            select b).Single( );

                return item;
            }
            catch(Exception)
            {
                return null;
            }
            
        }

        public bool insertGroupSupplie(string group)
        {
            try{
                db.Dispose( );
                db = new DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                ST_group_supply _group = new ST_group_supply();
                _group.group_supplies_name = group;

                db.ST_group_supplies.InsertOnSubmit(_group);
                db.SubmitChanges( );

                return true;
            }
            catch(Exception)
            {
                return false;
            }
            
        }

        public bool updateGroupSupplie(string name, Int64 id)
        {
            try
            {
                var group = (from b in db.ST_group_supplies
                             where id == b.group_supplies_id
                            select b).Single();

                group.group_supplies_name = name;              
                db.SubmitChanges( );

                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }

        public bool deleteGroupSupplie(Int64 id)
        {
            try
            {
                var delete = db.ST_group_supplies.Where(p => p.group_supplies_id.Equals(id)).SingleOrDefault( );

                db.ST_group_supplies.DeleteOnSubmit(delete);
                db.SubmitChanges( );
                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }

        public bool changeIdParent(Int64 id)
        {
            try
            {
                var datasource = from u in db.ST_supplies
                                where u.group_supplies_id == id
                                select u;
                
                if (datasource != null)
                {
                    foreach ( var item in datasource )
                    {
                        item.group_supplies_id = 1;
                    }
                    db.SubmitChanges();
                    return true;
                }
                return true;
   
            }
            catch(Exception)
            {
                return false;
            }
                      
        }
    }
}
