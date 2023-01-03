using Consts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemBase))]
public class InspectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ItemBase instance = target as ItemBase;

        switch (instance.Type)
        {
            case ItemType.STEALTH:
                //instance.Stealth = 
                //    EditorGUILayout.EnumMaskField(instance.Type, instance.Stealth);
                break;
            case ItemType.HEAL:
                break;
            case ItemType.STATUSUP:
                break;
        }
    }
}
