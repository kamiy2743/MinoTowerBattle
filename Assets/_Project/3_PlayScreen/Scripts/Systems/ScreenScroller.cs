using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

namespace MT.PlayScreen
{
    public class ScreenScroller : MonoBehaviour, IStaticAwake
    {
        private Transform _cameraTransfrom;
        private ScrollAmount _scrollAmount;

        public void StaticAwake()
        {
            _cameraTransfrom = Camera.main.transform;
        }

        public async UniTask InitializeAsync()
        {
            await SetScrollAsync(ScrollAmount.Min, 0);
        }

        public async UniTask SetScrollAsync(ScrollAmount scrollAmount, float duration)
        {
            _scrollAmount = scrollAmount;
            await _cameraTransfrom.DOMoveY(scrollAmount.value, duration);
        }
    }
}
