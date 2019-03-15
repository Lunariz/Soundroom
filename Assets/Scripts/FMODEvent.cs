using UnityEngine;
using FMODUnity;
using System.Collections;

[RequireComponent(typeof(FMODUnity.StudioEventEmitter))]
public class FMODEvent : MonoBehaviour
{
	public FMODParameter[] Parameters;

	private StudioEventEmitter m_event;

	public void Awake()
	{
		m_event = GetComponent<StudioEventEmitter>();

		for (int i = 0; i < Parameters.Length; i++)
		{
			FMODParameter modifier = Parameters[i];

			modifier.FMODEvent = this;
		}
	}

	public void SetParameter(string parameter, float value)
	{
		m_event.SetParameter(parameter, value);
	}
}
