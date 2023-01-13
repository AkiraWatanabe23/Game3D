using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary> アイテムボックスな内でアイテムを選んだ時のログ表示 </summary>
public class TextLog : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Tooltip("アイテムのログを表示するUI")]
    [SerializeField] private Image _logImage = default;
    [Tooltip("アイテムボックス内でのログ")]
    [SerializeField] private Text _logText = default;

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
