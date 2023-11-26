// UserMicroservice
// UserController.cs
using Microsoft.AspNetCore.Mvc;
using ProductServices.Model;
using System.Collections.Generic;
using ProductServices.Service;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private static List<ProductModel> users = new List<ProductModel>();
    private ProductService svc;
    private readonly ProductAppContext _AppContext;
    public ProductController(ProductAppContext AppContext) 
    {
        _AppContext = AppContext;
        svc = new ProductService(AppContext); 
    }

    [HttpGet]
    public ActionResult<List<ProductModel>> Get()
    {
        return Ok(svc.GetListData());
    }

    [HttpGet("{id}")]
    public ActionResult<ProductModel> GetById(int id)
    {
        var user = svc.GetListData().Where(x=>x.Id==id).FirstOrDefault();
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public ActionResult<ProductModel> Add(ProductModel data)
    {
        svc.Add(data);
        return CreatedAtAction(nameof(GetById), new { id = data.Id }, data);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, ProductModel data)
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
        var user = svc.GetListData().Where(x => x.Id == id).FirstOrDefault();
        if (user == null)
            return NotFound();
        else
            svc.Delete(id);

        return NoContent();
    }
}

