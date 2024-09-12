using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Turing
{
    public class LifebarBehaviour : MonoBehaviour
    {
        [SerializeField] private CharacterModel _model;
        [SerializeField] private UnityEvent<float> OnNormalizedLifeBarUpdate;
        private int _currentLife;

        private void Start()
        {
            _currentLife = _model.Life;
        }

        public void UpdateLifeBar(int amount)
        {
            _currentLife = Mathf.Clamp(_currentLife + amount, 0, _model.Life);

            OnNormalizedLifeBarUpdate?.Invoke(_currentLife / _model.Life);
        }
    }
}
