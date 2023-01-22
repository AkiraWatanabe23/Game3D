using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpController : MonoBehaviour
{
    [Tooltip("現在選択中のものを明示的にする")]
    [SerializeField] private Image _selecting = default;
    [Tooltip("HelpPage内のButton")]
    [SerializeField] private GameObject[] _helpPages = new GameObject[3];

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {

        }
    }
}
