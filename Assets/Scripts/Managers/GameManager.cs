using System;
using System.Collections;
using UnityEngine;

public enum EstadosDelJuego
{
    Inicio,
    Jugando,
    GameOver
}

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int velocidadMundo = 5;
    [SerializeField] private int multiplicadorPuntajePorMoneda = 10;

    public int Puntaje => (int) distanciaRecorrida + MonedasObtenidasEnEsteNivel * multiplicadorPuntajePorMoneda;

    public float ValorMultiplicador { get; set; }
    public EstadosDelJuego EstadoActual { get; set; }
    public int MonedasObtenidasEnEsteNivel { get; set; }

    private float distanciaRecorrida;

    private void Start()
    {
        ValorMultiplicador = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CambiarEstado(EstadosDelJuego.Jugando);
        }

        if(EstadoActual == EstadosDelJuego.Inicio || EstadoActual == EstadosDelJuego.GameOver)
        {
            return;
        }

        distanciaRecorrida += Time.deltaTime * velocidadMundo * ValorMultiplicador;
    }

    public void CambiarEstado(EstadosDelJuego nuevoEstado)
    {
        if (EstadoActual != nuevoEstado)
        {
            EstadoActual = nuevoEstado;
        }
    }

    public void IniciarConteoMultiplicador(float tiempo)
    {
        StartCoroutine(COMultiplicadorConteo(tiempo));
    }

    private IEnumerator COMultiplicadorConteo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        ValorMultiplicador = 1;
    }
}
