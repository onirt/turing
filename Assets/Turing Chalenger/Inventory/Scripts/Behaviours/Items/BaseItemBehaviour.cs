using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace Turing.Inventory
{
    public class BaseItemBehaviour : MonoBehaviour, IInventoryItem
    {
        [SerializeField] private InventoryChannel _channel;

        [SerializeField] protected BaseItemModel _model;

        [field: SerializeField] public int Count { get; set; }

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

        public virtual void Collect()
        {
            gameObject.SetActive(false);
            Debug.Log($"[InventoryItemBehaviour][Collect]: {Count}");
            _channel.Collect(this);
        }

        public virtual void Use()
        {
            _channel.Use(this);
        }

        public virtual void Delete()
        {
            _channel.Delete(this);
            Restart();
        }

        public virtual void Restart()
        {
            transform.SetPositionAndRotation(_startPosition, _startRotation);
            Count = _startCount;
            gameObject.SetActive(true);
        }
#if UNITY_EDITOR
        [ContextMenu("Test Collect")]
        public void TestCollect()
        {
            Collect();
        }
#endif
    }
}
