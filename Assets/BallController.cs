using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    //スコア変数
    int score;

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //スコアを表示するテキスト
    private GameObject scoreText;

    // Use this for initialization
    void Start()
    {
        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");

        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    //衝突時に呼ばれる関数
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SmallStarTag") {
            score += 20;
            Debug.Log(score);
        }
        if (collision.gameObject.tag == "LargeStarTag") {
            score += 30;
            Debug.Log(score);
        }
        if (collision.gameObject.tag == "SmallCloudTag") {
            score += 50;
            Debug.Log(score);
        }
        if (collision.gameObject.tag == "LargeCloudTag") {
            score += 40;
            Debug.Log(score);
        }
        this.scoreText.GetComponent<Text>().text = "SCORE:" + score;
    }

}