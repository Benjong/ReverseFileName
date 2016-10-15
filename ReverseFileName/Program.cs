using System;
using System.IO;
using System.Linq;

namespace ReverseFileName
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                var filename = args[0];
                if (File.Exists(filename))
                {
                    var path = Path.GetDirectoryName(filename);
                    if (!string.IsNullOrEmpty(path))
                    {
                        var stringToReverse = Path.GetFileNameWithoutExtension(filename);
                        File.Move(Path.Combine(path, filename),
                                  (Path.Combine(path, GetReverseString(stringToReverse)) + Path.GetExtension(filename))
                            );
                    }
                }
                else if (Directory.Exists(filename))
                {
                    var info = new DirectoryInfo(filename);
                    var currentDirectoryName = info.Name;
                    var firstPart = Path.GetDirectoryName(info.FullName) ?? info.Root.Name;
                    Directory.Move(info.FullName,
                        Path.Combine(firstPart, GetReverseString(currentDirectoryName)));
                }
            }
           
        }
        private static string GetReverseString(string input)
        {
            return new string(input.Reverse().ToArray());
        }
    }
}
