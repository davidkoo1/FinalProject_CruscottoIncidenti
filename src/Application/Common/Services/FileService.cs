using Application.Common.Interfaces;
using CsvHelper;
using Microsoft.AspNetCore.Http;
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
        public async Task<IEnumerable<T>> ReadCsvFileAsync<T>(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            using var reader = new StreamReader(stream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = new List<T>();
            await csv.ReadAsync();
            csv.ReadHeader();
            while (await csv.ReadAsync())
            {
                var record = csv.GetRecord<T>();
                records.Add(record);
            }
            return records;
        }
    }
}
