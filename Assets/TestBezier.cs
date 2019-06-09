using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBezier : MonoBehaviour
{
    public Transform targe3;
    [Header("开始目标")]
    public Transform targe1;
    [Header("控制点高度")]
    public float hight;
    [Header("终点目标")]
    public Transform targe2;
    [Header("速度")]
    public float speed = 1;
    float t;
    [Header("是否开始移动")]
    public bool isMove = false;//手动控制
    List<Vector3> path;

    void Awake()
    {
        var controlPoint = BezierUtils.GetControlPoint(targe1.position,targe2.position,hight);
        targe3.position = controlPoint;
        path = BezierUtils.GetBeizerList(targe1.position, controlPoint, targe2.position);
    }
    /// <summary>
    /// 寻路模拟
    /// </summary>
    /// <param name="path"></param>
    public void FindPath(List<Vector3> path)
    {
        t += Time.deltaTime;
        if (t >= speed)
        {
            t = 0;
            if (path != null && path.Count > 0)
            {
                var startPos = path[0];            
                targe1.transform.position = startPos;
                path.Remove(startPos);
            }
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMove = true;
        }
        if (isMove == true)
        {
            FindPath(path);
        }

    }
}
