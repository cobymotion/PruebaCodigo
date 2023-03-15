using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointAgrega : MonoBehaviour
{
    [SerializeField] GameObject checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(agregaCheckpoint());
    }

    IEnumerator agregaCheckpoint() {
        while(true){
            yield return new WaitForSeconds(3); 
            Vector2 randomPosition  = Random.insideUnitCircle * 5; 
            Instantiate(checkpoint, randomPosition, Quaternion.identity);
        }
    }
}
