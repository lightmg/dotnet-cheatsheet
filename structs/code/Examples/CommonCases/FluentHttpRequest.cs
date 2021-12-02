using System.Collections.Immutable;

namespace Examples.CommonCases
{
    public readonly struct HttpRequest
    {
        public readonly string Method;
        public readonly string Uri;
        public readonly ImmutableArray<QueryParameter> Parameters;
        public readonly string Body;

        public HttpRequest(string method, string uri)
            : this(method, uri, ImmutableArray<QueryParameter>.Empty, string.Empty)
        {
        }

        public HttpRequest(string method, string uri, ImmutableArray<QueryParameter> parameters, string body)
        {
            Method = method;
            Uri = uri;
            Parameters = parameters;
            Body = body;
        }

        public static HttpRequest Get(string uri) => new("GET", uri);
        public static HttpRequest Post(string uri) => new("POST", uri);

        public readonly struct QueryParameter
        {
            public readonly string Name;
            public readonly string Value;

            public QueryParameter(string name, string value)
            {
                Name = name;
                Value = value;
            }
        }
    }

    public static class HttpRequestExtensions
    {
        public static HttpRequest WithQueryParameter(this HttpRequest request, string name, string value) => 
            new HttpRequest(request.Method, request.Uri, request.Parameters.Add(new(name, value)), request.Body);

        public static HttpRequest WithBody(this HttpRequest request, string body) => 
            new HttpRequest(request.Method, request.Uri, request.Parameters, body);
    }

    public static class OrderRequests
    {
        public static HttpRequest GetWithinSection(string section, int? maxPrice = null) =>
            HttpRequest.Get("my-super-shop.com/orders")
                .WithQueryParameter("section", section)
                .WithBody($"{{ MaxPrice: {maxPrice} }}");
    }
}