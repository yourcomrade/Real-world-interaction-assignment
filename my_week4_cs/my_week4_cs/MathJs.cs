using System.Net.Http;
using System.Web;
using Evaluator;

namespace MathJs
{
   
    public class MathJSCalculator:IExpressionEvaluator
    {
        private readonly HttpClient _client = new HttpClient();
        public async Task<double> Evaluate(string expression)
        {
            string baseurl = "https://api.mathjs.org/v4/?expr=";
            var request = baseurl+HttpUtility.UrlEncode(expression);
            Console.WriteLine("The request is :{0}",request);
            // if (_client.BaseAddress == null)
            // {
            //     _client.BaseAddress = new Uri(request);
            // }
            HttpResponseMessage response = await _client.GetAsync(request);

            try
                {

                    response.EnsureSuccessStatusCode();
                    var text = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(text);
                    return Convert.ToDouble(text);
                }
            catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"Error: {await response.Content.ReadAsStringAsync()}");
                    return 0;
                }

            
           
        }

        public IList<string> Help { get=>new List<string>{"Please visit MathJS website for more information"}; }

        public string Description => "Calculator using Math Js API";
    }
}

