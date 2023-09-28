using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = nameof(SceneNetworkSettings), menuName = nameof(SceneNetworkSettings))]
    public class SceneNetworkSettings : ScriptableObject
    {
        public string IP;
        public ushort Port;
    }
}