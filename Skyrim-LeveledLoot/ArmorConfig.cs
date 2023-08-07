using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.FormKeys.SkyrimLE;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Records;

using Form = Mutagen.Bethesda.Plugins.IFormLink<Mutagen.Bethesda.Plugins.Records.IMajorRecordGetter>;
using SKY = Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Armor;
using DB = Mutagen.Bethesda.FormKeys.SkyrimLE.Dragonborn.Armor;
using DG = Mutagen.Bethesda.FormKeys.SkyrimLE.Dawnguard.Armor;
using SKYL = Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem;
using DBL = Mutagen.Bethesda.FormKeys.SkyrimLE.Dragonborn.LeveledItem;
using DGL = Mutagen.Bethesda.FormKeys.SkyrimLE.Dawnguard.LeveledItem;

namespace LeveledLoot {


    class ArmorConfig : LootConfig<ArmorConfig> {
        public ItemMaterial IRON = new("Iron", Program.Settings.armorLootTable.heavyArmorLootTable.IRON);
        public ItemMaterial DRAUGR = new("Draugr", Program.Settings.armorLootTable.heavyArmorLootTable.DRAUGR);
        public ItemMaterial STEEL = new("Steel", Program.Settings.armorLootTable.heavyArmorLootTable.STEEL);
        public ItemMaterial DWARVEN = new("Dwarven", Program.Settings.armorLootTable.heavyArmorLootTable.DWARVEN);
        public ItemMaterial BONEMOLD = new("Bonemold", Program.Settings.armorLootTable.heavyArmorLootTable.BONEMOLD, LootRQ.DLC2);
        public ItemMaterial CHITIN_HEAVY = new("ChitinHeavy", Program.Settings.armorLootTable.heavyArmorLootTable.CHITIN_HEAVY, LootRQ.DLC2);
        public ItemMaterial ORCISH = new("Orcish", Program.Settings.armorLootTable.heavyArmorLootTable.ORCISH);
        public ItemMaterial STEELPLATE = new("SteelPlate", Program.Settings.armorLootTable.heavyArmorLootTable.STEELPLATE);
        public ItemMaterial NORDIC = new("Nordic", Program.Settings.armorLootTable.heavyArmorLootTable.NORDIC, LootRQ.DLC2);
        public ItemMaterial EBONY = new("Ebony", Program.Settings.armorLootTable.heavyArmorLootTable.EBONY);
        public ItemMaterial STALHRIM_HEAVY = new("StalhrimHeavy", Program.Settings.armorLootTable.heavyArmorLootTable.STALHRIM_HEAVY, LootRQ.Rare, LootRQ.DLC2);
        public ItemMaterial DRAGON_HEAVY = new("DragonHeavy", Program.Settings.armorLootTable.heavyArmorLootTable.DRAGON_HEAVY, LootRQ.Rare);
        public ItemMaterial DAEDRIC = new("Daedric", Program.Settings.armorLootTable.heavyArmorLootTable.DAEDRIC, LootRQ.Rare);
        public ItemMaterial ULTIMATE_HEAVY = new("Ultimate", Program.Settings.armorLootTable.heavyArmorLootTable.ULTIMATE, LootRQ.Rare);


        public ItemMaterial HIDE = new("Hide", Program.Settings.armorLootTable.LightArmorLootTable.HIDE);
        public ItemMaterial LEATHER = new("Leather", Program.Settings.armorLootTable.LightArmorLootTable.LEATHER);
        public ItemMaterial ELVEN = new("Elven", Program.Settings.armorLootTable.LightArmorLootTable.ELVEN);
        public ItemMaterial ELVEN_LIGHT = new("ElvenLight", Program.Settings.armorLootTable.LightArmorLootTable.ELVEN_LIGHT);
        public ItemMaterial CHITIN_LIGHT = new("ChitinLight", Program.Settings.armorLootTable.LightArmorLootTable.CHITIN_LIGHT, LootRQ.DLC2);
        public ItemMaterial SCALED = new("Scaled", Program.Settings.armorLootTable.LightArmorLootTable.SCALED);
        public ItemMaterial GLASS = new("Glass", Program.Settings.armorLootTable.LightArmorLootTable.GLASS);
        public ItemMaterial STALHRIM_LIGHT = new("StalhrimLight", Program.Settings.armorLootTable.LightArmorLootTable.STALHRIM_LIGHT, LootRQ.Rare, LootRQ.DLC2);
        public ItemMaterial DRAGON_LIGHT = new("DragonLight", Program.Settings.armorLootTable.LightArmorLootTable.DRAGON_LIGHT, LootRQ.Rare);
        public ItemMaterial ULTIMATE_LIGHT = new("Ultimate", Program.Settings.armorLootTable.heavyArmorLootTable.ULTIMATE, LootRQ.Rare);


        public ItemMaterial JEWELRY = new("Jewlry", 100, 100, 0, 1);

        public ArmorConfig() {
            var regularMaterials = new List<ItemMaterial>() {
                IRON,
                STEEL,
                DWARVEN,
                BONEMOLD,
                CHITIN_HEAVY,
                ORCISH,
                STEELPLATE,
                NORDIC,
                EBONY,
                STALHRIM_HEAVY,
                DRAGON_HEAVY,
                DAEDRIC,
                HIDE,
                LEATHER,
                ELVEN,
                CHITIN_LIGHT,
                SCALED,
                GLASS,
                STALHRIM_LIGHT,
                DRAGON_LIGHT,
                ULTIMATE_HEAVY
            };

            var jewelryMaterials = new List<ItemMaterial>()
            {
                JEWELRY
            };

            var armorItemTypesHeavy = new ItemType[] {
                ItemType.HeavyHelmet,
                ItemType.HeavyCuirass,
                ItemType.HeavyGauntlets,
                ItemType.HeavyBoots,
                ItemType.HeavyShield };
            var armorItemTypesLight = new ItemType[] {
                ItemType.LightHelmet,
                ItemType.LightCuirass,
                ItemType.LightGauntlets,
                ItemType.LightBoots,
                ItemType.LightShield };
            var armorItemTypesJewelry = new ItemType[] {
                ItemType.Ring,
                ItemType.Necklace,
                ItemType.Circlet
            };

            IRON.DefaultHeavyArmor(SKY.ArmorIronHelmet, null, SKY.ArmorIronGauntlets, SKY.ArmorIronBoots, null);
            IRON.AddItem(ItemType.HeavyCuirass, SKY.ArmorIronCuirass, 3);
            IRON.AddItem(ItemType.HeavyCuirass, SKY.ArmorIronBandedCuirass, 1);
            IRON.AddItem(ItemType.HeavyShield, SKY.ArmorIronShield, 3);
            IRON.AddItem(ItemType.HeavyShield, SKY.ArmorIronBandedShield, 1);

            DRAUGR.DefaultHeavyArmor(SKY.ArmorDraugrHelmet, SKY.ArmorDraugrCuirass, SKY.ArmorDraugrGauntlets, SKY.ArmorDraugrBoots, null);

            STEEL.AddItem(ItemType.HeavyHelmet, SKY.ArmorSteelHelmetA, 1);
            STEEL.AddItem(ItemType.HeavyHelmet, SKY.ArmorSteelHelmetB, 1);
            STEEL.AddItem(ItemType.HeavyCuirass, SKY.ArmorSteelCuirassA, 1);
            STEEL.AddItem(ItemType.HeavyCuirass, SKY.ArmorSteelCuirassB, 1);
            STEEL.AddItem(ItemType.HeavyGauntlets, SKY.ArmorSteelGauntletsA, 3);
            STEEL.AddItem(ItemType.HeavyGauntlets, SKY.ArmorSteelGauntletsB, 1);
            STEEL.AddItem(ItemType.HeavyBoots, SKY.ArmorSteelBootsA, 3);
            STEEL.AddItem(ItemType.HeavyBoots, SKY.ArmorSteelBootsB, 1);
            STEEL.AddItem(ItemType.HeavyShield, SKY.ArmorSteelShield, 1);

            DWARVEN.DefaultHeavyArmor(SKY.ArmorDwarvenHelmet, SKY.ArmorDwarvenCuirass, SKY.ArmorDwarvenGauntlets, SKY.ArmorDwarvenBoots, SKY.ArmorDwarvenShield);

            BONEMOLD.DefaultHeavyArmor(DB.DLC2ArmorBonemoldHelmet, null, DB.DLC2ArmorBonemoldGauntlets, DB.DLC2ArmorBonemoldBoots, DB.DLC2ArmorBonemoldShield);
            BONEMOLD.AddItem(ItemType.HeavyCuirass, DB.DLC2ArmorBonemoldCuirassVariant01);
            BONEMOLD.AddItem(ItemType.HeavyCuirass, DB.DLC2ArmorBonemoldCuirassVariant02);

            CHITIN_HEAVY.DefaultHeavyArmor(DB.DLC2ArmorChitinHeavyHelmet, DB.DLC2ArmorChitinHeavyCuirass, DB.DLC2ArmorChitinHeavyGauntlets, DB.DLC2ArmorChitinHeavyBoots, null);
            ORCISH.DefaultHeavyArmor(SKY.ArmorOrcishHelmet, SKY.ArmorOrcishCuirass, SKY.ArmorOrcishGauntlets, SKY.ArmorOrcishBoots, SKY.ArmorOrcishShield);
            STEELPLATE.DefaultHeavyArmor(SKY.ArmorSteelPlateHelmet, SKY.ArmorSteelPlateCuirass, SKY.ArmorSteelPlateGauntlets, SKY.ArmorSteelPlateBoots, null);
            NORDIC.DefaultHeavyArmor(DB.DLC2ArmorNordicHeavyHelmet, DB.DLC2ArmorNordicHeavyCuirass, DB.DLC2ArmorNordicHeavyGauntlets, DB.DLC2ArmorNordicHeavyBoots, DB.DLC2ArmorNordicShield);
            EBONY.DefaultHeavyArmor(SKY.ArmorEbonyHelmet, SKY.ArmorEbonyCuirass, SKY.ArmorEbonyGauntlets, SKY.ArmorEbonyBoots, SKY.ArmorEbonyShield);
            STALHRIM_HEAVY.DefaultHeavyArmor(DB.DLC2ArmorStalhrimHeavyHelmet, DB.DLC2ArmorStalhrimHeavyCuirass, DB.DLC2ArmorStalhrimHeavyGauntlets, DB.DLC2ArmorStalhrimHeavyBoots, null);
            DRAGON_HEAVY.DefaultHeavyArmor(SKY.ArmorDragonplateHelmet, SKY.ArmorDragonplateCuirass, SKY.ArmorDragonplateGauntlets, SKY.ArmorDragonplateBoots, SKY.ArmorDragonplateShield);
            DAEDRIC.DefaultHeavyArmor(SKY.ArmorDaedricHelmet, SKY.ArmorDaedricCuirass, SKY.ArmorDaedricGauntlets, SKY.ArmorDaedricBoots, SKY.ArmorDaedricShield);


            HIDE.DefaultLightArmor(SKY.ArmorHideHelmet, null, SKY.ArmorHideGauntlets, SKY.ArmorHideBoots, SKY.ArmorHideShield);
            HIDE.AddItem(ItemType.LightCuirass, SKY.ArmorHideCuirass, 3);
            HIDE.AddItem(ItemType.LightCuirass, SKY.ArmorStuddedCuirass, 1);

            LEATHER.DefaultLightArmor(SKY.ArmorLeatherHelmet, SKY.ArmorLeatherCuirass, SKY.ArmorLeatherGauntlets, SKY.ArmorLeatherBoots, null);

            ELVEN_LIGHT.DefaultLightArmor(SKY.ArmorElvenLightHelmet, SKY.ArmorElvenLightCuirass, SKY.ArmorElvenLightGauntlets, SKY.ArmorElvenLightBoots, SKY.ArmorElvenShield);
            ELVEN.DefaultLightArmor(SKY.ArmorElvenHelmet, null, SKY.ArmorElvenGauntlets, SKY.ArmorElvenBoots, SKY.ArmorElvenShield);
            ELVEN.AddItem(ItemType.LightCuirass, SKY.ArmorElvenCuirass, 3);
            ELVEN.AddItem(ItemType.LightCuirass, SKY.ArmorElvenGildedCuirass, 1);

            CHITIN_LIGHT.DefaultLightArmor(DB.DLC2ArmorChitinLightHelmet, null, DB.DLC2ArmorChitinLightCuirass, DB.DLC2ArmorChitinLightBoots, DB.DLC2ArmorChitinShield);

            SCALED.DefaultLightArmor(SKY.ArmorScaledHelmet, null, SKY.ArmorScaledGauntlets, SKY.ArmorScaledBoots, null);
            SCALED.AddItem(ItemType.LightCuirass, SKY.ArmorScaledCuirass, 1);
            SCALED.AddItem(ItemType.LightCuirass, SKY.ArmorScaledCuirassB, 1);

            GLASS.DefaultLightArmor(SKY.ArmorGlassHelmet, SKY.ArmorGlassCuirass, SKY.ArmorGlassGauntlets, SKY.ArmorGlassBoots, SKY.ArmorGlassShield);

            STALHRIM_LIGHT.DefaultLightArmor(DB.DLC2ArmorStalhrimLightHelmet, DB.DLC2ArmorStalhrimLightCuirass, DB.DLC2ArmorStalhrimLightGauntlets, DB.DLC2ArmorStalhrimLightBoots, DB.DLC2ArmorStalhrimShield);
            DRAGON_LIGHT.DefaultLightArmor(SKY.ArmorDragonscaleHelmet, SKY.ArmorDragonscaleCuirass, SKY.ArmorDragonscaleGauntlets, SKY.ArmorDragonscaleBoots, SKY.ArmorDragonscaleShield);


            JEWELRY.AddItem(ItemType.Ring, SKY.JewelryRingSilver, SKY.JewelryRingSilverAmethyst, SKY.JewelryRingSilverGarnet, SKY.JewelryRingSilverRuby);
            JEWELRY.AddItem(ItemType.Ring, SKY.JewelryRingGold, SKY.JewelryRingGoldDiamond, SKY.JewelryRingGoldEmerald, SKY.JewelryRingGoldSapphire);

            JEWELRY.AddItem(ItemType.Necklace, SKY.JewelryNecklaceSilver, SKY.JewelryNecklaceSilverEmerald, SKY.JewelryNecklaceSilverGems, SKY.JewelryNecklaceSilverSapphire);
            JEWELRY.AddItem(ItemType.Necklace, SKY.JewelryNecklaceGold, SKY.JewelryNecklaceGoldDiamond, SKY.JewelryNecklaceGoldGems, SKY.JewelryNecklaceGoldRuby);

            JEWELRY.AddItem(ItemType.Circlet, SKY.ClothesCirclet01, SKY.ClothesCirclet02, SKY.ClothesCirclet03, SKY.ClothesCirclet04, SKY.ClothesCirclet05);
            JEWELRY.AddItem(ItemType.Circlet, SKY.ClothesCirclet06, SKY.ClothesCirclet07, SKY.ClothesCirclet08, SKY.ClothesCirclet09, SKY.ClothesCirclet10);


            // Find enchantments
            Enchanter.Reset(Program.Settings.apparel.doubleEnchantmentChance);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyHelmet, SKY.ArmorIronHelmet, SKYL.SublistEnchArmorIronHelmet01, 1);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyHelmet, SKY.ArmorIronHelmet, SKYL.SublistEnchArmorIronHelmet02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyHelmet, SKY.ArmorDwarvenHelmet, SKYL.SublistEnchArmorDwarvenHelmet02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyHelmet, SKY.ArmorIronHelmet, SKYL.SublistEnchArmorIronHelmet03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyHelmet, SKY.ArmorDwarvenHelmet, SKYL.SublistEnchArmorDwarvenHelmet03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyHelmet, SKY.ArmorOrcishHelmet, SKYL.SublistEnchArmorOrcishHelmet03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyHelmet, SKY.ArmorDwarvenHelmet, SKYL.SublistEnchArmorDwarvenHelmet04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyHelmet, SKY.ArmorOrcishHelmet, SKYL.SublistEnchArmorOrcishHelmet04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyHelmet, SKY.ArmorEbonyHelmet, SKYL.SublistEnchArmorEbonyHelmet04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyHelmet, SKY.ArmorDaedricHelmet, SKYL.SublistEnchArmorDaedricHelmet04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyHelmet, SKY.ArmorOrcishHelmet, SKYL.SublistEnchArmorOrcishHelmet05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyHelmet, SKY.ArmorEbonyHelmet, SKYL.SublistEnchArmorEbonyHelmet05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyHelmet, SKY.ArmorDaedricHelmet, SKYL.SublistEnchArmorDaedricHelmet05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyHelmet, SKY.ArmorDaedricHelmet, SKYL.SublistEnchArmorDaedricHelmet06, 6);

            Enchanter.RegisterArmorEnchantments(ItemType.HeavyCuirass, SKY.ArmorIronCuirass, SKYL.SublistEnchArmorIronCuirass01, 1);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyCuirass, SKY.ArmorIronCuirass, SKYL.SublistEnchArmorIronCuirass02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyCuirass, SKY.ArmorDwarvenCuirass, SKYL.SublistEnchArmorDwarvenCuirass02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyCuirass, SKY.ArmorIronCuirass, SKYL.SublistEnchArmorIronCuirass03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyCuirass, SKY.ArmorDwarvenCuirass, SKYL.SublistEnchArmorDwarvenCuirass03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyCuirass, SKY.ArmorOrcishCuirass, SKYL.SublistEnchArmorOrcishCuirass03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyCuirass, SKY.ArmorDwarvenCuirass, SKYL.SublistEnchArmorDwarvenCuirass04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyCuirass, SKY.ArmorOrcishCuirass, SKYL.SublistEnchArmorOrcishCuirass04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyCuirass, SKY.ArmorEbonyCuirass, SKYL.SublistEnchArmorEbonyCuirass04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyCuirass, SKY.ArmorDaedricCuirass, SKYL.SublistEnchArmorDaedricCuirass04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyCuirass, SKY.ArmorOrcishCuirass, SKYL.SublistEnchArmorOrcishCuirass05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyCuirass, SKY.ArmorEbonyCuirass, SKYL.SublistEnchArmorEbonyCuirass05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyCuirass, SKY.ArmorDaedricCuirass, SKYL.SublistEnchArmorDaedricCuirass05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyCuirass, SKY.ArmorDaedricCuirass, SKYL.SublistEnchArmorDaedricCuirass06, 6);

            Enchanter.RegisterArmorEnchantments(ItemType.HeavyGauntlets, SKY.ArmorIronGauntlets, SKYL.SublistEnchArmorIronGauntlets01, 1);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyGauntlets, SKY.ArmorIronGauntlets, SKYL.SublistEnchArmorIronGauntlets02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyGauntlets, SKY.ArmorDwarvenGauntlets, SKYL.SublistEnchArmorDwarvenGauntlets02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyGauntlets, SKY.ArmorIronGauntlets, SKYL.SublistEnchArmorIronGauntlets03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyGauntlets, SKY.ArmorDwarvenGauntlets, SKYL.SublistEnchArmorDwarvenGauntlets03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyGauntlets, SKY.ArmorOrcishGauntlets, SKYL.SublistEnchArmorOrcishGauntlets03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyGauntlets, SKY.ArmorDwarvenGauntlets, SKYL.SublistEnchArmorDwarvenGauntlets04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyGauntlets, SKY.ArmorOrcishGauntlets, SKYL.SublistEnchArmorOrcishGauntlets04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyGauntlets, SKY.ArmorEbonyGauntlets, SKYL.SublistEnchArmorEbonyGauntlets04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyGauntlets, SKY.ArmorDaedricGauntlets, SKYL.SublistEnchARmorDaedricGauntlets04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyGauntlets, SKY.ArmorOrcishGauntlets, SKYL.SublistEnchArmorOrcishGauntlets05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyGauntlets, SKY.ArmorEbonyGauntlets, SKYL.SublistEnchArmorEbonyGauntlets05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyGauntlets, SKY.ArmorDaedricGauntlets, SKYL.SublistEnchARmorDaedricGauntlets05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyGauntlets, SKY.ArmorDaedricGauntlets, SKYL.SublistEnchARmorDaedricGauntlets06, 6);

            Enchanter.RegisterArmorEnchantments(ItemType.HeavyBoots, SKY.ArmorIronBoots, SKYL.SublistEnchArmorIronBoots01, 1);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyBoots, SKY.ArmorIronBoots, SKYL.SublistEnchArmorIronBoots02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyBoots, SKY.ArmorDwarvenBoots, SKYL.SublistEnchArmorDwarvenBoots02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyBoots, SKY.ArmorIronBoots, SKYL.SublistEnchArmorIronBoots03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyBoots, SKY.ArmorDwarvenBoots, SKYL.SublistEnchArmorDwarvenBoots03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyBoots, SKY.ArmorOrcishBoots, SKYL.SublistEnchArmorOrcishBoots03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyBoots, SKY.ArmorDwarvenBoots, SKYL.SublistEnchArmorDwarvenBoots04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyBoots, SKY.ArmorOrcishBoots, SKYL.SublistEnchArmorOrcishBoots04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyBoots, SKY.ArmorEbonyBoots, SKYL.SublistEnchArmorEbonyBoots04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyBoots, SKY.ArmorDaedricBoots, SKYL.SublistEnchArmorDaedricBoots04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyBoots, SKY.ArmorOrcishBoots, SKYL.SublistEnchArmorOrcishBoots05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyBoots, SKY.ArmorEbonyBoots, SKYL.SublistEnchArmorEbonyBoots05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyBoots, SKY.ArmorDaedricBoots, SKYL.SublistEnchArmorDaedricBoots05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyBoots, SKY.ArmorDaedricBoots, SKYL.SublistEnchArmorDaedricBoots06, 6);

            Enchanter.RegisterArmorEnchantments(ItemType.HeavyShield, SKY.ArmorIronShield, SKYL.SublistEnchArmorIronShield01, 1);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyShield, SKY.ArmorIronShield, SKYL.SublistEnchArmorIronShield02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyShield, SKY.ArmorDwarvenShield, SKYL.SublistEnchArmorDwarvenShield02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyShield, SKY.ArmorIronShield, SKYL.SublistEnchArmorIronShield03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyShield, SKY.ArmorDwarvenShield, SKYL.SublistEnchArmorDwarvenShield03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyShield, SKY.ArmorOrcishShield, SKYL.SublistEnchArmorOrcishShield03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyShield, SKY.ArmorDwarvenShield, SKYL.SublistEnchArmorDwarvenShield04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyShield, SKY.ArmorOrcishShield, SKYL.SublistEnchArmorOrcishShield04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyShield, SKY.ArmorEbonyShield, SKYL.SublistEnchArmorEbonyShield04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyShield, SKY.ArmorDaedricShield, SKYL.SublistEnchArmorDaedricShield04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyShield, SKY.ArmorOrcishShield, SKYL.SublistEnchArmorOrcishShield05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyShield, SKY.ArmorEbonyShield, SKYL.SublistEnchArmorEbonyShield05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyShield, SKY.ArmorDaedricShield, SKYL.SublistEnchArmorDaedricShield05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.HeavyShield, SKY.ArmorDaedricShield, SKYL.SublistEnchArmorDaedricShield06, 6);

            Enchanter.RegisterArmorEnchantments(ItemType.LightHelmet, SKY.ArmorHideHelmet, SKYL.SublistEnchArmorHideHelmet01, 1);
            Enchanter.RegisterArmorEnchantments(ItemType.LightHelmet, SKY.ArmorHideHelmet, SKYL.SublistEnchArmorHideHelmet02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.LightHelmet, SKY.ArmorElvenHelmet, SKYL.SublistEnchArmorElvenHelmet02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.LightHelmet, SKY.ArmorHideHelmet, SKYL.SublistEnchArmorHideHelmet03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.LightHelmet, SKY.ArmorElvenHelmet, SKYL.SublistEnchArmorElvenHelmet03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.LightHelmet, SKY.ArmorScaledHelmet, SKYL.SublistEnchArmorScaledHelmet03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.LightHelmet, SKY.ArmorElvenHelmet, SKYL.SublistEnchArmorElvenHelmet04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.LightHelmet, SKY.ArmorScaledHelmet, SKYL.SublistEnchArmorScaledHelmet04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.LightHelmet, SKY.ArmorGlassHelmet, SKYL.SublistEnchArmorGlassHelmet04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.LightHelmet, SKY.ArmorDragonscaleHelmet, SKYL.SublistEnchArmorDragonscaleHelmet04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.LightHelmet, SKY.ArmorGlassHelmet, SKYL.SublistEnchArmorGlassHelmet05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.LightHelmet, SKY.ArmorDragonscaleHelmet, SKYL.SublistEnchArmorDragonscaleHelmet05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.LightHelmet, SKY.ArmorDragonscaleHelmet, SKYL.SublistEnchArmorDragonscaleHelmet06, 6);

            Enchanter.RegisterArmorEnchantments(ItemType.LightCuirass, SKY.ArmorHideCuirass, SKYL.SublistEnchArmorHideCuirass01, 1);
            Enchanter.RegisterArmorEnchantments(ItemType.LightCuirass, SKY.ArmorHideCuirass, SKYL.SublistEnchArmorHideCuirass02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.LightCuirass, SKY.ArmorElvenCuirass, SKYL.SublistEnchArmorElvenCuirass02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.LightCuirass, SKY.ArmorHideCuirass, SKYL.SublistEnchArmorHideCuirass03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.LightCuirass, SKY.ArmorElvenCuirass, SKYL.SublistEnchArmorElvenCuirass03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.LightCuirass, SKY.ArmorScaledCuirass, SKYL.SublistEnchArmorScaledCuirass03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.LightCuirass, SKY.ArmorElvenCuirass, SKYL.SublistEnchArmorElvenCuirass04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.LightCuirass, SKY.ArmorScaledCuirass, SKYL.SublistEnchArmorScaledCuirass04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.LightCuirass, SKY.ArmorGlassCuirass, SKYL.SublistEnchArmorGlassCuirass04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.LightCuirass, SKY.ArmorDragonscaleCuirass, SKYL.SublistEnchArmorDragonscaleCuirass04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.LightCuirass, SKY.ArmorGlassCuirass, SKYL.SublistEnchArmorGlassCuirass05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.LightCuirass, SKY.ArmorDragonscaleCuirass, SKYL.SublistEnchArmorDragonscaleCuirass05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.LightCuirass, SKY.ArmorDragonscaleCuirass, SKYL.SublistEnchArmorDragonscaleCuirass06, 6);

            Enchanter.RegisterArmorEnchantments(ItemType.LightGauntlets, SKY.ArmorHideGauntlets, SKYL.SublistEnchArmorHideGauntlets01, 1);
            Enchanter.RegisterArmorEnchantments(ItemType.LightGauntlets, SKY.ArmorHideGauntlets, SKYL.SublistEnchArmorHideGauntlets02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.LightGauntlets, SKY.ArmorElvenGauntlets, SKYL.SublistEnchArmorElvenGauntlets02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.LightGauntlets, SKY.ArmorHideGauntlets, SKYL.SublistEnchArmorHideGauntlets03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.LightGauntlets, SKY.ArmorElvenGauntlets, SKYL.SublistEnchArmorElvenGauntlets03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.LightGauntlets, SKY.ArmorScaledGauntlets, SKYL.SublistEnchArmorScaledGauntlets03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.LightGauntlets, SKY.ArmorElvenGauntlets, SKYL.SublistEnchArmorElvenGauntlets04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.LightGauntlets, SKY.ArmorScaledGauntlets, SKYL.SublistEnchArmorScaledGauntlets04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.LightGauntlets, SKY.ArmorGlassGauntlets, SKYL.SublistEnchArmorGlassGauntlets04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.LightGauntlets, SKY.ArmorDragonscaleGauntlets, SKYL.SublistEnchArmorDragonscaleGauntlets04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.LightGauntlets, SKY.ArmorGlassGauntlets, SKYL.SublistEnchArmorGlassGauntlets05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.LightGauntlets, SKY.ArmorDragonscaleGauntlets, SKYL.SublistEnchArmorDragonscaleGauntlets05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.LightGauntlets, SKY.ArmorDragonscaleGauntlets, SKYL.SublistEnchArmorDragonscaleGauntlets06, 6);

            Enchanter.RegisterArmorEnchantments(ItemType.LightBoots, SKY.ArmorHideBoots, SKYL.SublistEnchArmorHideBoots01, 1);
            Enchanter.RegisterArmorEnchantments(ItemType.LightBoots, SKY.ArmorHideBoots, SKYL.SublistEnchArmorHideBoots02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.LightBoots, SKY.ArmorElvenBoots, SKYL.SublistEnchArmorElvenBoots02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.LightBoots, SKY.ArmorHideBoots, SKYL.SublistEnchArmorHideBoots03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.LightBoots, SKY.ArmorElvenBoots, SKYL.SublistEnchArmorElvenBoots03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.LightBoots, SKY.ArmorScaledBoots, SKYL.SublistEnchArmorScaledBoots03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.LightBoots, SKY.ArmorElvenBoots, SKYL.SublistEnchArmorElvenBoots04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.LightBoots, SKY.ArmorScaledBoots, SKYL.SublistEnchArmorScaledBoots04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.LightBoots, SKY.ArmorGlassBoots, SKYL.SublistEnchArmorGlassBoots04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.LightBoots, SKY.ArmorDragonscaleBoots, SKYL.SublistEnchArmorDragonscaleBoots04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.LightBoots, SKY.ArmorGlassBoots, SKYL.SublistEnchArmorGlassBoots05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.LightBoots, SKY.ArmorDragonscaleBoots, SKYL.SublistEnchArmorDragonscaleBoots05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.LightBoots, SKY.ArmorDragonscaleBoots, SKYL.SublistEnchArmorDragonscaleBoots06, 6);

            Enchanter.RegisterArmorEnchantments(ItemType.LightShield, SKY.ArmorHideShield, SKYL.SublistEnchArmorHideShield01, 1);
            Enchanter.RegisterArmorEnchantments(ItemType.LightShield, SKY.ArmorHideShield, SKYL.SublistEnchArmorHideShield02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.LightShield, SKY.ArmorElvenShield, SKYL.SublistEnchArmorElvenShield02, 2);
            Enchanter.RegisterArmorEnchantments(ItemType.LightShield, SKY.ArmorHideShield, SKYL.SublistEnchArmorHideShield03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.LightShield, SKY.ArmorElvenShield, SKYL.SublistEnchArmorElvenShield03, 3);
            Enchanter.RegisterArmorEnchantments(ItemType.LightShield, SKY.ArmorElvenShield, SKYL.SublistEnchArmorElvenShield04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.LightShield, SKY.ArmorGlassShield, SKYL.SublistEnchArmorGlassShield04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.LightShield, SKY.ArmorDragonscaleShield, SKYL.SublistEnchArmorDragonscaleShield04, 4);
            Enchanter.RegisterArmorEnchantments(ItemType.LightShield, SKY.ArmorGlassShield, SKYL.SublistEnchArmorGlassShield05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.LightShield, SKY.ArmorDragonscaleShield, SKYL.SublistEnchArmorDragonscaleShield05, 5);
            Enchanter.RegisterArmorEnchantments(ItemType.LightShield, SKY.ArmorDragonscaleShield, SKYL.SublistEnchArmorDragonscaleShield06, 6);

            Enchanter.RegisterJewelryEnchantments(ItemType.Necklace, Skyrim.LeveledItem.LItemEnchNecklaceAll, "Necklace", "Amulet");
            Enchanter.RegisterJewelryEnchantments(ItemType.Ring, Skyrim.LeveledItem.LItemEnchRingAll, "Ring");
            Enchanter.RegisterJewelryEnchantments(ItemType.Circlet, Skyrim.LeveledItem.LItemEnchCircletAll, "Circlet");

            var itemTypeHierarchy = new List<List<ItemType>>() {
                armorItemTypesHeavy.ToList(),
                armorItemTypesLight.ToList(),
                armorItemTypesJewelry.ToList()
            };

            Enchanter.PostProcessEnchantments(itemTypeHierarchy);

            RecipeParser.Parse(armorItemTypesHeavy, regularMaterials, ULTIMATE_HEAVY, true, false);
            RecipeParser.Parse(armorItemTypesLight, regularMaterials, ULTIMATE_LIGHT, true, false);
            RecipeParser.Parse(armorItemTypesJewelry, jewelryMaterials, JEWELRY, true, false);

            var enchRings = LeveledList.CreateListEnchanted(ItemType.Ring, "EnchRings", LeveledList.FACTOR_BEST, jewelryMaterials).ToLink();
            var enchNecklaces = LeveledList.CreateListEnchanted(ItemType.Necklace, "EnchNecklaces", LeveledList.FACTOR_BEST, jewelryMaterials).ToLink();
            var enchCirclets = LeveledList.CreateListEnchanted(ItemType.Circlet, "EnchCirclets", LeveledList.FACTOR_BEST, jewelryMaterials).ToLink();
            LeveledList.LinkList(SKYL.LItemEnchRingAll25, enchRings);
            LeveledList.LinkList(SKYL.LItemEnchRingAll75, enchRings);
            LeveledList.LinkList(SKYL.LItemEnchRingAll, enchRings);
            LeveledList.LinkList(SKYL.LItemEnchNecklaceAll25, enchNecklaces);
            LeveledList.LinkList(SKYL.LItemEnchNecklaceAll, enchNecklaces);
            LeveledList.LinkList(SKYL.LItemEnchCircletAll25, enchCirclets);
            LeveledList.LinkList(SKYL.LItemEnchCircletAll75, enchCirclets);
            LeveledList.LinkList(SKYL.LItemEnchCircletAll, enchCirclets);
            return;

            // Best = 4
            // Special/Reward = 3
            // Blacksmith/Town/Normal = 2

            // Light

            LeveledList.LinkList(SKYL.LItemArmorHelmetLightSpecial, LeveledList.FACTOR_RARE, ItemType.LightHelmet, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorCuirassLightSpecial, LeveledList.FACTOR_RARE, ItemType.LightCuirass, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorGauntletsLightSpecial, LeveledList.FACTOR_RARE, ItemType.LightGauntlets, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorBootsLightSpecial, LeveledList.FACTOR_RARE, ItemType.LightBoots, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorShieldLightSpecial, LeveledList.FACTOR_RARE, ItemType.LightShield, regularMaterials, LootRQ.Rare);

            LeveledList.LinkList(SKYL.LItemArmorHelmetLightTown, LeveledList.FACTOR_JUNK, ItemType.LightHelmet, regularMaterials);
            LeveledList.LinkList(SKYL.LItemArmorCuirassLightTown, LeveledList.FACTOR_JUNK, ItemType.LightCuirass, regularMaterials);
            LeveledList.LinkList(SKYL.LItemArmorGauntletsLightTown, LeveledList.FACTOR_JUNK, ItemType.LightGauntlets, regularMaterials);
            LeveledList.LinkList(SKYL.LitemArmorBootsLightTown, LeveledList.FACTOR_JUNK, ItemType.LightBoots, regularMaterials);
            LeveledList.LinkList(SKYL.LItemArmorShieldLightTown, LeveledList.FACTOR_JUNK, ItemType.LightShield, regularMaterials);

            LeveledList.LinkList(SKYL.LItemArmorHelmetLightReward, LeveledList.FACTOR_RARE, ItemType.LightHelmet, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorCuirassLightReward, LeveledList.FACTOR_RARE, ItemType.LightCuirass, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorShieldLightReward, LeveledList.FACTOR_RARE, ItemType.LightShield, regularMaterials, LootRQ.Rare);

            LeveledList.LinkList(SKYL.LItemArmorHelmetLight, LeveledList.FACTOR_COMMON, ItemType.LightHelmet, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorCuirassLight, LeveledList.FACTOR_COMMON, ItemType.LightCuirass, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorGauntletsLight, LeveledList.FACTOR_COMMON, ItemType.LightGauntlets, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorBootsLight, LeveledList.FACTOR_COMMON, ItemType.LightBoots, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorShieldLight, LeveledList.FACTOR_COMMON, ItemType.LightShield, regularMaterials, LootRQ.Rare);

            LeveledList.LinkList(SKYL.LItemArmorHelmetLightBlacksmith, LeveledList.FACTOR_COMMON, ItemType.LightHelmet, regularMaterials);
            LeveledList.LinkList(SKYL.LItemArmorCuirassLightBlacksmith, LeveledList.FACTOR_COMMON, ItemType.LightCuirass, regularMaterials);
            LeveledList.LinkList(SKYL.LItemArmorGauntletsLightBlacksmith, LeveledList.FACTOR_COMMON, ItemType.LightGauntlets, regularMaterials);
            LeveledList.LinkList(SKYL.LitemArmorBootsLightBlacksmith, LeveledList.FACTOR_COMMON, ItemType.LightBoots, regularMaterials);
            LeveledList.LinkList(SKYL.LItemArmorShieldLightBlacksmith, LeveledList.FACTOR_COMMON, ItemType.LightShield, regularMaterials);

            LeveledList.LinkList(SKYL.LItemArmorHelmetLightBest, LeveledList.FACTOR_BEST, ItemType.LightHelmet, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorCuirassLightBest, LeveledList.FACTOR_BEST, ItemType.LightCuirass, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorGauntletsLightBest, LeveledList.FACTOR_BEST, ItemType.LightGauntlets, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorBootsLightBest, LeveledList.FACTOR_BEST, ItemType.LightBoots, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorShieldLightBest, LeveledList.FACTOR_BEST, ItemType.LightShield, regularMaterials, LootRQ.Rare);

            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorLightHelmet, LeveledList.FACTOR_COMMON, ItemType.LightHelmet, regularMaterials);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorLightCuirass, LeveledList.FACTOR_COMMON, ItemType.LightCuirass, regularMaterials);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorLightGauntlets, LeveledList.FACTOR_COMMON, ItemType.LightGauntlets, regularMaterials);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorLightBoots, LeveledList.FACTOR_COMMON, ItemType.LightBoots, regularMaterials);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorLightShield, LeveledList.FACTOR_COMMON, ItemType.LightShield, regularMaterials);

            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorLightHelmetNoDragon, LeveledList.FACTOR_COMMON, ItemType.LightHelmet, regularMaterials);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorLightCuirassNoDragon, LeveledList.FACTOR_COMMON, ItemType.LightCuirass, regularMaterials);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorLightGauntletsNoDragon, LeveledList.FACTOR_COMMON, ItemType.LightGauntlets, regularMaterials);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorLightBootsNoDragon, LeveledList.FACTOR_COMMON, ItemType.LightBoots, regularMaterials);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorLightShieldNoDragon, LeveledList.FACTOR_COMMON, ItemType.LightShield, regularMaterials);

            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorLightHelmetSpecial, LeveledList.FACTOR_RARE, ItemType.LightHelmet, regularMaterials, LootRQ.Rare);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorLightCuirassSpecial, LeveledList.FACTOR_RARE, ItemType.LightCuirass, regularMaterials, LootRQ.Rare);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorLightGauntletsSpecial, LeveledList.FACTOR_RARE, ItemType.LightGauntlets, regularMaterials, LootRQ.Rare);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorLightBootsSpecial, LeveledList.FACTOR_RARE, ItemType.LightBoots, regularMaterials, LootRQ.Rare);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorLightShieldSpecial, LeveledList.FACTOR_RARE, ItemType.LightShield, regularMaterials, LootRQ.Rare);

            // DLC2 Light

            LeveledList.LinkList(DBL.DLC2LItemArmorHelmetLight, LeveledList.FACTOR_COMMON, ItemType.LightHelmet, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkList(DBL.DLC2LItemArmorCuirassLight, LeveledList.FACTOR_COMMON, ItemType.LightCuirass, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkList(DBL.DLC2LItemArmorGauntletsLight, LeveledList.FACTOR_COMMON, ItemType.LightGauntlets, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkList(DBL.DLC2LItemArmorBootsLight, LeveledList.FACTOR_COMMON, ItemType.LightBoots, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkList(DBL.DLC2LItemArmorShieldLight, LeveledList.FACTOR_COMMON, ItemType.LightShield, regularMaterials, LootRQ.DLC2, LootRQ.Rare);

            LeveledList.LinkList(DBL.DLC2LItemArmorHelmetLightTown, LeveledList.FACTOR_JUNK, ItemType.LightHelmet, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkList(DBL.DLC2LItemArmorCuirassLightTown, LeveledList.FACTOR_JUNK, ItemType.LightCuirass, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkList(DBL.DLC2LItemArmorGauntletsLightTown, LeveledList.FACTOR_JUNK, ItemType.LightGauntlets, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkList(DBL.DLC2LitemArmorBootsLightTown, LeveledList.FACTOR_JUNK, ItemType.LightBoots, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkList(DBL.DLC2LItemArmorShieldLightTown, LeveledList.FACTOR_JUNK, ItemType.LightShield, regularMaterials, LootRQ.DLC2);

            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorLightHelmet, LeveledList.FACTOR_COMMON, ItemType.LightHelmet, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorLightCuirass, LeveledList.FACTOR_COMMON, ItemType.LightCuirass, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorLightGauntlets, LeveledList.FACTOR_COMMON, ItemType.LightGauntlets, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorLightBoots, LeveledList.FACTOR_COMMON, ItemType.LightBoots, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorLightShield, LeveledList.FACTOR_COMMON, ItemType.LightShield, regularMaterials, LootRQ.DLC2);

            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorLightHelmetNoDragon, LeveledList.FACTOR_COMMON, ItemType.LightHelmet, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorLightCuirassNoDragon, LeveledList.FACTOR_COMMON, ItemType.LightCuirass, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorLightGauntletsNoDragon, LeveledList.FACTOR_COMMON, ItemType.LightGauntlets, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorLightBootsNoDragon, LeveledList.FACTOR_COMMON, ItemType.LightBoots, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorLightShieldNoDragon, LeveledList.FACTOR_COMMON, ItemType.LightShield, regularMaterials, LootRQ.DLC2);

            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorLightHelmetSpecial, LeveledList.FACTOR_RARE, ItemType.LightHelmet, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorLightCuirassSpecial, LeveledList.FACTOR_RARE, ItemType.LightCuirass, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorLightGauntletsSpecial, LeveledList.FACTOR_RARE, ItemType.LightGauntlets, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorLightBootsSpecial, LeveledList.FACTOR_RARE, ItemType.LightBoots, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorLightShieldSpecial, LeveledList.FACTOR_RARE, ItemType.LightShield, regularMaterials, LootRQ.DLC2, LootRQ.Rare);


            // Heavy

            LeveledList.LinkList(SKYL.LItemArmorHelmetHeavySpecial, LeveledList.FACTOR_RARE, ItemType.HeavyHelmet, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorCuirassHeavySpecial, LeveledList.FACTOR_RARE, ItemType.HeavyCuirass, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorGauntletsHeavySpecial, LeveledList.FACTOR_RARE, ItemType.HeavyGauntlets, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorBootsHeavySpecial, LeveledList.FACTOR_RARE, ItemType.HeavyBoots, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorShieldHeavySpecial, LeveledList.FACTOR_RARE, ItemType.HeavyShield, regularMaterials, LootRQ.Rare);

            LeveledList.LinkList(SKYL.LItemArmorHelmetHeavyTown, LeveledList.FACTOR_JUNK, ItemType.HeavyHelmet, regularMaterials);
            LeveledList.LinkList(SKYL.LItemArmorCuirassHeavyTown, LeveledList.FACTOR_JUNK, ItemType.HeavyCuirass, regularMaterials);
            LeveledList.LinkList(SKYL.LItemArmorGauntletsHeavyTown, LeveledList.FACTOR_JUNK, ItemType.HeavyGauntlets, regularMaterials);
            LeveledList.LinkList(SKYL.LItemArmorBootsHeavyTown, LeveledList.FACTOR_JUNK, ItemType.HeavyBoots, regularMaterials);
            LeveledList.LinkList(SKYL.LitemArmorShieldHeavyTown, LeveledList.FACTOR_JUNK, ItemType.HeavyShield, regularMaterials);

            LeveledList.LinkList(SKYL.LItemArmorHelmetHeavyReward, LeveledList.FACTOR_RARE, ItemType.HeavyHelmet, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorCuirassHeavyReward, LeveledList.FACTOR_RARE, ItemType.HeavyCuirass, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorShieldHeavyReward, LeveledList.FACTOR_RARE, ItemType.HeavyShield, regularMaterials, LootRQ.Rare);

            LeveledList.LinkList(SKYL.LItemArmorHelmetHeavy, LeveledList.FACTOR_COMMON, ItemType.HeavyHelmet, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorCuirassHeavy, LeveledList.FACTOR_COMMON, ItemType.HeavyCuirass, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorGauntletsHeavy, LeveledList.FACTOR_COMMON, ItemType.HeavyGauntlets, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorBootsHeavy, LeveledList.FACTOR_COMMON, ItemType.HeavyBoots, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorShieldHeavy, LeveledList.FACTOR_COMMON, ItemType.HeavyShield, regularMaterials, LootRQ.Rare);

            LeveledList.LinkList(SKYL.LItemArmorHelmetHeavyBlacksmith, LeveledList.FACTOR_COMMON, ItemType.HeavyHelmet, regularMaterials);
            LeveledList.LinkList(SKYL.LItemArmorCuirassHeavyBlacksmith, LeveledList.FACTOR_COMMON, ItemType.HeavyCuirass, regularMaterials);
            LeveledList.LinkList(SKYL.LItemArmorGauntletsHeavyBlacksmith, LeveledList.FACTOR_COMMON, ItemType.HeavyGauntlets, regularMaterials);
            LeveledList.LinkList(SKYL.LItemArmorBootsHeavyBlacksmith, LeveledList.FACTOR_COMMON, ItemType.HeavyBoots, regularMaterials);
            LeveledList.LinkList(SKYL.LitemArmorShieldHeavyBlacksmith, LeveledList.FACTOR_COMMON, ItemType.HeavyShield, regularMaterials);

            LeveledList.LinkList(SKYL.LItemArmorHelmetHeavyBest, LeveledList.FACTOR_BEST, ItemType.HeavyHelmet, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorCuirassHeavyBest, LeveledList.FACTOR_BEST, ItemType.HeavyCuirass, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorGauntletsHeavyBest, LeveledList.FACTOR_BEST, ItemType.HeavyGauntlets, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorBootsHeavyBest, LeveledList.FACTOR_BEST, ItemType.HeavyBoots, regularMaterials, LootRQ.Rare);
            LeveledList.LinkList(SKYL.LItemArmorShieldHeavyBest, LeveledList.FACTOR_BEST, ItemType.HeavyShield, regularMaterials, LootRQ.Rare);

            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorHeavyHelmet, LeveledList.FACTOR_COMMON, ItemType.HeavyHelmet, regularMaterials);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorHeavyCuirass, LeveledList.FACTOR_COMMON, ItemType.HeavyCuirass, regularMaterials);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorHeavyGauntlets, LeveledList.FACTOR_COMMON, ItemType.HeavyGauntlets, regularMaterials);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorHeavyBoots, LeveledList.FACTOR_COMMON, ItemType.HeavyBoots, regularMaterials);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorHeavyShield, LeveledList.FACTOR_COMMON, ItemType.HeavyShield, regularMaterials);

            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorHeavyHelmetNoDragon, LeveledList.FACTOR_COMMON, ItemType.HeavyHelmet, regularMaterials);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorHeavyCuirassNoDragon, LeveledList.FACTOR_COMMON, ItemType.HeavyCuirass, regularMaterials);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorHeavyGauntletsNoDragon, LeveledList.FACTOR_COMMON, ItemType.HeavyGauntlets, regularMaterials);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorHeavyBootsNoDragon, LeveledList.FACTOR_COMMON, ItemType.HeavyBoots, regularMaterials);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorHeavyShieldNoDragon, LeveledList.FACTOR_COMMON, ItemType.HeavyShield, regularMaterials);

            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorHeavyHelmetSpecial, LeveledList.FACTOR_RARE, ItemType.HeavyHelmet, regularMaterials, LootRQ.Rare);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorHeavyCuirassSpecial, LeveledList.FACTOR_RARE, ItemType.HeavyCuirass, regularMaterials, LootRQ.Rare);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorHeavyGauntletsSpecial, LeveledList.FACTOR_RARE, ItemType.HeavyGauntlets, regularMaterials, LootRQ.Rare);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorHeavyBootsSpecial, LeveledList.FACTOR_RARE, ItemType.HeavyBoots, regularMaterials, LootRQ.Rare);
            LeveledList.LinkListEnchanted(SKYL.LItemEnchArmorHeavyShieldSpecial, LeveledList.FACTOR_RARE, ItemType.HeavyShield, regularMaterials, LootRQ.Rare);

            // DLC2 Heavy

            LeveledList.LinkList(DBL.DLC2LItemArmorHelmetHeavy, LeveledList.FACTOR_COMMON, ItemType.HeavyHelmet, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkList(DBL.DLC2LItemArmorCuirassHeavy, LeveledList.FACTOR_COMMON, ItemType.HeavyCuirass, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkList(DBL.DLC2LItemArmorGauntletsHeavy, LeveledList.FACTOR_COMMON, ItemType.HeavyGauntlets, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkList(DBL.DLC2LItemArmorBootsHeavy, LeveledList.FACTOR_COMMON, ItemType.HeavyBoots, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkList(DBL.DLC2LItemArmorShieldHeavy, LeveledList.FACTOR_COMMON, ItemType.HeavyShield, regularMaterials, LootRQ.DLC2, LootRQ.Rare);

            LeveledList.LinkList(DBL.DLC2LItemArmorHelmetHeavyTown, LeveledList.FACTOR_JUNK, ItemType.HeavyHelmet, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkList(DBL.DLC2LItemArmorCuirassHeavyTown, LeveledList.FACTOR_JUNK, ItemType.HeavyCuirass, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkList(DBL.DLC2LItemArmorGauntletsHeavyTown, LeveledList.FACTOR_JUNK, ItemType.HeavyGauntlets, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkList(DBL.DLC2LItemArmorBootsHeavyTown, LeveledList.FACTOR_JUNK, ItemType.HeavyBoots, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkList(DBL.DLC2LitemArmorShieldHeavyTown, LeveledList.FACTOR_JUNK, ItemType.HeavyShield, regularMaterials, LootRQ.DLC2);

            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorHeavyHelmet, LeveledList.FACTOR_COMMON, ItemType.HeavyHelmet, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorHeavyCuirass, LeveledList.FACTOR_COMMON, ItemType.HeavyCuirass, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorHeavyGauntlets, LeveledList.FACTOR_COMMON, ItemType.HeavyGauntlets, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorHeavyBoots, LeveledList.FACTOR_COMMON, ItemType.HeavyBoots, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorHeavyShield, LeveledList.FACTOR_COMMON, ItemType.HeavyShield, regularMaterials, LootRQ.DLC2);

            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorHeavyHelmetNoDragon, LeveledList.FACTOR_COMMON, ItemType.HeavyHelmet, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorHeavyCuirassNoDragon, LeveledList.FACTOR_COMMON, ItemType.HeavyCuirass, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorHeavyGauntletsNoDragon, LeveledList.FACTOR_COMMON, ItemType.HeavyGauntlets, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorHeavyBootsNoDragon, LeveledList.FACTOR_COMMON, ItemType.HeavyBoots, regularMaterials, LootRQ.DLC2);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorHeavyShieldNoDragon, LeveledList.FACTOR_COMMON, ItemType.HeavyShield, regularMaterials, LootRQ.DLC2);

            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorHeavyHelmetSpecial, LeveledList.FACTOR_RARE, ItemType.HeavyHelmet, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorHeavyCuirassSpecial, LeveledList.FACTOR_RARE, ItemType.HeavyCuirass, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorHeavyGauntletsSpecial, LeveledList.FACTOR_RARE, ItemType.HeavyGauntlets, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorHeavyBootsSpecial, LeveledList.FACTOR_RARE, ItemType.HeavyBoots, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkListEnchanted(DBL.DLC2LItemEnchArmorHeavyShieldSpecial, LeveledList.FACTOR_RARE, ItemType.HeavyShield, regularMaterials, LootRQ.DLC2, LootRQ.Rare);

            LeveledList.LinkList(DBL.DLC2LItemArmorHelmetHeavyBest, LeveledList.FACTOR_BEST, ItemType.HeavyHelmet, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkList(DBL.DLC2LItemArmorCuirassHeavyBest, LeveledList.FACTOR_BEST, ItemType.HeavyCuirass, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkList(DBL.DLC2LItemArmorGauntletsHeavyBest, LeveledList.FACTOR_BEST, ItemType.HeavyGauntlets, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkList(DBL.DLC2LItemArmorBootsHeavyBest, LeveledList.FACTOR_BEST, ItemType.HeavyBoots, regularMaterials, LootRQ.DLC2, LootRQ.Rare);
            LeveledList.LinkList(DBL.DLC2LItemArmorShieldHeavyBest, LeveledList.FACTOR_BEST, ItemType.HeavyShield, regularMaterials, LootRQ.DLC2, LootRQ.Rare);


            // Bandit

            LinkedList<ItemMaterial> banditArmor = new();
            banditArmor.AddLast(IRON);
            banditArmor.AddLast(STEEL);
            banditArmor.AddLast(STEELPLATE);
            banditArmor.AddLast(NORDIC);

            LeveledList.LinkList(SKYL.LItemBanditBossCuirass, LeveledList.FACTOR_JUNK, ItemType.HeavyCuirass, banditArmor);
            LeveledList.LinkList(SKYL.LItemBanditBossHelmet50, LeveledList.FACTOR_JUNK, ItemType.HeavyHelmet, banditArmor);
            LeveledList.LinkList(SKYL.LItemBanditBossBoots, LeveledList.FACTOR_JUNK, ItemType.HeavyBoots, banditArmor);
            LeveledList.LinkList(SKYL.LItemBanditBossGauntlets50, LeveledList.FACTOR_JUNK, ItemType.HeavyGauntlets, banditArmor);
            LeveledList.LinkList(SKYL.LItemBanditBossShield, LeveledList.FACTOR_JUNK, ItemType.HeavyShield, regularMaterials);

            LeveledList.LockLists(SKYL.LItemBanditBossCuirass, SKYL.LItemBanditBossHelmet50, SKYL.LItemBanditBossBoots, SKYL.LItemBanditBossGauntlets50, SKYL.LItemBanditBossShield);

            // Thalmor

            LinkedList<ItemMaterial> thalmorArmor = new();
            thalmorArmor.AddLast(ELVEN_LIGHT);
            thalmorArmor.AddLast(ELVEN);
            thalmorArmor.AddLast(GLASS);

            ELVEN_LIGHT.AddItem(ItemType.SetNoHelmet, SKYL.SublistThalmorElvenLightArmorNoHelmet);
            ELVEN_LIGHT.AddItem(ItemType.SetWithHelmet, SKYL.SublistThalmorElvenLightArmor);

            ELVEN.AddItem(ItemType.SetNoHelmet, SKYL.SublistThalmorElvenArmorNoHelmet);
            ELVEN.AddItem(ItemType.SetWithHelmet, SKYL.SublistThalmorElvenArmorWithHelmet);

            GLASS.AddItem(ItemType.SetNoHelmet, SKYL.SublistThalmorGlassArmorNoHelmet);
            GLASS.AddItem(ItemType.SetWithHelmet, SKYL.SublistThalmorGlassArmorWithHelmet);

            LeveledList.LinkList(SKYL.LItemThalmorArmorNoHelmetAll, LeveledList.FACTOR_RARE, ItemType.SetNoHelmet, thalmorArmor);
            LeveledList.LinkList(SKYL.LItemThalmorArmorWithHelmetBest, LeveledList.FACTOR_RARE, ItemType.SetWithHelmet, thalmorArmor);

            LeveledList.LinkList(SKYL.LItemThalmorShield, LeveledList.FACTOR_RARE, ItemType.LightShield, thalmorArmor);


            // Draugr / Nordic

            LinkedList<ItemMaterial> draugrArmor = new();
            draugrArmor.AddLast(DRAUGR);
            draugrArmor.AddLast(HIDE);
            draugrArmor.AddLast(LEATHER);
            draugrArmor.AddLast(IRON);
            draugrArmor.AddLast(STEEL);
            draugrArmor.AddLast(STEELPLATE);
            draugrArmor.AddLast(SCALED);
            draugrArmor.AddLast(EBONY);
            draugrArmor.AddLast(DRAGON_HEAVY);
            draugrArmor.AddLast(DRAGON_LIGHT);


            var factorDraugr = LeveledList.FACTOR_COMMON;
            var draugrHelmet = LeveledList.CreateList(ItemType.Helmet, "DraugrHelmet", factorDraugr, draugrArmor, LootRQ.Rare);
            var draugrCuirass = LeveledList.CreateList(ItemType.Cuirass, "DraugrCuirass", factorDraugr, draugrArmor, LootRQ.Rare);
            var draugrGauntlets = LeveledList.CreateList(ItemType.Gauntlets, "DraugrGauntlest", factorDraugr, draugrArmor, LootRQ.Rare);
            var draugrBoots = LeveledList.CreateList(ItemType.Boots, "DraugrBoots", factorDraugr, draugrArmor, LootRQ.Rare);
            var draugrShield = LeveledList.CreateList(ItemType.Shield, "DraugrShield", factorDraugr, draugrArmor, LootRQ.Rare);

            var draugrHelmetEnch = LeveledList.CreateListEnchanted(ItemType.Helmet, "DraugrHelmetEnch", 2, draugrArmor, LootRQ.Rare);
            var draugrCuirassEnch = LeveledList.CreateListEnchanted(ItemType.Cuirass, "DraugrCuirassEnch", 2, draugrArmor, LootRQ.Rare);
            var draugrGauntletsEnch = LeveledList.CreateListEnchanted(ItemType.Gauntlets, "DraugrGauntlestEnch", 2, draugrArmor, LootRQ.Rare);
            var draugrBootsEnch = LeveledList.CreateListEnchanted(ItemType.Boots, "DraugrBootsEnch", 2, draugrArmor, LootRQ.Rare);
            var draugrShieldEnch = LeveledList.CreateListEnchanted(ItemType.Shield, "DraugrShieldEnch", 2, draugrArmor, LootRQ.Rare);

            LeveledList.LinkList(SKYL.LootDraugrArmor10, draugrHelmet.ToLink(), draugrCuirass.ToLink(), draugrGauntlets.ToLink(), draugrBoots.ToLink(), draugrShield.ToLink());
            LeveledList.LinkList(SKYL.LootDraugrArmor100, draugrHelmet.ToLink(), draugrCuirass.ToLink(), draugrGauntlets.ToLink(), draugrBoots.ToLink(), draugrShield.ToLink());
            LeveledList.LinkList(SKYL.LootDraugrArmor25, draugrHelmet.ToLink(), draugrCuirass.ToLink(), draugrGauntlets.ToLink(), draugrBoots.ToLink(), draugrShield.ToLink());
            LeveledList.LinkList(SKYL.LootDraugrArmor50, draugrHelmet.ToLink(), draugrCuirass.ToLink(), draugrGauntlets.ToLink(), draugrBoots.ToLink(), draugrShield.ToLink());

            LeveledList.LinkList(SKYL.LootDraugrEnchArmor100, draugrHelmetEnch.ToLink(), draugrCuirassEnch.ToLink(), draugrGauntletsEnch.ToLink(), draugrBootsEnch.ToLink(), draugrShieldEnch.ToLink());
            LeveledList.LinkList(SKYL.LootDraugrEnchArmor25, draugrHelmetEnch.ToLink(), draugrCuirassEnch.ToLink(), draugrGauntletsEnch.ToLink(), draugrBootsEnch.ToLink(), draugrShieldEnch.ToLink());
            LeveledList.LinkList(SKYL.LootDraugrEnchArmor15, draugrHelmetEnch.ToLink(), draugrCuirassEnch.ToLink(), draugrGauntletsEnch.ToLink(), draugrBootsEnch.ToLink(), draugrShieldEnch.ToLink());

        }
    }
}
