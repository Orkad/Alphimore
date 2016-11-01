using UnityEngine;
using System.Collections;


public class Hexa : MonoBehaviour
{
	private Renderer _rend;

  public enum HexConnexion
  {
    eHexUp,
    eHexDown,
    eHexLeft,
    eHexRight,
  };


  public Hexa Up;
  public Hexa Dw;
  public Hexa Left;
  public Hexa Right;

  public int MapPosX;
  public int MapPosY;


  void Start ()
	{
		_rend = GetComponent<Renderer> ();
	}

	void OnMouseEnter()
	{
		_rend.material.color = Color.red;
	}

	void OnMouseOver()
	{
		//_rend.material.color = new Color (0.1f, 0, 0) * Time.deltaTime;
	}

	void OnMouseExit()
	{
    _rend.material.color = new Color(1, 1, 1, 0.35f);
	}

  public void UpdateHexa(Hexa LinkedHexa, HexConnexion type)
  {
    switch(type)
    {
      case HexConnexion.eHexDown:
        {
          Dw = LinkedHexa;
        }
        break;
      case HexConnexion.eHexUp:
        {
          Up = LinkedHexa;
        }
        break;
      case HexConnexion.eHexLeft:
        {
          Left = LinkedHexa;
        }
        break;
      case HexConnexion.eHexRight:
        {
          Right = LinkedHexa;
        }
        break;
    }

  }


}
