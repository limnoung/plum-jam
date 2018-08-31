using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Window : MonoBehaviour {
    [ExecuteInEditMode]

    [Header("적용해야할 변수")]
    [SerializeField] Text headline_Text;
    [SerializeField] Text main_Text;
    [SerializeField] Text[] changing_Status_text = new Text[6];

    [Header("테스트 전용 변수")]
    [SerializeField] bool test_Check_Button = false;

    private void Update()
    {
        if (test_Check_Button)
        {
            test_Check_Button = false;
            Get_Check_Button_Down();
        }
    }

    //public
    public void Get_Turn_Over_Signal(Event.Event_Data_Property get_eventData)
    {
        Get_Event_Property_And_Applying(get_eventData);
        Set_Active_Child_Obj(true);
    }

    public void Get_Check_Button_Down()
    {
        Set_Active_Child_Obj(false);
    }

    //private
    void Set_Active_Child_Obj(bool onOff)
    {
        for (int i = 0; i < transform.childCount; i++) transform.GetChild(i).gameObject.SetActive(onOff);
    }

    void Get_Event_Property_And_Applying(Event.Event_Data_Property get_eventData)
    {
        headline_Text.text = get_eventData.event_Name;
        main_Text.text = get_eventData.event_Explain_text;

        int i = 0;
        for (i = 0; i < changing_Status_text.Length; i++) changing_Status_text[i].text = "";

        if (get_eventData.club_Fund > 0) changing_Status_text[i++].text = "자금 + " + get_eventData.club_Fund;
        else if (get_eventData.club_Fund < 0) changing_Status_text[i++].text = "자금 - " + Mathf.Abs(get_eventData.club_Fund);
        if (get_eventData.club_Member_num > 0) changing_Status_text[i++].text = " 인원 + " + get_eventData.club_Member_num;
        else if (get_eventData.club_Member_num < 0) changing_Status_text[i++].text = " 인원 - " + Mathf.Abs(get_eventData.club_Member_num);
        if (get_eventData.club_Reputation > 0) changing_Status_text[i++].text = "명성도 + " + Mathf.Abs(get_eventData.club_Reputation);
        else if (get_eventData.club_Reputation < 0) changing_Status_text[i++].text = "명성도 - " + Mathf.Abs(get_eventData.club_Reputation);
        if (get_eventData.member_Happiness > 0) changing_Status_text[i++].text = "행복도 + " + Mathf.Abs(get_eventData.member_Happiness);
        else if (get_eventData.member_Happiness < 0) changing_Status_text[i++].text = "행복도 - " + Mathf.Abs(get_eventData.member_Happiness);
        if (get_eventData.member_Learning_Point > 0) changing_Status_text[i++].text = "학습도 + " + Mathf.Abs(get_eventData.member_Learning_Point);
        else if (get_eventData.member_Learning_Point < 0) changing_Status_text[i++].text = "학습도 - " + Mathf.Abs(get_eventData.member_Learning_Point);
        if (get_eventData.member_Participation > 0) changing_Status_text[i++].text = "참여도 + " + Mathf.Abs(get_eventData.member_Participation);
        else if (get_eventData.member_Participation < 0) changing_Status_text[i++].text = "참여도 - " + Mathf.Abs(get_eventData.member_Participation);
    }
}
