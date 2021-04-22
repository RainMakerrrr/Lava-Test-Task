using UnityEngine;

namespace Player.Shooting
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameData _data;

        private Rigidbody _rigidbody;
        private float _lifeTime;

        private void OnEnable() => _rigidbody = GetComponent<Rigidbody>();

        private void Update()
        {
            _lifeTime += Time.deltaTime;
            if (_lifeTime > 5f)
                Destroy(gameObject);
        }

        public void AddForceToBullet(Vector3 direction) =>
            _rigidbody.AddForce(direction * _data.BulletForce, _data.BulletForceMode);
    }
}