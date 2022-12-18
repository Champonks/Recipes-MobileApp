using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace CookUs.Services
{
    public class ApiServices
    {
        protected HttpClient client { get; set; } = new HttpClient();

        public ApiServices()
        {
            client.BaseAddress = new Uri("http://localhost:8000/api/");
        }

    }
}
