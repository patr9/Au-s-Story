using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour
{
    //Variables
    public float movementSpeed = 5f;
    private Vector2 movementDirection;
    private float dirx = 0f;
    private float diry = 0f;
    private bool collision = false;
    Rigidbody2D rb;
    Animator anim;

    public Transform barricadeCheck;
    public float barricadeCheckRadius;
    public LayerMask barricadeLayer;
    public LayerMask coinLayer;
    public LayerMask deadzoneLayer;
    public LayerMask potionLayer;
    private bool isTouchingPotion;
    private bool isTouchingDeadzone;
    private bool isTouchingCoin;
    private bool isTouchingBarricade;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        PlayerPrefs.SetFloat("Speed", movementSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingBarricade = Physics2D.OverlapCircle(barricadeCheck.position, barricadeCheckRadius, barricadeLayer);
        isTouchingCoin = Physics2D.OverlapCircle(barricadeCheck.position, barricadeCheckRadius, coinLayer);
        isTouchingPotion = Physics2D.OverlapCircle(barricadeCheck.position, barricadeCheckRadius, potionLayer);
        isTouchingDeadzone = Physics2D.OverlapCircle(barricadeCheck.position, barricadeCheckRadius, deadzoneLayer);
        diry = Input.GetAxis("Vertical");
        dirx = Input.GetAxis("Horizontal");
        movementDirection = new Vector2(dirx, diry);
        movementSpeed = PlayerPrefs.GetFloat("Speed", movementSpeed);
        PlayerPrefs.SetFloat("Speed", movementSpeed);
        if (dirx > 0)
        {
            resetAnims();
            anim.SetBool("rightWalk", true);
            anim.SetBool("isWalking", true);
            anim.SetBool("rightIdle", true);
        }
        else if(dirx < 0)
        {
            resetAnims();
            anim.SetBool("leftWalk", true);
            anim.SetBool("isWalking", true);
            anim.SetBool("leftIdle", true);
        }
        else if(diry > 0)
        {
            resetAnims();
            anim.SetBool("upWalk", true);
            anim.SetBool("isWalking", true);
            anim.SetBool("upIdle", true);
        }
        else if(diry < 0)
        {
            resetAnims();
            anim.SetBool("downWalk", true);
            anim.SetBool("isWalking", true);
            anim.SetBool("downIdle", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        rb.velocity = movementDirection * movementSpeed;

        if (isTouchingDeadzone && collision == false)
        {
            PlayerPrefs.SetFloat("Health", HealthController.instance.health - Random.Range(10, 20));
            collision = true;
        }
        if(!isTouchingDeadzone)
        {
            collision = false;
        }
    }

    void resetAnims()
    {
        anim.SetBool("rightWalk", false);
        anim.SetBool("leftWalk", false);
        anim.SetBool("upWalk", false);
        anim.SetBool("downWalk", false);
        anim.SetBool("isWalking", false);
        anim.SetBool("rightIdle", false);
        anim.SetBool("leftIdle", false);
        anim.SetBool("upIdle", false);
        anim.SetBool("downIdle", false);
    }
}
