using PasteBookModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//reference :https://blog.magnusmontin.net/2013/05/30/generic-dal-using-entity-framework/
namespace PasteBookDataAccess
{
    public class GenericDataAccess <T> where T : class
    {
        public List<T> RetrieveAllList(params Expression<Func<T, object>>[] foreignKeys)
        {
            List<T> ret = new List<T>();
            try
            {
                using (var context = new PasteBookEntities())
                {
                    IQueryable<T> dbQuery = context.Set<T>();
                    foreach (Expression<Func<T, object>> foreignKey in foreignKeys)
                    {
                        dbQuery = dbQuery.Include<T, object>(foreignKey);
                    }

                    ret = dbQuery.ToList<T>();
                }
                return ret;
            }
            catch (Exception e)
            {
                return new List<T>() { };
            }
        }
        public List<T>  RetrieveListWithCondition(Func<T,bool> condition, params Expression<Func<T, object>>[] foreignKeys)
        {
            List<T> ret = new List<T>();
            try
            {
                using(var context = new PasteBookEntities())
                {
                    IQueryable<T> dbQuery = context.Set<T>();
                    foreach (Expression<Func<T, object>> foreignKey in foreignKeys)
                    {
                        dbQuery = dbQuery.Include<T, object>(foreignKey);
                    }

                    ret = dbQuery.Where(condition).ToList();
                }
                return ret;
            }catch(Exception e)
            {
                return new List<T>() { };
            }
        }
         public T GetOneRecord(Func<T,bool> condition, params Expression<Func<T,object>>[] foreignKeys)
        {
            try
            {
                using(var context = new PasteBookEntities())
                {
                    IQueryable<T> dbQuery = context.Set<T>();
                    foreach(Expression<Func<T,object>>foreignKey in foreignKeys)
                    {
                        dbQuery = dbQuery.Include<T, object>(foreignKey);
                    }
                    T ret = dbQuery.Where(condition).Single();
                    return ret;
                }
            }catch(Exception e)
            {
                return null;
            }
        } 
        public bool CheckIfExist(Func<T,bool> condition,params Expression<Func<T, object>>[] foreignKeys)
        {
            try
            {
                using(var context = new PasteBookEntities())
                {
                    IQueryable<T> dbQuery = context.Set<T>();
                    foreach (Expression<Func<T,object>> foreignKey in foreignKeys)
                    {
                        dbQuery = dbQuery.Include<T, object>(foreignKey);
                    }
                    bool ret = dbQuery.Any(condition);
                    return ret;
                }
            }catch(Exception e)
            {
                return false;
            }
        }

        
        public bool AddRow( T data )
        {
            bool returnValue = false;
            try
            {
                using (var context = new PasteBookEntities())
                {
                    context.Entry(data).State = EntityState.Added;
                    var result = context.SaveChanges();
                    returnValue = result != 0 ? true : false;


                }
            }
            catch (Exception e)
            {
                return false;
            }
            return returnValue;

        }
        public bool RemoveRow(Func<T,bool> condition)
        {
            bool returnValue = false;
            try
            {
                using(var context = new PasteBookEntities())
                {
                    T result = (T)context.Set<T>().Where<T>(condition).Single();
                    context.Set<T>().Remove(result);
                    var output = context.SaveChanges();

                    returnValue = output != 0 ? true : false;
                }
                
            }catch(Exception e)
            {
                return false;
            }
            return returnValue;
        }
        public bool UpdateRow(T data)
        {
            bool returnValue = false;
            try
            {
                using(var context = new PasteBookEntities())
                {
                    context.Entry(data).State = EntityState.Modified;
                    var output = context.SaveChanges();
                    returnValue = output != 0 ? true : false;
                }
            }catch(Exception e)
            {
                return false;
            }
            return returnValue;
        }
         
    }
}
