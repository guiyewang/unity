using UnityEngine;
using System.Collections;
using DG.Tweening;

public class test : MonoBehaviour
{

    public Transform target;     //旋转物体
    private int MouseWheelSensitivity = 15;//滚轮快慢
    private int MouseZoomMin = 2; //视角最大最小值
    private int MouseZoomMax = 10;
    private float normalDistance = 5; //初始位置距离大小

    private Vector3 normalized;


    private float xSpeed = 600.0f; //控制旋转速度
    private float ySpeed = 600.0f;

    private int yMinLimit = 10;  //限制角度
    private int yMaxLimit = 70;

    private float x = 0.0f;
    private float y = 0.0f;

    private Vector3 screenPoint;
    private Vector3 offset;


    private Quaternion rotation = Quaternion.Euler(new Vector3(30f, 0f, 0f));//角度变化
    private Vector3 CameraTarget;
    //------定义变量

    //定义缓动值



    void Start()


    {


        target.position = Vector3.zero;//物体初始位置回归坐标原点
        //初始角度位置的变化
        CameraTarget = target.position;//获取target的三维坐标

        float z = target.transform.position.z - normalDistance;  //得到初始位置
        transform.position = rotation * new Vector3(transform.position.x, transform.position.y, z);

        transform.LookAt(target);

        var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    void Update()
    {






        if (Input.GetMouseButton(0))//判断鼠标点击
        {

            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            var rotation = Quaternion.Euler(y, x, 0);
            var position = rotation * new Vector3(0.0f, 0.0f, -normalDistance) + CameraTarget;

            transform.rotation = rotation;
            transform.position = position;

        }

        else if (Input.GetAxis("Mouse ScrollWheel") != 0)//滑动鼠标时发生的情况
        {
            normalized = (transform.position - CameraTarget).normalized;

            if (normalDistance >= MouseZoomMin && normalDistance <= MouseZoomMax)
            {
                normalDistance -= Input.GetAxis("Mouse ScrollWheel") * MouseWheelSensitivity;
            }
            if (normalDistance < MouseZoomMin)
            {
                normalDistance = MouseZoomMin;
            }
            if (normalDistance > MouseZoomMax)
            {
                normalDistance = MouseZoomMax;
            }
            transform.position = normalized * normalDistance;

        }
        else if (Input.GetMouseButtonDown(2))//
        {
            screenPoint = Camera.main.WorldToScreenPoint(target.transform.position);
            offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }


        //鼠标中间点击后位置移动

        /*	if(Input.GetMouseButton(2))
            {
                 Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

                Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
                 target.transform.position = curPosition;
            }
                transform.LookAt(CameraTarget);
            */
    }

    /// <summary>
    /// 角度限制
    /// </summary>
    /// <param name="angle"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}