using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public TipoPowerUp tipoPower;
    public Material nuevoMaterial;

    private void OnTriggerEnter(Collider other)
    {
        move jugador = other.GetComponent<move>();
        if (jugador != null)
        {
            switch (tipoPower)
            {
                case TipoPowerUp.Velocidad:
                    jugador.speed = 10f;
                    break;
                case TipoPowerUp.DobleDisparo:
                    jugador.dobleDisparoActivo = true;
                    break;
                case TipoPowerUp.CambioColor:
                    Renderer rend = jugador.GetComponent<Renderer>();
                    if (rend != null && nuevoMaterial != null)
                    {
                        rend.material = nuevoMaterial;
                    }
                    break;
            }

            Destroy(gameObject);
        }
    }

}
