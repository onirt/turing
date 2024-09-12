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
        private float _currentLife;

        private void Start()
        {
            _currentLife = _model.Life;
        }

        public void UpdateLifeBar(int amount)
        {
            _currentLife = Mathf.Clamp(_currentLife + amount, 0, _model.Life);
            float normalized = _currentLife / _model.Life;
            Debug.Log($"[Life][Update] {_currentLife} [Normalized]: { normalized}");
            OnNormalizedLifeBarUpdate?.Invoke(normalized);
        }
    }
}
