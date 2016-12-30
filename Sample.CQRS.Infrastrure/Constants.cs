using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.CQRS.Infrastrure
{
    public static class Constants
    {
            public static readonly string SampleCQRSMovieConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Movies.mdf;Integrated Security=True";
            public static readonly string SampleCQRSReadModelConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ReadModel.mdf;Integrated Security=True";
    }
}
