// UserMicroservice
// UserController.cs
using Microsoft.AspNetCore.Mvc;
using TokoServices.Model;
using System.Collections.Generic;
using TokoServices.Service;

[Route("api/[controller]")]
[ApiController]
public class TokoController : ControllerBase
{
    private static List<TokoModel> toko = new List<TokoModel>();
    private TokoService svc;
    private readonly TokoAppContext _appContext;
    public TokoController(TokoAppContext appContext) 
    {
        _appContext = appContext;
        svc = new TokoService(appContext); 
    }

    [HttpGet]
    public ActionResult<List<TokoModel>> Get()
    {
        return Ok(svc.GetListData());
    }

    [HttpGet("{id}")]
    public ActionResult<TokoModel> GetById(int id)
    {
        var user = svc.GetListData().Where(x=>x.Id==id).FirstOrDefault();
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public ActionResult<TokoModel> AddUser(TokoModel data)
    {
        svc.Add(data);
        return CreatedAtAction(nameof(GetById), new { id = data.Id }, data);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, TokoModel data)
    {
        var exist = svc.GetListData().Where(x => x.Id == id).FirstOrDefault();
        if (exist == null)
            return NotFound();
        else
            svc.Edit(data);        

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var exist = svc.GetListData().Where(x => x.Id == id).FirstOrDefault();
        if (exist == null)
            return NotFound();
        else
            svc.Delete(id);

        return NoContent();
    }
}

