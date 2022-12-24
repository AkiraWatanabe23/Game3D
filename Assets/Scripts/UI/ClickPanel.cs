using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// �I�u�W�F�N�g���N���b�N�������ɁA�w�肵�����������s����
/// </summary>
public class ClickPanel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEvent _event;

    public void OnPointerClick(PointerEventData eventData)
    {
        _event?.Invoke();
    }
}
