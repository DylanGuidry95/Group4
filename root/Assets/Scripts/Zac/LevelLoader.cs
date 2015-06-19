using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : Singleton<LevelLoader> 
{
    public List<GameObject> persistant;
    void Start()
    {
        lastLevel = "Intro";
        currentLevel = lastLevel;
        lvlStack.Push(lastLevel);
    }
    void addPersistant(GameObject o)
    {
        persistant.Add(o);
    }
    void removePersistant(GameObject o)
    {
        persistant.Remove(o);
    }

    void loadLevel(string nextLevel, LevelState state)
    {
        currentLevel = nextLevel;
        lastLevel = Application.loadedLevelName;
        Application.LoadLevel(nextLevel);
        // Carring over persistant Objects
        DontDestroyOnLoad(gameObject);
        for (int i =0; i < persistant.Count; i++)
        {
            DontDestroyOnLoad(persistant[i]);
        }          
    }

    public void loadLevel(string lvl)
    {
        if (lvl == "quit" || lvl == "Quit")
        {
            print("quit it ");
            Application.Quit();
        }
        else
        {
            print("loading " + lvl);
            Application.LoadLevel(lvl);
        }
        
    }
        // User can just pass in Quit to th level loader to quit out of the application 
    //public void ExitGame()
    //{
    //    Application.Quit();
    //}


    Stack<string> lvlStack = new Stack<string>();
    /*
void OnLevelWasLoaded(int lvl)
{
    lastLevel = lvlStack.Peek();
    currentLevel = Application.loadedLevelName;
    lvlStack.Push(currentLevel);
}
*/
    [SerializeField]
    private string lastLevel;
    public  string currentLevel;
}
