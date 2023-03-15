using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int salud = 10 ;
    float mHor;
    float mVer;
    bool cargado=true; 
    Vector3 moveDirection;
    Vector2 moveMira; 
    [SerializeField] int speed=3;
    [SerializeField] Camera camera; 
    [SerializeField] Transform mira; 
    [SerializeField] Transform bala; 
    [SerializeField] float cadencia = 1; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
        mHor = Input.GetAxis("Horizontal");
        mVer = Input.GetAxis("Vertical");
        moveDirection.x = mHor;
        moveDirection.y = mVer;
        transform.position += moveDirection * Time.deltaTime * speed;
        /// movimiento de la mira 
        moveMira = camera.ScreenToWorldPoint(Input.mousePosition) 
                       - transform.position;
        mira.position = (Vector3)moveMira.normalized + transform.position; 
        
        if(Input.GetMouseButton(0) && cargado){
            cargado = false; 
            float angulo = Mathf.Atan2(moveMira.y, moveMira.x) * Mathf.Rad2Deg;
            Quaternion objetivo = Quaternion.AngleAxis(angulo, Vector3.forward); 
            Instantiate(bala, transform.position, objetivo);
            StartCoroutine(Recargar());
        }

    }

    IEnumerator Recargar() {
        yield return new WaitForSeconds(1/cadencia);
        cargado = true; 
    }

    public void disminuirSalud() {
        salud--;
        if(salud == 0) {
            Destroy(gameObject);
        }
        
    }

}
