using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Orkad{
	
	private static bool MouseHoverUI(){
		return UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
	}

	private static List<T> ScreenRectCast<T>(Rect screenRect)where T:MonoBehaviour{
		List<T> objectsInside = new List<T>();
		foreach(T obj in GameObject.FindObjectsOfType<T>()){
			if(obj.GetComponent<Renderer>().isVisible){
				if(screenRect.Contains((Vector2)Camera.main.WorldToScreenPoint(obj.transform.position)))
					objectsInside.Add(obj);
			}
		}
		return objectsInside;
	}

	private static Rect CreateScreenRect(Vector2 v1,Vector2 v2){
		if(v1.x < v2.x)
		if(v1.y < v2.y)
			return new Rect(v1.x,v1.y,v2.x - v1.x,v2.y - v1.y);
		else
			return new Rect(v1.x,v2.y,v2.x - v1.x,v1.y - v2.y);
		else
			if(v1.y < v2.y)
				return new Rect(v2.x,v1.y,v1.x - v2.x,v2.y - v1.y);
			else
				return new Rect(v2.x,v2.y,v1.x - v2.x,v1.y - v2.y);
	}

	public static T MouseRaycast<T>()where T:class{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // créé le ray correspondant de la main camera vers la position de ta souris
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit)) // si le raycast rencontre quelque chose
		if(hit.collider.GetComponent<T>() != null) // si le raycast trouve un objet du type T
			return hit.collider.GetComponent<T>(); // retourne l'objet T
		return null;
	}

	private static Vector3 MousePositionOnPlane(){
		Plane p = new Plane(Vector3.zero,Vector3.forward,Vector3.right);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float distance;
		if(p.Raycast(ray,out distance))
			return ray.GetPoint(distance);
		return Vector3.zero;
	}
}
