using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace StudioLand
{
    public class UIFocuser : MonoBehaviour
    {
        [SerializeField] UIDocument deselectBackground;
        [SerializeField] InputReaderSO playerInput;
        PanelUI currentFocus;
        public void RequestFocus(PanelUI panel)
        {
            deselectBackground.rootVisualElement.style.display = panel.CanDeselect? DisplayStyle.Flex : DisplayStyle.None;

            Defocus();

            Focus(panel);
        }

        void Focus(PanelUI panel)
        {
            playerInput.EnableUIInput();
            panel.AnimateIn();
            currentFocus = panel;
        }

        public void Defocus()
        {
            currentFocus?.AnimateOut();
            currentFocus = null;
        }

        /// <summary> Clean up the UI </summary>
        public void Reset()
        {
            currentFocus?.Reset();
            deselectBackground.rootVisualElement.style.display = DisplayStyle.None;
        }


    }
}

