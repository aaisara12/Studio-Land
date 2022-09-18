using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using StudioLand;


public class EventTester : EditorWindow
{
    BaseField<Object> channelField;
    BaseField<Object> dataField;

    MinigameEventChannelSO minigameChannel;
    MinigameSO minigame;

    Button broadcastButton;

    [MenuItem("Window/Event Tester")]
    public static void ShowExample()
    {
        EventTester wnd = GetWindow<EventTester>();
        wnd.titleContent = new GUIContent("Event Tester");
    }

    private void OnEnable()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Import UXML -- NOTE: the "visual tree" is the structure of the UI created in UI Builder
        var original = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/EventTester.uxml");
        TemplateContainer visualTreeInstance = original.CloneTree();
        root.Add(visualTreeInstance);

        StyleSheet styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/EventTester.uss");
        root.styleSheets.Add(styleSheet);


        channelField = root.Q<BaseField<Object>>("Channel");
        channelField.RegisterValueChangedCallback(HandleNewMinigameEventChannel);

        dataField = root.Q<BaseField<Object>>("Data");
        dataField.RegisterValueChangedCallback(HandleNewMinigameData);

        broadcastButton = root.Q<Button>("Broadcast");
        broadcastButton.RegisterCallback<ClickEvent>(HandleBroadcastPressed);

    }

    private void HandleBroadcastPressed(ClickEvent evt)
    {
        if(minigameChannel && minigame)
        {
            minigameChannel.RaiseEvent(minigame);
        }
    }

    void OnDisable()
    {
        channelField.UnregisterValueChangedCallback(HandleNewMinigameEventChannel);
        dataField.UnregisterValueChangedCallback(HandleNewMinigameData);

    }

    private void HandleNewMinigameEventChannel(ChangeEvent<Object> evt)
    {
        if(evt.newValue != null)
        {
            Debug.Log("Found channel called " + evt.newValue.name);
            minigameChannel = evt.newValue as MinigameEventChannelSO;
        }
        
    }

    private void HandleNewMinigameData(ChangeEvent<Object> evt)
    {
        if(evt.newValue != null)
        {
            Debug.Log("Found minigame data called " + evt.newValue.name);
            minigame = evt.newValue as MinigameSO;
        }
        
    }
}