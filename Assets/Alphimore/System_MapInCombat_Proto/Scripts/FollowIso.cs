using UnityEngine;
using System.Collections;

public class FollowIso : MonoBehaviour
{
  public GUISkin CharacterSkin;
  public Vector3 Offset;
  public Transform Target;
  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Vector3 NewPos = (Target.position + Offset);
    //transform.position = new Vector3(NewPos.x, transform.position.y, NewPos.z);

  }

  bool GuiPressed = false;
  bool ShootDone = false;

  void OnGUI()
  {
    if (CharacterSkin != null)
    GUI.skin = CharacterSkin;
    Vector3 RectPoint = Camera.main.WorldToScreenPoint(Target.position+Vector3.up*12);
    if (ShootDone == false)
    GuiPressed = GUI.Button(new Rect(10, 10, 420, 150), "<color=yellow>Bienvenue</color> sur <color=red>Alphimore</color>!\n\n Vous commencé par la phase d'apprentissage de la magie. Par la suite vous monterez en grade afin de pouvoir enquêter sur les phénomènes qui ont bouleversé le monde il y a 25 ans.");
    if ((GuiPressed) && (ShootDone == false))
    {
      Application.CaptureScreenshot("MyCapteur.png");
      ShootDone = true;
    }
    else if (GuiPressed == false)
      ShootDone = false;
    GUI.Label(new Rect(RectPoint.x - 100, Screen.height - RectPoint.y, 200, 150), "<color=black>JDALIZ\n<Elfes></color>\n");
    GUI.Label(new Rect(RectPoint.x - 102, Screen.height - RectPoint.y-2, 200, 150), "<color=#55FF55>JDALIZ</color>\n<color=yellow><Elfes></color>\n");


  }
}
