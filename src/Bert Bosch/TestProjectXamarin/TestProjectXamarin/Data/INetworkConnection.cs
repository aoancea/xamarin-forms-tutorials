namespace TestProjectXamarin.Data
{
    public interface INetworkConnection
    {
        bool IsConnected { get; }

        void CheckNetworkConnection();
    }
}