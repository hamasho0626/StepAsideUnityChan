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
    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出す　＊　方向の範囲
    private float posRange = 3.4f;

	// Use this for initialization
	void Start () {
		for(int i = startPos; i< goalPos; i+=15)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if(num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for(float j = -1; j<= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(cornPrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            } else
            {
                //レーンごとにアイテムを生成
                for(int j = -1; j <= 1; j++)
                {
                    int item = Random.Range(1, 11);
                    //アイテムをおくZ座標のオフセットをランダムに設定
                    int offsetz = Random.Range(-5, 6);
                    //60%コイン配置：３０％車を配置：１０％で何もなし
                    if(1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetz);
                    } else if( 7 <= item && item <= 9)
                    {
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j , car.transform.position.y, i + offsetz);
                    }
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
