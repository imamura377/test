using UnityEngine;
using System.Collections;

public class unitymove : MonoBehaviour {//                 ーーーーーフィールドーーーーーーーーー
    public Transform tf;
    public Vector2 rb;
    public Rigidbody2D rb2;
    public float movespeed = 10f;//移動スピード
    public float jumppower = 100f;//ジャンプ力
    float h;//移動時のhorizontalの値を入れる
    bool isground;//地面判定
    public float heart = 5f;//体力
    private Animator anim;//アニメータの参照用
    float velo;
    public Rigidbody2D rg;//rigidbody2Dの参照用　　　　　ーーーーーースタートーーーーーー
	void Start () {
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
        
    }

    //ボタン入力関係はUpdateの中に              ーーーーーアップデートーーーーーーーー
    void Update() {
   

          //hに左押したら-1を右押したら1を入れる
        h = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Submit")){
            anim.SetTrigger("weapon");
        }

        if (Input.GetButtonDown("Jump") && isground)//ーーーーーーージャンプ関係ーーーーーーー
        {
            rb2.AddForce(Vector2.up * jumppower);
            isground = false;
            anim.SetTrigger("Jump");
            anim.SetBool("isGround", false);
 }

        if (rg.velocity.y < 0)//                          アニメーション落下時判定
        {
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("isFalling", false);
        }

    }


    void OnTriggerEnter2D(Collider2D collision)//          ーーーー衝突関係ーーーーーーーーーー
    {
        if (collision.tag == "ground")//             地面と接触時ジャンプ可能に
        {
            isground = true;
            anim.SetBool("isGround", true);//            着地モーション
        }

        if (collision.tag == "death")//             場外判定に触れたとき
        {
            GetComponent<Transform>().position = new Vector2(0, 1.6f);

        }

        if (collision.tag == "damage")
        {
            Damage();


        }
    }

    void Damage()//              ーーーーーーくらい判定ーーーーーー
    {
        if(heart != 0)
        {
            heart = heart - 1f;
        }else
        {
            GetComponent<Transform>().position = new Vector2(0, 1.6f);
            heart = 5f;
        }
    }
        

    //処理落ちが困るものはFixedUpdateの中に
    void FixedUpdate() {//                       ーーーーーーFixedUpdateーーーーーーーーー
        tf = gameObject.GetComponent<Transform>();
        rb2 = GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>().velocity;

        //!=はノットイコール
        if (h != 0)//                          ーーーーーーー横移動関係ーーーーーーー
        {
            //横移動　　rb =としてはいけない
            //rb.yでy方向の速度を継続
            rb2.velocity = new Vector2(h * movespeed, rb.y);

            //キャラの向きを変える
            tf.localScale = new Vector2(Mathf.Sign(h), transform.localScale.y);
            anim.SetBool("Dash", true);
        }
        else//動きっぱなしになるのを防ぐ
        {
            rb2.velocity = new Vector2(0f, rb.y);
            anim.SetBool("Dash", false);
        }

    }
	
	}

