using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// オブジェクトをクリックした時に、指定した処理を実行する
/// </summary>
public class ClickPanel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEvent _event;

    public void OnPointerClick(PointerEventData eventData)
    {
        _event?.Invoke();
    }
}
