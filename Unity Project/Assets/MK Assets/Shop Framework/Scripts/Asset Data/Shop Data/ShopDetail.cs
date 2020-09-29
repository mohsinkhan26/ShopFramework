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

        public bool IsABundle
        {
            get { return !(bundle == null || bundle.Count == 0); }
        }
    }
}