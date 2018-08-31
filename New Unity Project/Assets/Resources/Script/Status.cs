using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

    [ExecuteInEditMode]
    public string name;
    //기본 스테이터스 변수
    [Header("플럼 스테이터스")]
    public int member_HeadCount;
    public int Fund;
    [Range(0, 100)] public float Reputation;
    [Header("플럼 멤버 스테이터스")]
    [Range(0, 100)] public float member_Happiness;
    [Range(0, 100)] public float member_Participation, member_Learning_Point;

    [Header("스테이터스 증가율")]
    public float HeadCount_Increase_Rate = 1.00f;
    public float Fund_Increase_Rate = 1.00f, Reputation_Increase_Rate = 1.00f, member_Happiness_Increase_Rate = 1.00f, member_Participation_Increase_Rate = 1.00f, member_Learning_Point_Increase_Rate = 1.00f;

    public bool isEnabled = true;


    //스테이터스 변경 함수
    public void Get_Member_Status_Change_By_Addition(float Change_Happiness, float Change_Participation, float Change_Learning_Point)
    {
        member_Happiness += Mathf.RoundToInt(Change_Happiness * member_Happiness_Increase_Rate);
        member_Participation += Mathf.RoundToInt(Change_Participation * member_Participation_Increase_Rate);
        member_Learning_Point += Mathf.RoundToInt(Change_Learning_Point * member_Learning_Point_Increase_Rate);
        Get_GameInfo_Change();
    }

    public void Get_Member_Status_Change_By_Percentage(float Happinese_Rate, float Participation_Rate, float Learning_Point_Rate)
    {
        member_Happiness *= Happinese_Rate;
        member_Participation *= Participation_Rate;
        member_Learning_Point *= Learning_Point_Rate;
        Get_GameInfo_Change();
    }

    public void Get_Member_InOut(int Change_Member)
    {
        member_HeadCount += Mathf.RoundToInt(Change_Member * HeadCount_Increase_Rate);
        Get_GameInfo_Change();
    }

    public void Get_Fund_InOut(int Change_Fund)
    {
        Fund += Mathf.RoundToInt(Change_Fund * Fund_Increase_Rate);
        Get_GameInfo_Change();
    }

    public void Get_Reputateion_Change(float Change_Reputation)
    {
        Reputation += Mathf.RoundToInt(Change_Reputation * Reputation_Increase_Rate);
        Get_GameInfo_Change();
    }
    public void Get_GameInfo_Change()
    {
        GameInfo.Get_State(name, Fund, member_HeadCount, Reputation, member_Happiness, member_Participation
            , member_Learning_Point, isEnabled); 
    }

    public void Get_Increase_Rate_Change(float headerCount_Rate, float fund_Rate, float Reputatioin_Rate, float Happiness_Rate, float Participation_Rate, float Learning_Point_Rate)
    {
        HeadCount_Increase_Rate += headerCount_Rate;
        Fund_Increase_Rate += fund_Rate;
        Reputation_Increase_Rate += Reputatioin_Rate;
        member_Happiness_Increase_Rate += Happiness_Rate;
        member_Participation_Increase_Rate += Participation_Rate;
        member_Learning_Point_Increase_Rate += Learning_Point_Rate;
    }
}
