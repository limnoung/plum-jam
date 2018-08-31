using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Club_Item : MonoBehaviour {
    
    enum Helpful_Club_Item {Advertise_Pannel, Playing_Card, Sanquaehan, Coupang, Earplug }

    [Header("조정해야 할 변수")]
    [SerializeField] Helpful_Club_Item Item_Type;
    [SerializeField] float HeadCount_Increase_Rate = 0.00f, Fund_Increase_Rate = 0.00f, Reputation_Increase_Rate = 0.00f, member_Happiness_Increase_Rate = 0.00f, member_Participation_Increase_Rate = 0.00f, member_Learning_Point_Increase_Rate = 0.00f;
    [SerializeField] bool Data_Initialize_By_Script = false;

    [Space(30)]

    [Header("적용해야 할 변수")]
    [SerializeField] GameObject plum;

    [Header("테스트 시스템")]
    [SerializeField] bool Test_Apply_Item_Effect = false;

    private void Update()
    {
        if (Data_Initialize_By_Script)
        {
            Data_Initialize_By_Script = false;
            Item_Data_Initialize_By_Script();
        }
        if (Test_Apply_Item_Effect)
        {
            Test_Apply_Item_Effect = false;
            Apply_Item_Effect(plum);
        }
        
    }

    void Item_Data_Initialize_By_Script()
    {
        switch (Item_Type)
        {
            case Helpful_Club_Item.Advertise_Pannel:
                HeadCount_Increase_Rate = 0.10f;
                Fund_Increase_Rate = 0.00f;
                Reputation_Increase_Rate = 0.00f;
                member_Happiness_Increase_Rate = 0.00f;
                member_Participation_Increase_Rate = 0.00f;
                member_Learning_Point_Increase_Rate = 0.00f;
                break;

            case Helpful_Club_Item.Playing_Card:
                HeadCount_Increase_Rate = 0.00f;
                Fund_Increase_Rate = 0.10f;
                Reputation_Increase_Rate = 0.00f;
                member_Happiness_Increase_Rate = 0.00f;
                member_Participation_Increase_Rate = 0.00f;
                member_Learning_Point_Increase_Rate = 0.00f;
                break;

            case Helpful_Club_Item.Sanquaehan:
                HeadCount_Increase_Rate = 0.00f;
                Fund_Increase_Rate = 0.00f;
                Reputation_Increase_Rate = 0.10f;
                member_Happiness_Increase_Rate = 0.00f;
                member_Participation_Increase_Rate = 0.00f;
                member_Learning_Point_Increase_Rate = 0.00f;
                break;

            case Helpful_Club_Item.Coupang:
                HeadCount_Increase_Rate = 0.00f;
                Fund_Increase_Rate = 0.00f;
                Reputation_Increase_Rate = 0.00f;
                member_Happiness_Increase_Rate = 0.10f;
                member_Participation_Increase_Rate = 0.00f;
                member_Learning_Point_Increase_Rate = 0.00f;
                break;

            case Helpful_Club_Item.Earplug:
                HeadCount_Increase_Rate = 0.00f;
                Fund_Increase_Rate = 0.00f;
                Reputation_Increase_Rate = 0.00f;
                member_Happiness_Increase_Rate = 0.00f;
                member_Participation_Increase_Rate = 0.10f;
                member_Learning_Point_Increase_Rate = 0.00f;
                break;
        }
    }

    public void Apply_Item_Effect(GameObject target)
    {
        target.GetComponent<Status>().Get_Increase_Rate_Change(HeadCount_Increase_Rate, Fund_Increase_Rate, Reputation_Increase_Rate, member_Happiness_Increase_Rate, member_Participation_Increase_Rate, member_Learning_Point_Increase_Rate);
            //float headerCount_Rate, float fund_Rate, float Reputatioin_Rate, float Happiness_Rate, float Participation_Rate, float Learning_Point_Rate)
    }
}
