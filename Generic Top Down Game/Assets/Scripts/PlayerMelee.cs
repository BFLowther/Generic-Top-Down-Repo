using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public GameObject Melee;
    public Transform spawnPoint;
    private Vector3 Position;
    Quaternion rotation;

    [HideInInspector]
    public PlayerController player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        Position = spawnPoint.transform.position;
        rotation = player.shootingRotation;
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(Melee, Position, rotation);
        }

    }

}
