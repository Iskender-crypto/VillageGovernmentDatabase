namespace Village.Domain.Repositories;
public interface IRepository<T> where T: Entity,new()
{
    public List<T> GetList(string filter = "", string orderField = "Id", string orderType = "ASC", int pageIndex = 1,
        int pageSize = 20);
    public T GetById(int id);
    public void Add(T item);
    public void Update(T item);
    public void Delete(int id);
}