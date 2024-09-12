using System.Collections;
using System.Collections.Generic;
using Turing.Inventory;
using UnityEngine;

namespace Turing
{
    public class ParticlePositionerBehaviour : MonoBehaviour
    {
        [SerializeField] InventoryChannel _inventoryChannel;
        [SerializeField] ParticleSystem particles;

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
            particles.Play();
        }
    }
}
