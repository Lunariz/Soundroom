using UnityEngine;
using System.Collections;

public class FMODParameter : MonoBehaviour
{
	public string Parameter;

	public float CurrentParameterValue;
	
	public ParameterModifier[] ParameterModifiers;

	[HideInInspector]
	public FMODEvent FMODEvent;

	public void Awake()
	{
		ParameterModifiers = GetComponentsInChildren<ParameterModifier>();

		for (int i = 0; i < ParameterModifiers.Length; i++)
		{
			ParameterModifier modifier = ParameterModifiers[i];

			modifier.FMODParameter = this;
		}
	}

	public void SetParameter(float value)
	{
		CurrentParameterValue = value;
		FMODEvent.SetParameter(Parameter, value);

		gameObject.name = Parameter + ": " + CurrentParameterValue;
	}
}
