using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameManager : Singleton<GameManager>
{

    [SerializeField]
    //public List<LevelStruct> Level = new List<LevelStruct>();
    public List<string> Levels = new List<string>();

    private bool transitionPossible;
    [SerializeField]
    private GameStates c_GameState;
    [SerializeField]
    private PauseState c_PauseState;

    /// Quick reset of levels List to empty
    [ContextMenu("reset levels")]  
    public void ResetLevels()
    {
        Levels = new List<string>();
    }

    protected override void Awake()
    {
        transitionPossible = true;
        c_GameState = GameStates.init;
       
        base.Awake();
    }

    /// Initialization
    void Start()
    {
        c_GameState = GameStates.mainMenu;
        c_PauseState = PauseState.None;
    }

    /// usage: GameManager.instance.Transition("Combat")
    public void Transition(string lev)
    {
        print("hit");
        if (lev == "start" || lev == "Start")
        {
            if (CheckTransition(GameStates.mainMenu) == true)
            {
                print("Transition hit");
                LevelLoader.instance.loadLevel("start");
                print(Application.loadedLevelName);
            }
        }

        if (lev == "arena" || lev == "Arena")
        {
            if (CheckTransition(GameStates.gamePlay))
            {
                print("Transition hit");
                LevelLoader.instance.loadLevel("Arena");
                print(Application.loadedLevelName);
            }
        }

        if (lev == "exit" || lev == "Exit")
        {
            if (CheckTransition(GameStates.gameOver) == true)
            {
                print("Transition hit");
                LevelLoader.instance.loadLevel("exit");
                print(Application.loadedLevelName);
            }
        }

        if (lev == "close" || lev == "Close" || lev == "quit" || lev == "Quit")
        {
            if (CheckTransition(GameStates.close) == true)
            {
                print("Transition hit");
                LevelLoader.instance.loadLevel("quit");
            }
        }
        
        else
        {
            print("No Transition");
        }
    }

    private bool CheckTransition(GameStates stateB)
    {
        if (c_GameState == stateB)
        {
            /// Not valid; Transistion to current state
            print("Already in this state. Check returned: False");
            return false;
        }

        else
        {
            switch (c_GameState)
            {
                    
                case GameStates.init:
                    if (stateB == GameStates.mainMenu)
                        return true;
                    break;

                case GameStates.mainMenu:
                    if (stateB == GameStates.gamePlay)
                        return true;
                    if (stateB == GameStates.close)
                        return true;
                    break;

                case GameStates.gamePlay:
                    if (stateB == GameStates.pause)
                        return true;
                    if (stateB == GameStates.gameOver)
                        return true;
                    break;

                case GameStates.pause:
                    if (stateB == GameStates.mainMenu)
                        return true;
                    if (stateB == GameStates.gamePlay)
                        return true;
                    if (stateB == GameStates.close)
                        return true;
                    break;

                case GameStates.gameOver:
                    if (stateB == GameStates.close)
                        return true;
                    break;

                default:
                    break;
            }
            // if not valid path return false

            print("invalid trans from " + c_GameState + " ---> " + stateB);
            print("Transistion Check Failed. Check returned: False");
            return false;
        }
    }

    public void Pause(PauseState state)
    {
        string debugtext = "Blank";
        switch (state)
        {
            case PauseState.None:
                c_PauseState = PauseState.None;
                Time.timeScale = 1;
                debugtext = "Full Update";
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked; 
                break;

            case PauseState.Half:
                c_PauseState = PauseState.Half;
                Time.timeScale = 0.5f;
                debugtext = "Half Update";
                break;

            case PauseState.Full:
                c_PauseState = PauseState.Full;
                Time.timeScale = 0;
                debugtext = "Update Halfed";
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;                
                break;

            default: 
                break;
        }
        // Debug
        print("Pause function hit. State triggered: " + debugtext);
        print(Time.timeScale);
    }

}
