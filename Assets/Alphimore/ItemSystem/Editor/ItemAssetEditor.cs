using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(ItemAsset))]
public class TestOnInspector : Editor
{
	int currentId = 1;
	public override void OnInspectorGUI()
	{
		ItemAsset itemAsset = target as ItemAsset;
		List<Item> items = itemAsset.itemList;
		EditorGUILayout.LabelField("Note aux créateurs d'item", EditorStyles.boldLabel);
		EditorGUILayout.LabelField ("Il vous sera possible de créer vos item via ce panel");
		EditorGUILayout.LabelField ("=> une item est associée a un id");
		EditorGUILayout.LabelField ("=> une item créé ne peut etre retirée, uniquement modifiée");
		EditorGUILayout.LabelField("Item Database", EditorStyles.boldLabel);

		EditorGUILayout.BeginHorizontal ();
		if (GUILayout.Button ("<<") && currentId > 11)currentId = currentId - 10;
		if (GUILayout.Button ("<") && currentId > 1)currentId--;
		if (GUILayout.Button ("+")) {
			items.Add (new Item ());
			currentId = items.Count;
		}
		if (GUILayout.Button (">") && currentId < items.Count)currentId++;
		if (GUILayout.Button (">>") && currentId < items.Count - 10)currentId = currentId + 10;

		EditorGUILayout.EndHorizontal ();
		EditorGUILayout.LabelField ("Item ID => " + currentId.ToString() + " <=");
		items [currentId - 1].sprite = (Sprite)EditorGUILayout.ObjectField("Icon", items [currentId - 1].sprite, typeof(Sprite), false);

		items [currentId - 1].name = EditorGUILayout.TextField (new GUIContent ("Name"), items [currentId - 1].name);

		EditorGUILayout.LabelField("Description");
		items [currentId - 1].description = EditorGUILayout.TextArea (items [currentId - 1].description,GUILayout.MaxHeight(100));
	}
}