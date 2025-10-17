using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace DustInTheWind.ExecutionContextDemo.Controllers
{
    public class DummyController : ApiController
    {
        // GET api/values
        public async Task<IEnumerable<string>> Get()
        {
            HttpContext before = HttpContext.Current;

            ValuesUseCase valuesUseCase = new ValuesUseCase();
            IEnumerable<string> values = await valuesUseCase.Execute();

            HttpContext after = HttpContext.Current;

            return values;
        }
    }
}
