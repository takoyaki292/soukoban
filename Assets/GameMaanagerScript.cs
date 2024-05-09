using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;

public class GameMaanagerScript : MonoBehaviour
{
    //配列の宣言
    int[] map;
    // Start is called before the first frame update

    //配列の中を表示する
    void PrintArray()
    {
        string debugText = "";

        for(int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString()+",";
        }
        Debug.Log(debugText);
    }

    //1の値が格納されるメゾット化をする
    int GetPlayerIndex()
    {
        for(int i=0;i<map.Length;i++)
        {
            if (map[i]==1)
            {
                return i;
            }
        }
        return -1;
    }

    bool MoveNumbeer(int number,int moveFrom,int moveTo)
    {
        //移動先が範囲外なら移動不可にする  
        if (moveTo < 0 || moveTo >= map.Length)
        {
            return false;
        }
        //移動先に2があったら
        if (map[moveTo] == 2)
        {
            //どの方向に移動するか
            int velocity = moveTo - moveFrom;
            //処理を再起する
            bool success = MoveNumbeer(2, moveTo, moveTo + velocity);

            //2が移動失敗したら、プレイヤーの位置がそのまま
            if(!success)
            {
                return false;
            }
        }
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }
    void Start()
    {
        ////デバックログの出力
        //Debug.Log("Hello World");

        //配列を作る
        map = new int[] { 0, 0, 2, 1, 2, 2, 0, 0, 0 };

        PrintArray();
    }

    // Update is called once per frame
    void Update()
    {
        ////右キーを入力した場合
       if(Input.GetKeyDown(KeyCode.RightArrow))
       {
           //メゾットのクラス
           int playerIndex = GetPlayerIndex(); 
           MoveNumbeer(1, playerIndex, playerIndex + 1);
           PrintArray();
       }

        ////左キーを入力した場合
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //メゾットのクラス
            int playerIndex = GetPlayerIndex();
            MoveNumbeer(1, playerIndex, playerIndex - 1);
            PrintArray();
        }
    }
}
