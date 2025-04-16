using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //number of enemies
	[SerializeField]
    private int monsters = 0;

    //player HP
    private int hp;

	public int maxHP;
	public int maxAmmo;

    private int ammo ;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
	void Start()
	{
		SetHP(maxHP);
		SetAmmo(maxAmmo);
	}
  
    void Update()
    {
		//Debug.Log(GetMonsters());
    }

    public int GetHP()
    {
        return hp;
    }

    public void SetHP(int a)
    {
        hp = a;
    }

    public void ManageHP(int a)
    {
        hp += a;
    }

    public int GetMonsters()
    {
        return monsters;
    }

    public void ManageMonsters(int a)
    {
        monsters += a;
    }

    public void SubMonsters()
    {
        monsters --;
	}

	public int getAmmo()
	{
		return ammo;
	}

	public void SetAmmo(int a)
	{
		ammo = a;
	}

	public void ManageAmmo(int a)
    {
        ammo += a;
    }
    
}
