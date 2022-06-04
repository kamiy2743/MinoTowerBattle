using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT.MatchMakingScreen
{
    public class EntryState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private GameObject _nextStateObject;

        [Header("初期化対象")]
        [SerializeField] private LoadingUI _loadingUI;
        [SerializeField] private SelectMatchUI _selectMatchUI;
        [SerializeField] private FriendMatchUI _friendMatchUI;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public async void Enter()
        {
            await Fader.Instance.FadeOut(0);
            Initialize();

            await Fader.Instance.FadeIn(_fadeInDuration);
            _nextState.Enter();
        }

        private void Initialize()
        {
            _loadingUI.Initialize();
            _selectMatchUI.Initialize();
            _friendMatchUI.Initialize();
        }
    }
}
