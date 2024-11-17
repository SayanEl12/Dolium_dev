using lib_entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace lib_repositories;
public class Connection : DbContext
{
    // this is the connection string it must have a format like:
    // host:localhost, 
    public string? StringConnection { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(this.StringConnection!, p => { });
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
    
    protected DbSet<Users>? Users { get; set; }
    protected DbSet<Smokers>? Smokers { get; set; }
    protected DbSet<Images>? Images { get; set; }
    protected DbSet<Logs>? Logs { get; set; }
    protected DbSet<Qualities>? Qualities { get; set; }
    protected DbSet<Sale_Productcs>? Sale_Productcs { get; set; }
    protected DbSet<Sales>? Sales { get; set; }
    
    public virtual DbSet<T> GetDataSet<T>() where T : class, new()
    {
        return this.Set<T>();
    }
    public virtual List<T> GetList<T>() where T : class, new()
    {
        return this.Set<T>().ToList();
    }
    public virtual List<T> GetSearch<T>(Expression<Func<T, bool>> conditions) where T : class, new()
    {
        return this.Set<T>().Where(conditions).ToList();
    }
    public virtual bool Exists<T>(Expression<Func<T, bool>> conditions) where T : class, new()
    {
        return this.Set<T>().Any(conditions);
    }
    public virtual void Save<T>(T entity) where T : class, new()
    {
        this.Set<T>().Add(entity);
    }
    public virtual void Modify<T>(T entity) where T : class
    {
        var entry = this.Entry(entity);
        entry.State = EntityState.Modified;
    }
    public virtual void Delete<T>(T entity) where T : class, new()
    {
        this.Set<T>().Remove(entity);
    }
    public virtual void Separate<T>(T entity) where T : class, new()
    {
        this.Entry(entity).State = EntityState.Detached;
    }
    public virtual void Commit()
    {
        this.SaveChanges();
    }

}