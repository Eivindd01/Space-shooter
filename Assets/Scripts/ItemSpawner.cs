using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    PlayerHealth playerHealth; //Prend les hp du joueur
    [SerializeField]
    public int healBonus = 2; //Le heal de l'item

    [SerializeField]
    PlayerControler player;

    [SerializeField]
    private float spawnrate = 1f;

    [SerializeField]
    private GameObject[] itemPrefab;

    [SerializeField]
    private bool canSpawn = true;

    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (playerHealth.currentHealth < playerHealth.maxHealth) //Si hp moins que le max
        {
            Destroy(gameObject); //Detruit l'objet après collision
            playerHealth.currentHealth = playerHealth.currentHealth + healBonus; //Applique le heal 
        }
    }

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnrate); //Attend le nombre de secondes avant de spawn

        while (canSpawn)
        {
            yield return wait;
            int rand = Random.Range(0, itemPrefab.Length);
            GameObject itemToSpawn = itemPrefab[rand];

            Instantiate(itemToSpawn, transform.position, Quaternion.identity);
        }
    }
}
