using UnityEngine;
using System.Collections;

public class GUIRelay : MonoBehaviour
{

    public void loadLevelRelay(string lvl)
    {
        GameManager.instance.Transition(lvl);
    }




}
