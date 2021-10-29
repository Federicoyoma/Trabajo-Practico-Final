using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plancha : MonoBehaviour
{
    public GameObject planchaRosaPrefab;
    public GameObject rachel;
    private float lastShoot;
    private int Health = 3;

    public GameObject[] heartss;


    public float visionRadius;
    public float velocidad;
    GameObject cabezaPlancha;
    Vector3 initialPosition;

    private void Start()
    {
        cabezaPlancha = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;


        Health = heartss.Length;
    }
    





    // Start is called before the first frame update
    private void Update()
    {
        if (rachel == null) return;
        Vector3 direction = rachel.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(1.0f,1.0f,1.0f);

        float distance = Mathf.Abs(rachel.transform.position.x - transform.position.x);

        if(distance < 4.0f && Time.time > lastShoot +1.25f)
        {
            Shoot();
            lastShoot = Time.time;
        }

            Vector3 target = initialPosition;
            float dist = Vector3.Distance(rachel.transform.position, transform.position);
            if (dist < visionRadius) target = rachel.transform.position;
            float fixedSpeed = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);






        if (Health < 1)
        {
            Destroy(heartss[0].gameObject);
        }

        else if (Health < 2)
        {
            Destroy(heartss[1].gameObject);
        }

        else if (Health < 3)
        {
            Destroy(heartss[2].gameObject);
        }


    }


    private void Shoot()
    {
        Vector3 direction;

        if (transform.localScale.x == -1.0f) direction = Vector2.right;
        else direction = Vector3.left;
       GameObject planchaRosa = Instantiate(planchaRosaPrefab, transform.position + direction * 0.7f, Quaternion.identity);
        planchaRosa.GetComponent<BulletScript>().SetDirection(direction);
    }


    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);

    }





        //-------------------
       // if(Health == 0)
       // {
        //    SceneManager.LoadScene(escenaActual());
       // }
        //-----------------
    

    //---------------
   // int escenaActual()
    //{
     //  return SceneManager.GetActiveScene().buildIndex; 
   // }
    //---------------
}
