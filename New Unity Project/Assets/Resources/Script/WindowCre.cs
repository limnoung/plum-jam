using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCre : MonoBehaviour {
    [SerializeField] public GameObject winUI;
    public GameObject mainUI;
   
	// Use this for initialization
	void Start () {
        winUI.SetActive(false);
        mainUI = GameObject.FindWithTag("mainUI");


    }
	public void windowCreation()
    {
        winUI.SetActive(true);
        mainUI.SetActive(false);
    }
    public void windowDestory()
    {
        winUI.SetActive(false);
        mainUI.SetActive(true);
    }

}
