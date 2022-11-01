namespace Lab_17_Paupers_Reddit.Models
{
    public class PauperDAL
    {
        //Provides a class for sending HTTP requests and receiving HTTP responses from
        //a resource identified by a URI.
        private HttpClient GetClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://www.reddit.com");
            return client;
        }

        //TResult:
        //Specify that y using Asynchronous programming, the Application can continue with the other work that does not depend on the completion of the entire task.
        public async Task<Pauper> RedditFiles(string s)
        {
            var client = GetClient();

            var request = await client.GetAsync($"/r/{s}/.json");
            var response = await request.Content.ReadAsAsync<Pauper>(); 

            return response;
        }
    }
}
