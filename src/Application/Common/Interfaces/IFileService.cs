namespace Application.Common.Interfaces
{
    public interface IFileService
    {
        Task<byte[]> CreateCsvFileAsync<T>(IEnumerable<T> records);
    }

}
