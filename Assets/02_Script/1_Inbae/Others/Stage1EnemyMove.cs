using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1EnemyMove : MonoBehaviour
{
    public GameObject MoveScript;
    public GameObject EnemyObject;
    public int block_num;
    
    void Start()
    {
        MoveScript = GameObject.Find("Player");
    }

    public void MeetEnemy()
    {
        if (gameObject.transform.parent.transform.childCount > 1)
        {
            for (int i = 0; i < gameObject.transform.parent.transform.childCount; i++)
            {
                if (gameObject.transform.parent.transform.GetChild(i).name == "Enemy")
                {
                    EnemyObject = gameObject.transform.parent.transform.GetChild(i).gameObject;
                    block_num = MoveScript.GetComponent<Stage1Move>().block_num;
                    EnemyMove();
                }
            }
        }
    }

    public void EnemyMove()
    {
        if (MoveScript.GetComponent<Stage1Move>().Lefted)
        {
            if (block_num == 6 || block_num == 7)
            {
                Destroy(EnemyObject);
                MoveScript.GetComponent<Stage1Move>().Lefted = false;
                MoveScript.GetComponent<Stage1Move>().MoveRight();
                return;
            }
            
            int newblock_num;
            newblock_num = block_num - 4;
            string MoveEnemyHere_num = "Block" + newblock_num;
            GameObject MoveEnemyHere = GameObject.Find(MoveEnemyHere_num);
            EnemyObject.transform.SetParent(MoveEnemyHere.transform);
            EnemyObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
            MoveScript.GetComponent<Stage1Move>().Lefted = false;
            MoveScript.GetComponent<Stage1Move>().MoveRight();
            return;
        }

        if (MoveScript.GetComponent<Stage1Move>().Righted)
        {
            if (block_num == 18 || block_num == 24)
            {
                Destroy(EnemyObject);
                MoveScript.GetComponent<Stage1Move>().Righted = false;
                MoveScript.GetComponent<Stage1Move>().MoveLeft();
                return;
            }

            int newblock_num;
            if (block_num == 19)
                newblock_num = block_num + 5;
            else newblock_num = block_num + 4;
            string MoveEnemyHere_num = "Block" + newblock_num;
            GameObject MoveEnemyHere = GameObject.Find(MoveEnemyHere_num);
            if (MoveEnemyHere.transform.childCount > 0)
            {
                Destroy(EnemyObject);
                MoveScript.GetComponent<Stage1Move>().Righted = false;
                MoveScript.GetComponent<Stage1Move>().MoveLeft();
                return;
            }
            EnemyObject.transform.SetParent(MoveEnemyHere.transform);
            EnemyObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
            MoveScript.GetComponent<Stage1Move>().Righted = false;
            MoveScript.GetComponent<Stage1Move>().MoveLeft();
            return;
        }

        if (MoveScript.GetComponent<Stage1Move>().Uped)
        {
            Destroy(EnemyObject);
            MoveScript.GetComponent<Stage1Move>().Uped = false;
            MoveScript.GetComponent<Stage1Move>().MoveDown();
            return;
        }

        if (MoveScript.GetComponent<Stage1Move>().Downed)
        {
            if (block_num == 6)
            {
                int newblock_num = block_num - 1;
                string MoveEnemyHere_num = "Block" + newblock_num;
                GameObject MoveEnemyHere = GameObject.Find(MoveEnemyHere_num);
                EnemyObject.transform.SetParent(MoveEnemyHere.transform);
                EnemyObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
                MoveScript.GetComponent<Stage1Move>().Downed = false;
                MoveScript.GetComponent<Stage1Move>().MoveUp();
                return;
            }
            else
            {
                Destroy(EnemyObject);
                MoveScript.GetComponent<Stage1Move>().Downed = false;
                MoveScript.GetComponent<Stage1Move>().MoveUp();
                return;
            } 
        }
    }
}