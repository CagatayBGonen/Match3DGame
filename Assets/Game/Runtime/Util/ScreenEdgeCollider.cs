using UnityEngine;

namespace Game.Runtime.Util
{
    [RequireComponent(typeof(Camera))]
    public class ScreenEdgeCollider : MonoBehaviour
    {
        [Header("Screen Colliders")]
        [SerializeField] private BoxCollider leftCol;
        [SerializeField] private BoxCollider rightCol;
        [SerializeField] private BoxCollider topCol;
        [SerializeField] private BoxCollider bottomCol;
        private Camera _camera;
        
        private void Awake()
        {
            _camera = GetComponent<Camera>();
            
            if (!_camera.orthographic)
            {
                _camera.orthographic = true;
                Debug.LogWarning("<color=yellow>Your camera isn't orthographic camera, changing to orthographic...</color>");
            }
            
            SetCameraEdges();
        }

        private void SetCameraEdges()
        {
            var halfHeight = _camera.orthographicSize;
            var halfWidth = _camera.orthographicSize * _camera.aspect;

            leftCol.center = new Vector3(-halfWidth - leftCol.size.x * .5f, 0, 10f);
            leftCol.size = new Vector3(leftCol.size.x, halfHeight * 2, 30f);
            
            topCol.center = new Vector3(0, halfHeight + topCol.size.y * .5f, 10f);
            topCol.size = new Vector3(halfWidth * 2, topCol.size.y, 30f);
            
            rightCol.center = new Vector3(leftCol.center.x * -1, leftCol.center.y, leftCol.center.z);
            rightCol.size = leftCol.size;
            
            bottomCol.center = new Vector3(topCol.center.x, topCol.center.y * -1, topCol.center.z);
            bottomCol.size = topCol.size;
        }
    }
}
