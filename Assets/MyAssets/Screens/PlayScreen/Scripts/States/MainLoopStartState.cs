using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace MT.Screens.PlayScreen.States
{
    public class MainLoopStartState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public void Enter()
        {
            _nextState.Enter();
        }
    }
}
