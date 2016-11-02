using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

//Creates a custom Label on the inspector for all the scripts named ScriptName
// Make sure you have a ScriptName script in your
// project, else this will not work.
[CustomEditor(typeof(ItemAsset))]
public class TestOnInspector : Editor
{
	int index = 1;
	public override void OnInspectorGUI()
	{
		ItemAsset itemAsset = target as ItemAsset;
		List<Item> items = itemAsset.itemList;
		EditorGUILayout.LabelField("Item Database", EditorStyles.boldLabel);
		EditorGUILayout.BeginHorizontal ();

		if (GUILayout.Button ("<") && index > 1)index--;
		if (GUILayout.Button (">") && index < items.Count)index++;
		EditorGUILayout.LabelField ("id = " + index.ToString());

		EditorGUILayout.EndHorizontal ();

		items [index - 1].sprite = (Sprite)EditorGUILayout.ObjectField("Icon", items [index - 1].sprite, typeof(Sprite), false, GUILayout.MaxWidth(200));

		items [index - 1].name = EditorGUILayout.TextField (new GUIContent ("Name"), items [index - 1].name);

		EditorGUILayout.LabelField("Description");
		items [index - 1].description = EditorGUILayout.TextArea (items [index - 1].description,GUILayout.MaxHeight(100));
	}
}