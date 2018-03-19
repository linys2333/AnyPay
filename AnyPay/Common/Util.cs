using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AnyPay.Common
{
    public class Util
    {
        public static async Task<string> PostAsync(string endpoint, string data)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(endpoint, new StringContent(data, Encoding.UTF8, "application/xml"));
                var responseData = await response.Content.ReadAsByteArrayAsync();
                var result = Encoding.UTF8.GetString(responseData);
                return result;
            }
        }
        
        public static string SignMD5(string content)
        {
            var encoding = Encoding.UTF8;

            using (var md5Hash = MD5.Create())
            {
                var data = md5Hash.ComputeHash(encoding.GetBytes(content));
                return encoding.GetString(data).ToUpper();
            }
        }
    }
}
