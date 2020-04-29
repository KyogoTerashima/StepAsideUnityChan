using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    public GameObject carPrefab;

    public GameObject coinPrefab;

    public GameObject conePrefab;
    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すｘ方向の範囲
    private float posRange = 3.4f;
    //ユニティちゃんの位置情報
    private GameObject unitychan;
    private Vector3 unitychanPos;


    // Use this for initialization
    void Start()
    {
        //一定の距離ごとにアイテムを生成
        // for(int i = startPos; i < goalPos; i+=15)
        // {
        //     //どのアイテムを出すのかをランダムに設定
        //     int num = Random.Range(1, 11);
        //     if(num <= 2)
        //     {
        //         //コーンをX軸方向に一直線に配置
        //         for(float j = -1;j <= 1; j += 0.4f)
        //         {
        //             GameObject cone = Instantiate(conePrefab) as GameObject;
        //             cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
        //            
        //         }
        //     }
        //     else
        //     {
        //         //レーンごとにアイテムを生成
        //         for(int j = -1; j <= 1; j++)
        //         {
        //             //アイテムの種類を決める
        //             int item = Random.Range(1, 11);
        //             //アイテムを置くZ座標のオフセットをランダムに設定
        //             int offsetZ = Random.Range(-5, 6);
        //             //60%コインを配置。30％車を配置。10％なにもなし
        //             if(1 <= item && item <= 6)
        //             {
        //                 //コインを生成
        //                 GameObject coin = Instantiate(coinPrefab) as GameObject;
        //                 coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
        //             }else if(7 <= item && item <= 9)
        //             {
        //                 //車を生成
        //                 GameObject car = Instantiate(carPrefab) as GameObject;
        //                 car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
        //             }
        //         }
        //
        //     }
        // }

        this.unitychan = GameObject.Find("unitychan");
        this.unitychanPos = this.unitychan.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (this.unitychan.transform.position.z - this.unitychanPos.z >= 15)
        {
            this.unitychanPos = this.unitychan.transform.position;


            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをX軸方向に一直線に配置
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitychanPos.z + 40);

                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コインを配置。30％車を配置。10％なにもなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unitychanPos.z + 40);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, unitychanPos.z + 40);
                    }
                }
            }

        }
    }
}
