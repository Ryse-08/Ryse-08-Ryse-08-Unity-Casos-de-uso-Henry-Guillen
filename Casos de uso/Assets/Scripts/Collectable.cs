using Unity.VisualScripting;
using UnityEngine;


public class Collectable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisiona con " + other.name);

        move myobject = other.GetComponent<move>();

        myobject.cambiaObjeto = true;

        Destroy(this.gameObject);

        move myobject = other.GetComponent<move>();

        if (myobject != null)
        {
            myobject.cambiaObjeto = true;

            // Nueva lógica: aumentar velocidad
            myobject.StartCoroutine(AumentarVelocidadTemporal(myobject));
        }

        Destroy(this.gameObject);

    }
    
    private IEnumerator AumentarVelocidadTemporal(move jugador)
    {
        jugador.speed = 10f; // Duplicamos la velocidad
        yield return new WaitForSeconds(5f); // Dura 5 segundos
        jugador.speed = 5f; // Vuelve a la normalidad
    }

    
}
