using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject normalEnemy;

    [SerializeField]
    private GameObject bigEnemy;

    [SerializeField]
    private int spawnCountOffset;

    [SerializeField]
    private int bigSpawnCountOffset;

    [SerializeField]
    private float spawnRange;

    [SerializeField]
    private float minTimeBetweenSpawns;

    [SerializeField]
    private float maxTimeBetweenSpawns;

    [SerializeField]
    private AnimationCurve normalEnemySpawnCurve;

    [SerializeField]
    private AnimationCurve bigEnemySpawnCurve;

    [SerializeField]
    private Animator anim;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        GameEvents.Instance.WaveCleared += SpawnEnemys;
    }

    private void SpawnEnemys(bool _)
    {
        StartCoroutine("SpawnNomalEnemys");
        StartCoroutine("SpawnBigEnemys");
    }

    private IEnumerator SpawnNomalEnemys()
    {   
        yield return new WaitForSeconds(0.1f);
        int normalSpawnCount = Mathf.RoundToInt(normalEnemySpawnCurve.Evaluate(PlayerPrefs.GetInt("WavesCleared")) + Random.Range(0, spawnCountOffset));

        if (normalSpawnCount > 0 && anim !=null)
        {
            anim.Play("gate_down");

        }

        for (int i = 0; i < normalSpawnCount; i++)
        {
            yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns));
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));

            Instantiate(normalEnemy, transform.position + spawnPos, transform.rotation, this.transform);
        }
    }


    private IEnumerator SpawnBigEnemys()
    {
        int bigSpawnCount = Mathf.RoundToInt(bigEnemySpawnCurve.Evaluate(PlayerPrefs.GetInt("WavesCleared")) + Random.Range(0, bigSpawnCountOffset));

        if (bigSpawnCount > 0 && anim != null)
        {
            anim.Play("gate_down");

        }

        for (int i = 0; i < bigSpawnCount; i++)
        {
            yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns));
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));

            Instantiate(bigEnemy, transform.position + spawnPos, transform.rotation, this.transform);
        }
    }
}
