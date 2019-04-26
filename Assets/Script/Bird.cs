using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isClick;
    public Transform rightPos;
    public Transform leftPos;
    public float maxDic = 3;

    [HideInInspector]//让字段不显示在面板中
    public SpringJoint2D sp;
    private Rigidbody2D rd;
    private TestMyTrail mt;
    public LineRenderer rightRender;
    public LineRenderer leftRender;

    public GameObject boom;
    private bool canMove = true;//解决连续点击鼠标小鸟回收的bug

    public float smooth = 3;//摄像机平滑速度
    public AudioClip flyAudio;
    public AudioClip selectAudio;


    public void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rd = GetComponent<Rigidbody2D>();
        mt = GetComponent<TestMyTrail>();
    }

    //鼠标按下事件
    public void OnMouseDown()
    {
        if (canMove)
        {
            isClick = true;
            rd.isKinematic = true;
        }
    }

    //鼠标弹起事件
    public void OnMouseUp()
    {
        if (canMove)
        {
            AudioPlay(flyAudio);
            isClick = false;
            rd.isKinematic = false;
            //sp.enabled = false;
            Invoke("Fly", 0.1f);

            //清除皮筋划线
            rightRender.enabled = false;
            leftRender.enabled = false;
            canMove = false;
        }
    }

    public void Update()
    {
        if (isClick)
        {
            //屏幕坐标转世界坐标
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += new Vector3(0,0,10);

            //如果bird的position和弹弓上的标记 的distance 大于设置的最大值，需要限制一下长度
            if (Vector3.Distance(transform.position, rightPos.position) > maxDic)
            {
                Vector3 pos = (transform.position - rightPos.position).normalized;//单位化向量
                pos *= maxDic;//最大长度向量
                transform.position = pos + rightPos.position;
            }
            Line();
        }

        float posX = transform.position.x;
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position,new Vector3(Mathf.Clamp(posX,0,15),Camera.main.transform.position.y,Camera.main.transform.position.z),smooth * Time.deltaTime);

    }

    public void Fly()
    {
        mt.StartTrail();
        sp.enabled = false;
        Invoke("Next",4);
    }


    //弹弓拉的皮带
    public void Line()
    {
        rightRender.enabled = true;
        leftRender.enabled = true;

        rightRender.SetPosition(0,rightPos.position);
        rightRender.SetPosition(1, transform.position);


        leftRender.SetPosition(0, leftPos.position);
        leftRender.SetPosition(1, transform.position);
    }

    public void Next()
    {
        AudioPlay(selectAudio);
        GameManager._Instance.birds.Remove(this);
        Destroy(gameObject);
        Instantiate(boom,transform.position,Quaternion.identity);
        GameManager._Instance.NextBird();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        mt.ClearTrail();
    }

    public void AudioPlay(AudioClip audioClip)
    {
        AudioSource.PlayClipAtPoint(audioClip,transform.position);
    }

}
