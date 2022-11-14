using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenu : Fade
{
    public void Play()
    {
        SpriteRenderer sp = FindObjectOfType<SpriteRenderer>(CompareTag("UI")); 
        sp.DOFade(1,2).OnComplete(()=> {
            SceneManager.LoadScene("Main");
        });
    }
}
