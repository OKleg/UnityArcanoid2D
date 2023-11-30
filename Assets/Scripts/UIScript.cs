using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{

    [SerializeField] private GameObject menuImage;
    [SerializeField] private string username;
    [SerializeField] private Text usernameText;


    [SerializeField] public Text pauseText;
    [SerializeField] public Text youInTop;


    [SerializeField] private Text nameTop1;
    [SerializeField] private Text nameTop2;
    [SerializeField] private Text nameTop3;
    [SerializeField] private Text nameTop4;
    [SerializeField] private Text nameTop5;


    [SerializeField] private GameDataScript gameData;
    public void setName()
    {
        usernameText.text = gameData.username;
    }
    public void HideMenuImage()
    {
        //Disable the levelImage gameObject.
        Cursor.visible = false;
        menuImage.SetActive(false);
    }
    public void ShowMenuImage()
    {
        setName();
        Cursor.visible = true;
        menuImage.SetActive(true);
    }
    public void ChangeUsername()
    {
        username = usernameText.text;
        gameData.username = username;
    }
    public void SetTop()
    {
        nameTop1.text = gameData.nameTop1.ToString();
        nameTop2.text = gameData.nameTop2.ToString();
        nameTop3.text = gameData.nameTop3.ToString();
        nameTop4.text = gameData.nameTop4.ToString();
        nameTop5.text = gameData.nameTop5.ToString();
    }
    public void TopSetup()
    {
        //public Dictionary<string, int> playersTop = new Dictionary<string, int>();
        gameData.playersTop.Clear();
        gameData.playersTop.Add(gameData.nameTop1.Key, gameData.nameTop1.Value );
        gameData.playersTop.Add(gameData.nameTop2.Key, gameData.nameTop2.Value);
        gameData.playersTop.Add(gameData.nameTop3.Key, gameData.nameTop3.Value);
        gameData.playersTop.Add(gameData.nameTop4.Key, gameData.nameTop4.Value);
        gameData.playersTop.Add(gameData.nameTop5.Key, gameData.nameTop5.Value);

        if (username != "" )
        {
            if (gameData.playersTop.ContainsKey(username))
            {
                gameData.playersTop[username] = Mathf.Max(gameData.points, gameData.playersTop[username]);
            }
            else
                gameData.playersTop[username] = gameData.points;
        }
        gameData.playersTop = gameData.playersTop.OrderBy(x => x.Value).ToDictionary(x=>x.Key,x=>x.Value);
        var Top = gameData.playersTop.TakeLast(5).ToArray();

        if (username != gameData.nameTop1.Key 
            && username != gameData.nameTop2.Key
             && username != gameData.nameTop3.Key
             && username != gameData.nameTop4.Key
             && username != gameData.nameTop5.Key
            && (Top[0].ToString().Contains(username) 
                    || Top[1].ToString().Contains(username)
                    || Top[2].ToString().Contains(username)
                    || Top[3].ToString().Contains(username)
                    || Top[4].ToString().Contains(username)
                )
            )
        {
            youInTop.text = "Вы в топе";
            //GameObject.Find("YouInTop").SetActive(true); //GetComponent<Text>().text
        }
        else
        {
            //GameObject.Find("YouInTop").SetActive(false);
            youInTop.text = "";
        }


        gameData.nameTop1 = Top[4];
        gameData.nameTop2 = Top[3];
        gameData.nameTop3 = Top[2];
        gameData.nameTop4 = Top[1];
        gameData.nameTop5 = Top[0];

        nameTop1.text = Top[4].ToString();
        nameTop2.text = Top[3].ToString();
        nameTop3.text = Top[2].ToString();
        nameTop4.text = Top[1].ToString();
        nameTop5.text = Top[0].ToString();


        print("TOP: \n");
        foreach (var i in gameData.playersTop)
        {
            print($"{i.Key} - {i.Value} \n");
        }
        //print(Top[5].ToString());

    }
    public void EndGame()
    {
        TopSetup();
        gameData.setGamePlaying();
        gameData.Reset();
        ShowMenuImage();
    }

    public void OnPlayButtonClick()
    {
        print(Time.timeScale);
        if (username !="")
            if (!gameData.isGamePlaying())
            {
                gameData.setGamePlaying();
                HideMenuImage();
                ChangeUsername();
                Time.timeScale = 1;
            }
            else
            if (Time.timeScale <= 0)
            {
                Time.timeScale = 1;
                HideMenuImage();
            }
    }

    public void OnExitButtonClick()
    {
            EndGame();
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        
    }
    public void OnRestartButtonClick()
    {
        if (username != "" &&  (gameData.isGamePlaying()))
        {
            EndGame();
            SceneManager.LoadScene("MainScene");
        }
    }

}
