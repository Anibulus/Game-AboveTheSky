using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ENUM_GAME_STATUS
{
    MAIN_MENU,
    IN_GAME,
    GAME_OVER,
    PAUSE
}

public class GameManager : MonoBehaviour
{   
    public static GameManager sharedInstance;


    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;
    public static Action OnUpdateScore;


    [Space]
    [Header("Menus")]
    public GameObject GameOverScreen;

    void Awake()
    {
        sharedInstance = sharedInstance ?? this;
        DontDestroyOnLoad(this.gameObject);

        GameOverScreen.SetActive(false);
        OnPlayerDeath += ShowGameOverScreen;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void ShowGameOverScreen()
    {   
        GameOverScreen?.SetActive(true);
    }

    public void PlayerKilled()
    {
        OnPlayerDeath?.Invoke();
    }
    
    void OnEnable() 
    {
        OnUpdateScore += UpdateScoreUI;
    }

    void UpdateScoreUI()
    {
        //TODO cambiar el valor del score en la UI
        Debug.Log("Actualizando score");
    }

    public void ReturnToMainScreen()
    {
        SceneManager.LoadScene("Menu");
    }
}
