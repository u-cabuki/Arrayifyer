using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Arrayifyer2
{
    class Arrayifyer2
    {
        static void Main(string[] args)
        {
            try
            {
                var filePath = @"C:\Users\Uno\Desktop\Community Chest\MSc Psych\Dissertation\Our Planet Data\JSON";
                foreach (var file in
                    Directory.GetFiles(filePath, "*.json"))
                {
                        using (StreamReader sr = new StreamReader(file))
                    {
                        String line = sr.ReadToEnd();
                        line = Regex.Replace(line, @"\n\n", ",\n");
                        int index = line.LastIndexOf("}");
                        if (index > 0)
                            line = line.Substring(0, index);
                        line = line.Insert(0, "[\n");
                        line = line.Insert(line.Length, "\n]");
                        string docPath =
                        @"C:\Users\Uno\Desktop\Community Chest\MSc Psych\Dissertation\Our Planet Data\Fixed Files";
                        var newFile = file.Replace(filePath + @"\", "");
                        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, newFile)))
                        {
                            outputFile.WriteLine(line);
                        }
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
