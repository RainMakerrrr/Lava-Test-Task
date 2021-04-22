using UnityEngine;


[CreateAssetMenu(fileName = "New Game Data", menuName = "Game Data")]
public class GameData : ScriptableObject
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _bulletForce;
    [SerializeField] private ForceMode _bulletForceMode;
    [SerializeField] private float _enemyImpulseForce;
    [SerializeField] private ForceMode _enemyForceMode;

    public float MoveSpeed => _moveSpeed;
    public float FireRate => _fireRate;
    public float BulletForce => _bulletForce;
    public ForceMode BulletForceMode => _bulletForceMode;
    public float EnemyImpulseForce => _enemyImpulseForce;
    public ForceMode EnemyForceMode => _enemyForceMode;
}