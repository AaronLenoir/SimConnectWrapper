using System.Net.Sockets;
using System.Text;

namespace SimConnectWrapper.Samples.msfs2skydemon
{
    public class UdpMessage
    {
        private string _host;
        private int _port;
        private string _message;

        public UdpMessage(string host, int port, string message)
        {
            _host = host;
            _port = port;
            _message = message;
        }

        public void Send()
        {
            using (UdpClient udpClient = new UdpClient(_host, _port))
            {
                var sendBytes = Encoding.ASCII.GetBytes(_message);

                udpClient.Send(sendBytes, sendBytes.Length);
            }
        }
    }
}
