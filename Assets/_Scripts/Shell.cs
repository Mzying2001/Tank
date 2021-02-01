using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject shellExplosionPrefab;
    public AudioClip shellExplosionAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //播放子弹爆炸音效
        AudioSource.PlayClipAtPoint(shellExplosionAudio, transform.position);

        //实例化爆炸效果，完成后销毁
        Instantiate(shellExplosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);

        //像坦克发送伤害信息
        if (other.tag is "Tank")
            other.SendMessage("TakeDamage");
    }
}
