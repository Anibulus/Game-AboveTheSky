using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler sharedInstance;

    [Tooltip("Los objetos que pueden ser instanciados")]
    public List<ObjectPoolItem> itemsToPool;
    [Tooltip("Los objetos que ya se encuentran instanciados")]
    List<GameObject> instancedObjects;


    void Awake()
    {
        sharedInstance = sharedInstance ?? this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        instancedObjects = new();
        itemsToPool.ForEach(x=>
        {
            for (int i=0; i < x.amountToPool; i++)
            {
                GameObject go = Instantiate(x.objectToPool);
                go.SetActive(false);
                instancedObjects.Add(go);
            }
        });
    }

    public GameObject GetPoolObject(string tag)
    {
        GameObject go = null;
        
        instancedObjects.ForEach(x=> 
        {
            if(x.activeInHierarchy && x.CompareTag(tag))
            {
                Debug.Log("Esta es la bala que uso");
                go = x;
                return;
            }
        });

        if (go is not null)
            return go;

        Debug.Log("Comparo el tag");

        itemsToPool.ForEach(x=>{
            if (x.objectToPool.CompareTag(tag))
            {
                go = Instantiate(x.objectToPool);
                go.SetActive(false);
                instancedObjects.Add(go);
            }
        });

        return go;
    }

    [System.Serializable]
    public class ObjectPoolItem
    {
        public GameObject objectToPool;
        public int amountToPool;
    }
}
