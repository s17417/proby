using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace proby
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0) throw new ArgumentNullException("ggggg");
            string client = args.Length > 0 ? args[0] : "http://www.pjwstk.edu.pl";
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(client);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                MatchCollection matchCollection = Regex.Matches(result, "[a-zA-Z0-9]+@[a-zA-Z0-9]+[\\.[a-zA-Z]+]?");
                foreach(Match m in matchCollection){
                    Console.WriteLine(m.ToString());
                }
               // Console.WriteLine(result);
            }
           

            
        }
    }
}
