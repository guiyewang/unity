using UnityEngine;
using System.Collections;

public class Cut : MonoBehaviour {


    public Camera Frcamera ;
    public Camera Ancameta;

   public void freedon()
    {
        if (Frcamera.depth < 1)
        {
            Frcamera.depth = 2;
           // Camera.main.enabled = true;
        }
    }



   public void animations()
    {
        if (Frcamera.depth > 1)
        {
            Frcamera.depth = 0;
          //  Camera.main.enabled = false;
        }
    }
}
