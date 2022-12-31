using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲームシーン内のUIの表示をこのクラスで行う
/// </summary>
public class UIManager : MonoBehaviour
{
    [Tooltip("シーン上に表示するText")]
    [SerializeField] private Text[] _sceneTexts = new Text[5];
    [SerializeField] private Slider _hpSlider;

    //Sliderに関するHP値
    private readonly float _middleHp = Mathf.Floor(PlayerHealth.HP / 2);
    private readonly float _warningHp = Mathf.Floor(PlayerHealth.HP / 4);
    //最大HP
    private readonly int _maxHp = PlayerHealth.HP;
    //Sliderに反映させる色
    private Image _varColor = default;

    public int MaxHp => _maxHp;

    private void Start()
    {
        _hpSlider.maxValue = PlayerHealth.HP;
        _hpSlider.value = PlayerHealth.HP;

        _varColor = GameObject.Find("Fill").GetComponent<Image>();
    }

    private void Update()
    {
        _sceneTexts[0].text = GameManager.Timer.ToString("F0");
        _hpSlider.value = PlayerHealth.HP;

        //残りの体力によってSliderの色を変える
        if (PlayerHealth.HP <= _warningHp)
        {
            _varColor.color = Color.red;
        }
        else if (PlayerHealth.HP <= _middleHp)
        {
            _varColor.color = Color.yellow;
        }
        else
        {
            _varColor.color = Color.green;
        }
    }
}
