using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // 키보드, 마우스, 터치를 이벤트로 오브젝트에 보낼 수 있는 기능을 지원

public class Joystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform lever;
    private RectTransform rectTransform;

    [SerializeField, Range(10f, 150f)]
    private float leverRange;

    private Vector2 inputDirection;    // 추가
    private bool isInput;    // 추가
    [SerializeField]
    private TPSCharacterController controller;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);  // 추가
        isInput = true;    // 추가
    } 
    public void OnDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);    // 추가
        
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        isInput = false;
        controller.Move(Vector2.zero);
    }
    public void ControlJoystickLever(PointerEventData eventData)
    {
        var inputDir = eventData.position - rectTransform.anchoredPosition;
        var inputVector = inputDir.magnitude < leverRange ? inputDir
            : inputDir.normalized * leverRange;
        lever.anchoredPosition = inputVector;
        inputDirection = inputVector / leverRange;
        //Debug.Log(inputDirection);
    }
    private void InputControlVector()
    {
        controller.Move(inputDirection);
    }
    
    void Update()
    {
        if (isInput)
        {
            InputControlVector();
        }
    }
}