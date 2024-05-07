using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lopez_05072024.Application.Common.Interfaces;
public interface ICsvFileService
{
    List<T> ReadCSV<T>(Stream file);
    void WriteCSV<T>(List<T> records, string filename);
}
