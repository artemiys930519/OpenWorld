namespace Core.Services
{
    public interface INetworkWorldContext
    {
        public ushort Port { get; }
        public string IP { get; }
        
    }
}