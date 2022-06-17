using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Textos")]
    [SerializeField] private TextMeshProUGUI diamantesObtenidosTMP;
    [SerializeField] private TextMeshProUGUI puntajeTMP;

    // Update is called once per frame
    void Update()
    {
        diamantesObtenidosTMP.text = GameManager.Instancia.MonedasObtenidasEnEsteNivel.ToString();
        puntajeTMP.text = GameManager.Instancia.Puntaje.ToString();
    }
}
