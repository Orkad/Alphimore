using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Linq;
using System;

public static class ColorExtention{
	public static Vector3 ToVector3(this Color c){
		return new Vector3(c.r,c.g,c.b);
	}

	public static Color ToColor(this Vector3 v){
		return new Color(v.x,v.y,v.z);
	}

	public static Color WithAlpha(this Color c,float alpha){
		return new Color(c.r,c.g,c.b,alpha);
	}
}

public static class StringExtensions{
	//MUST BE [width]x[height]x[rate]
	public static Resolution ToResolution(this string str){
		string[] tab = new string[3];
		tab = str.Split(new char[]{'x'},3);
		Resolution ret = new Resolution();
		ret.width = int.Parse(tab[0]);
		ret.height = int.Parse(tab[1]);
		ret.refreshRate = int.Parse(tab[2]);
		return ret;
	}

	public static string ToCustomString(this Resolution res){
		return res.width + "x" + res.height + "x" + res.refreshRate;
	}
}


public static class RPCExtension{
	public static string Serialize (this object obj)
	{
		StringBuilder xml = new StringBuilder();

		XmlSerializer serializer = new XmlSerializer(obj.GetType());

		using (TextWriter textWriter = new StringWriter(xml))
		{
			serializer.Serialize(textWriter, obj);
		}

		return xml.ToString();
	}

	public static T Deserialize<T>(this string xml){
		T obj = default(T);
		XmlSerializer serializer = new XmlSerializer(typeof(T));
		using (TextReader textReader = new StringReader(xml))
		{
			obj = (T)serializer.Deserialize(textReader);
		}
		return obj;
	}
}

public static class GameObjectExtensions
{
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

	/// <summary>
	/// Returns all monobehaviours (casted to T)
	/// </summary>
	/// <typeparam name="T">interface type</typeparam>
	/// <param name="gObj"></param>
	/// <returns></returns>
	public static T[] GetInterfaces<T>(this GameObject gObj)
	{
		if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");
		var mObjs = gObj.GetComponents<MonoBehaviour>();

		return (from a in mObjs where a.GetType().GetInterfaces().Any(k => k == typeof(T)) select (T)(object)a).ToArray();
	}

	/// <summary>
	/// Returns the first monobehaviour that is of the interface type (casted to T)
	/// </summary>
	/// <typeparam name="T">Interface type</typeparam>
	/// <param name="gObj"></param>
	/// <returns></returns>
	public static T GetInterface<T>(this GameObject gObj)
	{
		if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");
		return gObj.GetInterfaces<T>().FirstOrDefault();
	}

	/// <summary>
	/// Returns the first instance of the monobehaviour that is of the interface type T (casted to T)
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="gObj"></param>
	/// <returns></returns>
	public static T GetInterfaceInChildren<T>(this GameObject gObj)
	{
		if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");
		return gObj.GetInterfacesInChildren<T>().FirstOrDefault();
	}

	/// <summary>
	/// Gets all monobehaviours in children that implement the interface of type T (casted to T)
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="gObj"></param>
	/// <returns></returns>
	public static T[] GetInterfacesInChildren<T>(this GameObject gObj)
	{
		if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");

		var mObjs = gObj.GetComponentsInChildren<MonoBehaviour>();

		return (from a in mObjs where a.GetType().GetInterfaces().Any(k => k == typeof(T)) select (T)(object)a).ToArray();
	}
}

public static class RectTransformExtensions
{
	public static void SetDefaultScale(this RectTransform trans) {
		trans.localScale = new Vector3(1, 1, 1);
	}
	public static void SetPivotAndAnchors(this RectTransform trans, Vector2 aVec) {
		trans.pivot = aVec;
		trans.anchorMin = aVec;
		trans.anchorMax = aVec;
	}

	public static Vector2 GetSize(this RectTransform trans) {
		return trans.rect.size;
	}
	public static float GetWidth(this RectTransform trans) {
		return trans.rect.width;
	}
	public static float GetHeight(this RectTransform trans) {
		return trans.rect.height;
	}

	public static void SetPositionOfPivot(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x, newPos.y, trans.localPosition.z);
	}

	public static void SetLeftBottomPosition(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x + (trans.pivot.x * trans.rect.width), newPos.y + (trans.pivot.y * trans.rect.height), trans.localPosition.z);
	}
	public static void SetLeftTopPosition(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x + (trans.pivot.x * trans.rect.width), newPos.y - ((1f - trans.pivot.y) * trans.rect.height), trans.localPosition.z);
	}
	public static void SetRightBottomPosition(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x - ((1f - trans.pivot.x) * trans.rect.width), newPos.y + (trans.pivot.y * trans.rect.height), trans.localPosition.z);
	}
	public static void SetRightTopPosition(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x - ((1f - trans.pivot.x) * trans.rect.width), newPos.y - ((1f - trans.pivot.y) * trans.rect.height), trans.localPosition.z);
	}

	public static void SetSize(this RectTransform trans, Vector2 newSize) {
		Vector2 oldSize = trans.rect.size;
		Vector2 deltaSize = newSize - oldSize;
		trans.offsetMin = trans.offsetMin - new Vector2(deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y);
		trans.offsetMax = trans.offsetMax + new Vector2(deltaSize.x * (1f - trans.pivot.x), deltaSize.y * (1f - trans.pivot.y));
	}
	public static void SetWidth(this RectTransform trans, float newSize) {
		SetSize(trans, new Vector2(newSize, trans.rect.size.y));
	}
	public static void SetHeight(this RectTransform trans, float newSize) {
		SetSize(trans, new Vector2(trans.rect.size.x, newSize));
	}
}

public static class MathExt{
	public static float Evaluate(float ratio,float min,float max,bool clamped = true){
		if(clamped)
			ratio = Mathf.Clamp01(ratio);
		return (max - min) * ratio + min;
	}

	public static float Ratio(float value,float min,float max,bool clamped = true){
		if(clamped)
			value = Mathf.Clamp(value,min,max);
		return (value - min) / (max - min);
	}

	public static float InverseRatio(float value,float min,float max,bool clamped = true){
		return 1 - Ratio(value,min,max,clamped);
	}

	public static float RandomByPercent(this float value,float percent){
		float maxValue = value + value * percent / 100f;
		float minValue = value - value * percent / 100f;
		return UnityEngine.Random.Range(minValue,maxValue);
	}
}