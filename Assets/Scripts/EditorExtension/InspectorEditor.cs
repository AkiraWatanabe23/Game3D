using Consts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemBox))]
public class InspectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ItemBase instance = target as ItemBase;
    }
}
