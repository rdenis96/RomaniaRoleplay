var cameraCharacterPreview = null;
var defaultMaleModel = 1885233650;
var defaultFemaleModel = 2627665880;

var SkinSlideBars = {
    FirstHeadShape: { Min:0, Max: 45}, 
    SecondHeadShape: { Min:0, Max: 45},
    FirstSkinTone : { Min:0, Max: 45},
    SecondSkinTone : { Min:0, Max: 45},
    HeadMix: { Min:0.0, Max: 1.0},
    SkinMix: { Min:0.0, Max: 1.0},
    Hair: { Min:0, Max: 74},
    FirstHairColor: { Min:0, Max: 63},
    SecondHairColor: { Min:0, Max: 63},
    Beard: { Min:0, Max: 28},
    BeardColor: { Min:0, Max: 63},
    Chest: { Min:0, Max: 16},
    ChestColor: { Min:0, Max: 63},
    Blemishes: { Min:0, Max: 23},
    Ageing: { Min:0, Max: 14},
    Complexion: { Min:0, Max: 11},
    Sundamage: { Min:0, Max: 10},
    Freckles: { Min:0, Max: 17},
    EyesColor: { Min:0, Max: 31},
    Eyebrows: { Min:0, Max: 33},
    EyebrowsColor: { Min:0, Max: 63},
    Makeup: { Min:0, Max: 74},
    Blush: { Min:0, Max: 6},
    BlushColor: { Min:0, Max: 63},
    Lipstick: { Min:0, Max: 9},
    LipstickColor: { Min:0, Max: 63},
    NoseWidth: { Min:-1.0, Max: 1.0},
    NoseHeight: { Min:-1.0, Max: 1.0},
    NoseLength: { Min:-1.0, Max: 1.0},
    NoseBridge: { Min:-1.0, Max: 1.0},
    NoseTip: { Min:-1.0, Max: 1.0},
    NoseShift: { Min:-1.0, Max: 1.0},
    BrowHeight: { Min:-1.0, Max: 1.0},
    BrowWidth: { Min:-1.0, Max: 1.0},
    CheekboneHeight: { Min:-1.0, Max: 1.0},
    CheekboneWidth: { Min:-1.0, Max: 1.0},
    CheeksWidth: { Min:-1.0, Max: 1.0},
    Eyes: { Min:-1.0, Max: 1.0},
    Lips: { Min:-1.0, Max: 1.0},
    JawWidth: { Min:-1.0, Max: 1.0},
    JawHeight: { Min:-1.0, Max: 1.0},
    ChinLength: { Min:-1.0, Max: 1.0},
    ChinPosition: { Min:-1.0, Max: 1.0},
    ChinWidth: { Min:-1.0, Max: 1.0},
    ChinShape: { Min:-1.0, Max: 1.0},
    NeckWidth: { Min:-1.0, Max: 1.0}
};

var defaultSkin = {
    Model: 1885233650,
    FirstHeadShape: 0, 
    SecondHeadShape: 0,
    FirstSkinTone : 0,
    SecondSkinTone : 0,
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
    NoseWidth:-1.0,
    NoseHeight:-1.0,
    NoseLength:-1.0,
    NoseBridge:-1.0,
    NoseTip:-1.0,
    NoseShift:-1.0,
    BrowHeight:-1.0,
    BrowWidth:-1.0,
    CheekboneHeight:-1.0,
    CheekboneWidth:-1.0,
    CheeksWidth:-1.0,
    Eyes:-1.0,
    Lips:-1.0,
    JawWidth:-1.0,
    JawHeight:-1.0,
    ChinLength:-1.0,
    ChinPosition:-1.0,
    ChinWidth:-1.0,
    ChinShape:-1.0,
    NeckWidth:-1.0,
};

var showCharacterPreview = function (shouldShow){
    if(shouldShow){
        mp.game.ui.displayRadar(false);
        cameraCharacterPreview = mp.cameras.new("Cam", {x: -422.38, y: 1134.75, z: 326.674}, {x: 0, y: 0, z: 163}, 6);
        cameraCharacterPreview.setActive(true);
        mp.game.cam.renderScriptCams(true, true, 20000000000000000000000000, false, false);
        var player = mp.players.local;
        player.position = new mp.Vector3(-427.65, 1116.374, 326.8);
        player.heading = 343;
    }
    else {
        mp.gui.cursor.visible = false;
		mp.game.ui.displayRadar(true);
		mp.gui.chat.show(true);
		cameraCharacterPreview.setActive(false);
		mp.game.cam.renderScriptCams(false, true, 0, true, true);
		cameraCharacterPreview.destroy();
    }
};

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

var FaceFeatureIndexes = {
    NoseWidth:0,
    NoseHeight:1,
    NoseLength:2,
    NoseBridge:3,
    NoseTip:4,
    NoseShift:5,
    BrowHeight:6,
    BrowWidth:7,
    CheekboneHeight:8,
    CheekboneWidth:9,
    CheeksWidth:10,
    Eyes:11,
    Lips:12,
    JawWidth:13,
    JawHeight:14,
    ChinLength:15,
    ChinPosition:16,
    ChinWidth:17,
    ChinShape:18,
    NeckWidth:19,
}

var setCharacterSkin = function(skin){
    if(skin === null || skin === undefined){
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
    player.setComponentVariation(2, skin.Hair, 0, 1);
    player.setHairColor(skin.FirstHairColor, skin.SecondHairColor);

    player.setHeadOverlay(HeadOverlayIds.Blemishes, skin.Blemishes, 1.0, skin.FirstHairColor, skin.SecondHairColor);
    player.setHeadOverlay(HeadOverlayIds.FacialHair, skin.Beard, 1.0, skin.BeardColor, skin.BeardColor);
    player.setHeadOverlay(HeadOverlayIds.Eyebrows, skin.Eyebrows, 1.0, skin.EyebrowsColor, skin.EyebrowsColor);
    player.setHeadOverlay(HeadOverlayIds.Ageing, skin.Ageing, 1.0, skin.FirstHairColor, skin.SecondHairColor);
    player.setHeadOverlay(HeadOverlayIds.Makeup, skin.Makeup, 1.0, skin.FirstHairColor, skin.SecondHairColor);
    player.setHeadOverlay(HeadOverlayIds.Blush, skin.Blush, 1.0, skin.BlushColor, skin.BlushColor);
    player.setHeadOverlay(HeadOverlayIds.Complexion, skin.Complexion, 1.0, skin.FirstHairColor, skin.SecondHairColor);
    player.setHeadOverlay(HeadOverlayIds.SunDamage, skin.Sundamage, 1.0, skin.FirstHairColor, skin.SecondHairColor);
    player.setHeadOverlay(HeadOverlayIds.Lipstick, skin.Lipstick, 1.0, skin.LipstickColor, skin.LipstickColor);
    player.setHeadOverlay(HeadOverlayIds.Freckles, skin.Freckles, 1.0, skin.FirstHairColor, skin.SecondHairColor);
    player.setHeadOverlay(HeadOverlayIds.ChestHair, skin.Chest, 1.0, skin.ChestColor, skin.ChestColor);
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
};

var setCharacter = function(character){
    player.name = character.Name;
    player.nametag = character.NameTag;
    player.setMoney(character.Money);

    //player.Level = character.Level; // Nu exista, trebuie implementata o altenativa

    mp.nametags.set({
        font: 6,
        outline: true,
        offset: 0.7,
        veh_offset: 1.0,
        color: [255, 255, 255, 255],
        size: 0.5,
    
        hbar: {
            size: [0.06, 0.008],
            color: [0, 0, 0, 0],
            bg_color: [0, 0, 0, 0]
        },
    });

    setCharacterSkin(character.Skin);
    showCharacterPreview(false);
    player.position = new mp.Vector3(-1036.755, -2737.948, 21.2772);
};