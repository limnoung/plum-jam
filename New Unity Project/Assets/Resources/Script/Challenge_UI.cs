using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Challenge_UI : MonoBehaviour
{
    private Stat[] gameInfo_stat;
    public Text[] status_Text;
    public float divide = 2f; // 확률 계산용
    // Use this for initialization
    void Start()
    {
        gameInfo_stat = Status.Get_Data();
        UIupdate();
        
    }
    void UIupdate()
    {
        float playerScore = gameInfo_stat[0].learning_Point * gameInfo_stat[0].participation / 100;
        for (int i=1; i<5; i++)
        {
            if (gameInfo_stat[i].isEnabled) {
                float enemyScore = gameInfo_stat[i].learning_Point * gameInfo_stat[i].participation / 100;
                float score = playerScore - enemyScore / divide;
                int sum = 0;
                if (score > 0)
                {
                    for (int j = (int)score; j >= 1; j--)
                        sum += j;
                    if(sum / (playerScore / divide * enemyScore / divide) < 1f)
                        status_Text[i - 1].text = "승리 확률 : " + sum / (playerScore / divide * enemyScore / divide)  * 100 + "%";
                    else
                        status_Text[i - 1].text = "승리 확률 : 100% !!! ";
                }
                else
                {
                    status_Text[i - 1].text = "좋지 않은 시도 입니다.";
                }
            }
            else
                status_Text[i - 1].text = "Unavailable";
        }
    }

}
