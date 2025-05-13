using Configs;
using UnityEngine;

namespace Camera
{
    [RequireComponent(typeof(CharacterController))]
    public class Camera : MonoBehaviour
    {
        [SerializeField] private CameraConfig config;

        private InputSystem _input;
        private CharacterController _controller;
        private Vector3 _direction;

        private float _xRotation;
        private float _yRotation;

        private void Awake()
        {
            _input = new InputSystem();
            _controller = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            Move();
            Look();
        }

        private void Move()
        {
            var inputMovement = _input.Camera.Move.ReadValue<Vector2>();
            _direction = (transform.forward * inputMovement.y + transform.right * inputMovement.x);

            _controller.Move(_direction.normalized * (config.Speed * Time.deltaTime));
        }

        private void Look()
        {
            var inputLook = _input.Camera.Look.ReadValue<Vector2>();
            _xRotation += inputLook.x * config.Sensitivity;
            _yRotation -= inputLook.y * config.Sensitivity;

            transform.rotation = Quaternion.Euler(_yRotation, _xRotation, 0);
        }

        private void OnEnable() => _input.Enable();

        private void OnDisable() => _input.Disable();
    }
}