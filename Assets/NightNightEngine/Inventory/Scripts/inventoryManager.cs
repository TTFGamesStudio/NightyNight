using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace NightNightEngine.Inventory
{
    public class inventoryManager : MonoBehaviour
    {
        /// <summary>
        /// An Array containing all the the players inventory Data
        /// </summary>
        public itemSlot[] slots = new itemSlot[9];
        
        /// <summary>
        /// An Array holding all of the item name assets
        /// </summary>
        public TextMeshProUGUI[] itemNames;
        
        /// <summary>
        /// An Array for holding all of the count texts
        /// </summary>
        public TextMeshProUGUI[] counts;
        
        /// <summary>
        /// An Array for all of the items
        /// </summary>
        public UnityEngine.UI.Image[] images;

        public int selectedSlot = 0;

        [Header("UI Elements")] 
        public TextMeshProUGUI descriptionText;

        public GameObject useButton;
        public GameObject discardButton;
        
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < 9; i++)
            {
                slots[i] = new itemSlot();
                slots[i].itm = null;
                slots[i].count = 0;
            }
        }

        // Update is called once per frame
        void Update()
        {
            updateAllSlots();
        }

        /// <summary>
        /// Updates a single inventory slot
        /// </summary>
        void updateSlot(int index)
        {
            if (slots[index].itm != null)
            {
                itemNames[index].text = slots[index].itm.displayName;
                if (slots[index].itm.stackable && slots[index].count > 1)
                {
                    counts[index].text = "" + slots[index].count;
                }
                images[index].sprite = slots[index].itm.icon;
            }
            else
            {
                itemNames[index].text = "";
                counts[index].text = "";
                images[index].sprite = null;
            }
        }

        /// <summary>
        /// Look through and update all of the slots
        /// </summary>
        void updateAllSlots()
        {
            for (int i = 0; i < 9; i++)
            {
                updateSlot(i);
            }
        }

        /// <summary>
        /// Returns the index of the first empty item slot, Returns -1 if no slot is empty
        /// </summary>
        int firstEmptySlot()
        {
            int index = -1;
            
            for (int i = 0; i < 9; i++)
            {
                if (slots[i].itm == null)
                {
                    index = i;
                    return index;
                }
            }

            return index;
        }
        
        /// <summary>
        /// Returns the index of the first slot containng item itm, if no slot is found returns -1
        /// </summary>
        int findItem(item itm)
        {
            int index = -1;

            for (int i = 0; i < 9; i++)
            {
                if (slots[i].itm == itm && itm.stackable && slots[i].count < itm.stack)
                {
                    index = i;
                    return index;
                }
            }

            return index;
        }

        /// <summary>
        /// adds the given item to the given slot
        /// </summary>
        private void addItem(item itm, int index)
        {
            if (slots[index].itm == null)
            {
                slots[index].itm = itm;
                slots[index].count = 1;
            }
            else
            {
                if (slots[index].itm == itm && itm.stackable)
                {
                    slots[index].count++;
                }
                else
                {
                    Debug.Log("attempted to add item over another item");
                }
            }

            updateSlot(index);
        }

        /// <summary>
        /// Returns true if the player has an item, otherwise returns fals
        /// </summary>
        public bool doesHaveItem(item itm)
        {
            if (findItem(itm) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Resets a given slot back to being empty
        /// </summary>
        public void clearSlot(int index)
        {
            slots[index].itm = null;
            slots[index].count = 0;
            updateSlot(index);
        }

        /// <summary>
        /// removes an intem from the inventory
        /// </summary>
        public void takeItem(item itm)
        {
            int index = findItem(itm);
            if (index == -1)
            {
                Debug.Log("take item failed, Item " + itm.displayName + " not contained in inventory");
            }
            else
            {
                if (slots[index].count <= 1 || itm.stackable == false)
                {
                    clearSlot(index);
                }
                else
                {
                    slots[index].count--;
                }
            }
        }
        
        /// <summary>
        /// adds a given item into the inventory, returns false if it could not add the item due to no space
        /// </summary>
        public bool pickupItem(item itm)
        {
            int index = findItem(itm);
            if (index == -1)
            {
                index = firstEmptySlot();
                if (index == -1)
                {
                    return false;
                }
                else
                {
                    addItem(itm,index);
                    return true;
                }
            }
            else
            {
                addItem(itm,index);
                return true;
            }
        }

        /// <summary>
        /// used for being able to click on items
        /// </summary>
        public void updateButtonsAndDescription(int index)
        {
            if (slots[index].itm != null)
            {
                selectedSlot = index;
                descriptionText.text = slots[selectedSlot].itm.descritption;
                if (slots[selectedSlot].itm.usable)
                {
                    useButton.SetActive(true);
                }
                else
                {
                    useButton.SetActive(false);
                }
                
                if (slots[selectedSlot].itm.discardable)
                {
                    discardButton.SetActive(true);
                }
                else
                {
                    discardButton.SetActive(false);
                }
            }
        }
        
    }
}
