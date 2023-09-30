using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = nameof(PrefabSettings), menuName = nameof(PrefabSettings))]
    public class PrefabSettings : ScriptableObject
    {
        public GameObject PlayerPrefab;
    }
}