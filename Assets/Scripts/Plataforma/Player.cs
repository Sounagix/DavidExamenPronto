using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //teclas
    [Header("Teclas")]
    [SerializeField]
    private KeyCode left;

    [SerializeField]
    private KeyCode rigth;

    [SerializeField]
    private KeyCode jump;

    [SerializeField]
    private KeyCode topMov;

    [SerializeField]
    private KeyCode attack;

    [Header("Movimiento")]
    [SerializeField] [Tooltip("Velocidad del jugador")] [Min(2.0f)]
    private float moveSpeed;

    [SerializeField]
    private float jumpSpeed;
    
    [SerializeField]
    private float topSpeed;

    [SerializeField]
    private float topMaxSpeed;

    [SerializeField]
    private int totalNumCoins;

    private int currNumCoins = 0;

    private Rigidbody2D rb;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

    private Sounds sounds;

    private Life life;

    private Vector2 initPos;

    [SerializeField]
    private GameObject prefabBala;

    [SerializeField]
    private float balaVelocidad;

    //  Si el player está situado en una escalera
    private bool EnPosicionEscaleras;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        life = GetComponent<Life>();
        sounds = GetComponent<Sounds>();
    }

    private void Start()
    {
        initPos = transform.position;
    }

    public void JugadorEnEscalera(bool status)
    {
        EnPosicionEscaleras = status;
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(rigth))
            {
                Move(Vector2.right); // 1,0
                spriteRenderer.flipX = false;
            }
            else if (Input.GetKey(left))
            {
                Move(Vector2.left);
                spriteRenderer.flipX = true;
            }
            else if (Input.GetKey(topMov) && EnPosicionEscaleras)
            {
                MoveToTop();
            }
            else if (Input.GetKeyDown(jump) && CanJump()) 
            {
                Jump();
            }
            else if (Input.GetKeyDown(attack))
            {
                Attack();
            }
        }
    }

    public void AddCoin()
    {
        currNumCoins++;
        if(currNumCoins >= totalNumCoins)
        {
            sounds.PlaySound(SOUND.WIN);
            GameManager.instance.WinPanel();
        }
    }

    private void Move(Vector2 dir)
    {
        rb.AddForce(dir * moveSpeed);
    }

    private void MoveToTop()
    {
        if (rb.velocity.magnitude < topMaxSpeed)
        {
            rb.AddForce(Vector2.up * topSpeed);
        }
    }

    private void Jump()
    {
        sounds.PlaySound(SOUND.JUMP);
        animator.SetBool("Jump", true);
        rb.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
    }

    private bool CanJump()
    {
        int layer = (1 << 7);
        Debug.DrawRay(transform.position, -transform.up * 1.5f, Color.red, 1.0f);
        Vector3 posicionInicialRayo = transform.position;
        Vector3 direccion = -transform.up; // Vector.up(0,1)
        float distance = 1.5f;
        RaycastHit2D hit = Physics2D.Raycast(posicionInicialRayo, direccion, distance, layer);
        if (hit.collider != null && hit.collider.CompareTag("Plataforma"))
        {
            return true;
        }
        else return false;
    }

    private void FixedUpdate()
    {
        animator.SetFloat("WalkSpeed", Mathf.Abs(rb.velocity.x));
        if (animator.GetBool("Jump") && rb.velocity.y == 0)
        {
            animator.SetBool("Jump", false);
        }
        else if (rb.velocity.y != 0)
        {
            animator.SetBool("Jump", true);
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void ResetPlayer()
    {
        rb.velocity = Vector2.zero;
        transform.position = initPos;
        life.LostLife();
    }

    private void OnBecameInvisible()
    {
        sounds.PlaySound(SOUND.HURT);
        ResetPlayer();
    }
}
