using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;

[CreateAssetMenu(fileName = "GameData", menuName = "Game Data", order = 51)]
public class GameDataScript : ScriptableObject
{

    public bool gamePlaying = false;


    [SerializeField] public string username = "";

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

    private System.Type pointsBonus = typeof(BonusScript);
    private System.Type fastBonus = typeof(FastBonusScript);
    private System.Type slowBonus = typeof(SlowBonusScript);
    private System.Type ballBonus = typeof(BallBonusScript);
    private System.Type addTwoBonus = typeof(AddTwoBonusScript);
    private System.Type addTenBonus = typeof(AddTenBonusScript);

    private List<System.Type> bonuses = new List<System.Type>();

    [SerializeField] public KeyValuePair<string, int> nameTop1 = new KeyValuePair<string, int>("Unknown1",3);
    [SerializeField] public KeyValuePair<string, int> nameTop2 = new KeyValuePair<string, int>("Unknown2", 4);
    [SerializeField] public KeyValuePair<string, int> nameTop3 = new KeyValuePair<string, int>("Unknown3", 5);
    [SerializeField] public KeyValuePair<string, int> nameTop4 = new KeyValuePair<string, int>("Unknown4", 2);
    [SerializeField] public KeyValuePair<string, int> nameTop5 = new KeyValuePair<string, int>("Unknown5", 1);

    [SerializeField]
    public Dictionary<string, int> playersTop = new Dictionary<string, int>()
    {
        { "Unknown1", 2 },
        { "Unknown2", 1 },
        { "Unknown3", 5 },
        { "Unknown4", 4 },
        { "Unknown5", 3 },
        { "Unknown6", 3 }
    };

    public bool isGamePlaying()
    {
        return gamePlaying;
    }
    public void setGamePlaying()
    {
        gamePlaying = !gamePlaying;
    }
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

    public System.Type BonusTypeСhoose()
    {
        BonusSetup();
        return bonuses[Random.Range(0, bonuses.Count - 1)];
    }


    public void Reset()
    {
        username = "";
        level = 1;
        balls = 6;
        points = 0;
        pointsToBall = 0;
    }

    public void Save()
    {
        PlayerPrefs.SetString("username", username);

        PlayerPrefs.SetString("nameTop1Key", nameTop1.Key);
        PlayerPrefs.SetString("nameTop2Key", nameTop2.Key);
        PlayerPrefs.SetString("nameTop3Key", nameTop3.Key);
        PlayerPrefs.SetString("nameTop4Key", nameTop4.Key);
        PlayerPrefs.SetString("nameTop5Key", nameTop5.Key);

        PlayerPrefs.SetInt("nameTop1Value", nameTop1.Value);
        PlayerPrefs.SetInt("nameTop2Value", nameTop2.Value);
        PlayerPrefs.SetInt("nameTop3Value", nameTop3.Value);
        PlayerPrefs.SetInt("nameTop4Value", nameTop4.Value);
        PlayerPrefs.SetInt("nameTop5Value", nameTop5.Value);

        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("balls", balls);
        PlayerPrefs.SetInt("points", points);
        PlayerPrefs.SetInt("pointsToBall", pointsToBall);
        PlayerPrefs.SetInt("music", music ? 1 : 0);
        PlayerPrefs.SetInt("sound", sound ? 1 : 0);

    }

    public void Load()
    {
        username = PlayerPrefs.GetString("username", username);

        nameTop1 = new KeyValuePair<string, int>(
            PlayerPrefs.GetString("nameTop1Key", nameTop1.Key),
            PlayerPrefs.GetInt("nameTop1Value", nameTop1.Value)
        );
        nameTop2 = new KeyValuePair<string, int>(
            PlayerPrefs.GetString("nameTop2Key", nameTop2.Key),
            PlayerPrefs.GetInt("nameTop1Value", nameTop2.Value)
        );
        nameTop3 = new KeyValuePair<string, int>(
            PlayerPrefs.GetString("nameTop3Key", nameTop3.Key),
            PlayerPrefs.GetInt("nameTop1Value", nameTop3.Value)
        );
        nameTop4 = new KeyValuePair<string, int>(
            PlayerPrefs.GetString("nameTop4Key", nameTop4.Key),
            PlayerPrefs.GetInt("nameTop4Value", nameTop4.Value)
        );
        nameTop5 = new KeyValuePair<string, int>(
            PlayerPrefs.GetString("nameTop5Key", nameTop5.Key),
            PlayerPrefs.GetInt("nameTop5Value", nameTop5.Value)
        );

        level = PlayerPrefs.GetInt("level", 1);
        balls = PlayerPrefs.GetInt("balls", 6);
        points = PlayerPrefs.GetInt("points", 0);
        pointsToBall = PlayerPrefs.GetInt("pointsToBall", 0);
        music = PlayerPrefs.GetInt("music", 1) == 1;
        sound = PlayerPrefs.GetInt("sound", 1) == 1;
        
    }
    
}
