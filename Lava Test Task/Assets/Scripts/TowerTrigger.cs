using Player;
using UnityEngine;

public class TowerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponentInChildren<PlayerState>();
        if (player == null) return;

        player.State = State.Shooting;
    }
}