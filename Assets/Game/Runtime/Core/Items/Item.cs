using DG.Tweening;
using StandardSetup.Runtime.Handlers;
using UnityEngine;

namespace Game.Runtime.Core.Items
{
    public class Item : MonoBehaviour
    {
        private const float TweenMoveTime = 1f;
        private const float TweenDisappearTime = .28f;

        private void Awake()
        {
            ActionHandler<Vector3>.Register(ActionKey.MoveItemKey, MoveAndDisappear);
        }

        private void OnDestroy()
        {
            ActionHandler<Vector3>.Unregister(ActionKey.MoveItemKey, MoveAndDisappear);
            DOTween.Kill(transform);
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
