using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	public static InputManager Instance;

	public enum InputType
	{
		Button,
		Axis
	}

	public enum InputSource
	{
		LeftTrigger,
		RightTrigger,
		LeftThumbstickX,
		LeftThumbstickY,
	}

	[System.Serializable]
	public class Input
	{
		public string InputName;
		public InputSource InputSource;
		public InputType InputType;
	}

	public Input[] Inputs;

	private Dictionary<InputSource, Input> m_inputs = new Dictionary<InputSource, Input>();

	public void Awake()
	{
		Instance = this;

		foreach (Input input in Inputs)
		{
			m_inputs[input.InputSource] = input;
		}
	}

	public float GetAxis(InputSource inputSource)
	{
		if (!m_inputs.ContainsKey(inputSource))
		{
			Debug.LogError("Input is not registered: " + inputSource + ", check the InputManager");
			return 0;
		}

		Input input = m_inputs[inputSource];

		if (input.InputType == InputType.Axis)
		{
			return UnityEngine.Input.GetAxis(input.InputName);
		}
		else
		{
			return UnityEngine.Input.GetButton(input.InputName) ? 1 : 0;
		}
		
	}

	public bool GetButton(InputSource inputSource, float minAxisTrigger = 0)
	{
		if (!m_inputs.ContainsKey(inputSource))
		{
			Debug.LogError("Input is not registered: " + inputSource + ", check the InputManager");
			return false;
		}

		Input input = m_inputs[inputSource];

		if (input.InputType == InputType.Axis)
		{
			return UnityEngine.Input.GetAxis(input.InputName) > minAxisTrigger;
		}
		else
		{
			return UnityEngine.Input.GetButton(input.InputName);
		}
	}
}

