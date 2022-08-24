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
   public InputAction confirm;



    private void Awake()
    {
        #region -INPUTS SET-
        moveForward = playerControls.movement.moveforward;
        moveRight = playerControls.movement.moveright;
        moveBack = playerControls.movement.moveback;
        moveLeft = playerControls.movement.moveleft;

        confirm = playerControls.actions.confirmUse;

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
}
