using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage_Controller : MonoBehaviour {
    [ExecuteInEditMode]
    [Header("확인해야할 변수")]
    [SerializeField] int Stage_Num = 1;
    [SerializeField] int Month = 1, Year = 2018;

    [Header("적용해야 할 변수")]
    [SerializeField] Text Date_Text;

    //[Hearder("조정해야할 변수")]


    [Header("테스트 전용 변수")]
    [SerializeField] bool test_Turn_Over_signal = false;
    //public bool Test_Sending_Signal = false;
    //public bool Test_Event_Signal_Send = false;
    //public bool Test_Activation_Signal_Send = false;

    private void Update()
    {
        if (test_Turn_Over_signal)
        {
            test_Turn_Over_signal = false;
            Get_Turn_Over_Signal();
        }
    }

    public void Get_Turn_Over_Signal()
    {
        Stage_Num++;
        Year += (Month + 1) / 13;
        Month = ++Month % 13 + Month / 13;
        
        GetComponent<Event>().Get_Turn_Over_Signal();
        Date_Text.text = Year + "년 " + Month + "월";
    }

    public void Get_Turn_Start_Siganl()
    {

    }

    /*public void Get_Event_Signal()
    {

    }

    public void Get_Activity_Signal()
    {

    }

    public void Get_TurnOver_Siganl()
    {

    }*/
}
