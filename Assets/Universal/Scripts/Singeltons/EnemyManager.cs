using UnityEngine;
public class EnemyManager : MonoBehaviourSingleton<EnemyManager>
{
    public int CurrentEnemyCount{ 
        set {
            currentEnemyCount = value;
            CheckEnemyCount();
        }
        get { return currentEnemyCount; }
    }

    private int currentEnemyCount;
    
    public int MaxEnemysInAttackRange;
    [HideInInspector]
    public int EnemysInAttackRange; 

    public void CheckEnemyCount()
    {
       

        if (CurrentEnemyCount <= 0)
        {
            int wavesCleared = PlayerPrefs.GetInt("WavesCleared");
            PlayerPrefs.SetInt("WavesCleared", wavesCleared + 1);
            GameEvents.Instance.WaveCleared.Invoke(true);

        }
    }

}
