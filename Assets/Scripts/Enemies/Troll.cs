using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && animator.GetBool("isAttacking"))
        {
            Hit();
        }
    }
    void Hit()
    {
        PlayerStats.health -= 15f;
    }

}
