using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NightNightEngine.Inventory
{
    public class clickManager : MonoBehaviour, IPointerClickHandler
    {
        public int index = 0;
        public inventoryManager inventory;

        private void Start()
        {
            inventory = GameObject.FindObjectOfType<inventoryManager>();
        }

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            inventory.updateButtonsAndDescription(index);
        }
    }
}
