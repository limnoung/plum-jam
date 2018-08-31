using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Challenge_UI : MonoBehaviour
{

    [Header("상대 동아리 스테이터스")]
    private Stat[] gameInfo_stat;
    public Text[] status_Text;
    // Use this for initialization
    void Start()
    {
        gameInfo_stat = GameInfo.Get_Data();
        UIupdate();
        
    }
    void UIupdate()
    {
        for(int i=0; i<4; i++)
        {
            status_Text[i].text = "자금 : " + gameInfo_stat[i].fund + "인원 : " + gameInfo_stat[i].headCount +
                "행복도 : " + gameInfo_stat[i].Happiness + "참여도 : " + gameInfo_stat[i].participation +
                "학습도 : " + gameInfo_stat[i].learning_Point + "명성도 : " + gameInfo_stat[i].reputation;
        }
    }
    void First()
    {
        
    }
    void Second()
    {

    }
    void Third()
    {

    }
    void Fourth()
    {

    }
    void Back()
    {
        gameObject.SetActive(false);
    }
}
