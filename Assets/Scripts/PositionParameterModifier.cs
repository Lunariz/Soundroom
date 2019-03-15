using UnityEngine;
using System.Collections;

public class PositionParameterModifier : ParameterModifier
{
	public float CurrentParameterValue;
	public TrackAxis PositionAxis;

	public void Update()
	{
		Vector3 playerPosition = PlayerManager.Instance.Player.transform.position;

		float positionValue = 0;
		
		if (PositionAxis == TrackAxis.X)
		{
			positionValue = playerPosition.x;
		}
		else if (PositionAxis == TrackAxis.Y)
		{
			positionValue = playerPosition.y;
		}
		else if (PositionAxis == TrackAxis.Z)
		{
			positionValue = playerPosition.z;
		}

		SetParameter(positionValue);
		CurrentParameterValue = positionValue;
	}
}