using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header ("References")]
    public Camera playerCamera;

    [Header ("General")]
    public float gravityScale = -20f;

    [Header ("Movement")]
    public float walkSpeed = 15f;
    public float runSpeed = 20f;

    [Header ("Rotation")]
    public float rotationSensibility = 10f;

    [Header ("Jump")]
    public float jumpHeight = 1.9f;

    private float cameraVerticalangle;
    Vector3 moveInput = Vector3.zero;
    Vector3 rotationInput = Vector3.zero;
    CharacterController characterController;
    private LogicaJugador logicaJugador;
    private float velocidadNormal=15f;
    private bool velocidadAlterada;
    private float tiempoRestanteVelocidadAlterada;
    
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        logicaJugador = GetComponent<LogicaJugador>();
        velocidadNormal = walkSpeed;
    }

    public void AlterarVelocidad(float nuevaVelocidad, float duracion)
    {
        walkSpeed = nuevaVelocidad;
        tiempoRestanteVelocidadAlterada = duracion;
        velocidadAlterada = true;
    }

     private void Update()
    {
        Move();
        Look();

         if (velocidadAlterada)
        {
            tiempoRestanteVelocidadAlterada -= Time.deltaTime;
            if (tiempoRestanteVelocidadAlterada <= 0)
            {
                // Volver a la velocidad normal después de que ha pasado el tiempo
                walkSpeed = velocidadNormal; // Asigna la velocidad normal aquí
                velocidadAlterada = false;
            }
        }
    }

    private void Move()
    {
        if (characterController.isGrounded)
        {
            moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveInput = Vector3.ClampMagnitude(moveInput, 1f);

            if (logicaJugador.tienePoweUp && logicaJugador.tiempoPowerUp > 0)
            {
                moveInput = transform.TransformDirection(moveInput) * logicaJugador.velocidadPowerUp;
                logicaJugador.tiempoPowerUp -= Time.deltaTime;
            }
            else
            {
                moveInput = transform.TransformDirection(moveInput) * walkSpeed;
            }

            if (Input.GetButtonDown("Jump"))
            {
                moveInput.y = Mathf.Sqrt(jumpHeight * -2f * gravityScale);
            }
        }

        moveInput.y += gravityScale * Time.deltaTime;
        characterController.Move(moveInput * Time.deltaTime);
    }

 

    private void Look(){
        rotationInput.x = Input.GetAxis("Mouse X") * rotationSensibility * Time.deltaTime;
        rotationInput.y = Input.GetAxis("Mouse Y") * rotationSensibility * Time.deltaTime;

        cameraVerticalangle += rotationInput.y;
        cameraVerticalangle = Mathf.Clamp(cameraVerticalangle, -70, 70);

        transform.Rotate(Vector3.up * rotationInput.x);

        playerCamera.transform.localRotation = Quaternion.Euler(-cameraVerticalangle,0,0);
    }


}