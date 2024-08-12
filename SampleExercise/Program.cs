
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace SampleExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. creat a service collection for ID
            var serviceCollection = new ServiceCollection();

            //2.Buld a configuration
            IConfiguration configuration;
            configuration = new ConfigurationBuilder()

                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("AppSettings.json")
                .Build();

            //3. Add the configuration to the service collection
            serviceCollection.AddSingleton<IConfiguration>(configuration);

            Smtp objSmtp = new Smtp(configuration);
          

            objSmtp.FileLog();


          //  ReadFile read = new ReadFile();
           // read.FileReade();
            //FileWrite write = new FileWrite();
            //write.WriteInFile();



        }
    }
}