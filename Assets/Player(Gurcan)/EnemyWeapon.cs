using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;
   
    public void DamagePlayer()
    {
        PlayerStats.health -= 10f;
    }
}
