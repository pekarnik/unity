using UnityEditor;
using UnityEngine;

public class MyWindow : EditorWindow
{
    public static GameObject ObjectInstatiate;
    public string _nameObject = "Hello World";
    public bool _groupEnabled;
    public bool _randomColor = true;
    public int _countObject = 1;
    public float _radius = 10;

    private void OnGUI()
    {
        GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);
        ObjectInstatiate =
            EditorGUILayout.ObjectField("Объект, который хоти вставить",
            ObjectInstatiate, typeof(GameObject), true)
            as GameObject;
        _nameObject = EditorGUILayout.TextField("Имя объекта", _nameObject);
        _groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки",
            _groupEnabled);
        _randomColor = EditorGUILayout.Toggle("Случайный цвет", _randomColor);
        _countObject = EditorGUILayout.IntSlider("КОличество обхектов",
            _countObject, 1, 100);
        _radius = EditorGUILayout.IntSlider("Количество объектов",
            _countObject, 1, 100);
        _radius = EditorGUILayout.Slider("Радиус окружности", _radius, 10, 50);
        EditorGUILayout.EndToggleGroup();
        if(GUILayout.Button("Создать объекты"))
            if(ObjectInstatiate)
            {
                GameObject root = new GameObject("Root");
                for(int i=0;i<_countObject;i++)
                {
                    float angle = i * Mathf.PI * 2 / _countObject;
                    Vector3 pos = new Vector3(Mathf.Cos(angle), 0,
                        Mathf.Sin(angle)) * _radius;
                    GameObject temp = Instantiate(ObjectInstatiate, pos,
                        Quaternion.identity);
                    temp.name = _nameObject + "(" + i + ")";
                    temp.transform.parent = root.transform;
                    if(temp.GetComponent<Renderer>()&&_randomColor)
                    {
                        temp.GetComponent<Renderer>().material.color = Random.ColorHSV();
                    }
                }
            }
    }
}
