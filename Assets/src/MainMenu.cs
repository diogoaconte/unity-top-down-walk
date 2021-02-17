using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void OnEnable()
    {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
        var startButton = rootVisualElement.Q<Button>("start-button");

        startButton.RegisterCallback<ClickEvent>(RedirectScene);
    }

    private void RedirectScene(ClickEvent evt) {
        SceneManager.LoadSceneAsync("main-scene");
    }

}
