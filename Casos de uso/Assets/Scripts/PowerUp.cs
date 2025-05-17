using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public TipoPowerUp tipoPower;
    public Color nuevoColor = Color.green;

    private void OnTriggerEnter(Collider other)
    {
        move jugador = other.GetComponent<move>();
        if (jugador != null)
        {
            switch (tipoPower)
            {
                case TipoPowerUp.Velocidad:
                    StartCoroutine(AumentarVelocidadTemporal(jugador));
                    break;
                case TipoPowerUp.DobleDisparo:
                    jugador.dobleDisparoActivo = true;
                    break;
                case TipoPowerUp.CambioColor:
                    jugador.GetComponent<Renderer>().material.color = nuevoColor;
                    break;
            }

            Destroy(gameObject);
        }
    }

    private IEnumerator AumentarVelocidadTemporal(move jugador)
    {
        jugador.speed = 10f;
        yield return new WaitForSeconds(1f);
        jugador.speed = 5f;
    }
}
