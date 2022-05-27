using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Blocks;
using MT.Util;

namespace MT.Screens.PlayScreen.States
{
    public class BlockSpawnState : MonoBehaviour, IState
    {
        [SerializeField] private Transform _blockSpawnPoint;
        [SerializeField] private BlockStore _blockStore;
        [SerializeField] private BlockGenerator _blockGenerator;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        void Awake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public void Enter()
        {
            SpawnNewBlock();
            ToNext();
        }

        public void ToNext()
        {
            _nextState.Enter();
        }

        private void SpawnNewBlock()
        {
            var cameraVertPos = new Vector3(0, Camera.main.transform.position.y, 0);
            var position = cameraVertPos + _blockSpawnPoint.position;
            var rotation = Quaternion.identity;
            var block = _blockGenerator.RandomGenerate(position, rotation);
            block.OnSpwned();
            _blockStore.Add(block);
        }
    }
}
