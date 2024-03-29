using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class YesNoBox : UpDownMenu
    // Choice boxes
    {
        private List<GameObject> _textGameObjects = new();
        [NonSerialized] public bool Result = true;
        
        public void Redraw()
        {
            if (choices.Count > 0) choices.Clear();
            
            choices.Add("OUI");
            choices.Add("NON");
            
            // Destroy existing text
            if (_textGameObjects.Count > 0)
            {
                foreach (var tObject in _textGameObjects)
                {
                    Destroy(tObject);
                }

                _textGameObjects.Clear();
            }
            
            // Print text
            var items = transform.Find("ObjectMenuItems");
            var textObject = items.Find("Text");
            
            foreach (var text in choices)
            {
                var newTextObject = Instantiate(textObject, items).gameObject;
                _textGameObjects.Add(newTextObject);
                var newText = newTextObject.GetComponent<TextMeshProUGUI>();
                newText.text = text;
                newTextObject.SetActive(true);
            }
        }

        public new void CloseMenu()
        {
            open = false;
            //ArrowPosition = 0;
        }
    }
}