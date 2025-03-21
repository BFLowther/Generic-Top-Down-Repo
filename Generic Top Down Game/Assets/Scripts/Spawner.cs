using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mob;
    void Start()
    {
        Instantiate(mob, transform.position, transform.rotation);
    }
}
