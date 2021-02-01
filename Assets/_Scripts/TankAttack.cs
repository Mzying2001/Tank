using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    public GameObject shellPrefab;          //子弹的预制体
    public KeyCode fireKey = KeyCode.Space; //发射子弹的按键

    public float shellSpeed = 10; //子弹发射的初速度
    public AudioClip shotAudio;   //发射子弹的音效

    private Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform.Find("FirePoint");
    }

    // Update is called once per frame
    void Update()
    {
        //按下按键后实例化一个子弹
        if (Input.GetKeyDown(fireKey))
        {
            AudioSource.PlayClipAtPoint(shotAudio, transform.position);
            var shell = Instantiate(shellPrefab, firePoint.position, firePoint.rotation);
            shell.GetComponent<Rigidbody>().velocity = shell.transform.forward * shellSpeed;
        }
    }
}
