using UnityEngine;
using System.Collections;

public class GoalStats : Stats
{
    void Start()
    {
        m_Health = m_MaxHealth;
        isGoal = true;
    }

    void Update()
    {
        FindObjectOfType<HUDManager>().CoinHpHUD(m_Health, m_MaxHealth);

        if (m_Health <= 0)
        {
            LevelLoader.instance.loadLevel("exit");
        }
    }

    void destroy()
    {
        print("test hit");
        GameManager.instance.Transition("exit");
    }
}
