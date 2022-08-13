using System;
using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ScenesManager
{
    private static int[] _list_SceneIndex;
    
    private static int[] List_SceneIndex
    {
        get
        {
            if (_list_SceneIndex == null || _list_SceneIndex.Length == 0)
            {
                _list_SceneIndex = new int[SceneManager.sceneCountInBuildSettings];
                for (int i = 0; i < _list_SceneIndex.Length; i++)
                {
                    _list_SceneIndex[i] = i;
                }
                Debug.Log("_list_SceneIndex" + _list_SceneIndex.Length);
    
            }
            return _list_SceneIndex;
        }
    }
    
    
    private static Queue<int> _sceneIndexRandomQueue;
    
    private static Queue<int> SceneIndexRandomQueue
    {
        get
        {
            if (_sceneIndexRandomQueue == null || _sceneIndexRandomQueue.Count == 0)
            {
                _sceneIndexRandomQueue = new Queue<int>(List_SceneIndex.RandomSort_oneself());
                Debug.Log("_sceneIndexRandomQueue" + _sceneIndexRandomQueue.Count);
            }
            return _sceneIndexRandomQueue;
        }
    }


    
   static int GetNextSceneIndexRandom()
   {
       return SceneIndexRandomQueue.Dequeue();
   }

    public static void LoadNextSceneRandom()
    {
        int nextScene = GetNextSceneIndexRandom();
        LoadScene(nextScene);
    }

    public static void LoadNextScene()
    {
        int nextScene = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        LoadScene(nextScene);
    }

    //(SceneManager.GetActiveScene().buildIndex + 1)% SceneManager.sceneCountInBuildSettings
    public static void LoadScene(int sceneIndex)
    {
        CoroutineManager.StartCoroutineTask(AsyncLoading(sceneIndex));
    }

    //StartCoroutine(AsyncLoading());
    private static AsyncOperation m_AsyOperation;

    static IEnumerator AsyncLoading(int sceneIndex)
    {
        m_AsyOperation = SceneManager.LoadSceneAsync(sceneIndex);
        m_AsyOperation.allowSceneActivation = true; //阻止加载完成自动切换
        yield return m_AsyOperation;
    }


    
}