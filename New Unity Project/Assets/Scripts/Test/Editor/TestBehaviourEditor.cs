﻿using UnityEngine;
using UnityEditor;

namespace Tests
{
    [CustomEditor(typeof(TestBehaviour))]
    public class TestBehaviourEditor:UnityEditor.Editor
    {
        private bool _isPressButtonOk;

        public override void OnInspectorGUI()
        {
           // DrawDefaultInspector();
            TestBehaviour testTarget = (TestBehaviour)target;

            testTarget.count = EditorGUILayout.IntSlider(testTarget.count, 10, 50);
            testTarget.offset = EditorGUILayout.IntSlider(testTarget.count, 10, 50);

            testTarget.obj =
                EditorGUILayout.ObjectField("Объект который хотим вставить",
                testTarget.obj, typeof(GameObject), false) as GameObject;
            var isPressButton = GUILayout.Button("Создание объектов по кнопке",
                EditorStyles.miniButtonLeft);

            if(isPressButton)
            {
                testTarget.CreateObj();
                _isPressButtonOk = true;
            }
            if(_isPressButtonOk)
            {
                testTarget.Test = EditorGUILayout.Slider(testTarget.Test, 10,50);
                EditorGUILayout.HelpBox("Вы нажали на кнопку", MessageType.Warning);
                if(GUILayout.Button("Add Com",
                    EditorStyles.miniButtonLeft))
                {
                    testTarget.AddComponent();
                }
                if(GUILayout.Button("Rem Com",
                    EditorStyles.miniButtonLeft))
                {
                    testTarget.RemoveComponent();
                }
            }
        }
    }
}
