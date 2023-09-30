using Core.Events;
using Core.Infractructure.StateMachine;
using Core.Logic;
using UnityEngine;
using Zenject;

namespace Core.Game
{
    public class Portal : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private TriggerObserver _triggerObserver;

        #endregion

        private SignalBus _signalBus;
        
        [Inject]
        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void OnEnable()
        {
            _triggerObserver.TriggerEnter += OnPlayerTriggerEnter;
        }

        private void OnDisable()
        {
            _triggerObserver.TriggerEnter -= OnPlayerTriggerEnter;
        }

        private void OnPlayerTriggerEnter()
        {
            _signalBus.Fire<RaisePortalSignal>();
        }
    }
}