using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float speed = 5;        //坦克的移动速度
    public float angularSpeed = 5; //坦克的旋转速度
    public float number = 1;       //玩家编号

    public AudioClip idleAudio;    //停止声音
    public AudioClip drivingAudio; //发动声音

    private Rigidbody body;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //通过上下键控制坦克移动
        float v = Input.GetAxis("VerticalP" + number);
        body.velocity = transform.forward * v * speed;

        //通过左右键控制坦克旋转
        float h = Input.GetAxis("HorizontalP" + number);
        body.angularVelocity = transform.up * h * angularSpeed;

        if (Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f)
            audio.clip = drivingAudio;
        else
            audio.clip = idleAudio;

        if (!audio.isPlaying)
            audio.Play();
    }
}
