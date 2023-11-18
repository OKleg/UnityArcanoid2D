using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "GameData", menuName = "Game Data", order = 51)]
public class GameDataScript : ScriptableObject
{
    public bool resetOnStart;
    public int level = 1;
    public int balls = 6;
    public int points = 0;
    public int pointsToBall = 0;

    public bool music = true;
    public bool sound = true;

    public int pointsBonusCount = 1;
    public int fastBonusCount = 1;
    public int slowBonusCount = 1;
    public int ballBonusCount = 1;
    public int addTwoBonusCount = 1;
    public int addTenBonusCount = 1;

    private System.Type pointsBonus =  typeof(BonusScript);
    private System.Type fastBonus =  typeof(FastBonusScript);
    private System.Type slowBonus =  typeof(SlowBonusScript);
    private System.Type ballBonus =  typeof(BallBonusScript);
    private System.Type addTwoBonus =  typeof(AddTwoBonusScript);
    private System.Type addTenBonus =  typeof(AddTenBonusScript);

    private List<System.Type> bonuses = new List<System.Type>();

    private void BonusSetup()
    {
        if (pointsBonus != null)
            bonuses.AddRange(Enumerable.Repeat(pointsBonus, pointsBonusCount));
        if (fastBonus != null)
            bonuses.AddRange(Enumerable.Repeat(fastBonus, fastBonusCount));
        if (slowBonus != null)
            bonuses.AddRange(Enumerable.Repeat(slowBonus, slowBonusCount));
        if (ballBonus != null)
            bonuses.AddRange(Enumerable.Repeat(ballBonus, ballBonusCount));
        if (addTwoBonus != null)
            bonuses.AddRange(Enumerable.Repeat(addTwoBonus, addTwoBonusCount));
        if (addTenBonus != null)
            bonuses.AddRange(Enumerable.Repeat(addTenBonus, addTenBonusCount));
    }

    public System.Type BonusTypeСhoose(){
        BonusSetup();
        return  bonuses[Random.Range(0, bonuses.Count-1)];
    }

    public void Reset()
    {
        level = 1;
        balls = 6;
        points = 0;
        pointsToBall = 0;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("balls", balls);
        PlayerPrefs.SetInt("points", points);
        PlayerPrefs.SetInt("pointsToBall", pointsToBall);
        PlayerPrefs.SetInt("music", music ? 1 : 0);
        PlayerPrefs.SetInt("sound", sound ? 1 : 0);
    }

    public void Load()
    {
        level = PlayerPrefs.GetInt("level", 1);
        balls = PlayerPrefs.GetInt("balls", 6);
        points = PlayerPrefs.GetInt("points", 0);
        pointsToBall = PlayerPrefs.GetInt("pointsToBall", 0);
        music = PlayerPrefs.GetInt("music", 1) == 1;
        sound = PlayerPrefs.GetInt("sound", 1) == 1;
    }

}
