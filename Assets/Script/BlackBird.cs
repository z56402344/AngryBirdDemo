using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : Bird
{
   public List<Pig> list = new List<Pig>();

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            list.Add(collision.gameObject.GetComponent<Pig>());
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            list.Remove(collision.gameObject.GetComponent<Pig>());
        }
    }

    public override void ShowSkill()
    {
        base.ShowSkill();
        if (Input.GetMouseButtonDown(0) && list != null && list.Count > 0)
        {
            for (int i = 0; i< list.Count; i++)
            {
                list[i].Dead();
            }
            Clear();
        }
    }

    public void Clear()
    {
        Instantiate(boom, transform.position, Quaternion.identity);
        rd.velocity = Vector3.zero;
        GetComponent<CircleCollider2D>().enabled = false;
        spriteRenderer.enabled = false;
        mt.ClearTrail();
    }

    public override void Next()
    {
        AudioPlay(selectAudio);
        GameManager._Instance.birds.Remove(this);
        Destroy(gameObject);
        GameManager._Instance.NextBird();
    }


}
