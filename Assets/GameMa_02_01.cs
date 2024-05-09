using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMa_02_01 : MonoBehaviour
{
    public GameObject playerPrefab;
    int[,] map;
    GameObject[,] field;
    // Start is called before the first frame update
    void Start()
    {
        map = new int[,]
        {
            {0,0,0,1,0,2,0,2,0},
            {0,0,0,1,0,2,0,2,0},
            {0,0,0,1,0,2,0,2,0},
        };
        field = new GameObject
        [
            map.GetLength(0),
            map.GetLength(1)
        ];
        string debugText = "";
        //行のfor文
        for(int y=0;y<map.GetLength(0);y++)
        {
            //列のfor文
            for(int x=0;x<map.GetLength(1);x++)
            {
                if (map[y,x]==1)
                {
                    field[y,x] = Instantiate
                        (playerPrefab,
                        new Vector3(x,map.GetLength(0)-y,0),
                        Quaternion.identity
                        );
                }
                //debugText += map[y,x].ToString()+",";
            }
            //改行
            debugText += "\n";
        }
        Debug.Log(debugText);
    }
    ////1の値が格納されるメゾット化をする
    Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y <field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                //45ページ
                if (field[y, x] == null)
                {
                    return continue;
                }
                if (field[y,x].tag=="Player")
                {
                    return new Vector2Int(x, y);
                }
            } 
        }
        return new Vector2Int(-1, -1);
    }
    //
    bool MoveNumbeer(Vector2Int moveFrom,Vector2Int moveTo)
    {
        if(moveFrom.y<0||moveTo.y>=field.GetLength(0))
        {
            return false;
        }

        if (moveFrom.x < 0 || moveTo.x >= field.GetLength(2))
        {
            return false;
        }
        //51ページ
        field[moveTo.y, moveTo.x] = field[moveFrom.y, moveFrom.x];
        field[moveFrom.y, moveFrom.x] = null;
        field[moveFrom.y, moveFrom.x].transform.position = 
            new Vector3(x, map.GetLength(0) - y, 0);
        return true;
    }
    //// Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector2Int playerIndex = GetPlayerIndex();
            MoveNumbeer
                (playerIndex,
                playerIndex + new Vector2Int(1, 0)); 
        }
    }
}
