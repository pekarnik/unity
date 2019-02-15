using UnityEditor;
namespace Game
{
    public class MenuItems
    {
        [MenuItem("Game/Пункт меню 0")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(MyWindow), false, "Game");
        }
    }
}