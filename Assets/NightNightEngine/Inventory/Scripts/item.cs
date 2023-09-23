using UnityEngine;

namespace NightNightEngine.Inventory
{
    /// <summary>
    /// a basic class for holding Item data
    /// </summary>
    [CreateAssetMenu (menuName = "data/item" , fileName = "item", order = 4)]
    public class item : ScriptableObject
    {
        public int id;
        [Header("InventoryUI")]
        public Sprite icon;
        public string displayName;
        public string descritption;
        
        [Header("Flags")]
        public bool stackable;
        public bool usable;
        public bool discardable;
        public int stack;
    }
}
