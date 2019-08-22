using UnityEngine;
using System;
using System.Collections.Generic;

public class FacingAngleParameterModifier : ParameterModifier
{
	public float CurrentParameterValue;
	public TrackAxis RotationAxis;

	public void Update()
	{
		Vector3 playerRotation = PlayerManager.Instance.Head.transform.rotation.eulerAngles;
		Vector3 modifiedPlayerRotation = new Vector3(
			Clamp180(playerRotation.y),
			-Clamp180(playerRotation.x),
			-Clamp180(playerRotation.z)
		);

		float rotationValue = TrackAxisUtility.GetValue(modifiedPlayerRotation, RotationAxis);


		SetParameter(rotationValue);
		CurrentParameterValue = rotationValue;
	}

	private float Clamp180(float value)
	{
		while (value > 180)
			value -= 360;
		while (value < -180)
			value += 180;

		return value;
	}
}