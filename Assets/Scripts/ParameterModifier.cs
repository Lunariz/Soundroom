using UnityEngine;
using System.Collections;

public class ParameterModifier : MonoBehaviour
{
	[HideInInspector]
	public FMODParameter FMODParameter;

	public virtual void SetParameter(float value)
	{
		if (FMODParameter)
		{
			FMODParameter.SetParameter(value);
		}
	}
}
