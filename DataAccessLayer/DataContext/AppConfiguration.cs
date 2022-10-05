using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataContext
{
    public class AppConfiguration
    {
        public AppConfiguration()
        {
            var configuration = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configuration.AddJsonFile(path, false);
            var root = configuration.Build();
            sqlConnectionString = root.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
        public string sqlConnectionString { get; set; }
    }
}
