using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectile;
    private PlayerController player;

    public int currentAmmo;

	public GameObject melee;
	public Transform spawnPoint;
	private Vector3 position;
	Quaternion rotation;

	[HideInInspector]
	public GameObject gameManager;
	[HideInInspector]
    public GameManager gmScript;
	
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gmScript = gameManager.GetComponent<GameManager>();
    }
    void Update()
    {
        position = spawnPoint.transform.position;
        rotation = player.shootingRotation;

        if (Input.GetButtonDown("Fire1") && currentAmmo > 0)
        {
            Instantiate(projectile, position, rotation);
            gmScript.ManageAmmo(-1);
        }

		if (Input.GetButtonDown("Fire2"))
		{
			Instantiate(melee, position, rotation);
		}
	}

	private void FixedUpdate()
    {
        currentAmmo = gmScript.getAmmo();
    }
}
