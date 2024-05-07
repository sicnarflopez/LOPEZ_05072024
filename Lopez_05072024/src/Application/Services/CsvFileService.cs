using System.Globalization;
using CsvHelper;
using Lopez_05072024.Application.Common.Interfaces;

namespace Lopez_05072024.Application.Services;
public class CsvFileService : ICsvFileService
{
    public List<T> ReadCSV<T>(Stream file)
    {
        var reader = new StreamReader(file);
        var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var records = csv.GetRecords<T>();
        return records.ToList();
    }

    public void WriteCSV<T>(List<T> records, string filename)
    {
        var folder = "C:\\FileAPI\\NewUsersCredentials\\";
        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
        using (var writer = new StreamWriter($"C:\\FileAPI\\{filename}.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(records);
        }
    }
}
