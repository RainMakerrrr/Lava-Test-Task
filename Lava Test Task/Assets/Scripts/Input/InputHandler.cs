using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputHandler
    {
        private readonly PlayerControls _playerControls;

        public bool IsPointerClicked => _playerControls.Movement.PointerClicked.triggered;

        public bool IsShooting => Mouse.current.leftButton.isPressed;
        public Vector2 PointerPosition => _playerControls.Movement.PointerPosition.ReadValue<Vector2>();

        public InputHandler()
        {
            _playerControls = new PlayerControls();
            _playerControls.Enable();
        }
    }
}
