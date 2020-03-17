using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static GameManager singleton;

    UiManager UiManager;
    //Altri Manager
    Animator GameSM;
    // Start is called before the first frame update

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
        Setup();
    }
    #region GameSm Trigger Delegate
    /// <summary>
    /// Delegato che gestisce gli eventi lanciati dall'esterno per triggerare il cambio di stato della GameStateMachine
    /// </summary>
    public delegate void GameSMTriggerDelegate();

    //public static GameSMTriggerDelegate Setup;

    public static GameSMTriggerDelegate GoToMainMenu;

    public static GameSMTriggerDelegate GoToOption;

    public static GameSMTriggerDelegate GoTOGamePlay;
    #endregion

    #region GamePlay Trigger Delegate
    public delegate void GamePlayTriggerDelegate();

    public static GamePlayTriggerDelegate RemoveLife;
    public static GamePlayTriggerDelegate AddLife;

    #endregion

    public static void Setup()
    {
        singleton.UiManager = FindObjectOfType<UiManager>();
        singleton.GameSM = singleton.GetComponent<Animator>();
    }
    private void OnEnable()
    {
        EventSetup();
    }
    /// <summary>
    /// Funzione che si occupa di iscriversi a N eventi in base alla tipologia di struttura.
    /// </summary>
    public static void EventSetup()
    {
        GoToMainMenu += singleton.HandleGoToMainMenu;
        GoToOption += singleton.HandleGoToOption; 
    }

    /// <summary>
    /// Funzione che gestisce l'evento GoToMainMenu
    /// </summary>
    void HandleGoToMainMenu()
    {
        if (!singleton.GameSM.GetCurrentAnimatorStateInfo(0).IsName("MainMenu"))
        {
            singleton.GameSM.SetTrigger("GoToMainMenu");
        }

        
    }

    void HandleGoToOption()
    {
      

        if (!singleton.GameSM.GetCurrentAnimatorStateInfo(0).IsName("Option"))
        {
            singleton.GameSM.SetTrigger("GoToOption");
        }
    }

    private void OnDisable()
    {
        GoToMainMenu -= singleton.HandleGoToMainMenu;
        GoToOption -= singleton.HandleGoToOption;
    }

}
