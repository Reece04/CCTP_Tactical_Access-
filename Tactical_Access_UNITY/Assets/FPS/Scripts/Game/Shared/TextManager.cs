using System;
using UnityEngine;

namespace Unity.FPS.Game
{
    public abstract class TextManager : MonoBehaviour
    {
        [Tooltip("Name of the objective that will be shown on screen")]
        public string Title;

        [Tooltip("Delay before the objective becomes visible")]
        public float DelayVisible;

        protected virtual void Start()
        {

            DisplayMessageEvent displayMessage = Events.DisplayMessageEvent;
            displayMessage.Message = Title;
            displayMessage.DelayBeforeDisplay = 0.0f;
            EventManager.Broadcast(displayMessage);
        }
    }
}