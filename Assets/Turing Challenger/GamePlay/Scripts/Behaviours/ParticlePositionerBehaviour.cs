using System.Collections;
using System.Collections.Generic;
using Turing.Inventory;
using UnityEngine;
using UnityEngine.Events;

namespace Turing
{
    public class ParticlePositionerBehaviour : MonoBehaviour
    {
        [SerializeField] private InventoryChannel _inventoryChannel;
        [SerializeField] private ParticleSystem particles;
        [SerializeField] private int amount = 20;

        [field: SerializeField] public UnityEvent OnPlay { get; private set; }

        private void OnEnable()
        {
            _inventoryChannel.OnCollect += PlayAt;
        }

        private void OnDisable()
        {
            _inventoryChannel.OnCollect -= PlayAt;
        }

        public void PlayAt(IPositioner positioner)
        {
            particles.transform.position = positioner.GetPostion();
            particles.Emit(amount);
            OnPlay?.Invoke();
        }
    }
}
