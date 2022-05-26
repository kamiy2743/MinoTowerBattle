using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Blocks;

namespace MT.PlayScreen
{
    public class Initializer : MonoBehaviour
    {
        [SerializeField] private PlayData _playData;
        [SerializeField] private BlockStore _blockStore;
        [SerializeField] private ResultUI _resultUI;

        public void Execute()
        {
            _playData.Initialize();
            _blockStore.Initialize();
            _resultUI.Initialize();
            ScreenScroller.Instance.Initialize();
        }
    }
}
