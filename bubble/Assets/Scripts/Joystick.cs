using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Ű����, ���콺, ��ġ�� �̺�Ʈ�� ������Ʈ�� ���� �� �ִ� ����� ����

public class Joystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform lever;
    private RectTransform rectTransform;

    [SerializeField, Range(10f, 150f)]
    private float leverRange;

    private Vector2 inputDirection;    // �߰�
    private bool isInput;    // �߰�
    [SerializeField]
    private TPSCharacterController controller;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);  // �߰�
        isInput = true;    // �߰�
    } 
    public void OnDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);    // �߰�
        
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