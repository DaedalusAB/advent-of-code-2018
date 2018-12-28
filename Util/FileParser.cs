using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Util
{
    public class FileParser
    {
        private string FileName { get; }

        public FileParser(string fileName)
        {
            FileName = fileName;
        }

        public IEnumerable<string> ReadAllLines() =>
            File.ReadAllLines(FileName);

        public IEnumerable<int> ReadAllLinesAsIntegers() =>
            File.ReadAllLines(FileName)
                .Select(int.Parse);
    }
}