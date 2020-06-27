using Domain.Characters.Models;
using GTANetworkAPI;
using RomaniaRoleplay.Helpers.Enums;
using System;
using System.Collections.Generic;

namespace RomaniaRoleplay.Helpers
{
    internal static class ClientCharacterHelper
    {
        public static void SetPlayerCharacter(Player player, Character character)
        {
            NAPI.Player.SetPlayerName(player, character.Name);
            NAPI.Player.SetPlayerNametag(player, $"{character.NameTag}(${player.Id})");

            SetCharacterCustomization(player, character);
            SetCharacterClothes(player, character);
        }

        public static void SetCharacterClothes(Player player, Character character, ClothesIndex? specificClotheIndex = null)
        {
            Dictionary<int, ComponentVariation> clothes = new Dictionary<int, ComponentVariation>();
            if (specificClotheIndex.HasValue)
            {
                AddClothesIndexToDictionary(specificClotheIndex.Value, clothes, character);
            }
            else
            {
                foreach (ClothesIndex overlay in Enum.GetValues(typeof(ClothesIndex)))
                {
                    AddClothesIndexToDictionary(overlay, clothes, character);
                }
            }
            player.SetClothes(clothes);
        }

        public static void SetCharacterCustomization(Player player, Character character)
        {
            HeadBlend headBlend = SetHeadBlend(character.Skin);

            var eyeColor = Convert.ToByte(character.Skin.EyesColor);
            var hairColor = Convert.ToByte(character.Skin.FirstHairColor);
            var highlightColor = Convert.ToByte(character.Skin.SecondHairColor);

            float[] faceFeatures = SetFaceFeatures(character.Skin);

            Dictionary<int, HeadOverlay> headOverlays = SetHeadOverlay(character.Skin);

            bool isMale = character.Skin.Model == (uint)PedHash.FreemodeMale01;

            player.SetCustomization(isMale, headBlend, eyeColor, hairColor, highlightColor, faceFeatures, headOverlays, new Decoration[] { });

        }

        private static void AddClothesIndexToDictionary(ClothesIndex clothesIndex, Dictionary<int, ComponentVariation> clothes, Character character)
        {
            switch (clothesIndex)
            {
                case ClothesIndex.Masks:
                    clothes.TryAdd((int)ClothesIndex.Masks, new ComponentVariation(0, 0));
                    break;
                case ClothesIndex.Hair:
                    clothes.TryAdd((int)ClothesIndex.Hair, new ComponentVariation(character.Skin.Hair, 0));
                    break;
                case ClothesIndex.Torsos:
                    clothes.TryAdd((int)ClothesIndex.Torsos, new ComponentVariation(character.Skin.Clothes.Torsos, 0));
                    break;
                case ClothesIndex.Legs:
                    clothes.TryAdd((int)ClothesIndex.Legs, new ComponentVariation(character.Skin.Clothes.Legs, 0));
                    break;
                case ClothesIndex.BagsAndParachutes:
                    clothes.TryAdd((int)ClothesIndex.BagsAndParachutes, new ComponentVariation(character.Skin.Clothes.BagsAndParachutes, 0));
                    break;
                case ClothesIndex.Shoes:
                    clothes.TryAdd((int)ClothesIndex.Shoes, new ComponentVariation(character.Skin.Clothes.Shoes, 0));
                    break;
                case ClothesIndex.Accessories:
                    clothes.TryAdd((int)ClothesIndex.Accessories, new ComponentVariation(character.Skin.Clothes.Accessories, 0));
                    break;
                case ClothesIndex.Undershirts:
                    clothes.TryAdd((int)ClothesIndex.Undershirts, new ComponentVariation(character.Skin.Clothes.Undershirts, 0));
                    break;
                case ClothesIndex.BodyArmors:
                    clothes.TryAdd((int)ClothesIndex.BodyArmors, new ComponentVariation(character.Skin.Clothes.BodyArmors, 0));
                    break;
                case ClothesIndex.Decals:
                    clothes.TryAdd((int)ClothesIndex.Decals, new ComponentVariation(character.Skin.Clothes.Decals, 0));
                    break;
                case ClothesIndex.Tops:
                    clothes.TryAdd((int)ClothesIndex.Tops, new ComponentVariation(character.Skin.Clothes.Tops, 0));
                    break;
            }
        }

        private static HeadBlend SetHeadBlend(Skin skin)
        {
            HeadBlend headBlend = new HeadBlend
            {
                ShapeFirst = Convert.ToByte(skin.FirstHeadShape),
                ShapeSecond = Convert.ToByte(skin.SecondHeadShape),
                ShapeMix = skin.HeadMix,
                SkinFirst = Convert.ToByte(skin.FirstSkinTone),
                SkinSecond = Convert.ToByte(skin.SecondHeadShape),
                SkinMix = skin.SkinMix
            };
            return headBlend;
        }

        private static float[] SetFaceFeatures(Skin skin)
        {
            float[] faceFeatures = new float[]
            {
                skin.NoseWidth, skin.NoseHeight, skin.NoseLength, skin.NoseBridge, skin.NoseTip, skin.NoseShift, skin.BrowHeight,
                skin.BrowWidth, skin.CheekboneHeight, skin.CheekboneWidth, skin.CheeksWidth, skin.Eyes, skin.Lips, skin.JawWidth,
                skin.JawHeight, skin.ChinLength, skin.ChinPosition, skin.ChinWidth, skin.ChinShape, skin.NeckWidth
            };
            return faceFeatures;
        }

        private static Dictionary<int, HeadOverlay> SetHeadOverlay(Skin skin)
        {
            Dictionary<int, HeadOverlay> headOverlays = new Dictionary<int, HeadOverlay>();

            foreach (HeadOverlayIndexes overlay in Enum.GetValues(typeof(HeadOverlayIndexes)))
            {
                if (skin.Model == (uint)PedHash.FreemodeMale01 && (overlay == HeadOverlayIndexes.Lipstick || overlay == HeadOverlayIndexes.Blush || overlay == HeadOverlayIndexes.Makeup))
                {
                    goto SkipCustomization;
                }
                if (skin.Model == (uint)PedHash.FreemodeFemale01 && overlay == HeadOverlayIndexes.FacialHair)
                {
                    goto SkipCustomization;
                }
                // Get the overlay model and color
                (int index, int color) = GetOverlayData(skin, overlay);

                // Create the overlay
                HeadOverlay headOverlay = new HeadOverlay();
                headOverlay.Index = Convert.ToByte(index);
                headOverlay.Color = Convert.ToByte(color);
                headOverlay.SecondaryColor = 0;
                headOverlay.Opacity = 1.0f;

                // Add the overlay
                headOverlays.TryAdd((int)overlay, headOverlay);

            SkipCustomization: continue;
            }
            return headOverlays;
        }

        private static (int index, int color) GetOverlayData(Skin skin, HeadOverlayIndexes overlay)
        {
            switch (overlay)
            {
                case HeadOverlayIndexes.Blemishes:
                    return (skin.Blemishes, 0);
                case HeadOverlayIndexes.FacialHair:
                    return (skin.Beard, skin.BeardColor);
                case HeadOverlayIndexes.Eyebrows:
                    return (skin.Eyebrows, skin.EyebrowsColor);
                case HeadOverlayIndexes.Ageing:
                    return (skin.Ageing, 0);
                case HeadOverlayIndexes.Makeup:
                    return (skin.Makeup, 0);
                case HeadOverlayIndexes.Blush:
                    return (skin.Blush, skin.BlushColor);
                case HeadOverlayIndexes.Complexion:
                    return (skin.Complexion, 0);
                case HeadOverlayIndexes.SunDamage:
                    return (skin.Sundamage, 0);
                case HeadOverlayIndexes.Lipstick:
                    return (skin.Lipstick, skin.LipstickColor);
                case HeadOverlayIndexes.Freckles:
                    return (skin.Freckles, 0);
                case HeadOverlayIndexes.ChestHair:
                    return (skin.Chest, skin.ChestColor);
                default:
                    return (0, 0);
            }
        }
    }
}
