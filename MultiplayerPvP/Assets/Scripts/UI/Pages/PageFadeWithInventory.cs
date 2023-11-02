using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class PageFadeWithInventory : PageFade
    {
        private bool _showInventory = false;

        public override void Enter(bool playAudio)
        {
            base.Enter(playAudio);
            InventoryPage.Open(_showInventory);
        }

        public override void Exit(bool playAudio)
        {
            base.Exit(playAudio);
            InventoryPage.Open(_showInventory);
        }
    }
}
