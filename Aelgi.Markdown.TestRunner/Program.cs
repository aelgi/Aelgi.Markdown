using Aelgi.Markdown.IServices;
using Aelgi.Markdown.Services;
using System;
using System.IO;

namespace Aelgi.Markdown.TestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            IParser parser = new Parser();
            var fullFilePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "test.md");
            var data = File.ReadAllText(fullFilePath);

            var doc = parser.Parse(data);

            Console.WriteLine("Hello World!!!");
        }
    }
}
