using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletRachel : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
   private void FixedUpdate()
    {
           Rigidbody2D.velocity = Direction * Speed;
        
    }


    public void SetDirection(Vector2 direction)
    {
       Direction = direction;
    }





    //----------------------------------------

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Plancha cabezaPlancha = collision.collider.GetComponent<Plancha>();

          if (cabezaPlancha != null)
         {
           cabezaPlancha.Hit();
           DestroyBullet();
        }
    }


}
