using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamante : MonoBehaviour
{
    [SerializeField] private int valorMoneda = 1;

    private void ObtenerDiamante()
    {
        MonedaManager.Instancia.AñadirMonedas(valorMoneda);
        GameManager.Instancia.MonedasObtenidasEnEsteNivel += valorMoneda;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"));
        {
            ObtenerDiamante();
        }
    }
}
