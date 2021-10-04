using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using UnityEngine.UI;
using System;
public class PlayerScores : MonoBehaviour
{
    public Text scoreText;
    public InputField nameText;

    private System.Random random = new System.Random();

    User user = new User();

    public static int playerScore;
    public static string playerName;

    private void Start()
    {
        playerScore = random.Next(0, 101);
        scoreText.text = " Puntos:" + playerScore;

    }

    private void UpdateScore()
    {
        scoreText.text = "Puntos: " + user.userScore;
    }


    private void PostToDataBase()
    {
        User user = new User();
        RestClient.Put("https://prueba1-9d9ac-default-rtdb.firebaseio.com/" + playerName + ".json", user);
    }
    public void OnSumbit()
    {
        playerName = nameText.text;
        PostToDataBase();
    }
    private void RetrieveFromDatabase()
    {
        RestClient.Get<User>("https://prueba1-9d9ac-default-rtdb.firebaseio.com/" + nameText.text + ".json").Then(response =>
        {
            user = response;
            UpdateScore();
            });

    }
    public void OnGetScore()
    {
        RetrieveFromDatabase();
    }

}


[Serializable]
public class User
{
    public string userName;
    public int userScore;

    public User()
    {
        userName = PlayerScores.playerName;
        userScore = PlayerScores.playerScore;
    }

}
