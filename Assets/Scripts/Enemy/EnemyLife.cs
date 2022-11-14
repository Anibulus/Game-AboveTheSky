using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D), typeof(BoxCollider2D))]
public class EnemyLife : MonoBehaviour
{
    public GameObject explotion;

    void OnEnable() 
    {
        GameManager.OnUpdateScore += Deactivate;  
    }

    void OnDisable() 
    {
        GameManager.OnUpdateScore.Invoke();
        GameManager.OnUpdateScore -= Deactivate;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(Tags.PLAYER))
        {
            Instantiate(explotion,this.transform.position, Quaternion.identity);
            Deactivate();
        }
        Debug.Log(collider.tag);
        
        if (collider.CompareTag(Tags.BULLET))
        {
            Instantiate(explotion,this.transform.position, Quaternion.identity);
            Deactivate();
        }
    }

    void Deactivate()
    {
        //Destroy
        this.gameObject.SetActive(false);
    }
}
