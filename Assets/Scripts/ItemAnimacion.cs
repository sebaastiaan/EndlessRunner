using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimacion : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private bool activarRotacion;
    [SerializeField] private bool activarScale;

    [Header("Rotacion")]
    [SerializeField] private Vector3 anguloRotacion;
    [SerializeField] private float velocidadRotacion;

    [Header("Scale")]
    [SerializeField] private Vector3 scaleInicial;
    [SerializeField] private Vector3 scaleFinal;
    [SerializeField] private float velocidadScale;
    [SerializeField] private float scaleRatio;

    private float tiempoScale;
    private bool scaleSuperior;

    // Update is called once per frame
    void Update()
    {
        if(activarRotacion)
        {
            transform.Rotate(anguloRotacion * velocidadRotacion * Time.deltaTime);
        }

        //animacion para aumentar y disminuair tamaño
        if(activarScale)
        {
            tiempoScale += Time.deltaTime;
            if(scaleSuperior)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, scaleFinal, velocidadScale * Time.deltaTime);
            }
            else
            {
                transform.localScale = Vector3.Lerp(transform.localScale, scaleInicial, velocidadScale * Time.deltaTime);
            }

            //invertimos la animacion
            if(tiempoScale >= scaleRatio)
            {
                scaleSuperior = !scaleSuperior;
                tiempoScale = 0f;
            }
        }
    }
}
