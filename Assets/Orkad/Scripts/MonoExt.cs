using UnityEngine;
using System.Collections;

/// <summary>
/// Utils Extension static class
/// </summary>
public static class MonoExt {
	
	/// <summary>
	/// Get the component or create it
	/// </summary>
	/// <returns>the component</returns>
	/// <param name="g">the gameobject to add or get the component</param>
	/// <typeparam name="T">The component wanted</typeparam>
	public static T GetOrAddComponent<T>(this GameObject g) where T : Component{
		if (g.GetComponent<T>() != null)
			return g.GetComponent<T> ();
		return g.AddComponent<T> ();
	}

}
