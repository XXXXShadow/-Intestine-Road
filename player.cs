using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    Animator MainAnimator;
    Animator TransAnimator;
    Animator StartTransAnimator;
    Animator EndTransAnimator;
    Transform Player;
    public Transform Trans;
    public Transform StartTrans;
    public Transform EndTrans;
    BoxCollider2D PlayerBoxCollider;
    Rigidbody2D PlayerRigid;
    public bool b_Walk;
    [Header("移動速度")]
    public float f_Speed;
    [Header("跳躍高度")]
    public float f_JumpHeight;

    public bool b_canJump = true;
    public bool b_canMove = true;
    public bool b_OnGround;
    #region 動畫參數
    public bool b_Down;
    public bool b_Dead;
    public bool b_Respawn;
    public bool b_Jump;
    public bool b_JumpUp;
    public bool b_JumptoFall;
    public bool b_Fall;
    public bool b_ToGround;
    public bool b_Transition;
    public bool b_StartTransition;
    public bool b_EndTransition;
    #endregion

    Vector2 checkpoint;
    public bool ray = false;
    public Transform raystart,rayend;
    public bool ray2 = false;
    public Transform ray2start,ray2end;

    public AudioSource Slow;
    public AudioSource Fast;
    public AudioSource Dead;
    public AudioSource Jump;
    void Start()
    {
        b_StartTransition = true;
        Player = gameObject.transform;
        PlayerBoxCollider = gameObject.GetComponent<BoxCollider2D>();
        MainAnimator = Player.GetComponent<Animator>();
        TransAnimator = Trans.GetComponent<Animator>();
        StartTransAnimator = StartTrans.GetComponent<Animator>();
        EndTransAnimator = EndTrans.GetComponent<Animator>();
        PlayerRigid = Player.GetComponent<Rigidbody2D>();
        f_Speed = 0.08f;
        f_JumpHeight = 300;
        checkpoint = Player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MainAnimator.SetBool("ParaWalk", b_Walk);
        MainAnimator.SetBool("ParaDown", b_Down);
        MainAnimator.SetBool("ParaDead", b_Dead);
        MainAnimator.SetBool("ParaRespawn", b_Respawn);
        MainAnimator.SetBool("ParaJump", b_Jump);
        MainAnimator.SetBool("ParaJumpUp", b_JumpUp);
        MainAnimator.SetBool("ParaJumptoFall", b_JumptoFall);
        MainAnimator.SetBool("ParaFall", b_Fall);
        MainAnimator.SetBool("ParaToGround", b_ToGround);
        TransAnimator.SetBool("ParaTransition", b_Transition);
        StartTransAnimator.SetBool("ParaStartTransition", b_StartTransition);
        EndTransAnimator.SetBool("ParaEndTransition", b_EndTransition);
        b_Respawn = true;
        if (b_canMove)
        {
            #region 上鍵
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (b_canJump == true)
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.up * f_JumpHeight);
                    b_JumpUp = true;
                    b_canJump = false;
                    Jump.Play();
                }
            }
            #endregion

            #region 右鍵
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Player.eulerAngles = Vector3.zero;//將角色面向方向回歸初始值
                Player.Translate(f_Speed, 0, 0);
                b_Walk = true;
            }
            #endregion

            #region 左鍵
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Player.eulerAngles = new Vector3(0, 180, 0);//旋轉角色面向方向
                Player.Translate(f_Speed, 0, 0);
                b_Walk = true;
            }
            #endregion

            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
                b_Walk = false;
        }
        #region 下鍵
        if (b_canJump)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                b_Down = true;
                b_canMove = false;
                PlayerBoxCollider.size = new Vector2(3.78f, 1.77f);
                PlayerBoxCollider.offset = new Vector2(0, -0.98f);
            }
            else
            {
                b_Down = false;
                PlayerBoxCollider.size = new Vector2(3.78f, 2.65f);
                PlayerBoxCollider.offset = new Vector2(0, -0.51f);
            }
        }
        #endregion

        // if (Input.GetKey(KeyCode.D))
        // {
        //     Respawn();
        // }

        if (b_OnGround == false && PlayerRigid.velocity.y > 1)//上升中
        {
            b_Jump = true;
            b_JumpUp = false;
            b_JumptoFall = false;
            b_Fall = false;
        }
        if (b_OnGround == false && PlayerRigid.velocity.y > 0 && 1 > PlayerRigid.velocity.y)//最高點中
        {
            b_JumptoFall = true;
            b_JumpUp = false;
            b_Jump = false;
            b_Fall = false;
        }
        if (b_OnGround == false && PlayerRigid.velocity.y < 0)//下降中
        {
            b_Fall = true;
            b_JumpUp = false;
            b_Jump = false;
            b_JumptoFall = false;
        }

        Debug.DrawLine(raystart.position ,rayend.position ,Color.green);
        ray = Physics2D.Linecast(raystart.position ,rayend.position ,1 << LayerMask.NameToLayer("floor"));
        Debug.DrawLine(ray2start.position ,ray2end.position ,Color.green);
        ray2 = Physics2D.Linecast(ray2start.position ,ray2end.position ,1 << LayerMask.NameToLayer("floor"));
        if (ray == true || ray2 == true)
        {
            b_canJump = true;
            b_OnGround = true;

            b_JumpUp = false;
            b_Jump = false;
            b_JumptoFall = false;
            b_Fall = false;
            b_ToGround = true;
        }
        else
        {
            b_OnGround = false;
            b_ToGround = false;
        }
    }
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "floor")
    //     {
    //         b_canJump = true;
    //         b_OnGround = true;

    //         b_JumpUp = false;
    //         b_Jump = false;
    //         b_JumptoFall = false;
    //         b_Fall = false;
    //         b_ToGround = true;
    //     }
    // }//若碰到地板將跳躍中參數關閉
    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "floor")
    //     {
    //         b_OnGround = false;
    //         b_ToGround = false;
    //     }
    // }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Collider2D>().tag == "Respawn")
        {
            checkpoint = Player.transform.position;
            //Debug.Log(checkpoint);
        }
        if (collider.GetComponent<Collider2D>().tag == "Finish")
        {
            b_EndTransition = true;
            Invoke("NextScene",1f);
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "deadly_object")
        {
            Dead.Play();
            b_Dead = true;
            b_canMove = false;
        }
        if (collider.gameObject.tag == "slow")
        {
            f_Speed = 0.05f;
            Slow.Play();
        }
        if (collider.gameObject.tag == "fast")
        {
            f_Speed = 0.11f;
            Fast.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        b_Dead = false;
        f_Speed = 0.08f;
    }
    void DowntoIdleEnd()
    {
        b_canMove = true;
    }
    void TransitionStart()
    {
        b_Transition = true;
    }
    void TransitionEnd()
    {
        b_Transition = false;
    }
    void Respawn()
    {
        b_Respawn = true;
        Player.transform.position = checkpoint;
        b_canMove = true;
    }
    void NextScene()
    {
        SceneManager.LoadScene(3);
    }
}
