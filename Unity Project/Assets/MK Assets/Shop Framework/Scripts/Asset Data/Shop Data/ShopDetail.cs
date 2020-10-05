/* 
 * Author : Mohsin Khan
 * LinkedIn : http://pk.linkedin.com/in/mohsinkhan26/
 * Github : https://github.com/mohsinkhan26/
 * BitBucket : https://bitbucket.org/mohsinkhan26/ 
*/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace MK.ShopFramework.Data
{
    [Serializable]
    public class ShopDetail
    {
        public int itemID;
        public ItemType itemType;
        public string itemName;
        public int itemQuantity;
        public ConsumeType consumeType;

        [Range(0.01f, 500f)]
        public float itemPrice; // just a limit, so no typo could occur. Otherwise better to remove the range attribute

        public Sprite smallSprite;
        public Sprite bigSprite;
        [TextArea(1, 3)] [Multiline] public string itemDescription;
        public List<ConsumeType> bundle;

        public ShopDetail(int _itemID, ItemType _itemType, string _itemName, int _quantity,
            ConsumeType _consumeType, float _price, Sprite _smallSprite, Sprite _bigSprite,
            string _description, ShopBundleModel _bundle)
        {
            itemID = _itemID;
            itemType = _itemType;
            itemName = _itemName;
            itemQuantity = _quantity;
            consumeType = _consumeType;
            itemPrice = _price;
            smallSprite = _smallSprite;
            bigSprite = _bigSprite;
            itemDescription = _description;

            if (bundle == null && _bundle != null)
                bundle = new List<ConsumeType>();
            if (_bundle != null)
            {
                bundle.Add((ConsumeType)Enum.Parse(typeof(ConsumeType), _bundle.Item1, true));
                bundle.Add((ConsumeType)Enum.Parse(typeof(ConsumeType), _bundle.Item2, true));
                bundle.Add((ConsumeType)Enum.Parse(typeof(ConsumeType), _bundle.Item3, true));
            }
        }

        public bool IsABundle
        {
            get { return !(bundle == null || bundle.Count == 0); }
        }
    }
}