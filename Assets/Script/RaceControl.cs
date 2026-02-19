using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceControl : MonoBehaviour
{
    // 카메라 오브젝트
    public GameObject cameraObject;

    // 게임 내의 말들 리스트
    public List<HorseControl> horseControlList;

    public List<HorseControl> ranking;

    public MakeRankList makeRankList;

    private bool raceStart = false;

    private int horseNum = 8;

    private bool f = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        makeRankList.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        if (raceStart)
        {
            for (int i = 0; i < horseNum; i++)
            {
                if (horseControlList[i].inRace == false && horseControlList[i].inRank==false)
                {
                    ranking.Add(horseControlList[i]);
                    horseControlList[i].inRank = true;
                }
            }

            if (ranking.Count == horseNum)
            {
                Debug.Log("The winner is " + ranking[0].gameObject.ToString());
                raceStart = false;
                for(int i = 0; i < horseNum; i++)
                {
                    ranking[i].SetStartRacing(false);
                }
                makeRankList.SetRankList(ranking);
                makeRankList.gameObject.SetActive(true);
            }
        }
    }

    public void FixedUpdate()
    {
        if (raceStart)
        {
            if(f) cameraObject.transform.position += Vector3.forward / 9.8f;
            if (cameraObject.transform.position.z >= 129f && f == true)
            {
                cameraObject.transform.rotation = Quaternion.Euler(14.763f,-90f,0f);
                f = false;
            }
            
        }
    }

    public void RaceStart()
    {
        if(raceStart == false)
        {
            for (int i = horseNum; i < 8; i++)
            {
                horseControlList.RemoveAt(horseNum);
            }
            raceStart = true;
            Debug.Log("Start Race");
            for (int i = 0; i < horseNum; i++)
            {
                horseControlList[i].SetStartRacing(true);
                horseControlList[i].SetAnimationTrigger();
            }
        }
    }

    public void ReStartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
