using Debugers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static ItemStack?[] inventoryItemSlots = new ItemStack?[20];
    private static ItemStack? armorItemSlotHelmet;
    private static ItemStack? armorItemSlotChest;
    private static ItemStack? armorItemSlotLegs;
    private static ItemStack? armorItemSlotWeapon;
    private static ItemStack?[] gearItemSlots = new ItemStack?[4];
    private static ItemStack?[] equipmentItemSlots = new ItemStack?[4];

    private static readonly Failed EquipHelmetFailed = new Failed("Only Helmet Armor Gear Items can be equiped here!");
    private static readonly Failed EquipChestFailed = new Failed("Only Chest Armor Gear Items can be equiped here!");
    private static readonly Failed EquipLegsFailed = new Failed("Only Leg Armor Gear Items can be equiped here!");
    private static readonly Failed EquipWeaponFailed = new Failed("Only Weapon Gear Items can be equiped here!");

    /// <summary>
    /// Invoked when an item has been added or removed from an inventory slot so relavant sources can be updated.
    /// </summary>
    public static Action itemAdded;

    #region EquipArmor
    private static bool CanEquipHemet(int position)
    {
        return inventoryItemSlots[position] == null || (inventoryItemSlots[position]?.GetItem() is SHelmetItem);
    }

    private static bool CanEquipChest(int position)
    {
        return inventoryItemSlots[position] != null && !(inventoryItemSlots[position]?.GetItem() is SChestItem);
    }

    private static bool CanEquipLegs(int position)
    {
        return inventoryItemSlots[position] != null && !(inventoryItemSlots[position]?.GetItem() is SLegItem);
    }

    private static bool CanEquipWeapon(int position)
    {
        return inventoryItemSlots[position] != null && !(inventoryItemSlots[position]?.GetItem() is SWeaponItem);
    }

    /// <summary>
    /// Equip item to helmet slot. Must be a SHelmetItem object.
    /// </summary>
    /// <param name="position">Position in inventory of Item to be equiped.</param>
    private static void EquipHelmet(int position)
    {
        if(!CanEquipHemet(position))
        {
            EquipHelmetFailed.ThisActionFailed();
            return;
        }

        ItemStack? swapedItemStack = inventoryItemSlots[position];

        inventoryItemSlots[position] = (armorItemSlotHelmet != null)? new ItemStack(armorItemSlotHelmet?.GetItem()) : (ItemStack?) null;

        armorItemSlotHelmet = (swapedItemStack != null) ? new ItemStack( swapedItemStack?.GetItem()) : (ItemStack?) null;
    }

    /// <summary>
    /// Equip item to Chest slot. Must be a SChestItem object.
    /// </summary>
    /// <param name="position">Position in inventory of Item to be equiped.</param>
    private static void EquipChest(int position)
    {
        if (CanEquipChest(position))
        {
            EquipChestFailed.ThisActionFailed();
            return;
        }

        ItemStack? swapedItemStack = inventoryItemSlots[position];

        inventoryItemSlots[position] = (armorItemSlotChest != null) ? new ItemStack(armorItemSlotChest?.GetItem()) : (ItemStack?)null;

        armorItemSlotChest = (swapedItemStack != null) ? new ItemStack(swapedItemStack?.GetItem()) : (ItemStack?)null;
    }

    /// <summary>
    /// Equip item to Chest slot. Must be a SChestItem object.
    /// </summary>
    /// <param name="position">Position in inventory of Item to be equiped.</param>
    private static void EquipLegs(int position)
    {
        if (CanEquipLegs(position))
        {
            EquipLegsFailed.ThisActionFailed();
            return;
        }

        ItemStack? swapedItemStack = inventoryItemSlots[position];

        inventoryItemSlots[position] = (armorItemSlotLegs != null) ? new ItemStack(armorItemSlotLegs?.GetItem()) : (ItemStack?)null;

        armorItemSlotLegs = (swapedItemStack != null) ? new ItemStack(swapedItemStack?.GetItem()) : (ItemStack?)null;
    }

    /// <summary>
    /// Equip item to Chest slot. Must be a SChestItem object.
    /// </summary>
    /// <param name="position">Position in inventory of Item to be equiped.</param>
    private static void EquipWeapon(int position)
    {
        if (CanEquipWeapon(position))
        {
            EquipWeaponFailed.ThisActionFailed();
            return;
        }

        ItemStack? swapedItemStack = inventoryItemSlots[position];

        inventoryItemSlots[position] = (armorItemSlotWeapon != null) ? new ItemStack(armorItemSlotWeapon?.GetItem()) : (ItemStack?)null;

        armorItemSlotWeapon = (swapedItemStack != null) ? new ItemStack(swapedItemStack?.GetItem()) : (ItemStack?)null;
    }
    #endregion

    /// <summary>
    /// Automatically add the given item to the inventory. Applying to existing stacks appropriatly and 
    /// thencreating a new stack as needed.
    /// </summary>
    /// <param name="item">Item to be added. </param>
    /// <param name="amount">Total to be added</param>
    private static int AddItems(SItem item, int amount) => AddItems(new ItemStack(item, amount));

    // Exists to be recersively called 
    internal static int AddItems(ItemStack itemStack)
    {
        if (itemStack.GetTotal() <= 0)
        {
            return 0;
        }
        
        int overflow = itemStack.GetTotal();
        for (int i = 0; i < inventoryItemSlots.Length; i++)
        {
            //position++;
            if (inventoryItemSlots[i] != null && (inventoryItemSlots[i]?.GetItem() == itemStack.GetItem()) && (bool)!inventoryItemSlots[i]?.IsFull())
            {
                int tempOverflow = (int)inventoryItemSlots[i]?.GetTotal() + overflow - (int)inventoryItemSlots[i]?.GetMax();

                inventoryItemSlots[i] = new ItemStack(inventoryItemSlots[i]?.GetItem(), (int)inventoryItemSlots[i]?.GetTotal() + overflow);

                overflow = tempOverflow;

                //Debug.Log("Overflow Value: " + tempOverflow + "(" + itemStack.GetTotal() + "-" + (int)inventoryItemSlots[i]?.GetTotal() + ")");
                if(overflow<=0)
                    break;
            }
        }

        //Debug.Log("[" + System.DateTime.Now + "]Inventory Before new stack: \n" + InventoryToString());

        if (overflow > 0)
        {
            for (int i = 0; i < inventoryItemSlots.Length; i++)
            {
                if (inventoryItemSlots[i].Equals(null))
                {
                    inventoryItemSlots[i] = new ItemStack(itemStack.GetItem(), overflow);
                    overflow = 0;
                    
                    break;
                }
            }
        }

        //Debug.Log("[" + System.DateTime.Now + "]Inventory After new stack: \n" + InventoryToString());
        itemAdded?.Invoke();
        return overflow;
    }

    private static bool RemoveItems(SItem item, int amount) => RemoveItems(new ItemStack(item, amount));
    
    // Exists to be recersively called 
    private static bool RemoveItems(ItemStack itemStack)
    {
        if (itemStack.GetTotal() <= 0)
        {
            return false;
        }

        for (int i = inventoryItemSlots.Length; i >= 0; i--)
        {
            if (inventoryItemSlots[i]?.GetItem() == itemStack.GetItem())
            {
                bool isEnough = true;

                int overflow = itemStack.GetTotal() - (int)inventoryItemSlots[i]?.GetTotal();

                    //(int)inventoryItemSlots[i]?.ModifyTotal(-itemStack.GetTotal());

                if (overflow > 0)
                {
                    isEnough = RemoveItems(itemStack.GetItem(), overflow);
                }
                //InventorySlotUpdated(i, itemStack.GetItem().itemImage, itemStack.GetTotal());
                return isEnough;
            }
        }
        itemAdded?.Invoke();
        return false;
    }

    /// <summary>
    /// Get all inventory items In their associated Positions.
    /// </summary>
    /// <returns>A list of duplicate item stacks with the given values.</returns>
    public static SItem[] GetInventoryItems()
    {
        SItem[] items = new SItem[inventoryItemSlots.Length];

        for(int i = 0; i < inventoryItemSlots.Length; i++)
        {
            if (!inventoryItemSlots[i].Equals(null))
                items[i] = inventoryItemSlots[i]?.GetItem();
        }

        return items;
    }

    /// <summary>
    /// Get all inventory items In their associated Positions.
    /// </summary>
    /// <returns>A list of duplicate item stacks with the given values.</returns>
    public static int[] GetInventoryTotals()
    {
        int[] total = new int[inventoryItemSlots.Length];

        for (int i = 0; i < inventoryItemSlots.Length; i++)
        {
            if (!inventoryItemSlots[i].Equals(null))
                total[i] = (int) inventoryItemSlots[i]?.GetTotal();
        }

        return total;
    }

    public static SItem GetItemAtPosition(int position)
    {
        if (position < 0)
        {
            switch (position)
            {
                case -2:
                    return armorItemSlotHelmet?.GetItem();
                case -3:
                    return armorItemSlotChest?.GetItem();
                case -4:
                    return armorItemSlotLegs?.GetItem();
                case -5:
                    return armorItemSlotWeapon?.GetItem();
            }
        }

        return inventoryItemSlots[position]?.GetItem();
    }

    /// <summary>
    /// Returns the Icon Sprite for the item at this position. 
    /// </summary>
    /// <param name="position">Item Icon</param>
    /// <returns></returns>
    public static Sprite GetImageAtPosition(int position)
    {
        //Debug.Log("Getting image at: " + position + " and found " + inventoryItemSlots[position]?.GetItem().itemImage);

        if (position < 0)
        {
            switch (position)
            {
                case -2:
                    return armorItemSlotHelmet?.GetItem().itemImage;
                case -3:
                    return armorItemSlotChest?.GetItem().itemImage;
                case -4:
                    return armorItemSlotLegs?.GetItem().itemImage;
                case -5:
                    return armorItemSlotWeapon?.GetItem().itemImage;
            }
        }

        return inventoryItemSlots[position]?.GetItem().itemImage;
    }

    /// <summary>
    /// Returns the amount of items in this stack at this position. 
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public static int GetTotalAtPosition(int position)
    {
        if (position < 0)
        {
            switch (position)
            {
                case -2:
                    return (int)armorItemSlotHelmet?.GetTotal();
                case -3:
                    return (int)armorItemSlotChest?.GetTotal();
                case -4:
                    return (int)armorItemSlotLegs?.GetTotal();
                case -5:
                    return (int)armorItemSlotWeapon?.GetTotal();
            }
        }

        return (int)inventoryItemSlots[position]?.GetTotal();
    }

    /// <summary>
    /// Swap 2 items with this given positions. 
    /// </summary>
    /// <param name="positionOne">The item selected to be moved</param>
    /// <param name="positionTwo">The position to be moved to.</param>
    public static bool SwapItems(int positionOne, int positionTwo)
    {
        if ((positionOne >= 0 && inventoryItemSlots[positionOne].Equals(null)) && (positionTwo >= 0 && inventoryItemSlots[positionTwo].Equals(null)))
        {
            return false;
        }

        if(positionOne < 0 && positionTwo < 0)
        {
            if (positionOne >= -4 || positionTwo >= -4)
            {
                switch (positionOne)
                {
                    case -2:
                        EquipHelmetFailed.ThisActionFailed();
                        break;
                    case -3:
                        EquipChestFailed.ThisActionFailed();
                        break;
                    case -4:
                        EquipLegsFailed.ThisActionFailed();
                        break;
                    case -5:
                        EquipWeaponFailed.ThisActionFailed();
                        break;
                }
                switch (positionTwo)
                {
                    case -2:
                        EquipHelmetFailed.ThisActionFailed();
                        break;
                    case -3:
                        EquipChestFailed.ThisActionFailed();
                        break;
                    case -4:
                        EquipLegsFailed.ThisActionFailed();
                        break;
                    case -5:
                        EquipWeaponFailed.ThisActionFailed();
                        break;
                }
                itemAdded?.Invoke();
                return false;
            }
        }

        // Handle Equipment. . . Equiping? Handle stuff being put on. 
        if(positionTwo < 0)
        {
            switch (positionTwo)
            {
                case -2:
                    EquipHelmet(positionOne);
                    break;
                case -3:
                    EquipChest(positionOne);
                    break;
                case -4:
                    EquipLegs(positionOne);
                    break;
                case -5:
                    EquipWeapon(positionOne);
                    break;
            }
            itemAdded?.Invoke();
            return true;
        }

        if(positionOne < 0)
        {
            switch (positionOne)
            {
                case -2:
                    EquipHelmet(positionTwo);
                    break;
                case -3:
                    EquipChest(positionTwo);
                    break;
                case -4:
                    EquipLegs(positionTwo);
                    break;
                case -5:
                    EquipWeapon(positionTwo);
                    break;
            }
            itemAdded?.Invoke();
            return true;
        }

        if (inventoryItemSlots[positionOne]?.GetItem() == inventoryItemSlots[positionTwo]?.GetItem())
        {
            var item = inventoryItemSlots[positionOne]?.GetItem();
            var totalOne = (int)inventoryItemSlots[positionOne]?.GetTotal();
            var totalTwo = (int)inventoryItemSlots[positionTwo]?.GetTotal();
            inventoryItemSlots[positionTwo] = new ItemStack(item, totalOne + totalTwo);

            if (totalOne+totalTwo< inventoryItemSlots[positionTwo]?.GetMax())
            {
                inventoryItemSlots[positionOne] = null;
            }
            else
            {
                inventoryItemSlots[positionOne] = new ItemStack(item, totalOne + totalTwo - (int)inventoryItemSlots[positionTwo]?.GetMax());
            }

            //InventorySlotUpdated(positionOne, inventoryItemSlots[positionOne]?.GetItem().itemImage, inventoryItemSlots[positionOne]?.GetTotal());
            itemAdded?.Invoke();
            return true;
        }

        ItemStack? positionOneItem = inventoryItemSlots[positionOne];

        inventoryItemSlots[positionOne] = inventoryItemSlots[positionTwo];
        inventoryItemSlots[positionTwo] = positionOneItem;

        itemAdded?.Invoke();
        return true;
    }

    public void EquipItem()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<ItemDrop>(out ItemDrop itemComponent))
        {
            AddItems(itemComponent.GetItemStack());
            itemComponent.DestroyItem();
        }
    }

    /// <summary>
    /// For Debugging stuff.
    /// </summary>
    /// <returns></returns>
    private static string InventoryToString()
    {
        bool isNull = inventoryItemSlots[0] == null;
        string stringBuilder = "[" + ((isNull) ? "Empty" : inventoryItemSlots[0]?.GetItem().itemName) + " " + ((isNull) ? "NA" : inventoryItemSlots[0]?.GetTotal().ToString()) + ", ";
        for (int i = 1; i < inventoryItemSlots.Length - 1; i++)
        {
            isNull = inventoryItemSlots[i] == null;
            stringBuilder += ((isNull) ? "Empty" : inventoryItemSlots[i]?.GetItem().itemName) + "-" + ((isNull) ? "NA" : inventoryItemSlots[i]?.GetTotal().ToString()) + ", ";
        }
        isNull = inventoryItemSlots[inventoryItemSlots.Length - 1] == null;
        stringBuilder += ((isNull) ? "Empty" : inventoryItemSlots[inventoryItemSlots.Length - 1]?.GetItem().itemName) + " " + ((isNull) ? "NA" : inventoryItemSlots[inventoryItemSlots.Length - 1]?.GetTotal().ToString()) + "]";


        return stringBuilder;
    }


}
