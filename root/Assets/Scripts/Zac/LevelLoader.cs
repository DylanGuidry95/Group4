using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : Singleton<LevelLoader> 
{
    public List<GameObject> persistant;
    [SerializeField]
    private string lastLevel;
    [SerializeField]
    private string currentLevel;

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

    public void loadLevel(string lvl)
    {
        if (lvl == "quit" || lvl == "Quit")
        {
            print("quit it ");
            Application.Quit();
        }

        if(lvl == "last" || lvl == "Last")
        {
            print("loading " + lvl);
            currentLevel = lvl;
            lastLevel = Application.loadedLevelName;
            Application.LoadLevel(lvl);
            // Carring over persistant Objects
            DontDestroyOnLoad(gameObject);
            for (int i = 0; i < persistant.Count; i++)
            {
                DontDestroyOnLoad(persistant[i]);
            }
        }

        else
        {
            print("loading " + lvl);
            currentLevel = lvl;
            lastLevel = Application.loadedLevelName;
            Application.LoadLevel(lvl);
            // Carring over persistant Objects
            DontDestroyOnLoad(gameObject);
            for (int i = 0; i < persistant.Count; i++)
            {
                DontDestroyOnLoad(persistant[i]);
            }
        }
        
    }


    Stack<string> lvlStack = new Stack<string>();
    /*
void OnLevelWasLoaded(int lvl)
{
    lastLevel = lvlStack.Peek();
    currentLevel = Application.loadedLevelName;
    lvlStack.Push(currentLevel);
}
*/
  
}


