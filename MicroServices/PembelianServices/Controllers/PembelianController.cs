// UserMicroservice
// UserController.cs
using Microsoft.AspNetCore.Mvc;
using PembelianServices.Model;
using System.Collections.Generic;
using PembelianServices.Service;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{    
    private PembelianService svc;
    private readonly PembelianAppContext _appContext;
    public UserController(PembelianAppContext appContext) 
    {
        _appContext = appContext;
        svc = new PembelianService(appContext); 
    }

    [HttpGet]
    public ActionResult<List<PembelianModel>> Get()
    {
        return Ok(svc.GetListData());
    }

    [HttpGet("{id}")]
    public ActionResult<PembelianModel> GetById(int id)
    {
        var user = svc.GetListData().Where(x=>x.Id==id).FirstOrDefault();
        if (user == null)
            return NotFound();

        return Ok(user);
    }



    [HttpPost]
    public ActionResult<PembelianModel> Add(PembelianModel data)
    {
        svc.Add(data);
        return CreatedAtAction(nameof(GetById), new { id = data.Id }, data);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, PembelianModel data)
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

