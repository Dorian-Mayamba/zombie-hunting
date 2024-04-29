using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    

    private static GameController instance;

    private PlayerController playerManager;
    

    private void Awake() {
        if(instance != this || instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(transform.gameObject);
    }

    public static GameController GetInstance()
    {
        return instance;
    }

    void Start()
    {
        playerManager = PlayerController.GetInstance();
    }

// Update is called once per frame
    
}
