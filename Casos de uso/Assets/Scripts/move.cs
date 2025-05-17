using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    public float horizontalInput;
    public float verticalInput;
    public GameObject miObjeto;
    public GameObject miOtroObjeto;
    public bool cambiaObjeto = false;
    void Start()
    {

    }

    void Update()
    {
        //transform.Translate(Vector3.right * Time.deltaTime * speed);

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        if (transform.position.z < -15.86f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -15.86f);
        }
        if (transform.position.z > -7.05f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -7.05f);
        }
        if (transform.position.x > -0.05f)
        {
            transform.position = new Vector3(-0.05f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -5.05f)
        {
            transform.position = new Vector3(-5.05f, transform.position.y, transform.position.z);
        }


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            /* Instantiate(miObjeto, transform.position, Quaternion.identity); */
            cambiarObjeto();
        }


    }
    private void cambiarObjeto()
    {
        if (cambiaObjeto == true)
        {
            Instantiate(miOtroObjeto, transform.position, Quaternion.identity);
        } else
        {
            Instantiate(miObjeto, transform.position, Quaternion.identity);
        }

    }
}



