using UnityEngine;
using UnityEngine.AI;

namespace Player.Movement
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
    public class PlayerAnimations : MonoBehaviour
    {
        private static readonly int VelocityX = Animator.StringToHash("VelocityX");
        private static readonly int VelocityY = Animator.StringToHash("VelocityY");
        private static readonly int IsMove = Animator.StringToHash("isMove");

        [SerializeField] private Transform _head;

        private Vector3 _lookAtTargetPosition;
        private Vector3 _lookAtPosition;

        private Vector3 _worldDeltaPosition;
        private Vector2 _deltaPosition;
        private Vector2 _velocity;

        private float _lookAtWeight;

        private NavMeshAgent _agent;
        private Animator _animator;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();

            _lookAtTargetPosition = _head.position + transform.forward;
            _lookAtPosition = _lookAtTargetPosition;

            _agent.updatePosition = false;
        }

        private void Update()
        {
            UpdateAnimations();
            _lookAtTargetPosition = _agent.steeringTarget + transform.forward;
        }

        private void UpdateAnimations()
        {
            _worldDeltaPosition = _agent.nextPosition - transform.position;

            _deltaPosition.x = Vector3.Dot(transform.right, _worldDeltaPosition);
            _deltaPosition.y = Vector3.Dot(transform.forward, _worldDeltaPosition);

            _velocity = Time.deltaTime > 1e-5f ? _deltaPosition / Time.deltaTime : _velocity = Vector2.zero;

            var shouldMove = _velocity.magnitude > 0.025f && _agent.remainingDistance > _agent.radius;

            _animator.SetBool(IsMove, shouldMove);
            _animator.SetFloat(VelocityX, _velocity.x);
            _animator.SetFloat(VelocityY, _velocity.y);
        }

        private void OnAnimatorMove() => transform.position = _agent.nextPosition;

        private void OnAnimatorIK(int layerIndex)
        {
            var position = _head.position;

            _lookAtTargetPosition.y = position.y;
            const float lookAtTargetWeight = 1f;

            var currentDirection = _lookAtPosition - position;
            var futureDirection = _lookAtTargetPosition - position;

            currentDirection = Vector3.RotateTowards(currentDirection, futureDirection, 6.28f * Time.deltaTime,
                float.PositiveInfinity);
            _lookAtPosition = position + currentDirection;

            const float blendTime = 0.2f;
            _lookAtWeight = Mathf.MoveTowards(_lookAtWeight, lookAtTargetWeight, Time.deltaTime / blendTime);

            _animator.SetLookAtWeight(_lookAtWeight, 0.2f, 0.5f, 0.7f, 0.5f);
            _animator.SetLookAtPosition(_lookAtPosition);
        }
    }
}