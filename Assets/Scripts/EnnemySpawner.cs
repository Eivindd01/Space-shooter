using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour{

    [SerializeField]
    private float spawnrate = 1f;

    [SerializeField]
    private GameObject[] ennemyPrefab;

    [SerializeField]
    private bool canSpawn = true;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnrate);

        while (canSpawn)
        {
            int rand = Random.Range(0, ennemyPrefab.Length);
            GameObject ennemyToSpawn = ennemyPrefab[rand];

            Instantiate(ennemyToSpawn, transform.position, Quaternion.identity);
            yield return wait;
        }     
    }

}
