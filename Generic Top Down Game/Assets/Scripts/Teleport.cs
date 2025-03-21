using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform destination;

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			col.transform.position = destination.transform.position;
		}
	}
}
