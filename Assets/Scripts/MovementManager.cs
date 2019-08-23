using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
	public float Speed = 1;

	public void Update()
	{
		float xInput = InputManager.Instance.GetAxis(InputManager.InputSource.LeftThumbstickX);
		float yInput = InputManager.Instance.GetAxis(InputManager.InputSource.LeftThumbstickY);

		transform.position += new Vector3(xInput, 0, yInput) * Speed * Time.deltaTime;
	}
}
