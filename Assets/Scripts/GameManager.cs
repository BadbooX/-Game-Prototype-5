using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Ajouter une list de prefabs pour la remplir avec les gameobjets
    public List<GameObject> targets;
    // Temps en seconde du spawn des prefabs
    private float spawnRate = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { // Lance la coroutine
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnTarget()
    {
        // Attends spawnRate seconde 
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            // CHoisit un index aléatoire entre 0 et le nombre max de préfab dans la list
            int index = Random.Range(0, targets.Count);
            // SPawn
            Instantiate(targets[index]);
        }
    }
}
