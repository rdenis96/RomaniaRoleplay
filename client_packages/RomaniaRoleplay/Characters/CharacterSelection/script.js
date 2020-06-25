var selectedCharacterId = -1;

$(document).ready(function (e) {
    $("#createCharacter").click(function(){
        mp.trigger('initCreateCaracter');
    });
});

function showCharacter(characterId){
    mp.trigger('showCharacter', characterId);
    selectedCharacterId = characterId;
};

function submitSelectedCharacter(){
    if(selectedCharacterId != -1){
        mp.trigger('selectCharacter', selectedCharacterId);
        selectedCharacterId = -1;
    }
}

// function selectCharacter(event, characterId){
//     if(event.keyCode == 13){
//         mp.trigger('selectCharacter', characterId);
//     }
// };