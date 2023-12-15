using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 0.1f;
    public float jumpForce = 100;
    [ReadOnly] public Vector2 position;
    public int maxHealth = 5;
    public float timeInvincible = 1.25f;
    public int Health { get { return currentHealth; } }
    [SerializeField] [ReadOnly] int currentHealth;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    [SerializeField] [ReadOnly]bool isInvincible = false;
    [SerializeField] [ReadOnly]float invincibleTimer;

    Animator animator;
    Vector2 lookDirection = new(1, 0);
    public GameObject projectilePrefab;
    public float cooldown = 0.25f;
    public bool canJump = true;
    public bool climping = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        if(climping == false)
        {
            Vector2 move = new(horizontal, 0);
            if (!Mathf.Approximately(move.x, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();

            }
            rigidbody2d.gravityScale = 1;
            animator.SetFloat("Look X", lookDirection.x);
            animator.SetFloat("Speed", move.magnitude);
            if (canJump == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rigidbody2d.AddForce(transform.up * jumpForce);
                    canJump = false;
                }
                
            }
        }
        else
        {
            Vector2 move = new(horizontal, vertical);
            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                Launch();
                Debug.Log("Launch!!!");
            }
            rigidbody2d.gravityScale = 0;
            animator.SetFloat("Look X", lookDirection.x);
            animator.SetFloat("Look Y", lookDirection.y);
            animator.SetFloat("Speed", move.magnitude);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Launch();
        }
    }
    void FixedUpdate()
    {
        float dt = Time.deltaTime;
        position = rigidbody2d.position;
        if(climping == false)
        {
            position.x += speed * horizontal * dt;
            position.y = transform.position.y;
        }
        else
        {
            position.x += speed * horizontal * dt;
            position.y += speed * vertical * dt;
        }
        rigidbody2d.MovePosition(position);
    }
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
    public void SetInvincibility()
    {
        isInvincible = true;
        invincibleTimer = timeInvincible;
    }
    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        //projectile.Launch(lookDirection, 300f);
        projectile.dir = lookDirection;
        projectile.f = 100f;
        animator.SetTrigger("Launch");
    }
}
