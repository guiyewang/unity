using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class UImate : MonoBehaviour {

    private string Imgname;

    private Material mat;

    private Texture[] maps;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        //当点击鼠标左键时
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                //点到了UGUI
               Imgname= EventSystem.current.currentSelectedGameObject.name;

                getmate();

                getTexture();
                //print(Imgname);

                for (int i = 0; i < maps.Length; i++)
                {


                    string aa=  maps[i].name;
                    if (Imgname.Equals(aa))
                     {
                         mat.SetTexture(Imgname, maps[i]);

                        mat.mainTexture = maps[i];


                     }
                     
                 
                }



                

            }
        }
    }



    void getmate()
    {
        mat =  Resources.Load("Materials/zong") as Material;

       
    
    }

    void getTexture()
    {
        maps = Resources.LoadAll<Texture>("Textures") ;
    }

}
