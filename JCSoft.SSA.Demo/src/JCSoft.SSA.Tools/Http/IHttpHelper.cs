using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JCSoft.SSA.Tools.Http
{
    public interface IHttpHelper
    {
        Task<string> GetAsync(string url);

        Task<String> DeleteAsync(string url);

        Task<String> PostAsync(string url, string data);

        Task<String> PutAsync(string url, string data);
    }
}
