using UnityEngine;
using System.Collections;

public class PositionParameterModifier : ParameterModifier
{
	public float CurrentParameterValue;
	public TrackAxis PositionAxis;

	public void Update()
	{
		Vector3 playerPosition = PlayerManager.Instance.Player.transform.position;

		float positionValue = TrackAxisUtility.GetValue(playerPosition, PositionAxis);

		SetParameter(positionValue);
		CurrentParameterValue = positionValue;
	}
}