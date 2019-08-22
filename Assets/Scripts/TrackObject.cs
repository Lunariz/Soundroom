using UnityEngine;

public enum TrackObject
{
	Head,
	LeftHand,
	RightHand
}

public static class TrackObjectUtility
{
	public static GameObject GetObject(TrackObject trackObject)
	{
		if (trackObject == TrackObject.Head)
		{
			return PlayerManager.Instance.Head;
		}
		if (trackObject == TrackObject.LeftHand)
		{
			return PlayerManager.Instance.LeftHand;
		}
		if (trackObject == TrackObject.RightHand)
		{
			return PlayerManager.Instance.RightHand;
		}

		return null;
	}
}