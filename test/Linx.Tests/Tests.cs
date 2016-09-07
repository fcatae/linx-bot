using System;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Linx.Tests
{
    public class Tests
    {
        public static string XMLFILE;
        public static string DATABASE;

        static Tests()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .AddUserSecrets("aspnet-LinxBot-20160906015605");

            var config = builder.Build();

            DATABASE = config["database"];
            XMLFILE = config["xmlfile"];

            if(DATABASE == null)
                throw new ArgumentNullException("database");
        }

        public static void Main(string[] args) 
        {
            var test = new QuestionTests();

            test.Associate_Known_Answer();
        }
    }
}
