using UnityEngine;
using System.Collections;

public class FMODParameter : MonoBehaviour
{
	public string Parameter;
	public ParameterModifier[] ParameterModifiers;

	[HideInInspector]
	public FMODEvent FMODEvent;

	public void Awake()
	{
		for (int i = 0; i < ParameterModifiers.Length; i++)
		{
			ParameterModifier modifier = ParameterModifiers[i];

			modifier.FMODParameter = this;
		}
	}

	public void SetParameter(float value)
	{
		FMODEvent.SetParameter(Parameter, value);
	}
}
