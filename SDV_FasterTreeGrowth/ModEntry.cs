using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.TerrainFeatures;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;

namespace SDV_KeyListener
{
    public class ModEntry : Mod
    {
        Random r = new Random();
        int chance = 35;

        // helper - contains i/o methods for working dir
        public override void Entry(ModHelper helper)
        {
            TimeEvents.OnNewDay += this.onNewDay;
        }


        // sender - event sender
        // e - Event data
        private void onNewDay(object sender, EventArgsNewDay e)
        {
            foreach (GameLocation location in Game1.locations)
            {
                foreach (KeyValuePair<Vector2, StardewValley.TerrainFeatures.TerrainFeature> pair in location.terrainFeatures)
                {
                    if (pair.Value is Tree)
                    {
                        Tree tree = (Tree)pair.Value;
                        if (tree.growthStage < 5 && tree.treeType != 6 && r.Next(1, 100) <= chance) tree.growthStage++;
                    } else if (pair.Value is FruitTree)
                    {
                        FruitTree tree = (FruitTree)pair.Value;
                        if (tree.growthStage < 5 && r.Next(1, 100) <= chance) tree.growthStage++;
                    }
                }
            }
        }
    }
}