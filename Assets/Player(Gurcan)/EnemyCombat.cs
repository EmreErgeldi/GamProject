using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] MeshCollider weapon;
    [SerializeField] Animator player;
    public void ActivateCollider()
    {
        weapon.isTrigger = true;
        weapon.enabled = true;
        player.SetTrigger("takeDamage");
        //PlayerStats.health -= 10f;
    }

    public void DeactivateCollider()
    {
        weapon.enabled = false;
        weapon.isTrigger = true;
    }
}
