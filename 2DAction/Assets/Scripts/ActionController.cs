using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//RequireComponent(コンポーネント型)と記述することによって
//指定したコンポーネントを一緒に付けてくれる様になる
[RequireComponent(typeof(Rigidbody2D))]
public class ActionController : MonoBehaviour
{
    Rigidbody2D rigidbody = null;
    Animator animator = null;

    [SerializeField] float movePower = 50.0f;
    [SerializeField] float jumpPower = 10.0f;
    [SerializeField] int jumpCount = 2;
    [SerializeField] float maxSpeed = 3.0f;
    [SerializeField] GameObject particleObject = null;

    bool liftFlg = false;

    public void ReStart()
    {
        gameObject.SetActive(true);
        transform.position = Vector3.zero;
    }

    public void GameOver()
    {
        gameObject.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddForce(Vector2.right * movePower);
            key = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddForce(Vector2.left * movePower);
            key = -1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            animator.Play("Jump");
            jumpCount++;
        }
        if (Input.GetKey(KeyCode.UpArrow) && liftFlg)
        {
            rigidbody.MovePosition(rigidbody.position + new Vector2(0.0f,0.1f));
        }
        if (Input.GetKey(KeyCode.DownArrow) && liftFlg)
        {
            rigidbody.MovePosition(rigidbody.position + new Vector2(0.0f, -0.1f));
        }


        //X移動量を絶対値に戻す
        var verocityX = Mathf.Abs(rigidbody.velocity.x);
        if (verocityX > maxSpeed)
        {
            var velocity = rigidbody.velocity;
            velocity.x = maxSpeed * key;
            rigidbody.velocity = velocity;
        }

        if (key != 0)
        {
            //最大速度の時にアニメーションの再生速度が1になるように調整
            animator.speed = verocityX / maxSpeed;
            if (jumpCount == 0)
            {
                //走りアニメーション再生
                animator.Play("Run");
            }
            //反転
            var scale = transform.localScale;
            scale.x = key;
            transform.localScale = scale;
        }
        else
        {
            animator.speed = 1.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag == "Damage" || collision.tag == "Enemy")
        {
            //パーティクルを複製
            var cloneParticle = Instantiate(particleObject);
            cloneParticle.transform.position = transform.position;

            GameManager.instance.GameOver();
        }
        if( collision.tag == "Lift" )
        {
            rigidbody.gravityScale = 0.0f;
            rigidbody.velocity = Vector2.zero;
            liftFlg = true;
        }
        jumpCount = 0;
        animator.Play("Wait");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Lift")
        {
            rigidbody.gravityScale = 3.0f;
            liftFlg = false;
        }
    }
}
