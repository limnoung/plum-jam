using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

    //기본 스테이터스 변수
    [Header("플럼 스테이터스")]
    public int plum_member_HeadCount;
    public int plum_Fund;
    [Range(0, 100)] public float plum_Reputation;
    [Header("플럼 멤버 스테이터스")]
    [Range(0, 100)] public float member_Happiness, member_Participation, member_Learning_Point;


    //스테이터스 변경 함수
    public void Get_Member_Status_Change_By_Addition(float Change_Happiness, float Change_Participation, float Change_Learning_Point)
    {
        member_Happiness += Change_Happiness;
        member_Participation += Change_Participation;
        member_Learning_Point += Change_Learning_Point;
    }

    public void Get_Member_Status_Change_By_Percentage(float Happinese_Rate, float Participation_Rate, float Learning_Point_Rate)
    {
        member_Happiness *= Happinese_Rate;
        member_Participation *= Participation_Rate;
        member_Learning_Point *= Learning_Point_Rate;
    }

    public void Get_Member_InOut(int Change_Member)
    {
        plum_member_HeadCount += Change_Member;
    }

    public void Get_Fund_InOut(int Change_Fund)
    {
        plum_Fund += Change_Fund;
    }

    public void Get_Reputateion_Change(int Change_Reputation)
    {
        plum_Fund += Change_Reputation;
    }
}
