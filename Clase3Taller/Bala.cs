using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] float velocidad = 1; 

    void Start()
    {
       Destroy(gameObject, 5) ; 
    }
    void Update()
    {
        transform.position += transform.right 
        * Time.deltaTime * velocidad; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemigo")){
            collision.GetComponent<Enemigo>().disminuirSalud(); 
            Destroy(gameObject);
        }
        
    }
}
