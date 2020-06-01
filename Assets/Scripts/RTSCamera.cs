namespace AshkolTools.Cameras
{
    using UnityEngine;

    public class RTSCamera : MonoBehaviour
    {
        /// Camera hierarchy
        /// Ground level game object
        ///     Pivot
        ///         Swivel
        ///             Camera
        private Camera cam;
        private Transform swivel, pivot;

        [SerializeField, Range(-100, 5)] private float maxZoom = 5;
        [SerializeField, Range(-100, 5)] private float minZoom = -30;
        private float intendedZoom;
        private float intendedYAngle = 0;
        private Vector3 intendedCameraPos;

        // Mouse delta
        private Vector2 mousePrevPos;

        void Awake()
        {
            cam = GetComponentInChildren<Camera>();
            swivel = cam.transform.parent;
            pivot = swivel.transform.parent;
            intendedZoom = cam.transform.position.z;
            intendedCameraPos = transform.position;

            // Mouse delta
            mousePrevPos = Input.mousePosition;
        }

        void Update()
        {
            HandleInput();
        }

        void LateUpdate()
        {
            Zoom(intendedZoom);
            RotateY(intendedYAngle);
            MoveCamera(intendedCameraPos);
            intendedYAngle = 0;
        }

        private void HandleInput()
        {
            intendedZoom += Input.mouseScrollDelta.y * 2;
            intendedZoom = Mathf.Clamp(intendedZoom, minZoom, maxZoom);
            if (Input.GetMouseButton(1))
            {
                intendedYAngle = GetMouseDelta().x * 0.1f;
                Debug.Log(intendedYAngle);
            }
            mousePrevPos = Input.mousePosition;
            intendedCameraPos += (Vector3) (pivot.localToWorldMatrix * (new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")) * 0.02f * Mathf.Abs(intendedZoom)));
        }


        private void Zoom(float intendedZoom)
        {
            cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, new Vector3(0, 0, intendedZoom), 0.2f);
        }

        private void RotateY(float angle)
        {
            pivot.Rotate(transform.up, angle);
        }

        private void MoveCamera(Vector3 intendedCameraPos)
        {
            transform.position = Vector3.Lerp(transform.position, intendedCameraPos, 0.2f);
        }

        private Vector2 GetMouseDelta()
        {
            return (Vector2)Input.mousePosition - mousePrevPos;
        }
    }

}
