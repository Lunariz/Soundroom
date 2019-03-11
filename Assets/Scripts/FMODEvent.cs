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
	}
}
