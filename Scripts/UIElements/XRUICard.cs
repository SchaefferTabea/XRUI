// MIT License
// Copyright (c) 2021 Chris Warin
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace com.chwar.xrui.UIElements
{
    public class XRUICard : XRUIElement
    {
        // UXML Attributes
        private Label _title;
        private Label _subtitle;
        private Button _closeButton;
        
        [Tooltip("Dimensions of the card")]
        public Vector2 cardDimensions;

        [Tooltip("Title of the card")]
        public string Title
        {
            get => _title.text;
            set => _title.text = value;
        }

        [Tooltip("Subtitle of the card")]
        public string Subtitle
        {
            get => _subtitle.text;
            set => _subtitle.text = value;
        }
        
        protected internal override void Init()
        {
            base.Init();
            _title = UIDocument.rootVisualElement.Q<Label>("Title");
            _subtitle = UIDocument.rootVisualElement.Q<Label>("Subtitle");
            _closeButton = UIDocument.rootVisualElement.Q<Button>("Close");
        }

        /// <summary>
        /// Updates UXML UI with the values inserted in the inspector.
        /// </summary>
        internal override void UpdateUI()
        {
            base.UpdateUI();
            UpdateTitle(Title);
            UpdateSubtitle(Subtitle);
            UpdateDimensions(cardDimensions);
        }
        
        /*Update Methods*/

        public void UpdateTitle(string text)
        {
            if(_title != null && _title.text != text)
                _title.text = text;
        }
        
        public void UpdateSubtitle(string text)
        {
            if(_subtitle != null && _subtitle.text != text)
                _subtitle.text = text;
        }

        public void UpdateDimensions(Vector2 dimensions)
        {
            if (UIDocument != null && cardDimensions != dimensions)
            {
                UIDocument.rootVisualElement.ElementAt(0).style.width = dimensions.x;
                UIDocument.rootVisualElement.ElementAt(0).style.height = dimensions.y;
            }
        }

        public void SetCloseButtonAction(Action closeButtonAction)
        {
            if(_closeButton != null)
                _closeButton.clicked += closeButtonAction;
        }
    }
}
