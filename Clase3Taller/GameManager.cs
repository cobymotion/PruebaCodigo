using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int time = 30; 
     [SerializeField] public int difficulty = 1;
    private void Awake()
    {
        if(Instance == null){
            Instance = this; 
        }
    }

    private void Start()
    {
        StartCoroutine(CountdownRoutine());        
    }

    IEnumerator CountdownRoutine(){

        while(time>0){
            yield return new WaitForSeconds(1);
            time --;
        }
        // se termino el juego. 
    }
}
