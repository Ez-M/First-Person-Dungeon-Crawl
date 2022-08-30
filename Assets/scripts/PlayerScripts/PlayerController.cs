using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    #region -Init Connections-

    private PlayerManager playerManager;
    private GameObject playerCap;
    private Camera playerCam;

    #endregion


    private PlayerControls playerControls;

    public InputAction moveForward;
    public InputAction moveRight;
    public InputAction moveBack;
    public InputAction moveLeft;
    public InputAction turnLeft;
    public InputAction turnRight;
    public InputAction confirm;




    private void Awake()
    {
        playerControls = new PlayerControls();

        #region -PLAYER INIT-

        playerCap = gameObject.transform.GetChild(0).gameObject;
        playerCam = playerCap.transform.GetChild(0).gameObject.GetComponent<Camera>();


        #endregion

        #region -INPUTS SET-

        moveForward = playerControls.movement.moveforward;
        moveRight = playerControls.movement.moveright;
        moveBack = playerControls.movement.moveback;
        moveLeft = playerControls.movement.moveleft;

        turnLeft = playerControls.movement.turnleft;
        turnRight = playerControls.movement.turnright;

        confirm = playerControls.actions.confirmUse;


        moveForward.performed += InputForward;
        moveRight.performed += InputRight;
        moveBack.performed += InputBack;
        moveLeft.performed += InputLeft;

        turnLeft.performed += InputTurnLeft;
        turnRight.performed += InputTurnRight;

        playerControls.Enable();

        #endregion



    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #region -InputMoveFuncs-
    public void InputForward(InputAction.CallbackContext value)
    {
        Debug.Log("inputForward");
        AttemptMove(0, 1);
    }

    public void InputRight(InputAction.CallbackContext value)
    {
        AttemptMove(90, 1);
    }

    public void InputBack(InputAction.CallbackContext value)
    {
        AttemptMove(180, 1);
    }

    public void InputLeft(InputAction.CallbackContext value)
    {
        AttemptMove(270, 1);
    }
    #endregion


    #region -InputTurnFuncs-

    public void InputTurnLeft(InputAction.CallbackContext value)
    {
        Vector3 currentRotation = playerCap.transform.eulerAngles;
        Vector3 targetRotation = currentRotation + new Vector3 (0, -90, 0);
        playerCap.transform.eulerAngles = targetRotation;
    }
    public void InputTurnRight(InputAction.CallbackContext value)
    {
        Vector3 currentRotation = playerCap.transform.eulerAngles;
        Vector3 targetRotation = currentRotation + new Vector3 (0, 90, 0);
        playerCap.transform.eulerAngles = targetRotation;
    }


    #endregion



    public void AttemptMove(float direction, float distance)
    {
        RaycastHit hit;
        float moveDistance;
        Vector3 moveDirection = new Vector3(0, direction, 0); 

        Vector3 moveActual;

        switch (direction)
        {
            case 0f:
                moveActual = playerCap.transform.forward;
                moveDistance = distance * 1f;
                break;
            case 90f:
                moveActual = playerCap.transform.right;
                moveDistance = distance * 1f;
                break;
            case 180f:
                moveActual = playerCap.transform.forward;
                moveDistance = distance * -1f;
                break;
            case 270f:
                moveActual = playerCap.transform.right;
                moveDistance = distance * -1f;
                break;
            default:
                moveActual = playerCap.transform.forward;
                moveDistance = distance * 0f;
                Debug.Log(moveDirection.y);
                break;
        }
        if (Physics.Raycast(gameObject.transform.position, moveDirection, out hit, moveDistance, 0, QueryTriggerInteraction.Ignore))
        {
            Debug.Log("Invalid move!");
        }
        else
        {
            Debug.DrawLine(playerCap.transform.position, playerCap.transform.position + (moveActual * moveDistance), Color.cyan, 1f);
            Vector3 newSpot = gameObject.transform.position + (moveActual * moveDistance);
            gameObject.transform.position = newSpot;
            // gameObject.transform.eulerAngles = moveDirection;
            // gameObject.transform.position += (moveDirection * moveDistance);
        }
    }
}
