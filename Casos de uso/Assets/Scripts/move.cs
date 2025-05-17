using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject miObjeto;
    public GameObject miOtroObjeto;
    public bool cambiaObjeto = false;
    public bool dobleDisparoActivo = false;

    public AudioClip disparoClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Disparar();
        }

        // Límite en eje X (ancho de la plataforma)
        if (transform.position.x > 6f)
        {
            transform.position = new Vector3(6f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -6f)
        {
            transform.position = new Vector3(-6f, transform.position.y, transform.position.z);
        }

        // Límite en eje Z (profundidad de la plataforma)
        if (transform.position.z > 1f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1f);
        }
        if (transform.position.z < -13f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -13f);
        }


    }

    void Disparar()
    {
        if (dobleDisparoActivo)
        {
            Instantiate(miObjeto, transform.position + Vector3.left * 0.2f, Quaternion.identity);
            Instantiate(miObjeto, transform.position + Vector3.right * 0.2f, Quaternion.identity);
        }
        else
        {
            Instantiate(miObjeto, transform.position, Quaternion.identity);
        }

        if (audioSource != null && disparoClip != null)
        {
            audioSource.PlayOneShot(disparoClip);
        }
    }
}





