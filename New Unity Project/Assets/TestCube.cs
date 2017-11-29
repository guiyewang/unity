using UnityEngine;
using System.Collections;

public class TestCube : MonoBehaviour
{
    private GameObject rotateObj;
    private GameObject camera;
    public float speed =80f;

    private bool rotate = false;

    public float maxView = 90;
    public float minView = 10;
    void Start()
    {
        rotateObj = GameObject.Find("Rotate");
        camera = GameObject.Find("Main Camera");
    }
    void Update()
    {
        //滑动鼠标滑轮控制视角的大小
        float offsetView = Input.GetAxis("Mouse ScrollWheel") * speed;
        float tmpView = offsetView + Camera.main.fieldOfView;
        tmpView = Mathf.Clamp(tmpView, minView, maxView);
        Camera.main.fieldOfView = tmpView;

        //绕主角旋转摄像机
        if (rotate)
        {
            camera.transform.RotateAround(transform.position, Vector3.up, speed * Input.GetAxis("Mouse X"));
        }
        if (Input.GetMouseButtonDown(0))
        {
            rotate = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            rotate = false;
        }
    }
}