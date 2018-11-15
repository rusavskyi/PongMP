using UnityEngine;
using System.Collections;


public class PlayerMovementControl : MonoBehaviour
{
    public bool canMove = true;
    public float paddleSpeed = 1.0f;
    protected Vector3 paddlePosition;
    protected float rightBorder = 6.8f;
    protected float leftBorder = -6.8f;

    //for AI
    //still waiting

    //effects booleans and support variables
    public bool SlippingEffectEnabled { get; set; }
    public float slippingTime;
    public float slippingTimeDelay;
    public enum MoveState { right, left, stay }
    public MoveState moveState;

    public bool SizeEffectEnabled { get; set; }
    private float originalSize;
    private float originalLeftBorder;
    private float originalRightBorder;

    public bool FissionEffectEnabled { get; set; }
    public GameObject BallPrefab { get; set; }

    public bool ReflectorEffectEnabled { get; set; }
    public int playerId { get; set; }
    public Transform paddleTransform { get; set; }
    private float force = 5;
    GameObject[] balls;

    void Start()
    {
        paddlePosition = transform.localPosition;
    }

    void Update()
    {
        if (canMove)
        {
            float horizontal = Input.GetAxis("Horizontal");

            if (SlippingEffectEnabled)
            {
                if (moveState == MoveState.stay)
                {
                    //horizontal = Input.GetAxis("Horizontal");
                    if (horizontal < 0)
                        moveState = MoveState.left;
                    else if (horizontal > 0)
                        moveState = MoveState.right;
                    else
                        moveState = MoveState.stay;
                }
                else
                {
                    slippingTime += Time.deltaTime;
                    if (moveState == MoveState.left)
                    {
                        horizontal = -0.3f;
                    }
                    else
                    {
                        horizontal = 0.3f;
                    }
                    if (slippingTime >= slippingTimeDelay)
                    {
                        slippingTime = 0;
                        //horizontal = Input.GetAxis("Horizontal");
                        if (horizontal < 0)
                            moveState = MoveState.left;
                        else if (horizontal > 0)
                            moveState = MoveState.right;
                        else
                            moveState = MoveState.stay;
                    }
                }
            }
            /*else
            {
                horizontal = Input.GetAxis("Horizontal");
            }*/

            float xPosition = transform.localPosition.x + (horizontal * paddleSpeed);
            paddlePosition = new Vector3(Mathf.Clamp(xPosition, leftBorder, rightBorder), paddlePosition.y, paddlePosition.z);
            transform.localPosition = paddlePosition;

        }
    }
}
