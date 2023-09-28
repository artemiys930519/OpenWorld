using ScriptableObjects;

namespace Core.Services
{
    public class NetworkWorldContext : INetworkWorldContext
    {
        public ushort Port {
            get
            {
                if (_sceneNetworkSettings == null)
                    return 0;
                
                return _sceneNetworkSettings.Port;
            }
        }
        public string IP {
            get
            {
                if (_sceneNetworkSettings == null)
                    return string.Empty;

                return _sceneNetworkSettings.IP;
            }
        }

        private SceneNetworkSettings _sceneNetworkSettings;

        public NetworkWorldContext(SceneNetworkSettings sceneNetworkSettings)
        {
            _sceneNetworkSettings = sceneNetworkSettings;
        }
    }
}