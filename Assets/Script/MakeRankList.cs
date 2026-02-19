using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MakeRankList : MonoBehaviour
{
    public List<TextMeshProUGUI> rankList;
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void SetRankList(List<HorseControl> ranking)
    {
        if(ranking.Count == rankList.Count)
        {
            int num = ranking.Count;
            for(int i=0; i<num; i++)
            {
                rankList[i].text = "#"+ (i+1) + " : " + ranking[i].horseName;
            }
        }
    }
}
