using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class JellyController : MonoBehaviour
{
    public JellyData jellyData;
    private JellyMovement movement;
    private SpriteRenderer spriteRenderer;
    private JellyReward jellyReward;

    [Header("MouseControl")]
    private bool isDragging = false;
    private Vector3 mouseSet;
    [SerializeField] private float holdTime = 0f;
    [SerializeField] private float holdingTime = 1.0f;

    [Header("Auto Clicker")]
    [SerializeField] private bool autoClickEnabled = true;
    [SerializeField] private float autoClickInterval = 5.0f;

    [Header("Sell")]
    [SerializeField] private bool isOverSellButton;
    private Button sellButton;
    private void Awake()
    {
        movement = GetComponent<JellyMovement>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        jellyReward = FindObjectOfType<JellyReward>();
        sellButton = GameObject.FindWithTag("SellButton").GetComponent<Button>();

        isOverSellButton = false;

        if (jellyData != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = jellyData.jellySprite;
        }

        if (autoClickEnabled)
        {
            StartCoroutine(AutoClickRoutine());
        }
    }

    private void Update()
    {
        // 마우스를 꾹 누르고 있는 시간 체크
        if (holdTime > 0f)
        {
            holdTime += Time.deltaTime;

            if (holdTime >= holdingTime && !isDragging)
            {
                isDragging = true;
                mouseSet = GetMouseLocalPosition();
            }
        }
    }

    private void OnMouseDown()
    {
        holdTime = Time.deltaTime;

        // 젤리 클릭 시 보상 추가
        movement.OnTouch();
        if (jellyData != null && jellyReward != null)
        {
            jellyReward.AddJellatin(jellyData.rewardAmount);
            Debug.Log($"{jellyData.jellyName} 터치! 보상: {jellyData.rewardAmount}");
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            UpdateJellyPositionToMouse();
        }
    }

    private void OnMouseUp()
    {
        if (isOverSellButton == true) 
        {
            SellJelly();
        }
        else
        {
            isDragging = false;
            holdTime = 0f;
            movement.OutPosition();
        }
    }

    private void UpdateJellyPositionToMouse()
    {   
        Vector3 mouseWorldPosition = GetMouseLocalPosition();
        transform.position = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, transform.position.z);
    }

    private Vector3 GetMouseLocalPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private IEnumerator AutoClickRoutine()
    {
        while (autoClickEnabled)
        {
            yield return new WaitForSeconds(autoClickInterval);
            movement.OnTouch();
            if (jellyData != null && jellyReward != null)
            {
                jellyReward.AddJellatin(jellyData.rewardAmount);
                Debug.Log($"[자동 클릭] {jellyData.jellyName} 보상: {jellyData.rewardAmount}");
            }
        }
    }

    private void SellJelly()
    {
        Debug.Log($"{jellyData.jellyName} 판매 완료! 보상: {jellyData.sellGold} 골드");
        jellyReward.AddGold(jellyData.sellGold);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SellButton"))
        {
            isOverSellButton = true;
            HighlightSellButton(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SellButton"))
        {
            isOverSellButton = false;
            HighlightSellButton(false);
        }
    }
    private void HighlightSellButton(bool isHighlighted)
    {
        if (isHighlighted)
        {
            sellButton.Select();
        }
        else
        {
            sellButton.OnDeselect(null);
        }
    }
}
