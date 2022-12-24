using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickPanel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEvent _event;

    /// <summary>
    /// オブジェクトをクリックしたら、設定した処理を実行する
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        _event?.Invoke();
    }
}
