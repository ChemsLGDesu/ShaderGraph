using UnityEngine;
using UnityEngine.InputSystem;

public sealed class ExploradorCamaraController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float sprintMultiplier = 2.5f;
    [SerializeField] private float verticalSpeed = 8.0f;

    [Header("Rotación")]
    [SerializeField] private float mouseSensitivity = 0.12f;
    [SerializeField] private float minPitch = -85.0f;
    [SerializeField] private float maxPitch = 85.0f;

    private float yaw;
    private float pitch;

    private void Start()
    {
        InitializeRotation();
        LockCursor();
    }

    private void Update()
    {
        UpdateCursorState();
        UpdateLookRotation();
        UpdateMovement();
    }

    private void InitializeRotation()
    {
        Vector3 euler = transform.eulerAngles;
        yaw = euler.y;
        pitch = NormalizeAngle(euler.x);
        ApplyRotation();
    }

    private void UpdateCursorState()
    {
        Keyboard keyboard = Keyboard.current;
        Mouse mouse = Mouse.current;

        if (keyboard != null && keyboard.escapeKey.wasPressedThisFrame)
        {
            UnlockCursor();
            return;
        }

        bool shouldLock = mouse != null
            && mouse.leftButton.wasPressedThisFrame
            && Cursor.lockState != CursorLockMode.Locked;

        if (shouldLock)
        {
            LockCursor();
        }
    }

    private void UpdateLookRotation()
    {
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            return;
        }

        Mouse mouse = Mouse.current;

        if (mouse == null)
        {
            return;
        }

        Vector2 delta = mouse.delta.ReadValue();
        yaw += delta.x * mouseSensitivity;
        pitch -= delta.y * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        ApplyRotation();
    }

    private void UpdateMovement()
    {
        Keyboard keyboard = Keyboard.current;

        if (keyboard == null)
        {
            return;
        }

        float horizontalInput = ReadAxis(keyboard.dKey.isPressed, keyboard.aKey.isPressed);
        float forwardInput = ReadAxis(keyboard.wKey.isPressed, keyboard.sKey.isPressed);
        float verticalInput = ReadAxis(keyboard.eKey.isPressed, keyboard.qKey.isPressed);

        Vector3 horizontalDirection = GetFlatForward() * forwardInput + GetFlatRight() * horizontalInput;

        if (horizontalDirection.sqrMagnitude > 1.0f)
        {
            horizontalDirection.Normalize();
        }

        float currentSpeed = keyboard.leftShiftKey.isPressed
            ? moveSpeed * sprintMultiplier
            : moveSpeed;

        Vector3 translation = horizontalDirection * currentSpeed
            + Vector3.up * (verticalInput * verticalSpeed);

        transform.position += translation * Time.deltaTime;
    }

    private float ReadAxis(bool positive, bool negative)
    {
        float axis = 0.0f;

        if (positive)
        {
            axis += 1.0f;
        }

        if (negative)
        {
            axis -= 1.0f;
        }

        return axis;
    }

    private Vector3 GetFlatForward()
    {
        Vector3 forward = transform.forward;
        forward.y = 0.0f;
        return forward.normalized;
    }

    private Vector3 GetFlatRight()
    {
        Vector3 right = transform.right;
        right.y = 0.0f;
        return right.normalized;
    }

    private void ApplyRotation()
    {
        transform.rotation = Quaternion.Euler(pitch, yaw, 0.0f);
    }

    private static float NormalizeAngle(float angle)
    {
        return angle > 180.0f ? angle - 360.0f : angle;
    }

    private static void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private static void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
