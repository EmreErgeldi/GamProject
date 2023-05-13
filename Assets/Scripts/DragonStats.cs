using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonStats : MonoBehaviour
{
	public static int health = 100;
	public static int armor;
	public int armorValue;
	public Animator dragon;
	void Start()
	{
		armor = armorValue;
	}

	private void Update()
	{
		if (health <= 0)
		{
			Die();

		}
	}
	public static void TakeDamage()
	{
		health -= (35 - armor);
		Debug.Log(health);
	}

	private void Die()
	{
		dragon.SetTrigger("isDead");
		Destroy(gameObject, 4f);
	}
}
