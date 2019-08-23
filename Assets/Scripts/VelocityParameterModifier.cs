using UnityEngine;
using System;
using System.Collections.Generic;

public class VelocityParameterModifier : ParameterModifier
{
	public float CurrentParameterValue;
	public TrackObject SourceObject;
	public TrackAxis VelocityAxis;
	public float OverDuration = 1f;
	
	private List<TimePosition> m_recentPositions = new List<TimePosition>();

	public void Update()
	{
		Vector3 position = TrackObjectUtility.GetObject(SourceObject).transform.position;

		m_recentPositions.Add(new TimePosition()
		{
			Time = Time.time,
			Position = position
		});

		while (m_recentPositions.Count > 1 && m_recentPositions[1].Time <= Time.time - OverDuration)
		{
			m_recentPositions.RemoveAt(0);
		}

		Vector3 velocity = Vector3.zero;

		for (int i = 0; i < m_recentPositions.Count-1; i++)
		{
			Vector3 delta = m_recentPositions[i+1].Position - m_recentPositions[i].Position;
			float deltaTime = m_recentPositions[i+1].Time - Mathf.Max(Time.time - OverDuration, m_recentPositions[i].Time);

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