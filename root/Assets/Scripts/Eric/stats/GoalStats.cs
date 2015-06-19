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
            Destroy();
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
       LevelLoader.instance.loadLevel("Exit");
    }
}
