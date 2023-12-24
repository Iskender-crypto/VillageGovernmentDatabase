using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;

namespace Village.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class Controller : ControllerBase
{
    private string q = "\"";
    private readonly string _connectionString =
        "Host=localhost;Database=Village;Username=iskender-crypto;Password=Iskndr-2003";

    private  DataContext _dataContext;
    public Controller(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    [HttpGet("/User")]
    public List<User> GetList(string? filter = "", string? orderField = "Id", string? orderType = "ASC",
        int? pageIndex = 1, int? pageSize = 10)
    {
        List<User> users = _dataContext.Set<User>().ToList();
        return users;
    }

    [HttpGet("/UserId")]
    public User GetById(int id)=> _dataContext.Set<User>().FirstOrDefault(i => i.Id == id);
    
    [HttpPost($"/User")]
    public User  Add(User model)
    {
        _dataContext.Set<User>().Add(model);
        _dataContext.SaveChanges();
        return model;
    }
    
    [HttpPut($"/User")]
    public User Update(User model)
    {
        _dataContext.Set<User>().Update(model);
        _dataContext.SaveChanges();
        return model;
    }
    [HttpDelete("/User")]
    public void Delete(int id)
    {
        var user = _dataContext.Set<User>().First(u => u.Id == id);
        _dataContext.Set<User>().Remove(user);
        _dataContext.SaveChanges();
    }
}