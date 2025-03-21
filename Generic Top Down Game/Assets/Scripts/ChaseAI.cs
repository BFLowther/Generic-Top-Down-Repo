using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAI : MonoBehaviour
{
    public float moveSpeed = 4f;
    public int minDist = 1;
    private Rigidbody2D rb2d;
    private GameObject player;

    [HideInInspector]
    public GameObject gameManager;
	[HideInInspector]
	public GameManager gmScript;

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gmScript = gameManager.GetComponent<GameManager>();
    }

    void Update()
    {
        Vector3 dir = (player.transform.position - rb2d.transform.position).normalized;

        if (Vector3.Distance(player.transform.position, rb2d.transform.position) > minDist)
        {
            rb2d.MovePosition(rb2d.transform.position + dir * moveSpeed * Time.deltaTime);
        }
    }
}

