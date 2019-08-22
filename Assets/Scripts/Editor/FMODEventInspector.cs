using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(FMODEvent))]
public class FMODEventInspector : Editor
{
	public override void OnInspectorGUI()
	{
		FMODEvent FMODEvent = (FMODEvent) target;

		if (GUILayout.Button("Add Parameter"))
		{
			GameObject newParamGO = new GameObject("New Parameter");
			newParamGO.name = "New Parameter";
			FMODParameter newParam = newParamGO.AddComponent<FMODParameter>();
			newParamGO.transform.parent = FMODEvent.transform;
			Selection.activeGameObject = newParamGO;
		}

		FMODParameter[] parameters = FMODEvent.GetComponentsInChildren<FMODParameter>();
		FMODEvent.Parameters = parameters;

		base.OnInspectorGUI();
	}
}
