using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
	public static PlayerManager Instance;

	public GameObject Player;

	public void Awake()
	{
		Instance = this;
	}
}
