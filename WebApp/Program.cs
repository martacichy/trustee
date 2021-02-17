using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp
{
    public class Program
    {
        //zmienna do rozrozniania typu pracownika (potrzebna do blokowania wyswietlania innych widok�w)
        public static int if_manager = -1;
        // zmienna company_id wyciagnieta z tabeli Employee w celu rozpoznania firmy, z kt�r� zwiazany jest uzytkownik
        public static int company_id = -1;
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
