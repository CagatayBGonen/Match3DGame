using DG.Tweening;
using StandardSetup.Runtime.Handlers;
using StandardSetup.Runtime.Util;
using UnityEngine;

namespace Game.Runtime.Core.Items
{
    public class Item : MonoBehaviour, IFactoryElement
    {
        private const float TweenMoveTime = 1f;
        private const float TweenDisappearTime = .28f;

        #region UnityFunctions
        private void Awake()
        {
            ActionHandler<Vector3>.Register(ActionKey.MoveItemKey, MoveAndDisappear);
        }

        private void OnDestroy()
        {
            ActionHandler<Vector3>.Unregister(ActionKey.MoveItemKey, MoveAndDisappear);
            DOTween.Kill(transform);
        }
        #endregion
        
        public void Prepare(object customParameter = null)
        {
            
        }
        
        private void MoveAndDisappear(Vector3 targetPosition)
        {
            DOTween.Sequence()
                .Append(transform.DOMove(targetPosition, TweenMoveTime).SetEase(Ease.InOutSine))
                .Append(transform.DOScale(0, TweenDisappearTime).SetEase(Ease.InBack))
                .SetId(transform);
        } 
    }
}
