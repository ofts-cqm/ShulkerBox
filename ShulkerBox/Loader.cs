using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley.GameData.BigCraftables;
using StardewValley.GameData.Objects;

namespace ShulkerBox
{
    internal class Loader
    {
        public static void Load(object? sender, AssetRequestedEventArgs args)
        {
            switch(args.NameWithoutLocale.BaseName)
            {
                case "Data/BigCraftables": args.Edit((asset) => LoadBC(asset.AsDictionary<string, BigCraftableData>().Data)); break;

                case "ofts.shulkerbox.texture": args.LoadFromModFile<Texture2D>("assets/texture", AssetLoadPriority.Low); break;

                case "ofts\\shulkerbox\\string": args.LoadFrom(LoadString, AssetLoadPriority.Low); break;

                case "Data/Objects": args.Edit((asset) => LoadItems(asset.AsDictionary<string, ObjectData>().Data)); break;
            }
        }

        public static void LoadItems(IDictionary<string, ObjectData> dic)
        {
            ObjectData shulkerShell = new() 
            { 
                Name = "Shulker Shell",
                DisplayName = "[LocalizedText ofts\\shulkerbox\\string:ShulkerShell_Display]",
                Description = "[LocalizedText ofts\\shulkerbox\\string:ShulkerShell_Descrip]",
                Price = 100, 
                Texture = "ofts.shulkerbox.texture",
                SpriteIndex = 1,
                Type = "Basic",
                Category = -28
                // TODO: set up way to get this item
            };
            dic.Add("ofts.shulkerbox.shell", shulkerShell);
        }

        public static Dictionary<string, string> LoadString()
        {
            ITranslationHelper? helper = ModEntry.Instance?.Helper.Translation;
            if (helper == null) return new();

            return new()
            {
                {"ShulkerBox_Display", helper.Get("ShulkerBox_Display") },
                {"ShulkerBox_Descrip", helper.Get("ShulkerBox_Descrip") },
                {"ShulkerShell_Display", helper.Get("ShulkerShell_Display") },
                {"ShulkerShell_Descrip", helper.Get("ShulkerShell_Descrip") }
            };
        }

        public static void LoadBC(IDictionary<string, BigCraftableData> dic)
        {
            BigCraftableData shulkerBox = new()
            {
                Name = "Shulker Box",
                DisplayName = "[LocalizedText ofts\\shulkerbox\\string:ShulkerBox_Display]",
                Description = "[LocalizedText ofts\\shulkerbox\\string:ShulkerBox_Descrip]",
                Price = 500,
                Fragility = 0,
                IsLamp = false,
                Texture = "ofts.shulkerbox.texture",
                SpriteIndex = 0, 
            };
            dic.Add("ofts.shulkerbox.box", shulkerBox);
        }
    }
}
