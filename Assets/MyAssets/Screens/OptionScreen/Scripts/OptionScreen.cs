using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Screens.OptionScreen.States;

namespace MT.Screens.OptionScreen
{
    public class OptionScreen : MonoBehaviour, IScreen
    {
        [SerializeField] private EntryState _entryState;

        public ScreenType Type { get; private set; } = ScreenType.Option;

        public void Open()
        {
            if (gameObject.activeSelf) return;
            gameObject.SetActive(true);
            _entryState.Enter();
        }

        public void Close()
        {
            if (!gameObject.activeSelf) return;
            gameObject.SetActive(false);
        }
    }
}
