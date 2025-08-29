using Microsoft.AspNetCore.Mvc;

namespace ExecutionContextDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : Controller
{
    // GET api/values
    public async Task<IEnumerable<string>> Get()
    {
        HttpContext before = this.HttpContext;

        ValuesUseCase valuesUseCase = new ValuesUseCase();
        IEnumerable<string> values = await valuesUseCase.Execute();

        HttpContext after = this.HttpContext;

        return values;
    }

    // GET api/values/5
    public string Get(int id)
    {
        return "value";
    }

    // POST api/values
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    public void Delete(int id)
    {
    }
}
