using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InputManager
{
    private static PlayerController _controls;

    private static Vector3 _mousePos;
    private static Camera cam;

    

    public static Ray GetCameraRay()
    {
        return cam.ScreenPointToRay(_mousePos);
    }

    public static void Init(Player myPlayer)
    {
        _controls = new PlayerController();

        cam = Camera.main;
        _controls.Permanent.Enable();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;


        _controls.MainGamePlay.Movment.performed += ctx =>
        {
            myPlayer.SetMoveDirection(ctx.ReadValue<Vector3>());
            Debug.Log("tried to move");
        };

        _controls.MainGamePlay.Look.performed += ctx =>
        {
            myPlayer.SetLookRotation(ctx.ReadValue<Vector2>());
        };


        _controls.Permanent.MousePos.performed += ctx =>
        {
            _mousePos = ctx.ReadValue<Vector2>();
        };

    }
    public static void GameMode()
    {
        _controls.MainGamePlay.Enable();

    }




}
