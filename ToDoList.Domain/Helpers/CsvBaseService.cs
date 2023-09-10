using CsvHelper;
using CsvHelper.Configuration;
using System.Collections;
using System.Globalization;
using System.Text;

namespace ToDoList.Domain.Helpers
{
    public class CsvBaseService<Type>
    {
        private readonly CsvConfiguration _csvConfiguration;

        public CsvBaseService()
        {
            _csvConfiguration = CsvBaseService<Type>.GetConfiguration();
        }

        public byte[] UploadFile(IEnumerable data)
        {
            using var memoryStream = new MemoryStream();
            using var streamWriter = new StreamWriter(memoryStream);
            using var csvWriter = new CsvWriter(streamWriter, _csvConfiguration);

            csvWriter.WriteRecords(data);
            streamWriter.Flush();

            return memoryStream.ToArray();
        }

        private static CsvConfiguration GetConfiguration()
        {
            return new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                Encoding = Encoding.UTF8,
                NewLine = "\r\n",
            };
        }
    }
}