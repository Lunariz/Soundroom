using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;

public class Bending : MonoBehaviour
{
	public Transform CenterPosition;
	public Transform ForwardPosition;
	private Vector3 forwardVector;

	public float HistoricLength = 5f;

	private Hand hand;
	private Queue<KeyValuePair<float, Vector3>> historicPositions = new Queue<KeyValuePair<float, Vector3>>();

	private bool grip;
	private bool pinch;

	private Vector3 currentPosition;

	//Punch
	public GameObject PunchPrefab;
	public float PunchStartDistance;
	public float PunchStartTime;
	public float PunchEndDistance;
	public float PunchEndTime;
	public float PunchCooldown;
	private float currentPunchCooldown;

	public void Awake()
	{
		hand = GetComponent<Hand>();
	}

	public void Update()
	{
		float currentTime = Time.time;

		currentPosition = CenterPosition.transform.position;
		forwardVector = ForwardPosition.position - currentPosition;

		grip = hand.grabGripAction.GetState(Valve.VR.SteamVR_Input_Sources.Any);
		pinch = hand.grabPinchAction.GetState(Valve.VR.SteamVR_Input_Sources.Any);

		while (historicPositions.Count != 0 && historicPositions.Peek().Key < currentTime - HistoricLength)
		{
			historicPositions.Dequeue();
		}

		historicPositions.Enqueue(new KeyValuePair<float, Vector3>(currentTime, currentPosition));

		DoPunch();
	}

	private void DoPunch()
	{
		if (!(grip && pinch))
		{
			return;
		}
		if (currentPunchCooldown > 0)
		{
			currentPunchCooldown -= Time.deltaTime;
			return;
		}

		bool startValid = false;
		bool endValid = false;

		Vector3 start = currentPosition;
		Vector3 end = currentPosition;

		foreach (var historicPosition in historicPositions)
		{
			float timeSince = Time.time - historicPosition.Key;
			float distance = (currentPosition - historicPosition.Value).magnitude;

			if (timeSince < PunchStartTime && distance > PunchStartDistance && !startValid)
			{
				startValid = true;
				start = historicPosition.Value;
			}
			if (timeSince > PunchEndTime && distance < PunchEndDistance)
			{
				endValid = true;
				end = historicPosition.Value;
			}
		}
		
		if (startValid && endValid)
		{
			float dot = Vector3.Dot((end - start), forwardVector);
			float magnitude = (end - start).magnitude * forwardVector.magnitude;
			float pointingAngle = Mathf.Rad2Deg * Mathf.Acos(dot / magnitude);

			if (pointingAngle < 30)
			{
				GameObject fireballGO = (GameObject) Instantiate(PunchPrefab, ForwardPosition.transform.position, Quaternion.identity);
				Fireball fireball = fireballGO.GetComponent<Fireball>();
				fireball.Initialize((end - start).normalized, (end - start).magnitude / 3);
			}

			currentPunchCooldown = PunchCooldown;
		}
	}
}
