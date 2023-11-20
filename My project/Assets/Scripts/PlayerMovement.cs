using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    //[SerializeField] float velocidad = 5f;
    //[SerializeField] private float fuerzaSalto = 5f;

    // Variables de uso interno en el script
    private float moverHorizontal;
    private Vector2 direccion;
    private Animator anim;
    private SpriteRenderer sprite;
     private bool puedoSaltar = true;
    private bool saltando = false;
    public PlayerData playerData;

    public ShootScript shoot;
    [SerializeField] private AudioSource jumpSoundEffect;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        direccion = new Vector2(moverHorizontal, 0f);

         if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {
            jumpSoundEffect.Play();
            puedoSaltar = false;
            playerData.xp = playerData.xp + 25;
        }
        UpdateAnimationState();


        if (Input.GetMouseButton(0))
        {
           Recoil();
        }
    }



    private void FixedUpdate()
    {
        miRigidbody2D.AddForce(direccion * playerData.speed);

         if (!puedoSaltar && !saltando)
        {
            miRigidbody2D.AddForce(Vector2.up * playerData.jumpHeight, ForceMode2D.Impulse);
            saltando = true;
        }
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
        puedoSaltar = true;
        saltando = false;
    }



    private void UpdateAnimationState()
    {
     if(moverHorizontal > 0f)
        {
            anim.SetBool("running", true);
             sprite.flipX = false;
        }
        else if(moverHorizontal < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }

    public void Recoil()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        //var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //miRigidbody2D.AddForce((dir * -1) + (new Vector3(1f,1f,1f)));
        miRigidbody2D.AddForce((dir * -1) / 20);
        
    }
    
}