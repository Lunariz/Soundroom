using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;

public class PlayerManager : MonoBehaviour
{
	public static PlayerManager Instance;

	public Player Player;

	public void Awake()
	{
		Instance = this;

		Player = Player.instance;
	}
}
