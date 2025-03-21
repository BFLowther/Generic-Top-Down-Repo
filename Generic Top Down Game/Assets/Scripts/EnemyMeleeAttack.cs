using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
	public int damage;

	[HideInInspector]
	public GameObject gameManger;
	[HideInInspector]
	public GameManager gmScript;

	private void Start()
	{
		gameManger = GameObject.FindGameObjectWithTag("GameManager");
		gmScript = gameManger.GetComponent<GameManager>();
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gmScript.ManageHP(damage);
            Destroy(gameObject);
        }
    }
}
