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
                        while (!sr.EndOfStream)
                        {
                            String line = sr.ReadLine();
                            if (!string.IsNullOrEmpty(line))
                            {
                                if (line.Substring(0, 1) == "{")
                                {
                                    var countLeft = line.ToCharArray().Count(c => c == '{');
                                    var countRight = line.ToCharArray().Count(c => c == '}');
                                    while (countLeft > countRight)
                                    {
                                        completeFile += line;
                                        line = sr.ReadLine();
                                        countRight += line.TakeWhile(c => c == '}').Count();
                                    }
                                    completeFile += line + ",\n";
                                }
                            }
                        }
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
