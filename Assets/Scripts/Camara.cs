using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject rachel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rachel != null)
        {
            Vector3 position = transform.position;
            position.x = rachel.transform.position.x;
            transform.position = position;
        }
    }
}
