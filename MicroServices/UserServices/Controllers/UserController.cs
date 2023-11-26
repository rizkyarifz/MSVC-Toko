// UserMicroservice
// UserController.cs
using Microsoft.AspNetCore.Mvc;
using UserServices.Model;
using System.Collections.Generic;
using UserServices.Service;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private static List<UserModel> users = new List<UserModel>();
    private UserService svc;
    private readonly UserAppContext _appContext;
    public UserController(UserAppContext appContext) 
    {
        _appContext = appContext;
        svc = new UserService(appContext); 
    }

    [HttpGet]
    public ActionResult<List<UserModel>> Get()
    {
        return Ok(svc.GetListData());
    }

    [HttpGet("{id}")]
    public ActionResult<UserModel> GetById(int id)
    {
        var user = svc.GetListData().Where(x=>x.Id==id).FirstOrDefault();
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public ActionResult<UserModel> Add(UserModel data)
    {
        svc.Add(data);
        return CreatedAtAction(nameof(GetById), new { id = data.Id }, data);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UserModel data)
    {
        var exist = svc.GetListData().Where(x => x.Id == id).FirstOrDefault();
        if (exist == null)
            return NotFound();
        else
            svc.Edit(data);        

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var exist = svc.GetListData().Where(x => x.Id == id).FirstOrDefault();
        if (exist == null)
            return NotFound();
        else
            svc.Delete(id);

        return NoContent();
    }
}

