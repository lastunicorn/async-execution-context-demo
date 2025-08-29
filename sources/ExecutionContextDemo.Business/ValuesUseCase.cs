using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExecutionContextDemo.Controllers
{
    public class ValuesUseCase
    {
        public async Task<IEnumerable<string>> Execute()
        {
            return await GetValues().ConfigureAwait(false);
        }

        private Task<IEnumerable<string>> GetValues()
        {
            return Task.Run(() =>
            {
                string[] strings = new string[] { "value1", "value2" };
                return strings as IEnumerable<string>;
            });
        }
    }
}