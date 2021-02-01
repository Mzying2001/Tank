using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public int hp = 100;
    public GameObject tankExplosion;
    public AudioClip tankExplosionAudio;
    public Slider hpSlider;

    private int hpTotal;

    // Start is called before the first frame update
    void Start()
    {
        hpTotal = hp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TakeDamage()
    {
        if (hp <= 0)
            return;

        if ((hp -= Random.Range(10, 20)) <= 0)
        {
            AudioSource.PlayClipAtPoint(tankExplosionAudio, transform.position);
            Instantiate(tankExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        hpSlider.value = (float)hp / hpTotal;
    }
}
