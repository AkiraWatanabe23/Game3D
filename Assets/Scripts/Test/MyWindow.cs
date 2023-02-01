using System;
using UnityEngine;
using UnityEditor;

public class MyWindow : EditorWindow
{
    [Tooltip("この値以上の重要度が設定された値をコンソールに表示する")]
    private int _importance = 0;
    [Tooltip("このフラグに登録されている値をコンソールに表示する")]
    // 登録や削除などの使い方 : https://programming.pc-note.net/csharp/bit2.html
    private Type _type = Type.None;
    bool[] _flags = new bool[Enum.GetValues(typeof(Type)).Length];
    bool test;

    //ウインドウを開くメニューのパス
    [MenuItem("Window/My Window")]
    public static void ShowWindow()
    {
        //ウインドウを作成して表示
        EditorWindow.GetWindow(typeof(MyWindow));
    }

    private void OnGUI()
    {
        //ここにウインドウの内容を描画する処理を書く
        _importance = EditorGUILayout.IntSlider(
            "DrawImportance", _importance, 0, 10);
        for (int i = 0; i < _flags.Length; i++)
        {
            RegisterType(i);
        }
    }

    private void RegisterType(int index)
    {
        if (_flags[index] != EditorGUILayout.Toggle(IntToType(index).ToString(), _flags[index]))
        {
            if (index == 0)
            {
                // 全てのFlagを寝かせる
                _type &= IntToType(index);
            }
            else if (index == 1)
            {
                // 全てのFlagを立たせる
                _type |= IntToType(index);
            }
            else if (!EditorGUILayout.Toggle(IntToType(index).ToString(), _flags[index]))
            {
                _type |= IntToType(index);
            }
            else
            {
                _type &= ~IntToType(index);
            }
            UpdateTypeToggle();
        }
    }

    private void UpdateTypeToggle()
    {
        for (int i = 0; i < _flags.Length; i++)
        {
            _flags[i] = _type.HasFlag(IntToType(i));
        }
    }

    private Type IntToType(int index)
    {
        switch (index)
        {
            case 0: return Type.None;
            case 1: return Type.Every;
            case 2: return Type.Player;
            case 3: return Type.Enemy;
            case 4: return Type.Gimmick;
            case 5: return Type.Other;
            default:
                Debug.LogError("不正値が渡されました！");
                return Type.None;
        }
    }

    [Flags]
    enum Type
    {
        None = 0,
        Every = ~0,
        Player = 1 << 0,
        Enemy = 1 << 1,
        Gimmick = 1 << 2,
        Other = 1 << 3,
    }
}