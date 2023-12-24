using Village.Domain.Repositories;
namespace Village.Infrastructure.Ef.Repositories;

public class EfRepository<T> : IRepository<T> where T : Entity,new()
{
    private readonly DataContext _dataContext;

    public EfRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<T> GetList(string filter = "", string orderField = "Id", string orderType = "ASC", int pageIndex = 1, int pageSize = 20) =>
        _dataContext.Set<T>()
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    
    public T GetById(int id) => _dataContext.Set<T>().First(u => u.Id == id);
    
        public void Add(T model)
        {
            _dataContext.Set<T>().Add(model);
            _dataContext.SaveChanges();
        }

        public void Update(T model)
        {
            _dataContext.Set<T>().Update(model);
            _dataContext.SaveChanges();
        }

    public void Delete(int id)
    {
        var user = _dataContext.Set<T>().First(u => u.Id == id);
        _dataContext.Set<T>().Remove(user);
        _dataContext.SaveChanges();
    }
    
}