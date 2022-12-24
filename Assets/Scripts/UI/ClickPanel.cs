using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickPanel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEvent _event;

    /// <summary>
    /// �I�u�W�F�N�g���N���b�N������A�ݒ肵�����������s����
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        _event?.Invoke();
    }
}
