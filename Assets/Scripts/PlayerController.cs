using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Speed = 15.0f;
    [SerializeField] float Range = 6f;

    [SerializeField] Transform leftPaddel;
    [SerializeField] Transform rightPaddel;

    float yThrow;
    float yThrow2;

    PlayerSelector playerSelector;
    bool player2Active;

    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        yThrow = context.ReadValue<Vector2>().y;
    }

    public void OnMoveRight(InputAction.CallbackContext context)
    {
        yThrow2 = context.ReadValue<Vector2>().y;
    }

    private void Start()
    {
        playerSelector = FindObjectOfType<PlayerSelector>();
        player2Active = playerSelector.player2Active;
        Destroy(playerSelector.gameObject);
    }

    void Update()
    {
        // yThrow = Input.GetAxis("Vertical");
        float yOffset = yThrow * Time.deltaTime * Speed;
        float rawYPos = leftPaddel.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -Range, Range);

        leftPaddel.localPosition = new Vector2(leftPaddel.localPosition.x, clampedYPos);

        if (player2Active)
        {
            float yOffset2 = yThrow2 * Time.deltaTime * Speed;
            float rawYPos2 = rightPaddel.localPosition.y + yOffset2;
            float clampedYPos2 = Mathf.Clamp(rawYPos2, -Range, Range);

            rightPaddel.localPosition = new Vector2(rightPaddel.localPosition.x, clampedYPos2);
        }
        else
        {
            rightPaddel.GetComponent<AI>().enabled = true;
        }
    }

}
