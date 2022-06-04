using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT.PlayScreen.Multi
{
    public class EntryState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private GameObject _nextStateObject;

        [Header("初期化対象")]
        [SerializeField] private BlockStore _blockStore;
        [SerializeField] private RotateButton _rotateButton;
        [SerializeField] private ScreenScroller _screenScroller;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public async void Enter()
        {
            await Fader.Instance.FadeOut(0);
            await Initialize();

            await Fader.Instance.FadeIn(_fadeInDuration);
            _nextState.Enter();
        }

        private async UniTask Initialize()
        {
            _blockStore.Initialize();
            _rotateButton.Initialize();
            await _screenScroller.Initialize();
        }
    }
}
