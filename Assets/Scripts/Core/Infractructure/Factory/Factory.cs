using UnityEngine;
using Zenject;

namespace Core.Infractructure.Factory
{
    public class Factory : IFactory
    {

        private DiContainer _diContainer;

        private Factory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public GameObject CreatePlayer()
        {

            //GameObject tempPlayerPrefab = _diContainer.InstantiatePrefab();
            //tempPlayerPrefab.transform.position = _playerPoints[0].transform.position;
            //tempPlayerPrefab.transform.rotation = _playerPoints[0].transform.rotation;

            //return tempPlayerPrefab;
            return null;
        }
    }
}