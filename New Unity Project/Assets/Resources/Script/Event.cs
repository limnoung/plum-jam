using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour {
    [ExecuteInEditMode]

    enum Club_Event_List {Club_Merge, Club_Closing, Get_Other_Club, Get_Chanllenge, Nitpicking_From_Dep_Office}
    List<Club_Event_List> All_Event_List;
    List<Club_Event_List> Event_Will_Applying;

    /*[Header("확인해야할 변수")]
    [SerializeField] int final_member_Change_Value;
    [SerializeField] int final_fund_Change_Value;
    [SerializeField] float final_club_Reputation_Change_Value, final_M_member_Happiness_Value, final_M_member_Participation_Value, final_M_Leanr_Value;*/

    [Header("적용해야할 변수")]
    [SerializeField] GameObject plum;
    [SerializeField] GameObject Event_Window;
    

    [Header("테스트용 변수")]
    [SerializeField] bool Initialize_Test = false;

    //이벤트 구조체
    public struct Event_Data_Property
    {
        public string event_Name, event_Explain_text;

        public int event_Num ,club_Fund, club_Member_num;
        public float club_Reputation, member_Happiness, member_Learning_Point, member_Participation;

        public Event_Data_Property(string event_Name, string event_Explain_text, int event_Num, int club_Fund, int club_Member_num, float club_Reputation, float member_Happiness, float member_Learning_Point, float member_Participation)
        {
            this.event_Name = event_Name;
            this.event_Explain_text = event_Explain_text;
            this.event_Num = event_Num;
            this.club_Fund = club_Fund;
            this.club_Member_num = club_Member_num;
            this.club_Reputation = club_Reputation;
            this.member_Happiness = member_Happiness;
            this.member_Learning_Point = member_Learning_Point;
            this.member_Participation = member_Participation;
        }
        
        public void Get_Data (string name, int event_Number, int Fund, int Member_num, float Reputation, float Happiness, float Learning_Point, float Participation)
        {
            event_Name = name;
            event_Num = event_Number;
            club_Fund = Fund;
            club_Member_num = Member_num;
            club_Reputation = Reputation;
            member_Happiness = Happiness;
            member_Learning_Point = Learning_Point;
            member_Participation = Participation;
        }

        public void Get_Explain_Text(string Long_Text)
        {
            event_Explain_text = Long_Text;
        }
    }
    List<Event_Data_Property> all_Event_Property = new List<Event_Data_Property>();

    //private
    public Event_Data_Property Club_Merge, Club_Closing, Get_Other_Club, Nitpicking_From_Dep_Office,
        Black_Out, WorkShop, Exam_Period;

    //[Header("조정해야할 변수")]
    //[SerializeField]

    //초기화
    private void Awake()
    {
        //이름, 이벤트 색인 넘버, 자금, 인원, 평판, 행복도, 학습도, 참여도
        Club_Merge.Get_Data("동아리 병합", 0, 0, 0, 1, 0, 1, 1);
        Club_Closing.Get_Data("동아리 폐쇄", 1, 0, 0, -1, 0, 0, 0);
        Get_Other_Club.Get_Data("타 동아리 흡수", 2, 0, 1, 0, 0, 1, 1);
        Nitpicking_From_Dep_Office.Get_Data("과사의 잔소리", 3, 0, 0, 0, -1, 0, 0);
        Black_Out.Get_Data("미래관 정전", 4, 0, 0, 0, -1, -1, 0);
        WorkShop.Get_Data("동아리 워크샵", 5, 1, 0, 1, 0, 0, 0);
        Exam_Period.Get_Data("시험기간", 6, 0, 0, 1, -1, 1, 1);

        Apply_Explain_text_To_event();

        all_Event_Property.Add(Club_Merge);
        all_Event_Property.Add(Club_Closing);
        all_Event_Property.Add(Get_Other_Club);
        all_Event_Property.Add(Nitpicking_From_Dep_Office);
        all_Event_Property.Add(Black_Out);
        all_Event_Property.Add(WorkShop);
        all_Event_Property.Add(Exam_Period);
    }

    private void Update()
    {
        if (Initialize_Test)
        {
            Initialize_Test = false;
            Get_Turn_Over_Signal();
        }
    }

    //public
    public void Get_Turn_Over_Signal()
    {
        Event_Data_Property Randomly_Created_Data = all_Event_Property[Random_Event_Create()];

        Send_Event_Signal(plum ,Randomly_Created_Data);
        Event_Window.GetComponent<Event_Window>().Get_Turn_Over_Signal(Randomly_Created_Data);
    }

    //private
    private int Random_Event_Create()
    {
        int Random_Value_Event = Mathf.RoundToInt(Random.Range(0.0f, 6.0f));
        Debug.Log("From Event 이벤트 실행 : " + all_Event_Property[Random_Value_Event].event_Name);

        return Random_Value_Event;
    }

    void Apply_Explain_text_To_event()
    {
        Club_Merge.Get_Explain_Text("동아리가 합쳐졌다!");
        Club_Closing.Get_Explain_Text("동아리가 폐쇄되었다 ㅠㅠ");
        Get_Other_Club.Get_Explain_Text("다른 동아리가 우리에게 합쳐졌다");
        Nitpicking_From_Dep_Office.Get_Explain_Text("과사에서 청소하라고 잔소리한다");
        Black_Out.Get_Explain_Text("미래관이 정전되어서 실습실 컴퓨터를 사용할 수가 없다");
        WorkShop.Get_Explain_Text("컴퓨터공학과 동아리 워크숍을 진행했다");
        Exam_Period.Get_Explain_Text("시험기간이 찾아왔다");
    }

    private void Send_Event_Signal(GameObject target, Event_Data_Property changing_Value_Struct)
    {
        target.GetComponent<Status>().Get_Fund_InOut(changing_Value_Struct.club_Fund);
        target.GetComponent<Status>().Get_Member_InOut(changing_Value_Struct.club_Member_num);
        target.GetComponent<Status>().Get_Reputateion_Change(changing_Value_Struct.club_Reputation);
        target.GetComponent<Status>().Get_Member_Status_Change_By_Addition(changing_Value_Struct.member_Happiness, changing_Value_Struct.member_Participation, changing_Value_Struct.member_Learning_Point);
    }
}
