using System;
using Xunit;

namespace Linx.Tests
{
    public class ProgramTest
    {
        public static void Main(string[] args) 
        {
            var test = new LoaderTests();

            test.Load_Rss_File();
        }
    }
}
