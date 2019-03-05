using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour
{
	private Vector3 direction;
	private float speed;

	public void Initialize(Vector3 direction, float speed)
	{
		this.direction = direction;
		this.speed = speed;
	}
	
	public void Update()
	{
		transform.position += direction.normalized * speed;
	}
}
