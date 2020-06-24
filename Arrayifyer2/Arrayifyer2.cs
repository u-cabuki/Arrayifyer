using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Arrayifyer2
{
    class Arrayifyer2
    {
        static void Main(string[] args)
        {
            try
            {
                var completeFile = string.Empty;
                var filePath = @"C:\Users\Uno\Desktop\Test";
                foreach (var file in
                    Directory.GetFiles(filePath, "*.json"))
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        String line = sr.ReadLine();
                        if (line.Substring(0, 1) != "{")
                        {
                            break;
                        }
                        var countLeft = line.TakeWhile(c => c == '{').Count();
                        var countRight = line.TakeWhile(c => c == '}').Count();
                        while (countLeft > countRight)
                        {
                            line += sr.ReadLine();
                        }
                        completeFile += line + ",\n";
                    }
                    int index = completeFile.LastIndexOf(",");
                    if (index > 0)
                        completeFile = completeFile.Substring(0, index);
                    completeFile = "[" + completeFile + "]";
                    string docPath =
                    @"C:\Users\Uno\Desktop\Community Chest\MSc Psych\Dissertation\Our Planet Data\Fixed Files";
                    var newFile = file.Replace(filePath + @"\", "");
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, newFile)))
                    {
                        outputFile.WriteLine(completeFile);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
