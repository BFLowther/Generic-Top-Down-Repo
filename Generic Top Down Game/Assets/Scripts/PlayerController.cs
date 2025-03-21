using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    
    [SerializeField]
    private float moveSpeed;
    private Rigidbody2D rb2d;

    [HideInInspector]
    private GameManager gameManager;

    [HideInInspector]
    public Quaternion shootingRotation;

    private float moveSpeedActual;
    private SpriteRenderer sr;
    private GameObject gun;
	private GameObject gunSpawn;

	void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        moveSpeedActual = moveSpeed;
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
		gun = GameObject.FindWithTag("Gun");
		gunSpawn = GameObject.FindWithTag("Gun Spawn");
		sr = GetComponent<SpriteRenderer>();
    }

    void Update() 
    {
		Vector3 mouseScreen = Input.mousePosition;
		Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);

		float angle = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg;

		shootingRotation = Quaternion.Euler(0, 0, angle - 90);

		gun.gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);

		if (Input.GetAxis("Fire1") > 0)
        {
            if (angle < 90 && angle > -90)
            {
                gunSpawn.GetComponent<SpriteRenderer>().flipY = false;
            }
            else
            {
                gunSpawn.GetComponent<SpriteRenderer>().flipY = true;
            }

            if ((Input.GetAxis("Horizontal")) > 0)
                sr.flipX = false;
            else if ((Input.GetAxis("Horizontal") < 0))
                sr.flipX = true;
        }
    }

	void FixedUpdate()
	{
		Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		rb2d.MovePosition(rb2d.position + (movement * moveSpeedActual * Time.deltaTime));
	}

	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Health"))
        {
            gameManager.ManageHP(3);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Ammo"))
        {
            gameManager.ManageAmmo(10);
            Destroy(collision.gameObject);
        }
    }
}