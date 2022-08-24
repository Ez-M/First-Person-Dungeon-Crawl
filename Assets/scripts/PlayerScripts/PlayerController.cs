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

    public void AttemptMove(int direction, float distance)
    {
        RaycastHit hit;
        float moveDistance = distance * 2.5f;
        Vector3 moveDirection = playerCap.transform.forward + new Vector3(0, direction, 0);
        if(Physics.Raycast(gameObject.transform.position, moveDirection, out hit, moveDistance, 0, QueryTriggerInteraction.Ignore)){
            Debug.Log("Invalid move!");
        } else
        {
            gameObject.transform.position += (moveDirection.normalized * moveDistance);
        }
    }
}
