using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;

public class GameMaanagerScript : MonoBehaviour
{
    //�z��̐錾
    int[] map;
    // Start is called before the first frame update

    //�z��̒���\������
    void PrintArray()
    {
        string debugText = "";

        for(int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString()+",";
        }
        Debug.Log(debugText);
    }

    //1�̒l���i�[����郁�]�b�g��������
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
        //�ړ��悪�͈͊O�Ȃ�ړ��s�ɂ���  
        if (moveTo < 0 || moveTo >= map.Length)
        {
            return false;
        }
        //�ړ����2����������
        if (map[moveTo] == 2)
        {
            //�ǂ̕����Ɉړ����邩
            int velocity = moveTo - moveFrom;
            //�������ċN����
            bool success = MoveNumbeer(2, moveTo, moveTo + velocity);

            //2���ړ����s������A�v���C���[�̈ʒu�����̂܂�
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
        ////�f�o�b�N���O�̏o��
        //Debug.Log("Hello World");

        //�z������
        map = new int[] { 0, 0, 2, 1, 2, 2, 0, 0, 0 };

        PrintArray();
    }

    // Update is called once per frame
    void Update()
    {
        ////�E�L�[����͂����ꍇ
       if(Input.GetKeyDown(KeyCode.RightArrow))
       {
           //���]�b�g�̃N���X
           int playerIndex = GetPlayerIndex(); 
           MoveNumbeer(1, playerIndex, playerIndex + 1);
           PrintArray();
       }

        ////���L�[����͂����ꍇ
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //���]�b�g�̃N���X
            int playerIndex = GetPlayerIndex();
            MoveNumbeer(1, playerIndex, playerIndex - 1);
            PrintArray();
        }
    }
}
