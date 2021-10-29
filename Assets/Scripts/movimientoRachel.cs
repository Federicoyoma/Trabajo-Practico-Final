using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movimientoRachel : MonoBehaviour
{
    public GameObject proyectilPrefab;
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    public float JumpForce;
    public float Speed;
    private bool Grounded;
    private Animator Animator;
    private int Health = 5;
    private float LastShoot;



    public GameObject[] hearts;


    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();


        Health = hearts.Length;
    }

    
    void Update()
    {
       Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("Running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;
        

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }


        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }





        
        if(Health < 1)
        {
            Destroy(hearts[0].gameObject);
        }

        else if(Health < 2)
        {
            Destroy(hearts[1].gameObject);
        }

        else if (Health < 3)
        {
            Destroy(hearts[2].gameObject);
        }

        else if (Health < 4)
        {
            Destroy(hearts[3].gameObject);
        }

        else if (Health < 5)
        {
            Destroy(hearts[4].gameObject);
        }
       

    }

    private void Shoot()
    {

        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;
        GameObject proyectil = Instantiate(proyectilPrefab, transform.position + direction * 0.7f, Quaternion.identity);
        proyectil.GetComponent<bulletRachel>().SetDirection(direction);
    }


    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate() {
        Rigidbody2D.velocity = new Vector2(Horizontal*Speed, Rigidbody2D.velocity.y);
    }
        
    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);


      
        if (Health == 0)
        {
            SceneManager.LoadScene(escenaActual());
        }
        



        

    }



    
    int escenaActual()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    
}
