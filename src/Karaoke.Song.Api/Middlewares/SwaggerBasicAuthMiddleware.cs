using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Karaoke.Song.Api.Middlewares
{
    public class SwaggerBasicAuthMiddleware
    {
        private readonly RequestDelegate next; 
        
        public SwaggerBasicAuthMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                string authHeader = context.Request.Headers["Authorization"];

                if (authHeader != null && authHeader.StartsWith("Basic"))
                {
                    // Get the credentials from request header
                    AuthenticationHeaderValue header = AuthenticationHeaderValue.Parse(authHeader);
                    byte[] inBytes = Convert.FromBase64String(header.Parameter);
                    string[] credentials = Encoding.UTF8.GetString(inBytes).Split(':');
                    string username = credentials[0];
                    string password = credentials[1];

                    // TODO: Mejorar para consultar desde BBDD
                    // validate credentials
                    if (username.Equals("swagger") && password.Equals("swagger"))
                    {
                        await next.Invoke(context).ConfigureAwait(false);
                        return;
                    }
                }

                context.Response.Headers["WWW-Authenticate"] = "Basic";
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                await next.Invoke(context).ConfigureAwait(false);
            }
        }
    }
}
