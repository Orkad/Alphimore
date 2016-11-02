using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ProgressBar : MonoBehaviour {
	public RectTransform emptyArea;
	public RectTransform fillArea;
	public RectTransform.Axis axis;
	public float value;
	public float minValue;
	public float maxValue;

	protected void Update () {
		value = Mathf.Clamp(value,minValue,maxValue);
		//fillArea.sizeDelta = new Vector2(emptyArea.sizeDelta.x *MathExt.Ratio(value,minValue,maxValue),emptyArea.sizeDelta.y);
		if(axis == RectTransform.Axis.Horizontal)
			fillArea.SetSizeWithCurrentAnchors(axis,MathExt.Ratio(value,minValue,maxValue)*emptyArea.sizeDelta.x);
		else
			fillArea.SetSizeWithCurrentAnchors(axis,MathExt.Ratio(value,minValue,maxValue)*emptyArea.sizeDelta.y);
	}


}
