using Player.Movement;
using Player.Shooting;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private GameData _data;
        [SerializeField] private Rigidbody[] _rigidbodies;
        private Animator _animator;
        private Collider _collider;

        private PlayerMovement _player;

        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
            _collider = GetComponent<Collider>();

            _player = FindObjectOfType<PlayerMovement>();

            SetActiveRagdoll(true);
        }

        private void OnCollisionEnter(Collision other)
        {
            var bullet = other.gameObject.GetComponent<Bullet>();
            if (bullet == null) return;

            var direction = _player.transform.position - transform.position;
            direction.Normalize();

            _collider.enabled = false;

            SetActiveRagdoll(false);
            ForceRagdoll(-direction);

            Destroy(_animator);
            Destroy(gameObject, 4f);
        }

        private void ForceRagdoll(Vector3 direction)
        {
            foreach (var rigidbody in _rigidbodies)
            {
                rigidbody.AddForce(direction * _data.EnemyImpulseForce, _data.EnemyForceMode);
            }
        }

        private void SetActiveRagdoll(bool isActive)
        {
            foreach (var rigidbody in _rigidbodies)
            {
                rigidbody.isKinematic = isActive;
            }
        }
    }
}