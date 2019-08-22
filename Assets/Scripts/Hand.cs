using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Hand : MonoBehaviour
{
	public XRNode NodeType;

	public void Start()
	{
		//XRDevice.SetTrackingSpaceType(TrackingSpaceType.RoomScale);
	}

	public void Update()
	{
		transform.localPosition = InputTracking.GetLocalPosition(NodeType);
		transform.localRotation = InputTracking.GetLocalRotation(NodeType);
	}
}
