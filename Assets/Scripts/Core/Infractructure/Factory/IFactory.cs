using UnityEngine;

namespace Core.Infractructure.Factory
{
    public interface IFactory
    {
        public GameObject CreatePlayer();
    }
}