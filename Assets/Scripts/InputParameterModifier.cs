using UnityEngine;
using System.Collections;

public class InputParameterModifier : ParameterModifier
{
	public float CurrentParameterValue;
	public InputManager.InputSource Input;

	public void Update()
	{
		float inputValue = InputManager.Instance.GetAxis(Input);

		SetParameter(inputValue);
		CurrentParameterValue = inputValue;
	}
}