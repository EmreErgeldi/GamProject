using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
             if(enemyAnimator.GetBool("isAttacking"))
             {
                 PlayerStats.health -= 10f;
                 if(PlayerStats.health < 0)
                 {
                     Destroy(GameObject.Find("Player"));
                 }
             }

            
        }
    }
}
