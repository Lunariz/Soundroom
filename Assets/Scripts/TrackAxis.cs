using UnityEngine;

public enum TrackAxis
{
	X,
	Y,
	Z,
	Magnitude
}

public static class TrackAxisUtility
{
	public static float GetValue(Vector3 vector, TrackAxis trackAxis)
	{
		if (trackAxis == TrackAxis.X)
		{
			return vector.x;
		}
		else if (trackAxis == TrackAxis.Y)
		{
			return vector.y;
		}
		else if (trackAxis == TrackAxis.Z)
		{
			return vector.z;
		}
		else if (trackAxis == TrackAxis.Magnitude)
		{
			return vector.magnitude;
		}

		return 0;
	}
}