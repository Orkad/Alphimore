using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateItemAsset {
	[MenuItem("Assets/Create/Item Asset")]
	public static ItemAsset Create()
	{
		ItemAsset asset = ScriptableObject.CreateInstance<ItemAsset>();

		AssetDatabase.CreateAsset(asset, "Assets/ItemAsset.asset");
		AssetDatabase.SaveAssets();
		return asset;
	}
}