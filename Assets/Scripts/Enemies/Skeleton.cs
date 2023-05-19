using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
	public float EnemyHealth = 50f;
	string getEnemyName;
	Collider[] colliders;
	EnemyAI EAI;
	EnemyAIRanged EAIR;
	private Animator animator;
	private Animator playerAnimator;
	void Start()
	{
		colliders = gameObject.GetComponents<Collider>();
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        animator = GetComponent<Animator>();
        EAI = GetComponent<EnemyAI>();
        EAIR = GetComponent<EnemyAIRanged>();
	}

	// Update is called once per frame
	void Update()
	{
		//print(EnemyHealth);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Sword") && playerAnimator.GetBool("combo"))
		{
			animator.SetTrigger("GetHit");
			EnemyHealth -= 10f;
			Diead();
		}
	}
	void Diead()
	{
		if (EnemyHealth <= 0 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
		{
			foreach (Collider col in colliders)
			{
				col.enabled = false;
			}
			animator.SetTrigger("Die");
			Destroy(EAI);
			Destroy(EAIR);
			Destroy(gameObject, 4f);
		}
	}

}
