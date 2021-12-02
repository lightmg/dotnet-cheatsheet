namespace Examples.CommonCases
{
    public readonly struct ApiUri
    {
        public readonly string Address;
        public readonly int Port;

        public ApiUri(string address, int port)
        {
            Address = address;
            Port = port;
        }

        public override string ToString() => 
            $"https://{Address}:{Port}/";

        public static ApiUri Localhost => new("localhost", 5001);
        public static ApiUri Staging => new("staging-domain.ru", 5051);
    }
}
