using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Challenge_Event : MonoBehaviour {

    public GameObject Player;
    private float divide = 2f; // 확률 계산용 
    private Stat[] gameInfo_stat;
    private float playerScore; // 플럼 점수
    private float enemyScore; // 적 동아리 점수
    private Image image;
    private Text text;
    public GameObject ChallengeResult;
    // Use this for initialization
    void Start()
    {
        divide = transform.parent.GetComponent<Challenge_UI>().divide;
        gameInfo_stat = Status.Get_Data();
    }
    public void Challenge(int number)
    {
        Debug.Log("Challenge" + number);
        ChallengeResult.SetActive(true);
        image = ChallengeResult.transform.Find("Image").GetComponent<Image>();
        text = ChallengeResult.transform.Find("Text").GetComponent<Text>();
        if (gameInfo_stat[number].isEnabled)
        {
            playerScore = Random.value * (gameInfo_stat[0].learning_Point * gameInfo_stat[0].participation / 100) + (gameInfo_stat[0].learning_Point * gameInfo_stat[0].participation / 100 / divide + 1);
            enemyScore = Random.value * (gameInfo_stat[number].learning_Point * gameInfo_stat[number].participation / 100) + (gameInfo_stat[number].learning_Point * gameInfo_stat[number].participation / 100 / divide + 1);
            Debug.Log(playerScore.ToString() + "   " + enemyScore + ToString());
            if (playerScore > enemyScore) // Win
            {
                float avg = (gameInfo_stat[number].learning_Point + gameInfo_stat[0].learning_Point) / 2 - gameInfo_stat[0].learning_Point;
                image.sprite = Resources.Load<Sprite>("Image/pass");
                text.text = "도전에 성공하였습니다. 상대 동아리를 합병시킵니다.";
                gameInfo_stat[number].isEnabled = false;
                //Player.GetComponent<Status>().Get_Member_Status_Change_By_Addition(4f, -2f, avg);
            }
            else // Lose
            {
                image.sprite = Resources.Load<Sprite>("Image/fail");
                text.text = "도전에 실패하였습니다. 일부 스텟이 떨어집니다.";
                //Player.GetComponent<Status>().Get_Member_Status_Change_By_Addition(-5f, -5f, -3f);               
            }
        }
        else
        {
            image.sprite = Resources.Load<Sprite>("Image/Triangle_Error");
            text.text = "이미 없어진 동아리입니다.";
        }
        new WaitForSeconds(2f);
        transform.parent.gameObject.SetActive(false);
    }

    public void Back()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
