var app = angular.module('romaniaRoleplayApp', ['toastr']);
app.config([
    'toastrConfig',
    function (toastrConfig) {
        angular.extend(toastrConfig, {
            autoDismiss: true,
            maxOpened: 1,
            newestOnTop: true,
            positionClass: 'toast-top-center',
            preventDuplicates: false,
            preventOpenDuplicates: false,
            target: 'body',
            closeButton: true,
            extendedTimeOut: 5000,
            timeOut: 5000
        });
    }]);
app.controller('characterCreationController',
    function ($scope, $window, toastr) {
        $scope.defaultMaleModel = 1885233650;
        $scope.defaultFemaleModel = 2627665880;

        $scope.skin = {
            Model: $scope.defaultMaleModel,
            FirstHeadShape: 0,
            SecondHeadShape: 0,
            FirstSkinTone: 0,
            SecondSkinTone: 0,
            HeadMix: -1.0,
            SkinMix: -1.0,
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
                Legs: 0,
                BagsAndParachutes: 0,
                Shoes: 0,
                Accessories: 0,
                Undershirts: 0,
                BodyArmors: 0,
                Decals: 0,
                Tops: 0,
                TorsosColor: 0,
                LegsColor: 0,
                BagsAndParachutesColor: 0,
                ShoesColor: 0,
                AccessoriesColor: 0,
                UndershirtsColor: 0,
                BodyArmorsColor: 0,
                DecalsColor: 0,
                TopsColor: 0
            }
        };

        $scope.skinSlideBars = {
            FirstHeadShape: {
                Min: 0,
                Max: 45
            },
            SecondHeadShape: {
                Min: 0,
                Max: 45
            },
            FirstSkinTone: {
                Min: 0,
                Max: 45
            },
            SecondSkinTone: {
                Min: 0,
                Max: 45
            },
            HeadMix: {
                Min: 0.0,
                Max: 1.0
            },
            SkinMix: {
                Min: 0.0,
                Max: 1.0
            },
            Hair: {
                Min: 0,
                Max: 74
            },
            FirstHairColor: {
                Min: 0,
                Max: 63
            },
            SecondHairColor: {
                Min: 0,
                Max: 63
            },
            Beard: {
                Min: 0,
                Max: 28
            },
            BeardColor: {
                Min: 0,
                Max: 63
            },
            Chest: {
                Min: 0,
                Max: 16
            },
            ChestColor: {
                Min: 0,
                Max: 63
            },
            Blemishes: {
                Min: 0,
                Max: 23
            },
            Ageing: {
                Min: 0,
                Max: 14
            },
            Complexion: {
                Min: 0,
                Max: 11
            },
            Sundamage: {
                Min: 0,
                Max: 10
            },
            Freckles: {
                Min: 0,
                Max: 17
            },
            EyesColor: {
                Min: 0,
                Max: 31
            },
            Eyebrows: {
                Min: 0,
                Max: 33
            },
            EyebrowsColor: {
                Min: 0,
                Max: 63
            },
            Makeup: {
                Min: 0,
                Max: 74
            },
            Blush: {
                Min: 0,
                Max: 6
            },
            BlushColor: {
                Min: 0,
                Max: 63
            },
            Lipstick: {
                Min: 0,
                Max: 9
            },
            LipstickColor: {
                Min: 0,
                Max: 63
            },
            NoseWidth: {
                Min: -1.0,
                Max: 1.0
            },
            NoseHeight: {
                Min: -1.0,
                Max: 1.0
            },
            NoseLength: {
                Min: -1.0,
                Max: 1.0
            },
            NoseBridge: {
                Min: -1.0,
                Max: 1.0
            },
            NoseTip: {
                Min: -1.0,
                Max: 1.0
            },
            NoseShift: {
                Min: -1.0,
                Max: 1.0
            },
            BrowHeight: {
                Min: -1.0,
                Max: 1.0
            },
            BrowWidth: {
                Min: -1.0,
                Max: 1.0
            },
            CheekboneHeight: {
                Min: -1.0,
                Max: 1.0
            },
            CheekboneWidth: {
                Min: -1.0,
                Max: 1.0
            },
            CheeksWidth: {
                Min: -1.0,
                Max: 1.0
            },
            Eyes: {
                Min: -1.0,
                Max: 1.0
            },
            Lips: {
                Min: -1.0,
                Max: 1.0
            },
            JawWidth: {
                Min: -1.0,
                Max: 1.0
            },
            JawHeight: {
                Min: -1.0,
                Max: 1.0
            },
            ChinLength: {
                Min: -1.0,
                Max: 1.0
            },
            ChinPosition: {
                Min: -1.0,
                Max: 1.0
            },
            ChinWidth: {
                Min: -1.0,
                Max: 1.0
            },
            ChinShape: {
                Min: -1.0,
                Max: 1.0
            },
            NeckWidth: {
                Min: -1.0,
                Max: 1.0
            },
            Clothes: {
                Torsos: {
                    Min: 0,
                    Max: $scope.skin.Model == $scope.defaultMaleModel ? 168 : 209
                },
                TorsosColor: {
                    Min: 0,
                    Max: 63
                },
                Legs: {
                    Min: 0,
                    Max: $scope.skin.Model == $scope.defaultMaleModel ? 126 : 131
                },
                LegsColor: {
                    Min: 0,
                    Max: 63
                },
                BagsAndParachutes: {
                    Min: 0,
                    Max: 84
                },
                BagsAndParachutesColor: {
                    Min: 0,
                    Max: 63
                },
                Shoes: {
                    Min: 0,
                    Max: $scope.skin.Model == $scope.defaultMaleModel ? 95 : 99
                },
                ShoesColor: {
                    Min: 0,
                    Max: 63
                },
                Accessories: {
                    Min: 0,
                    Max: $scope.skin.Model == $scope.defaultMaleModel ? 135 : 104
                },
                AccessoriesColor: {
                    Min: 0,
                    Max: 63
                },
                Undershirts: {
                    Min: 0,
                    Max: $scope.skin.Model == $scope.defaultMaleModel ? 164 : 200
                },
                UndershirtsColor: {
                    Min: 0,
                    Max: 63
                },
                BodyArmors: {
                    Min: 0,
                    Max: 55
                },
                BodyArmorsColor: {
                    Min: 0,
                    Max: 63
                },
                Decals: {
                    Min: 0,
                    Max: $scope.skin.Model == $scope.defaultMaleModel ? 77 : 72
                },
                DecalsColor: {
                    Min: 0,
                    Max: 63
                },
                Tops: {
                    Min: 0,
                    Max: $scope.skin.Model == $scope.defaultMaleModel ? 331 : 346
                },
                TopsColor: {
                    Min: 0,
                    Max: 63
                }
            }
        };

        $scope.$watch('skin', function () {
            var skinJson = JSON.stringify($scope.skin);
            $window.mp.trigger('updateSkin', skinJson);
        }, true);

        var getRandomInt = function (max) {
            return Math.floor(Math.random() * Math.floor(max) + 1);
        }

        $scope.randomSkin = function () {
            var randomSkin = {
                Model: $scope.skin.Model,
                FirstHeadShape: getRandomInt($scope.skinSlideBars.FirstHeadShape.Max),
                SecondHeadShape: getRandomInt($scope.skinSlideBars.SecondHeadShape.Max),
                FirstSkinTone: getRandomInt($scope.skinSlideBars.FirstSkinTone.Max),
                SecondSkinTone: getRandomInt($scope.skinSlideBars.SecondSkinTone.Max),
                HeadMix: Math.random(),
                SkinMix: Math.random(),
                Hair: getRandomInt($scope.skinSlideBars.Hair.Max),
                FirstHairColor: getRandomInt($scope.skinSlideBars.FirstHairColor.Max),
                SecondHairColor: getRandomInt($scope.skinSlideBars.SecondHairColor.Max),
                Beard: getRandomInt($scope.skinSlideBars.Beard.Max),
                BeardColor: getRandomInt($scope.skinSlideBars.BeardColor.Max),
                Chest: getRandomInt($scope.skinSlideBars.Chest.Max),
                ChestColor: getRandomInt($scope.skinSlideBars.ChestColor.Max),
                Blemishes: getRandomInt($scope.skinSlideBars.Blemishes.Max),
                Ageing: getRandomInt($scope.skinSlideBars.Ageing.Max),
                Complexion: getRandomInt($scope.skinSlideBars.Complexion.Max),
                Sundamage: getRandomInt($scope.skinSlideBars.Sundamage.Max),
                Freckles: getRandomInt($scope.skinSlideBars.Freckles.Max),
                EyesColor: getRandomInt($scope.skinSlideBars.EyesColor.Max),
                Eyebrows: getRandomInt($scope.skinSlideBars.Eyebrows.Max),
                EyebrowsColor: getRandomInt($scope.skinSlideBars.EyebrowsColor.Max),
                Makeup: getRandomInt($scope.skinSlideBars.Makeup.Max),
                Blush: getRandomInt($scope.skinSlideBars.Blush.Max),
                BlushColor: getRandomInt($scope.skinSlideBars.BlushColor.Max),
                Lipstick: getRandomInt($scope.skinSlideBars.Lipstick.Max),
                LipstickColor: getRandomInt($scope.skinSlideBars.LipstickColor.Max),
                NoseWidth: Math.random(),
                NoseHeight: Math.random(),
                NoseLength: Math.random(),
                NoseBridge: Math.random(),
                NoseTip: Math.random(),
                NoseShift: Math.random(),
                BrowHeight: Math.random(),
                BrowWidth: Math.random(),
                CheekboneHeight: Math.random(),
                CheekboneWidth: Math.random(),
                CheeksWidth: Math.random(),
                Eyes: Math.random(),
                Lips: Math.random(),
                JawWidth: Math.random(),
                JawHeight: Math.random(),
                ChinLength: Math.random(),
                ChinPosition: Math.random(),
                ChinWidth: Math.random(),
                ChinShape: Math.random(),
                NeckWidth: Math.random(),
                Clothes: {
                    Torsos: getRandomInt($scope.skinSlideBars.Clothes.Torsos.Max),
                    Legs: getRandomInt($scope.skinSlideBars.Clothes.Legs.Max),
                    BagsAndParachutes: 0,
                    Shoes: getRandomInt($scope.skinSlideBars.Clothes.Shoes.Max),
                    Accessories: getRandomInt($scope.skinSlideBars.Clothes.Accessories.Max),
                    Undershirts: getRandomInt($scope.skinSlideBars.Clothes.Undershirts.Max),
                    BodyArmors: 0,
                    Decals: getRandomInt($scope.skinSlideBars.Clothes.Decals.Max),
                    Tops: getRandomInt($scope.skinSlideBars.Clothes.Tops.Max),
                    TorsosColor: 0,
                    LegsColor: 0,
                    BagsAndParachutesColor: 0,
                    ShoesColor: 0,
                    AccessoriesColor: 0,
                    UndershirtsColor: 0,
                    BodyArmorsColor: 0,
                    DecalsColor: 0,
                    TopsColor: 0
                }
            };
            angular.copy(randomSkin, $scope.skin);
        }

        $scope.setModel = function (skinModel) {
            var resetedSkin = {
                Model: skinModel,
                FirstHeadShape: $scope.skinSlideBars.FirstHeadShape.Min,
                SecondHeadShape: $scope.skinSlideBars.SecondHeadShape.Min,
                FirstSkinTone: $scope.skinSlideBars.FirstSkinTone.Min,
                SecondSkinTone: $scope.skinSlideBars.SecondSkinTone.Min,
                HeadMix: $scope.skinSlideBars.HeadMix.Min,
                SkinMix: $scope.skinSlideBars.SkinMix.Min,
                Hair: $scope.skinSlideBars.Hair.Min,
                FirstHairColor: $scope.skinSlideBars.FirstHairColor.Min,
                SecondHairColor: $scope.skinSlideBars.SecondHairColor.Min,
                Beard: $scope.skinSlideBars.Beard.Min,
                BeardColor: $scope.skinSlideBars.BeardColor.Min,
                Chest: $scope.skinSlideBars.Chest.Min,
                ChestColor: $scope.skinSlideBars.ChestColor.Min,
                Blemishes: $scope.skinSlideBars.Blemishes.Min,
                Ageing: $scope.skinSlideBars.Ageing.Min,
                Complexion: $scope.skinSlideBars.Complexion.Min,
                Sundamage: $scope.skinSlideBars.Sundamage.Min,
                Freckles: $scope.skinSlideBars.Freckles.Min,
                EyesColor: $scope.skinSlideBars.EyesColor.Min,
                Eyebrows: $scope.skinSlideBars.Eyebrows.Min,
                EyebrowsColor: $scope.skinSlideBars.EyebrowsColor.Min,
                Makeup: $scope.skinSlideBars.Makeup.Min,
                Blush: $scope.skinSlideBars.Blush.Min,
                BlushColor: $scope.skinSlideBars.BlushColor.Min,
                Lipstick: $scope.skinSlideBars.Lipstick.Min,
                LipstickColor: $scope.skinSlideBars.LipstickColor.Min,
                NoseWidth: $scope.skinSlideBars.NoseWidth.Min,
                NoseHeight: $scope.skinSlideBars.NoseHeight.Min,
                NoseLength: $scope.skinSlideBars.NoseLength.Min,
                NoseBridge: $scope.skinSlideBars.NoseBridge.Min,
                NoseTip: $scope.skinSlideBars.NoseTip.Min,
                NoseShift: $scope.skinSlideBars.NoseShift.Min,
                BrowHeight: $scope.skinSlideBars.BrowHeight.Min,
                BrowWidth: $scope.skinSlideBars.BrowWidth.Min,
                CheekboneHeight: $scope.skinSlideBars.CheekboneHeight.Min,
                CheekboneWidth: $scope.skinSlideBars.CheekboneWidth.Min,
                CheeksWidth: $scope.skinSlideBars.CheeksWidth.Min,
                Eyes: $scope.skinSlideBars.Eyes.Min,
                Lips: $scope.skinSlideBars.Lips.Min,
                JawWidth: $scope.skinSlideBars.JawWidth.Min,
                JawHeight: $scope.skinSlideBars.JawHeight.Min,
                ChinLength: $scope.skinSlideBars.ChinLength.Min,
                ChinPosition: $scope.skinSlideBars.ChinPosition.Min,
                ChinWidth: $scope.skinSlideBars.ChinWidth.Min,
                ChinShape: $scope.skinSlideBars.ChinShape.Min,
                NeckWidth: $scope.skinSlideBars.NeckWidth.Min,
                Clothes: {
                    Torsos: $scope.skinSlideBars.Clothes.Torsos.Min,
                    Legs: $scope.skinSlideBars.Clothes.Legs.Min,
                    BagsAndParachutes: $scope.skinSlideBars.Clothes.BagsAndParachutes.Min,
                    Shoes: $scope.skinSlideBars.Clothes.Shoes.Min,
                    Accessories: $scope.skinSlideBars.Clothes.Accessories.Min,
                    Undershirts: $scope.skinSlideBars.Clothes.Undershirts.Min,
                    BodyArmors: $scope.skinSlideBars.Clothes.BodyArmors.Min,
                    Decals: $scope.skinSlideBars.Clothes.Decals.Min,
                    Tops: $scope.skinSlideBars.Clothes.TopsColor.Min,
                    TorsosColor: $scope.skinSlideBars.Clothes.TorsosColor.Min,
                    LegsColor: $scope.skinSlideBars.Clothes.LegsColor.Min,
                    BagsAndParachutesColor: $scope.skinSlideBars.Clothes.BagsAndParachutesColor.Min,
                    ShoesColor: $scope.skinSlideBars.Clothes.ShoesColor.Min,
                    AccessoriesColor: $scope.skinSlideBars.Clothes.AccessoriesColor.Min,
                    UndershirtsColor: $scope.skinSlideBars.Clothes.UndershirtsColor.Min,
                    BodyArmorsColor: $scope.skinSlideBars.Clothes.BodyArmorsColor.Min,
                    DecalsColor: $scope.skinSlideBars.Clothes.DecalsColor.Min,
                    TopsColor: $scope.skinSlideBars.Clothes.TopsColor.Min
                }
            };
            angular.copy(resetedSkin, $scope.skin);
        };

        $scope.cancelCreate = function () {
            $window.mp.trigger('cancelCreateCharacter');
        };

        $scope.createCharacter = function () {
            $window.mp.trigger('submitCreateCharacter', $scope.characterName);
        };

        $scope.showErrorMessage = function (message) {
            toastr.error(message);
        };
    });

function showErrorMessage(message) {
    angular.element(document.getElementById('characterCreationController')).scope().showErrorMessage(message);
}