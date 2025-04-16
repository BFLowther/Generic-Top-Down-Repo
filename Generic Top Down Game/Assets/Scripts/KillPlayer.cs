using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject gameManger;
    public GameManager gmScript;
	private bool isPlayerDead = false;
   
   
    private void Start()
    {
        gameManger = GameObject.FindGameObjectWithTag("GameManager");
        gmScript = gameManger.GetComponent<GameManager>();
    }

	private void Update()
	{
		isPlayerDead = false;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player") && isPlayerDead == false)
		{
			gmScript.ManageHP(-1);
			isPlayerDead = true;
			//Destroy(gameObject);
			//gmScript.SubMonsters();
		}
	}
}
