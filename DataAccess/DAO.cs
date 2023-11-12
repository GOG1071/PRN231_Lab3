using System.Runtime.CompilerServices;
using BusinessObject;

namespace DataAccess;

public abstract class DAO<T> : IDAO<T> where T : class, IModel
{
    public static T? Get(int id)
    {
        T model;
        try
        {
            using var context = new Lab3DbContext();
            model = context.Set<T>().Find(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return model;
    }

    public static T? Get(params object[] keys)
    {
        T model;
        try
        {
            using var context = new Lab3DbContext();
            model = context.Set<T>().Find(keys);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return model;
    }

    public static T? Get(T model)
    {
        return Get(model.Id);
    }

    public static List<T> GetAll()
    {
        try
        {
            using var context = new Lab3DbContext();
            return context.Set<T>().ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void Add(T model)
    {
        try
        {
            using var context = new Lab3DbContext();
            if (Get(model) != null)
                throw new Exception("Object already exists");
            context.Set<T>().Add(model);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void Update(T model)
    {
        try
        {
            using var context = new Lab3DbContext();
            if (Get(model) == null)
                throw new Exception("Object does not exist");
            context.Set<T>().Update(model);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void Delete(int id)
    {
        try
        {
            using var context = new Lab3DbContext();
            var model = Get(id);
            if(model == null)
                throw new Exception("Object does not exist");
            context.Set<T>().Remove(model);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void Delete(T model)
    {
        Delete(model.Id);
    }
}