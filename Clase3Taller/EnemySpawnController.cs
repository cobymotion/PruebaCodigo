using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs; 
    [Range(1,10)][SerializeField] float spawnRate=1; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }


    IEnumerator SpawnEnemy(){
        while(true){
            yield return new WaitForSeconds(3/spawnRate);
            float random = Random.Range(0.0f, 1.0f);
            if(random < GameManager.Instance.difficulty * 0.1f){
                Instantiate(enemyPrefabs[1]);
            }else 
            {
                Instantiate(enemyPrefabs[0]);
            }
            
        }
    }
}
