using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace Turing.Inventory
{
    public class BaseItemBehaviour : MonoBehaviour, IInventoryItem
    {
        [SerializeField] private InventoryChannel _channel;

        [SerializeField] protected BaseItemModel _model;
        [SerializeField] protected Rigidbody _rigidbody;

        [field: SerializeField] public int Count { get; set; }

        [field: SerializeField] public UnityEvent UpdateItem { get; set; }

        public UnityEvent<int> OnUse;

        public int Id => _model.Id;

        public BaseItemModel Model => _model;

        private Vector3 _startPosition;
        private Quaternion _startRotation;
        private int _startCount;

        private void Awake()
        {
            Assert.IsNotNull(_model, $"Error: No model detected on : {name}");
            _startPosition = transform.position;
            _startRotation = transform.rotation;
            _startCount = Count;
        }
        [ContextMenu("Collect")]
        public virtual void Collect()
        {
            gameObject.SetActive(false);
            Debug.Log($"[BaseItemBehaviour][Collect]: {Count}");
            _channel.Collect(this);
        }

        public virtual void Use()
        {
            Debug.Log($"[BaseItemBehaviour][Use]: {Count}");
            OnUse?.Invoke(Count);
            _channel.Use(this);
        }

        public virtual void Delete()
        {
            _channel.Delete(this);
            Restart();
        }

        public virtual void Restart()
        {
            UpdateItem.RemoveAllListeners();
            Count = _startCount;
            gameObject.SetActive(true);
            RestartPosition();
        }

        public void RestartPosition()
        {
            if (_rigidbody)
            {
                Debug.Log($"[BaseItemBehaviour][Clearing][Rigidbody]");
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.angularVelocity = Vector3.zero;
                _rigidbody.position = _startPosition;
                _rigidbody.rotation = _startRotation;
            }
            else
            {
                transform.SetPositionAndRotation(_startPosition, _startRotation);
            }
        }

        public Vector3 GetPostion()
        {
            return transform.position;
        }
    }
}
