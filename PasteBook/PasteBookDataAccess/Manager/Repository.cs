﻿using PasteBookModel;
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
    public class Repository <T> where T : class
    {
        public List<T> RetrieveAllList()
        {
            List<T> ret = new List<T>();
       
                using (var context = new PasteBookEntities())
                {
                    IQueryable<T> dbQuery = context.Set<T>();
                    ret = dbQuery.ToList<T>();
                }
                return ret;
        
        }
        public List<T>Find(Func<T,bool> condition)
        {
            List<T> ret = new List<T>();
                using(var context = new PasteBookEntities())
                {
                    IQueryable<T> dbQuery = context.Set<T>();
                    ret = dbQuery.Where(condition).ToList();
                }
                return ret;
        }
         public T GetOneRecord(Func<T,bool> condition)
        {
                using(var context = new PasteBookEntities())
                {
                    IQueryable<T> dbQuery = context.Set<T>();
                    T ret = dbQuery.Where(condition).Single();
                    return ret;
                }
        } 
        public bool CheckIfExist(Func<T,bool> condition)
        {
        using(var context = new PasteBookEntities())
                {
                    IQueryable<T> dbQuery = context.Set<T>();
                    bool ret = dbQuery.Any(condition);
                    return ret;
                }
        }

        
        public bool AddRow( T data )
        {
            bool returnValue = false;
  
                using (var context = new PasteBookEntities())
                {
                    context.Entry(data).State = EntityState.Added;
                    var result = context.SaveChanges();
                    returnValue = result != 0 ? true : false;


                }
            return returnValue;

        }
        public bool RemoveRow(T data)
        {
            bool returnValue = false;
    
                using(var context = new PasteBookEntities())
                {
                    context.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                    var output = context.SaveChanges();

                    returnValue = output != 0 ? true : false;
                }
                
            return returnValue;
        }
        public bool UpdateRow(T data)
        {
            bool returnValue = false;
                using(var context = new PasteBookEntities())
                {
                    context.Entry(data).State = EntityState.Modified;
                    var output = context.SaveChanges();
                    returnValue = output != 0 ? true : false;
                }
            return returnValue;
        }
         
    }
}
