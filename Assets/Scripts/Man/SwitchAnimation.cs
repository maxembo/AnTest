using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Man
{
    [RequireComponent(typeof(Animator))]
    public class SwitchAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private static readonly int AnimationHash = Animator.StringToHash("animation");

        private InputSystem _input;
        private int _currentAnimation = 0;

        private InputAction InputSwitch => _input.Man.Switch;

        private void Awake()
            => _input = new InputSystem();

        private void OnSwitchState()
        {
            if (_currentAnimation >= 2) _currentAnimation = -1;
            _currentAnimation++;
            animator.SetInteger(AnimationHash, _currentAnimation);
        }

        private void OnEnable()
        {
            _input.Enable();
            InputSwitch.performed += _ => OnSwitchState();
        }

        private void OnDisable()
        {
            InputSwitch.performed -= _ => OnSwitchState();
            _input.Disable();
        }
    }
}