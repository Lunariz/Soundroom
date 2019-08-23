using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Linq;

[CustomEditor(typeof(FMODParameter))]
public class FMODParameterInspector : Editor
{
	public override void OnInspectorGUI()
	{
		FMODParameter FMODParameter = (FMODParameter) target;

		if (GUILayout.Button("Add Position Modifier"))
		{
			GameObject newParamModifierGO = new GameObject("Position Modifier");
			ParameterModifier newParamModifier = newParamModifierGO.AddComponent<PositionParameterModifier>();
			newParamModifierGO.transform.parent = FMODParameter.transform;
			Selection.activeGameObject = newParamModifierGO;
		}
		if (GUILayout.Button("Add Velocity Modifier"))
		{
			GameObject newParamModifierGO = new GameObject("Velocity Modifier");
			ParameterModifier newParamModifier = newParamModifierGO.AddComponent<VelocityParameterModifier>();
			newParamModifierGO.transform.parent = FMODParameter.transform;
			Selection.activeGameObject = newParamModifierGO;
		}
		if (GUILayout.Button("Add Facing Angle Modifier"))
		{
			GameObject newParamModifierGO = new GameObject("Facing Angle Modifier");
			ParameterModifier newParamModifier = newParamModifierGO.AddComponent<FacingAngleParameterModifier>();
			newParamModifierGO.transform.parent = FMODParameter.transform;
			Selection.activeGameObject = newParamModifierGO;
		}
		if (GUILayout.Button("Add Input Modifier"))
		{
			GameObject newParamModifierGO = new GameObject("Input Modifier");
			ParameterModifier newParamModifier = newParamModifierGO.AddComponent<InputParameterModifier>();
			newParamModifierGO.transform.parent = FMODParameter.transform;
			Selection.activeGameObject = newParamModifierGO;
		}

		ParameterModifier[] modifiers = FMODParameter.GetComponentsInChildren<ParameterModifier>().Where(m => m.enabled).ToArray();
		FMODParameter.ParameterModifiers = modifiers;

		if (!Application.isPlaying && FMODParameter.gameObject.name != FMODParameter.Parameter)
		{
			if (string.IsNullOrEmpty(FMODParameter.Parameter))
			{
				FMODParameter.gameObject.name = "New Parameter";
			}
			else
			{
				FMODParameter.gameObject.name = FMODParameter.Parameter;
			}
		}

		base.OnInspectorGUI();
	}
}
