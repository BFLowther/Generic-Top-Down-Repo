using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 0;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            gm.ManageMonsters(5);
			Destroy(gameObject);
            
        }

    }

   public void DamageEnemy()
    {
        health--;
    }
}
