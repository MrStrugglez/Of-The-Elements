using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Side_Player : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    public float groundRadius;

    [SerializeField]
    public LayerMask whatIsGround;
    [SerializeField]
    public Transform[] groundPoints;

    [SerializeField]
    public Sprite glidingSprite;

    private float horizontal;

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private GameObject movingPlatform;

    private GameObject[] crates;
    private GameObject[] movingPlatforms;

    private bool facingRight;
    private bool meleeAttack;
    private bool rangedAttack;
    private bool isGrounded;
    private bool jump;
    private bool isOnMovingPlatform;
    
    // Use this for initialization
    protected void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        crates = GameObject.FindGameObjectsWithTag("Crates");
        movingPlatform = null;
        movingPlatforms = GameObject.FindGameObjectsWithTag("MovingPlatforms");

        animator.SetFloat("speedMultiplier", 1);

        facingRight = true;
        meleeAttack = false;
        rangedAttack = false;
        isOnMovingPlatform = false;
    }

    // Update is called once per frame
    protected void Update()
    {
        GetInput();

        isGrounded = IsGrounded();

        isOnMovingPlatform = IsOnMovingPlatform();

        OnMovingPlatform();

        IsOnCrate();

        HandleLayers();

        Move();

        Jump();

        Attack();

        ResetValues();

        Flip(horizontal);
    }

    private void GetInput()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.F))
        {
            meleeAttack = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            rangedAttack = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    private void Move()
    {
        //If the character is not attacking
        if (!this.animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack") && !this.animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack_Ranged"))
        {
            rigidBody.velocity = new Vector2(horizontal * movementSpeed, rigidBody.velocity.y);
        }
        else
        {
            rigidBody.velocity = Vector2.zero;  //Stop moving while attacking
        }

        AnimateMovement(horizontal);
    }

    public void Jump()
    {
        if (isGrounded && jump && !HasUmbrella())
        {
            isGrounded = false;

            rigidBody.AddForce(new Vector2(0, jumpForce));

            animator.SetTrigger("jump");
        }

        if (rigidBody.velocity.y < 0)
        {
            isGrounded = false;

            animator.SetBool("land", true);
        }
    }

    public void AnimateMovement(float horizontal)
    {
        animator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void Attack()
    {
        //Cannot attack while still attacking
        if (meleeAttack && isGrounded && !this.animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack_Ranged") && !this.animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            animator.SetTrigger("attack");
        }

        if (rangedAttack && isGrounded && !this.animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack_Ranged") && !this.animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            if (GameObject.Find("ElementImage").GetComponent<Image>().sprite != null)
            {
                animator.SetTrigger("attack_ranged");

                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);

        GameObject instance = Instantiate(Resources.Load("Elements_" + GameObject.Find("ElementImage").GetComponent<Image>().sprite.name, typeof(GameObject))) as GameObject;

        if (facingRight)
        {
            instance.transform.position = new Vector3(GetComponent<Transform>().position.x + 2, GetComponent<Transform>().position.y + 0.2f, 0);
        }
        else
        {
            instance.transform.position = new Vector3(GetComponent<Transform>().position.x - 2, GetComponent<Transform>().position.y + 0.2f, 0);
            instance.GetComponent<SpriteRenderer>().flipX = false;
        }
        
        instance.AddComponent<RangedAttack>();
    }

    private void Flip(float horizontal)
    {
        if (horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            spriteRenderer.flipX = true;
        }
        else if (horizontal > 0 && !facingRight)
        {
            facingRight = !facingRight;

            spriteRenderer.flipX = false;
        }
    }

    private bool IsGrounded()
    {
        if (rigidBody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != this.gameObject && colliders[i].gameObject.name != "Coin")
                    {
                        animator.ResetTrigger("jump");
                        animator.SetBool("land", false);

                        GetComponent<Animator>().enabled = true;
                        GetComponent<Rigidbody2D>().gravityScale = 1;

                        return true;
                    }
                }
            }
        }

        return false;
    }

    private void IsOnCrate()
    {
        if (rigidBody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    foreach (GameObject crate in crates)
                    {
                        if (colliders[i].gameObject == crate)
                        {
                            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
                            
                            isGrounded = true;
                        }
                    }
                }
            }
        }
    }

    private bool IsOnMovingPlatform()
    {
        foreach (Transform point in groundPoints)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

            for (int i = 0; i < colliders.Length; i++)
            {
                foreach (GameObject movingPlat in movingPlatforms)
                {
                    if (colliders[i].gameObject == movingPlat)
                    {
                        movingPlatform = movingPlat;

                        return true;
                    }
                }
            }
        }

        return false;
    }

    private void OnMovingPlatform()
    {
        if (isOnMovingPlatform)
        {
            transform.parent = movingPlatform.transform;
        }
        else
        {
            transform.parent = null;
        }
    }

    private void ResetValues()
    {
        meleeAttack = false;
        rangedAttack = false;
        jump = false;
    }

    private void HandleLayers()
    {
        if (!isGrounded)
        {
            animator.SetLayerWeight(1, 1);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
    }

    private bool HasUmbrella()
    {
        if (gameObject.GetComponent<SpriteRenderer>().sprite == glidingSprite)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
