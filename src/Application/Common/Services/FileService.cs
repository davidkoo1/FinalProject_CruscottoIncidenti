using Application.Common.Interfaces;
using CsvHelper;
using System.Globalization;

namespace Application.Common.Services
{
    public class FileService : IFileService
    {
        public async Task<byte[]> CreateCsvFileAsync<T>(IEnumerable<T> records)
        {
            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream))
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(records);
                streamWriter.Flush();
                return memoryStream.ToArray();
            }
        }
    }
}
