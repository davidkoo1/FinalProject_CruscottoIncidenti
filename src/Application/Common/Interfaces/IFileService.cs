using Microsoft.AspNetCore.Http;

namespace Application.Common.Interfaces
{
    public interface IFileService
    {
        Task<byte[]> CreateCsvFileAsync<T>(IEnumerable<T> records);
        Task<IEnumerable<T>> ReadCsvFileAsync<T>(IFormFile file);
    }

}
