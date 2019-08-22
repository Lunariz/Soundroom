using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Hand : MonoBehaviour
{
	public XRNode NodeType;
	public string TriggerButton;

	private Vector3 m_baseScale;

	public void Start()
	{
		XRDevice.SetTrackingSpaceType(TrackingSpaceType.RoomScale);

		m_baseScale = gameObject.transform.localScale;
	}

	public void Update()
	{
		transform.localPosition = InputTracking.GetLocalPosition(NodeType);
		transform.localRotation = InputTracking.GetLocalRotation(NodeType);

		if (Input.GetAxis(TriggerButton) >= 0.1f)
		{
			gameObject.transform.localScale = m_baseScale / 2;
		}
		else
		{
			gameObject.transform.localScale = m_baseScale;
		}
	}
}
