using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform player1; //坦克1
    public Transform player2; //坦克2

    private Camera camera;  //相机组件
    private Vector3 offset; //视角的偏移量

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        offset = transform.position - (player1.position + player2.position) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 == null || player2 == null)
            return;

        //改变相机的位置
        transform.position = (player1.position + player2.position) / 2 + offset;

        //获取两个坦克之间的距离
        float distance = Vector3.Distance(player1.position, player2.position);
        if (distance < 5f)
            return;

        float size = distance * 0.875f; //获取size
        camera.orthographicSize = size; //修改相机的size属性
    }
}
