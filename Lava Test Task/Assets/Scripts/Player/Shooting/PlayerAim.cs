using Input;
using UnityEngine;

namespace Player.Shooting
{
    public class PlayerAim : MonoBehaviour
    {
        [SerializeField] private GameData _data;
        
        [SerializeField] private Transform _target;
        [SerializeField] private Transform _arm;
        [SerializeField] private Bullet _bulletPrefab;
        
        private Camera _camera;
        private InputHandler _inputHandler;

        private float _nextAttackTime;
        
        private void OnEnable()
        {
            _camera = Camera.main;
            _inputHandler = new InputHandler();
        }

        private void Update()
        {
            if(_inputHandler.IsShooting)
                Shoot();
            
            LookAtTarget();
        }

        private void Shoot()
        {
            if (!(Time.time >= _nextAttackTime)) return;
            
            var bullet = Instantiate(_bulletPrefab, _arm.position + new Vector3(0.25f,0f,0f), Quaternion.identity);
            bullet.AddForceToBullet(transform.forward);
            
            _nextAttackTime = Time.time + 1f / _data.FireRate;
            
        }
        
        private void LookAtTarget()
        {
            var ray = _camera.ScreenPointToRay(_inputHandler.PointerPosition);
            if (!Physics.Raycast(ray, out var hit)) return;

            var mousePosition = new Vector3(hit.point.x, _target.position.y, hit.point.z);
            var direction = mousePosition - transform.position;
            var targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 4f * Time.deltaTime);
        }
    }
}