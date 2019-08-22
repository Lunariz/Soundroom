using UnityEngine;
using System.Collections;

public class PositionParameterModifier : ParameterModifier
{
	public float CurrentParameterValue;
	public TrackObject SourceObject;
	public TrackAxis PositionAxis;

	public void Update()
	{
		Vector3 position = TrackObjectUtility.GetObject(SourceObject).transform.position;

		float positionValue = TrackAxisUtility.GetValue(position, PositionAxis);

		SetParameter(positionValue);
		CurrentParameterValue = positionValue;
	}
}