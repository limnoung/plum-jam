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
public class GameInfo : MonoBehaviour {
    private static Stat[] stats;
    private void Start()
    {
        stats[0].name = "Player";
        stats[1].name = "EA";
        stats[2].name = "다방";
        stats[3].name = "WMV";
        stats[4].name = "ITQ";
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    static public Stat[] Get_Data()
    {
        return stats;
    }
    public static void Get_State(string name, int fund, int headCount, float reputation, float Happines, float participation,
        float learning_Point, bool isEnabled)
    {
        for(int i=0; i<stats.Length; i++)
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
}
