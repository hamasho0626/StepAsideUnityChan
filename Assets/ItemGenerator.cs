using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPreafabを入れる
    public GameObject cornPrefab;
    //アイテムを出す　＊　方向の範囲
    private float posRange = 3.4f;


    //ユニティちゃん用の変数を用意
    private GameObject UnityChan;

    //ユニティちゃんの現在位置を入れる変数
    private float UnityPos;

    //ユニティちゃんの前回の位置
    private float UnityBeforPos;

    //ユニティちゃんの進んだ距離
    private float MovingDistance;

    //生成停止位置　(ゴールの位置 - ユニティの現在位置 = 65)
    private int RestDistance = 65;

    //生成開始位置 (startPos + 50(生成が５０ｍ先のため) = 210)
    private int GenerateStartPos = -210;

    //生成を許可するキー
    private bool GenerateKey = false;
    

    // Use this for initialization
    void Start () {
        //ユニティちゃんのオブジェクトを取得
        this.UnityChan = GameObject.Find("unitychan");
        //ユニティちゃんのスタート位置を取得
        this.UnityBeforPos = UnityChan.transform.position.z;
    }

    // Update is called once per frame
    void Update() {

        //ユニティちゃんの位置を取得
        this.UnityPos = UnityChan.transform.position.z;
        //移動距離を取得
        this.MovingDistance = this.UnityPos - this.UnityBeforPos;

        /* Unityが生成開始位置を通り過ぎていない　＆＆　ゴールまでの距離が65ｍをきる*/
        if(this.RestDistance < this.UnityPos || this.UnityPos < this.GenerateStartPos)
        {
            GenerateKey = true;
        }  else
        {
            GenerateKey = false;
        }

        //１５ｍ移動するごとにアイテムを生成する
        if (this.MovingDistance > 15 && GenerateKey == false) {

            //現在のユニティの位置をUnityBeforPosに保存する
            this.UnityBeforPos = this.UnityPos;

            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(cornPrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, UnityPos + 50);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    int item = Random.Range(1, 11);
                    //アイテムをおくZ座標のオフセットをランダムに設定
                    int offsetz = Random.Range(-5, 6);
                    //60%コイン配置：３０％車を配置：１０％で何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, UnityPos + 50 + offsetz);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, UnityPos + 50 + offsetz);
                    }
                }
            }
        }

    }
}
