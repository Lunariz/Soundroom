using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
	public static PlayerManager Instance;

	public GameObject Head;
	public GameObject LeftHand;
	public GameObject RightHand;

	public void Awake()
	{
		Instance = this;
	}
}
