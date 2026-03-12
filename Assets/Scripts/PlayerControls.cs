using System.Collections;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 playerVelocity;
    public Animator anim;
    public bool groundedPlayer;
    public float playerSpeed;
    public float gravityValue;
    public GameObject activeChar;
    public float moveHorizontal;
    public float moveVertical;
    public float speed = 4;
    public float moveSpeed = 0;
    public float jumpHeight = 1.2f;
    public bool isJumping;

    void Start()
    {
        playerSpeed = 4;
        gravityValue = -20;
        anim = activeChar.GetComponent<Animator>();
    }


	void Update()
	{
		groundedPlayer = controller.isGrounded;

		float moveX = Input.GetAxis("Horizontal");
		float moveZ = Input.GetAxis("Vertical");
        {
		Vector3 move = transform.right * moveX + transform.forward * moveZ;

		controller.Move(move * speed * Time.deltaTime);
	}

        if (Input.GetKey(KeyCode.E) && groundedPlayer)
        {
            isJumping = true;
            activeChar.GetComponent<Animator>().Play("Jump");
            playerVelocity.y += 10;
            StartCoroutine(ResetJump());
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            this.gameObject.GetComponent<CharacterController>().minMoveDistance = 0.001f;
            if (isJumping == false)
            {
                activeChar.GetComponent<Animator>().Play("Standard Run (3) 0");
            }
        }

        else
        {
            this.gameObject.GetComponent<CharacterController>().minMoveDistance = 0.901f;
            if (isJumping == false)
            {
                activeChar.GetComponent<Animator>().Play("Idle");
            }
        }
    }


    IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(0.9f);
        isJumping = false;
    }
}