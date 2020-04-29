using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour {

    //アニメーションするためのコンポーネントを作成
    private Animator myAnimator;

    //移動させるコンポーネントを入れる
    private Rigidbody myRigidbody;
    //前進するための力
    private float forwardForce = 800.0f;
    //左右に移動するための力
    private float trunForce = 500.0f;
    //左右に移動できる範囲
    private float movableRange = 3.4f;
    //ジャンプするための力
    private float upForce = 500.0f;
    //動きを減速させる係数
    private float coefficient = 0.95f;

    //ゲーム終了の判定
    private bool isEnd = false;

    //ゲーム終了時に表示するUI
    private GameObject stateTexet;

    //スコアを表示するUi
    private GameObject scoreText;
    //得点
    private int score = 0;

    //左ボタン押下の判定
    private bool isLBottonDown = false;
    //右ボタン
    private bool isRBottonDown = false;

    //ボックストリガーを入れる
    private BoxCollider itemDestroyTrigger;

    //カプセルトリガーを入れる
    private CapsuleCollider unitychanTrigger;


    // Use this for initialization
    void Start () {
        this.myAnimator = GetComponent<Animator>();

        this.myAnimator.SetFloat("Speed", 1);

        //リジットを取得
        this.myRigidbody = GetComponent<Rigidbody>();

        //シーン中のstateTextを取得
        this.stateTexet = GameObject.Find("GameResultText");

        //シーン中のscoretextを取得
        this.scoreText = GameObject.Find("ScoreText");

        //シーン中のアイテムを消すトリガーを取得
        this.itemDestroyTrigger = GetComponent<BoxCollider>();

        //シーン中のユニティちゃんのカプセルトリガーを取得
        this.unitychanTrigger = GetComponent<CapsuleCollider>();


    }

    // Update is called once per frame
    void Update () {

        //ゲーム終了ならUnityちゃんの動きを減速させる
        if (this.isEnd)
        {
            this.forwardForce *= this.coefficient;
            this.trunForce *= coefficient;
            this.upForce *= coefficient;
            this.myAnimator.speed *= this.coefficient;
        }

        //前方向のちからを加える
        this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);

        //ユニティちゃんを矢印キーまたはボタンに応じて左右に移動させる
        if((Input.GetKey(KeyCode.LeftArrow) || this.isLBottonDown) && -this.movableRange < this.transform.position.x)
        {
            //左に移動
            this.myRigidbody.AddForce(-this.trunForce, 0, 0);
        }else if((Input.GetKey(KeyCode.RightArrow) || this.isRBottonDown) && this.transform.position.x < this.movableRange)
        {
            //右に移動
            this.myRigidbody.AddForce(this.trunForce, 0, 0);
        }

        //jumpステートの場合は、jumpにfalseを代入
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }

        //ジャンプしていない時にスペースを押されたらジャンプする
        if(Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f)
        {
            //ジャンプアニメーションを再生
            this.myAnimator.SetBool("Jump", true);
            //ユニティちゃんに上方向の力を加える
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }


            
	}

    //トリガーモードで他のオブジェクトと接触した場合の処理
    void OnTriggerEnter(Collider other)
    {
        //障害物に衝突した場合
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
           // if (this.itemDestroyTrigger)
           // {
           //     Destroy(other.gameObject);
           // }
           // else if(this.unitychanTrigger)
           // {
           
            this.isEnd = true;
            //statetextにGameoverを表示
            this.stateTexet.GetComponent<Text>().text = "GameOver";
            //}
        }

        //ゴール地点に達した場合
        if (other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
            //stateTextにCLEARを表示
            this.stateTexet.GetComponent<Text>().text = "CLEAR!!";
        }

        //コインに衝突した時
        if (other.gameObject.tag == "CoinTag")
        {

         //   if (this.itemDestroyTrigger)
         //   {
         //       Destroy(other.gameObject);
         //   }
         //   else
         //   {

                //スコアを代入
                this.score += 10;

                //スコアテキストに点数を表示
                this.scoreText.GetComponent<Text>().text = "Score" + this.score + "pt";

                //パーティクルを再生
                GetComponent<ParticleSystem>().Play();

                //接触したコインのオブジェクトを破棄
                Destroy(other.gameObject);
         //   }
        }
    }

    //ジャンプボタンを押した処理
    public void GetMyJumpBottonDown()
    {
        if(this.transform.position.y < 0.5f)
        {
            this.myAnimator.SetBool("Jump", true);
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }
    }

    //左ボタンを押し続けた場合の処理
    public void GetMyLeftButtonDown()
    {
        this.isLBottonDown = true;
    }

    //左ボタンを離した場合の処理
    public void GetMyLeftButtonUp()
    {
        this.isLBottonDown = false;
    }

    //右ボタンを押し続けた場合の処理
    public void GetMyRightButtonDown()
    {
        this.isRBottonDown = true;
    }
    //右ボタンを離した場合の処理
    public void GetMyRightButtonUp()
    {
        this.isRBottonDown = false;
    }
}
