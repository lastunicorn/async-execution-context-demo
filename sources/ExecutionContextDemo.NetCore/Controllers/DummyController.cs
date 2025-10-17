using DustInTheWind.ExecutionContextDemo.NetCore.Business;
using Microsoft.AspNetCore.Mvc;

namespace DustInTheWind.ExecutionContextDemo.NetCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DummyController : Controller
{
    // GET api/values
    public async Task<IEnumerable<string>> Get()
    {
        HttpContext before = HttpContext;

        ValuesUseCase valuesUseCase = new();
        IEnumerable<string> values = await valuesUseCase.Execute();

        HttpContext after = HttpContext;

        return values;
    }
}
