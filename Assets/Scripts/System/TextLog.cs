using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary> アイテムボックスな内でアイテムを選んだ時のログ表示 </summary>
public class TextLog : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Tooltip("アイテムのログを表示するUI")]
    [SerializeField] private Image _logImage = default;
    [Tooltip("アイテムボックス内でのログ")]
    [SerializeField] private Text _logText = default;
    [SerializeField] private UnityEvent _openEvent = default;
    [SerializeField] private UnityEvent _closeEvent = default;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //TODO：アイテムの説明をText表示
        _openEvent?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //TODO：表示していたLogを閉じる
        _closeEvent?.Invoke();
    }
}
