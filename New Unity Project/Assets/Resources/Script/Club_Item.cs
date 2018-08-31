using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club_Item : MonoBehaviour {
    [ExecuteInEditMode]
    enum Helpful_Club_Item {Advertise_Pannel, Playing_Card, Sanquaehan, Coupang, Earplug }

    [Header("조정해야 할 변수")]
    [SerializeField] Helpful_Club_Item Item_Type;

}
