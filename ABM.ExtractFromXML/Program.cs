using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ABM.ExtractFromXML
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filename = "Sample.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            var ieImportFilepath = Path.Combine(currentDirectory, filename);

            var ieImport = XElement.Load(ieImportFilepath);

            var requiredRefCodes = "MWB,TRV,CAR".Split(',').ToList();

            var refs = ieImport.Descendants("Reference")
                .Where(item => requiredRefCodes.Contains((string)item.Attribute("RefCode")))
                .Select(x => new
                {
                    RefCode = (string)x.Attribute("RefCode"),
                    RefText = (string)x.Element("RefText")
                }).ToList();

            refs.ForEach(x => Console.WriteLine($"{x.RefCode}, {x.RefText}"));

            Console.ReadKey();
        }
    }
}
