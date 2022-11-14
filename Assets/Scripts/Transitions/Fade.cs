using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fade : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        FadeOut();
        GameManager.OnPlayerDeath += FadeIn;
    }

    [ContextMenu("Fade In")]
    public void FadeIn()
    {
        spriteRenderer.DOFade(1,2);
    }

    [ContextMenu("FadeOut")]
    public void FadeOut()
    {
        spriteRenderer.DOFade(0,2);
    }
}
