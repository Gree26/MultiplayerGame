using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ItemDescriptionPage : MonoBehaviour
    {
        private static CanvasGroup s_thisCanvaseGroup;
        [SerializeField]
        private Text _name;
        private static Text s_name;

        // Basic Item Text
        [SerializeField]
        private CanvasGroup _basicItemCanvasGroup;
        [SerializeField]
        private Text _basicItemRarity;
        [SerializeField]
        private Text _basicItemDescription;

        private static CanvasGroup s_basicItemCanvasGroup;
        private static Text s_basicItemRarity;
        private static Text s_basicItemDescription;

        // Gear Item Texts
        [SerializeField]
        private CanvasGroup _gearItemCanvasGroup;
        [SerializeField]
        private Text _gearItemRarity;
        [SerializeField]
        private Text _gearItemAbilityOne, _gearItemAbilityTwo, _gearItemAbilityThree, _gearItemAbilityFour;
        [SerializeField]
        private Text _gearItemStats;

        private static CanvasGroup s_gearItemCanvasGroup;
        private static Text s_gearItemRarity;
        private static Text s_gearItemAbilityOne, s_gearItemAbilityTwo, s_gearItemAbilityThree, s_gearItemAbilityFour;
        private static Text s_gearItemStats;


        private void OnEnable()
        {
            s_thisCanvaseGroup = this.GetComponent<CanvasGroup>();

            s_name = _name;

            s_basicItemCanvasGroup = _basicItemCanvasGroup;
            s_basicItemRarity = _basicItemRarity;
            s_basicItemDescription = _basicItemDescription;

            s_gearItemCanvasGroup = _gearItemCanvasGroup;
            s_gearItemRarity = _gearItemRarity;
            s_gearItemAbilityOne = _gearItemAbilityOne;
            s_gearItemAbilityTwo = _gearItemAbilityTwo;
            s_gearItemAbilityThree = _gearItemAbilityThree;
            s_gearItemAbilityFour = _gearItemAbilityFour;
            s_gearItemStats = _gearItemStats;

            Close();
        }

        private void OnDisable()
        {
            s_thisCanvaseGroup = null;

            s_name = null;

            s_basicItemCanvasGroup = null;
            s_basicItemRarity = null;
            s_basicItemDescription = null;

            s_gearItemCanvasGroup = null;
            s_gearItemRarity = null;
            s_gearItemAbilityOne = null;
            s_gearItemAbilityTwo = null;
            s_gearItemAbilityThree = null;
            s_gearItemAbilityFour = null;
            s_gearItemStats = null;
        }

        /// <summary>
        /// Close the item description window. 
        /// </summary>
        public static void Close()
        {
            s_thisCanvaseGroup.alpha = 0;
            s_thisCanvaseGroup.blocksRaycasts = false;
            s_thisCanvaseGroup.interactable = false;
        }

        /// <summary>
        /// Opens a popup with this gears info.
        /// </summary>
        /// <param name="item">The item to open</param>
        public static void Open(SItem item)
        {
            if(item is SGearItem)
            {
                SGearItem gearItem = (SGearItem)item;

                string stats = ((gearItem.health != 0) ? "HEALTH: " + gearItem.health.ToString() : "") +
                                ((gearItem.armor != 0) ? "ARMOR: " + gearItem.armor.ToString() : "") +
                                ((gearItem.health != 0) ? "HEALTH: " + gearItem.health.ToString() : "") +
                                ((gearItem.chaos != 0) ? "CHAOS: " + gearItem.chaos.ToString() : "") +
                                ((gearItem.order != 0) ? "ORDER: " + gearItem.order.ToString() : "") +
                                ((gearItem.creation != 0) ? "CREATION: " + gearItem.creation.ToString() : "") +
                                ((gearItem.destruction != 0) ? "DESTRUCTION: " + gearItem.destruction.ToString() : "");

                OpenGearItem(gearItem.Rarity.Name, gearItem.itemName, stats);

                return;
            }

            OpenBasicItem(item.Rarity.Name, item.name, item.Description);
        }

        /// <summary>
        /// Open the item description window with basic item properties.
        /// </summary>
        /// <param name="rarity">Name of the rarity level.</param>
        /// <param name="itemName">Name of the basic item.</param>
        /// <param name="description">Description of this item.</param>
        private static void OpenBasicItem(string rarity, string itemName, string description)
        {
            s_gearItemCanvasGroup.alpha = 0;
            s_gearItemCanvasGroup.blocksRaycasts = false;
            s_gearItemCanvasGroup.interactable = false;

            s_basicItemCanvasGroup.alpha = 1;
            s_basicItemCanvasGroup.blocksRaycasts = true;
            s_basicItemCanvasGroup.interactable = true;

            s_thisCanvaseGroup.alpha = 1;
            s_thisCanvaseGroup.blocksRaycasts = true;
            s_thisCanvaseGroup.interactable = true;

            s_name.text = itemName;

            s_basicItemRarity.text = rarity;
            s_basicItemDescription.text = description;
        }

        private static void OpenGearItem(string rarity, string itemName, string stats) => OpenGearItem(rarity, itemName, stats, "", "", "", "");
        private static void OpenGearItem(string rarity, string itemName, string stats, string abilityOne) => OpenGearItem(rarity, itemName, stats, abilityOne, "", "", "");
        private static void OpenGearItem(string rarity, string itemName, string stats, string abilityOne, string abilityTwo) => OpenGearItem(rarity, itemName, stats, abilityOne, abilityTwo, "", "");
        private static void OpenGearItem(string rarity, string itemName, string stats, string abilityOne, string abilityTwo, string abilityThree) => OpenGearItem(rarity, itemName, stats, abilityOne, abilityTwo, abilityThree, "");

        /// <summary>
        /// Open the item description window with gear item properties.
        /// </summary>
        /// <param name="rarity">Name of the rarity level.<</param>
        /// <param name="itemName">Name of the gear item.</param>
        /// <param name="stats">Gear items stats.</param>
        /// <param name="abilityOne">Ability one's name.</param>
        /// <param name="abilityTwo">Ability two's name.</param>
        /// <param name="abilityThree">Ability three's name.</param>
        /// <param name="abilityFour">Ability four's name.</param>
        private static void OpenGearItem(string rarity, string itemName, string stats, string abilityOne, string abilityTwo, string abilityThree, string abilityFour)
        {
            s_gearItemCanvasGroup.alpha = 1;
            s_gearItemCanvasGroup.blocksRaycasts = true;
            s_gearItemCanvasGroup.interactable = true;

            s_basicItemCanvasGroup.alpha = 0;
            s_basicItemCanvasGroup.blocksRaycasts = false;
            s_basicItemCanvasGroup.interactable = false;

            s_thisCanvaseGroup.alpha = 1;
            s_thisCanvaseGroup.blocksRaycasts = true;
            s_thisCanvaseGroup.interactable = true;

            s_name.text = itemName;

            s_gearItemRarity.text = rarity;
            s_gearItemStats.text = stats;
            s_gearItemAbilityOne.text = abilityOne;
            s_gearItemAbilityTwo.text = abilityTwo;
            s_gearItemAbilityThree.text = abilityThree;
            s_gearItemAbilityFour.text = abilityFour;
        }
    }
}
