using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class CameraRay : MonoBehaviour {

    private  Ray cr; //射线
    private RaycastHit rs;//碰撞信息

    private int Sw;//屏幕宽度
    private int Sh;//屏幕高度
    private float DJw; //点击处

    private float dhx;//最后定位到XY
    private float dhy;
    private int jbx;

    private float sf=0;
    public Image img;
    private float DJy;

    private float bianhua;

    //private Color Acol;


    void Start()
    {
        bianhua = 2f;
    }

    // Update is called once per frame
    void Update () {



        if (Input.GetMouseButtonDown(0)&&Camera.main.depth>1&& bianhua >= 2)
        {

            //初始化判断条件
           

            Sw = Screen.width;//获取屏幕大小

            Sh = Screen.height;//获取屏幕高度

        //  print(Screen.width);
        //  print(Input.mousePosition);
            cr = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(cr,out rs))
            {

                bianhua = 0;

                DJw = Input.mousePosition.x;//获取点击值
                DJy = Input.mousePosition.y;

                sf = 0;
                print(rs.transform.name);
                if (DJw < (Sw / 2))
                   {
                    jbx = Sw / 6;
                }
                else
                {
                    jbx = Sw / 6 * 5;
                }
            


                dhx = Input.mousePosition.x;
                dhy = Input.mousePosition.y;


                DOTween.To(() => sf, sa => sf = sa, 1, 2);
                DOTween.To(() => dhy, sa => dhy = sa, Sh / 5*3, 2);
                DOTween.To(() => dhx, xa => dhx = xa, jbx, 2);
    
                print(Input.mousePosition);


                DOTween.To(() => bianhua, xa => bianhua = xa, 2, 3);

               
            }


        }
        img.transform.position = new Vector3(dhx, dhy, 0);
        img.transform.localScale = new Vector3(sf, sf, sf);
        img.color = new Color(1, 1, 1, sf);
        


  

       

    }



    public void shouhui()
    {
        if(bianhua >= 2)
        {
            DOTween.To(() => sf, sa => sf = sa, 0, 1);
            DOTween.To(() => dhy, sa => dhy = sa, DJy, 1);
            DOTween.To(() => dhx, xa => dhx = xa, DJw, 1);
        }
    }



}
