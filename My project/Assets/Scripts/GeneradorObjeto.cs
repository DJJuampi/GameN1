using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjeto : MonoBehaviour
{
    [SerializeField] private GameObject objetoPrefab;

    [SerializeField]
    [Range(0.0f, 0.0f)]
    private float tiempoEspera;

    [SerializeField]
    [Range(0.0f, 0.0f)]
    private float tiempoIntervalo;

    [SerializeField] private float segundos;
    [SerializeField] private float startTime;

    private float tiempoRestante;
    private GameObject newInstance;

    void Start()
    {
        tiempoRestante = startTime;
        //Invoke("GenerarObjetoLoop", tiempoEspera);
        //InvokeRepeating(nameof(GenerarObjetoLoop), tiempoEspera, tiempoIntervalo);
    }

 void Update()
    {   
       
        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0)
        {  
            tiempoRestante = segundos;
            //CancelInvoke(nameof(GenerarObjetoLoop));
            Destroy(newInstance);
            Invoke("GenerarObjetoLoop", tiempoEspera);
            //InvokeRepeating(nameof(GenerarObjetoLoop), tiempoEspera, tiempoIntervalo);
        }
    }
    void GenerarObjetoLoop()
    {
        
        newInstance = Instantiate(objetoPrefab, new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 1), Quaternion.identity);
    }
}