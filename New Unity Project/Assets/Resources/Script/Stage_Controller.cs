using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Controller : MonoBehaviour {
    [ExecuteInEditMode]
    [Header("확인해야할 변수")]
    [SerializeField] int Stage_Num = 1;
    [SerializeField] int Month = 1;

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
        Month = ++Month % 12;
        GetComponent<Event>().Get_Turn_Over_Signal();
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
