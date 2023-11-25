using StandardSetup.Runtime.Handlers;
using UnityEngine;

namespace Game.Runtime.Core.Items
{
    public class ItemManager : MonoBehaviour
    {
        [SerializeField] private Transform targetPosition;
        
        private void Start()
        {
            ActionHandler<Vector3>.Raise(ActionKey.MoveItemKey, targetPosition.position);
        }
    }
}
