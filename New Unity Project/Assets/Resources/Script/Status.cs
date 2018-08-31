using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct Stat
{
    public string name;
    public int fund, headCount;
    public float reputation, Happiness, participation, learning_Point;
    public bool isEnabled;
};
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
    private static Stat[] stats;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        stats = new Stat[5];
        stats[0].name = "PLUM";
        stats[1].name = "EA";
        stats[2].name = "다방";
        stats[3].name = "WMV";
        stats[4].name = "ITQ";
        Get_State("PLUM", 150000, 40, 10f, 20f, 50f, 30f, true);
        Get_State("EA", 3000000, 90, 90f, 70f, 70f, 70f, true);
        Get_State("다방", 3000000, 70, 40f, 40f, 90f, 50f, true);
        Get_State("WMV", 3000000, 70, 40f, 90f, 40f, 40f, true);
        Get_State("ITQ", 3000000, 70, 90f, 30f, 30f, 70f, true);
    }
    public static Stat[] Get_Data()
    {
        return stats;
    }
    public static void Get_State(string name, int fund, int headCount, float reputation, float Happines, float participation,
        float learning_Point, bool isEnabled)
    {
        for (int i = 0; i < stats.Length; i++)
        {
            if (stats[i].name == name)
            {
                stats[i].fund = fund;
                stats[i].headCount = headCount;
                stats[i].reputation = reputation;
                stats[i].Happiness = Happines;
                stats[i].participation = participation;
                stats[i].learning_Point = learning_Point;
                stats[i].isEnabled = isEnabled;
                break;
            }
        }
    }

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
        Get_State(name, Fund, member_HeadCount, Reputation, member_Happiness, member_Participation
            , member_Learning_Point, isEnabled); 
    }
}
