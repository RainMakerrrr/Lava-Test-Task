using Input;
using UnityEngine;
using UnityEngine.AI;

namespace Player.Movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private GameData _data;

        private InputHandler _inputHandler;

        private NavMeshAgent _agent;
        private Camera _camera;
        

        private void Start()
        {
            _inputHandler = new InputHandler();

            _agent = GetComponent<NavMeshAgent>();
            _camera = Camera.main;
        }

        private void Update() => Movement();

        private void Movement()
        {
            _agent.speed = _data.MoveSpeed;

            if (!_inputHandler.IsPointerClicked) return;

            var ray = _camera.ScreenPointToRay(_inputHandler.PointerPosition);

            if (!Physics.Raycast(ray, out var hit, Mathf.Infinity)) return;

            _agent.SetDestination(hit.point);
        }

        public void ReduceSpeed() => _agent.speed = 0f;
    }
}