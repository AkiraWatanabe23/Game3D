﻿using Consts;
using UnityEngine;
using UnityEngine.UI;

/// <summary> ゲームシーン内のUIの表示をこのクラスで行う </summary>
public class UIManager : MonoBehaviour
{
    [Tooltip("シーン上に表示するText")]
    [SerializeField] private Text[] _sceneTexts = new Text[5];
    [SerializeField] private Slider _hpSlider = default;

    //PlayerHP
    private int _hp = default;
    //Sliderに関するHP値
    private float _middleHp = default;
    private float _warningHp = default;
    //最大HP
    private int _maxHp = default;
    //Sliderに反映させる色
    private Image _varColor = default;

    public Slider HpSlider { get => _hpSlider; set => _hpSlider = value; }

    private void Start()
    {
        _hp = GameObject.FindGameObjectWithTag(Define.PLAYER_TAG).
            GetComponent<PlayerController>().Health.HP;
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
        _sceneTexts[0].text = $"TIMER : {GameManager.Timer : 0}";
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
