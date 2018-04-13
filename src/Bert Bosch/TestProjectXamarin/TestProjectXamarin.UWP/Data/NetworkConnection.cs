using System.Net.NetworkInformation;
using TestProjectXamarin.Data;
using TestProjectXamarin.UWP.Data;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkConnection))]
namespace TestProjectXamarin.UWP.Data
{
    public class NetworkConnection : INetworkConnection
    {
        public bool IsConnected { get; set; }

        public void CheckNetworkConnection()
        {
            IsConnected = NetworkInterface.GetIsNetworkAvailable();
        }
    }
}