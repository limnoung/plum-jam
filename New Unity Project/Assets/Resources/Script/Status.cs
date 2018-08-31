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
    public bool isEnabled = true;


    //스테이터스 변경 함수
    public void Get_Member_Status_Change_By_Addition(float Change_Happiness, float Change_Participation, float Change_Learning_Point)
    {
        member_Happiness += Change_Happiness;
        member_Participation += Change_Participation;
        member_Learning_Point += Change_Learning_Point;
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
        member_HeadCount += Change_Member;
        Get_GameInfo_Change();
    }

    public void Get_Fund_InOut(int Change_Fund)
    {
        Fund += Change_Fund;
        Get_GameInfo_Change();
    }

    public void Get_Reputateion_Change(int Change_Reputation)
    {
        Reputation += Change_Reputation;
        Get_GameInfo_Change();
    }
    public void Get_GameInfo_Change()
    {
        GameInfo.Get_State(name, Fund, member_HeadCount, Reputation, member_Happiness, member_Participation
            , member_Learning_Point, isEnabled); 
    }
}
