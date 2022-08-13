using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }//单例

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
                
    }

    // private float timer = 0;
    // public float rote = 1;
    // // Update is called once per frame
    // void Update()
    // {
    //     if (Time.time > timer + rote)
    //     {
    //         timer = Time.time;
    //         ScenesManager.LoadNextSceneRandom();
    //
    //     }
    // }
}
