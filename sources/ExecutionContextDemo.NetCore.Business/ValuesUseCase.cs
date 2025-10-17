namespace DustInTheWind.ExecutionContextDemo.NetCore.Business;

public class ValuesUseCase
{
    public async Task<IEnumerable<string>> Execute()
    {
        return await GetValues().ConfigureAwait(false);
    }

    private static Task<IEnumerable<string>> GetValues()
    {
        return Task.Run(() =>
        {
            string[] strings = ["value1", "value2"];
            return strings as IEnumerable<string>;
        });
    }
}