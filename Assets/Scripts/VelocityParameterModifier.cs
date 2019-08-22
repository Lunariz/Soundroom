using UnityEngine;
using System;
using System.Collections.Generic;

public class VelocityParameterModifier : ParameterModifier
{
	public float CurrentParameterValue;
	public TrackObject SourceObject;
	public TrackAxis VelocityAxis;
	public float OverDuration = 1f;
	public List<TimePosition> RecentPositions;

	public void Update()
	{
		Vector3 position = TrackObjectUtility.GetObject(SourceObject).transform.position;

		RecentPositions.Add(new TimePosition()
		{
			Time = Time.time,
			Position = position
		});

		while (RecentPositions.Count > 1 && RecentPositions[1].Time <= Time.time - OverDuration)
		{
			RecentPositions.RemoveAt(0);
		}

		Vector3 velocity = Vector3.zero;

		for (int i = 0; i < RecentPositions.Count-1; i++)
		{
			Vector3 delta = RecentPositions[i+1].Position - RecentPositions[i].Position;
			float deltaTime = RecentPositions[i+1].Time - Mathf.Max(Time.time - OverDuration, RecentPositions[i].Time);

			velocity += (delta / deltaTime) * (deltaTime / OverDuration);
		}

		float velocityValue = TrackAxisUtility.GetValue(velocity, VelocityAxis);

		SetParameter(velocityValue);
		CurrentParameterValue = velocityValue;
	}
}

[System.Serializable]
public struct TimePosition
{
	public float Time;
	public Vector3 Position;
}