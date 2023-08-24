using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ruszanie : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Vector3 moveDirection;

    // S T A M I N A
    public float dashSpeed = 10.0f;
    public float dashStaminaCost = 5.0f;
    public float staminaRegenRate = 10.0f;
    public float maxStamina = 100.0f;
    private float stamina;
    private float cooldownRemaining;
    public Image staminaBar;
    public CanvasGroup canvasGroup;
    private float fadeTime = 2f;
    private float showTime = 1f;
    private float waitTime = 2f;
    private float startFadeTime;
    public float cooldownTime = 3.0f;
    private bool isWaiting;
    private bool isFading;

    // H U D
    public KIFOLskrypt script1;
    public MOLTEKskrypt script2;
    public REVOLVERskrypt script3;

    private void Start()
    {
        stamina = maxStamina;
        canvasGroup.alpha = 1f;
    }

    private void Update()
    {
        staminaBar.fillAmount = stamina / maxStamina;
        movementup();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            script1.klikniete1();
            script2.odklikniete2();
            script3.odklikniete3();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            script2.klikniete2();
            script1.odklikniete1();
            script3.odklikniete3();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            script3.klikniete3();
            script1.odklikniete1();
            script2.odklikniete2();
        }
    }

    private void movementup()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;
        }
        moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && stamina > 0)
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime * dashSpeed;
            stamina -= dashStaminaCost * Time.deltaTime;
            cooldownRemaining = cooldownTime;
        }
        else
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            if (cooldownRemaining <= 0)
            {
                stamina += staminaRegenRate * Time.deltaTime;
                stamina = Mathf.Clamp(stamina, 0, maxStamina);
            }
            else
            {
                cooldownRemaining -= Time.deltaTime;
            }
        }
        if (stamina == maxStamina)
        {
            if (!isWaiting)
            {
                startFadeTime = Time.time + waitTime;
                isWaiting = true;
            }
            if (Time.time >= startFadeTime)
            {
                if (!isFading)
                {
                    StartCoroutine(FadeOut());
                }
            }
        }
        else
        {
            if (isFading || isWaiting)
            {
                StopAllCoroutines();
                StartCoroutine(FadeIn());
            }
        }
    }
    IEnumerator FadeOut()
    {
        isFading = true;

        float startAlpha = canvasGroup.alpha;
        float endAlpha = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeTime);
            yield return null;
        }

        canvasGroup.alpha = endAlpha;
        isFading = false;
        isWaiting = false;
    }
    IEnumerator FadeIn()
    {
        isFading = true;

        float startAlpha = canvasGroup.alpha;
        float endAlpha = 1f;
        float elapsedTime = 0f;

        while (elapsedTime < showTime)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / showTime);
            yield return null;
        }

        canvasGroup.alpha = endAlpha;
        isFading = false;
        isWaiting = false;
    }
}
