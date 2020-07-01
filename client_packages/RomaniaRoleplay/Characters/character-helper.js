var cameraCharacterPreview = null;
var defaultMaleModel = 1885233650;
var defaultFemaleModel = 2627665880;


var defaultSkin = {
    Model: 1885233650,
    FirstHeadShape: 0,
    SecondHeadShape: 0,
    FirstSkinTone: 0,
    SecondSkinTone: 0,
    HeadMix: -1,
    SkinMix: -1,
    Hair: 0,
    FirstHairColor: 0,
    SecondHairColor: 0,
    Beard: 0,
    BeardColor: 0,
    Chest: 0,
    ChestColor: 0,
    Blemishes: 0,
    Ageing: 0,
    Complexion: 0,
    Sundamage: 0,
    Freckles: 0,
    EyesColor: 0,
    Eyebrows: 0,
    EyebrowsColor: 0,
    Makeup: 0,
    Blush: 0,
    BlushColor: 0,
    Lipstick: 0,
    LipstickColor: 0,
    NoseWidth: -1.0,
    NoseHeight: -1.0,
    NoseLength: -1.0,
    NoseBridge: -1.0,
    NoseTip: -1.0,
    NoseShift: -1.0,
    BrowHeight: -1.0,
    BrowWidth: -1.0,
    CheekboneHeight: -1.0,
    CheekboneWidth: -1.0,
    CheeksWidth: -1.0,
    Eyes: -1.0,
    Lips: -1.0,
    JawWidth: -1.0,
    JawHeight: -1.0,
    ChinLength: -1.0,
    ChinPosition: -1.0,
    ChinWidth: -1.0,
    ChinShape: -1.0,
    NeckWidth: -1.0,
    Clothes: {
        Torsos: 0,
        TorsosColor: 0,
        Legs: 0,
        LegsColor: 0,
        BagsAndParachutes: 0,
        BagsAndParachutesColor: 0,
        Shoes: 0,
        ShoesColor: 0,
        Accessories: 0,
        AccessoriesColor: 0,
        Undershirts: 0,
        UndershirtsColor: 0,
        BodyArmors: 0,
        BodyArmorsColor: 0,
        Decals: 0,
        DecalsColor: 0,
        Tops: 0,
        TopsColor: 0
    }
};

var showCharacterPreview = function (shouldShow) {
    if (shouldShow) {
        try {
            mp.game.ui.displayRadar(false);
            cameraCharacterPreview = mp.cameras.new("Cam", {
                x: -422.38,
                y: 1134.75,
                z: 326.674
            }, {
                x: 0,
                y: 0,
                z: 163
            }, 6);
            cameraCharacterPreview.setActive(true);
            mp.game.cam.renderScriptCams(true, true, 20000000000000000000000000, false, false);
            player.position = new mp.Vector3(-427.65, 1116.374, 326.8);
            player.heading = 343;
            setTimeout(function () {
                mp.gui.cursor.show(true, true);
            }, 10);
            setTimeout(function () {
                player.freezePosition(true);
            }, 10);
            setTimeout(function () {
                mp.game.player.setInvincible(true);
            }, 10);
            setTimeout(function () {
                activateChat(false);
            }, 1000);
        } catch (e) {
            console.log(e);
        }
    } else {
        try {
            mp.game.ui.displayRadar(true);
            activateChat(true);
            cameraCharacterPreview.setActive(false);
            mp.game.cam.renderScriptCams(false, true, 0, true, true);
            cameraCharacterPreview.destroy();
            setTimeout(function () {
                mp.gui.cursor.show(false, false);
            }, 10);
            setTimeout(function () {
                player.freezePosition(false);
            }, 10);
            setTimeout(function () {
                mp.game.player.setInvincible(false);
            }, 10);
            setTimeout(function () {
                activateChat(true);
            }, 1000);
        } catch (e) {
            console.log(e);
        }
    }
};

var setCharacterLocal = function (character) {
    player.setMoney(character.Money);
    mp.game.stats.statSetInt(mp.game.joaat('SP0_TOTAL_CASH'), character.Money, true);
}

var HeadOverlayIds = {
    Blemishes: 0,
    FacialHair: 1,
    Eyebrows: 2,
    Ageing: 3,
    Makeup: 4,
    Blush: 5,
    Complexion: 6,
    SunDamage: 7,
    Lipstick: 8,
    Freckles: 9,
    ChestHair: 10,
    BodyBlemishes: 11,
    AddBodyBlemishes: 12
};

var ClothesIndex = {
    Masks: 1,
    Hair: 2,
    Torsos: 3,
    Legs: 4,
    BagsAndParachutes: 5,
    Shoes: 6,
    Accessories: 7,
    Undershirts: 8,
    BodyArmors: 9,
    Decals: 10,
    Tops: 11
}

var FaceFeatureIndexes = {
    NoseWidth: 0,
    NoseHeight: 1,
    NoseLength: 2,
    NoseBridge: 3,
    NoseTip: 4,
    NoseShift: 5,
    BrowHeight: 6,
    BrowWidth: 7,
    CheekboneHeight: 8,
    CheekboneWidth: 9,
    CheeksWidth: 10,
    Eyes: 11,
    Lips: 12,
    JawWidth: 13,
    JawHeight: 14,
    ChinLength: 15,
    ChinPosition: 16,
    ChinWidth: 17,
    ChinShape: 18,
    NeckWidth: 19,
}

var setCharacterSkin = function (skin) {
    if (skin === null || skin === undefined) {
        skin = defaultSkin;
    }

    player.model = skin.Model;

    player.setHeadBlendData(
        skin.FirstHeadShape,
        skin.SecondHeadShape,
        0,
        skin.FirstSkinTone,
        skin.SecondSkinTone,
        0,
        skin.HeadMix,
        skin.SkinMix,
        0,
        false);
    player.setComponentVariation(ClothesIndex.Hair, skin.Hair, 0, 2);
    player.setHairColor(skin.FirstHairColor, skin.SecondHairColor);
    player.setEyeColor(skin.EyesColor);

    player.setHeadOverlay(HeadOverlayIds.Blemishes, skin.Blemishes, 1.0, 0, 0);
    if (skin.Model == defaultMaleModel) {
        player.setHeadOverlay(HeadOverlayIds.FacialHair, skin.Beard, 1.0, skin.BeardColor, 0);
    } else {
        player.setHeadOverlay(HeadOverlayIds.Makeup, skin.Makeup, 1.0, 0, 0);
        player.setHeadOverlay(HeadOverlayIds.Blush, skin.Blush, 1.0, skin.BlushColor, 0);
        player.setHeadOverlay(HeadOverlayIds.Lipstick, skin.Lipstick, 1.0, skin.LipstickColor, 0);
    }
    player.setHeadOverlay(HeadOverlayIds.Eyebrows, skin.Eyebrows, 1.0, skin.EyebrowsColor, 0);
    player.setHeadOverlay(HeadOverlayIds.Ageing, skin.Ageing, 1.0, 0, 0);

    player.setHeadOverlay(HeadOverlayIds.Complexion, skin.Complexion, 1.0, 0, 0);
    player.setHeadOverlay(HeadOverlayIds.SunDamage, skin.Sundamage, 1.0, 0, 0);
    player.setHeadOverlay(HeadOverlayIds.Freckles, skin.Freckles, 1.0, 0, 0);
    player.setHeadOverlay(HeadOverlayIds.ChestHair, skin.Chest, 1.0, skin.ChestColor, 0);
    //player.setHeadOverlay(HeadOverlayIds.BodyBlemishes, skinShowedDefault.BodyBlemishes, 1.0, skinShowedDefault.FirstHairColor, skinShowedDefault.SecondHairColor);
    //player.setHeadOverlay(HeadOverlayIds.AddBodyBlemishes, skinShowedDefault.AddBodyBlemishes, 1.0, skinShowedDefault.FirstHairColor, skinShowedDefault.SecondHairColor);

    player.setFaceFeature(FaceFeatureIndexes.NoseWidth, skin.NoseWidth);
    player.setFaceFeature(FaceFeatureIndexes.NoseHeight, skin.NoseHeight);
    player.setFaceFeature(FaceFeatureIndexes.NoseLength, skin.NoseLength);
    player.setFaceFeature(FaceFeatureIndexes.NoseBridge, skin.NoseBridge);
    player.setFaceFeature(FaceFeatureIndexes.NoseTip, skin.NoseTip);
    player.setFaceFeature(FaceFeatureIndexes.NoseShift, skin.NoseShift);
    player.setFaceFeature(FaceFeatureIndexes.BrowHeight, skin.BrowHeight);
    player.setFaceFeature(FaceFeatureIndexes.BrowWidth, skin.BrowWidth);
    player.setFaceFeature(FaceFeatureIndexes.CheekboneHeight, skin.CheekboneHeight);
    player.setFaceFeature(FaceFeatureIndexes.CheekboneWidth, skin.CheekboneWidth);
    player.setFaceFeature(FaceFeatureIndexes.CheeksWidth, skin.CheeksWidth);
    player.setFaceFeature(FaceFeatureIndexes.Eyes, skin.Eyes);
    player.setFaceFeature(FaceFeatureIndexes.Lips, skin.Lips);
    player.setFaceFeature(FaceFeatureIndexes.JawWidth, skin.JawWidth);
    player.setFaceFeature(FaceFeatureIndexes.JawHeight, skin.JawHeight);
    player.setFaceFeature(FaceFeatureIndexes.ChinLength, skin.ChinLength);
    player.setFaceFeature(FaceFeatureIndexes.ChinPosition, skin.ChinPosition);
    player.setFaceFeature(FaceFeatureIndexes.ChinWidth, skin.ChinWidth);
    player.setFaceFeature(FaceFeatureIndexes.ChinShape, skin.ChinShape);
    player.setFaceFeature(FaceFeatureIndexes.NeckWidth, skin.NeckWidth);

    player.setComponentVariation(ClothesIndex.Torsos, skin.Clothes.Torsos, skin.Clothes.TorsosColor, 2);
    player.setComponentVariation(ClothesIndex.Legs, skin.Clothes.Legs, skin.Clothes.LegsColor, 2);
    player.setComponentVariation(ClothesIndex.BagsAndParachutes, skin.Clothes.BagsAndParachutes, skin.Clothes.BagsAndParachutesColor, 2);
    player.setComponentVariation(ClothesIndex.Shoes, skin.Clothes.Shoes, skin.Clothes.ShoesColor, 2);
    player.setComponentVariation(ClothesIndex.Accessories, skin.Clothes.Accessories, skin.Clothes.AccessoriesColor, 2);
    player.setComponentVariation(ClothesIndex.Undershirts, skin.Clothes.Undershirts, skin.Clothes.UndershirtsColor, 2);
    player.setComponentVariation(ClothesIndex.BodyArmors, skin.Clothes.BodyArmors, skin.Clothes.BodyArmorsColor, 2);
    player.setComponentVariation(ClothesIndex.Decals, skin.Clothes.Decals, skin.Clothes.DecalsColor, 2);
    player.setComponentVariation(ClothesIndex.Tops, skin.Clothes.Tops, skin.Clothes.TopsColor, 2);
};