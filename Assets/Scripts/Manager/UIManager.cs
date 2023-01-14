using UnityEngine;
using UnityEngine.UI;

/// <summary> ゲームシーン内のUIの表示をこのクラスで行う </summary>
public class UIManager : MonoBehaviour
{
    [Tooltip("シーン上に表示するText")]
    [SerializeField] private Text[] _sceneTexts = new Text[5];
    [SerializeField] private Slider _hpSlider = default;

    private int _hp = default;
    //Sliderに関するHP値
    private float _middleHp = default;
    private float _warningHp = default;
    //最大HP
    private int _maxHp = default;
    //Sliderに反映させる色
    private Image _varColor = default;
    private static bool _isHit = false;

    public Slider HpSlider { get => _hpSlider; set => _hpSlider = value; }
    public static bool IsHit { get => _isHit; set => _isHit = value; }

    private void Start()
    {
        _hp = GameObject.Find("Player").GetComponent<PlayerController>().Health.HP;
        _middleHp = Mathf.Floor(_hp / 2);
        _warningHp = Mathf.Floor(_hp / 4);
        _maxHp = _hp;

        _hpSlider.maxValue = _maxHp;
        _hpSlider.value = _maxHp;

        _varColor = GameObject.Find("Fill").GetComponent<Image>();
    }

    private void Update()
    {
        //TODO：ステータス等のUI表示
        _sceneTexts[0].text = GameManager.Timer.ToString("F0");
        _hpSlider.value = _hp;

        //残りの体力によってSliderの色を変える
        if (_hp <= _warningHp)
            _varColor.color = Color.red;
        else if (_hp <= _middleHp)
            _varColor.color = Color.yellow;
        else
            _varColor.color = Color.green;
    }
}
