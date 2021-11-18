var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/{*s}", (string s, HttpRequest r) =>
{
    var path = r.Path;
    var queryString = r.QueryString;

    // Proxy the request with above information through your desired interface, like HttpClient or grpc.
    // Return the result from that service below.

    return $"Request path+query: {path}{queryString}";
});

app.MapPost("/{*s}", async (string s, HttpRequest r) =>
{
    var path = r.Path;
    var queryString = r.QueryString;
    string body;

    using (var reader = new StreamReader(r.Body))
    {
        body = await reader.ReadToEndAsync();
    }

    // Proxy the request with above information through your desired interface, like HttpClient or grpc.
    // Return the result from that service below.

    return $"Request path+query: {path}{queryString} - Body: {body}";
});

app.Run();