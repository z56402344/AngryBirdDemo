using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public float maxSpeed = 10;
    public float minSpeed = 5;

    private SpriteRenderer sr;
    public Sprite sprite;
    public GameObject boom;
    public GameObject score;
    public bool isPig;

    public AudioClip dieAudio;//死亡
    public AudioClip hurtAudio;//受伤
    public AudioClip birdAudio;//触碰

    public void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        AudioPlay(birdAudio);
        //collision.relativeVelocity.magnitude 是受到的相对速度
        if (collision.relativeVelocity.magnitude > maxSpeed)
        {
            //死亡逻辑
            Dead();

        }
        else if (collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude < maxSpeed)
        {
            //受伤逻辑,切换受伤图片
            sr.sprite = sprite;
            AudioPlay(hurtAudio);
        }
    }

   public void Dead()
    {
        if (isPig)
        {
            Destroy(gameObject);
            Instantiate(boom, transform.position, Quaternion.identity);

            GameObject go = Instantiate(score, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            Destroy(go, 4);
            GameManager._Instance.pigs.Remove(this);
            AudioPlay(dieAudio);
        }

    }

    public void AudioPlay(AudioClip audioClip)
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }
}
