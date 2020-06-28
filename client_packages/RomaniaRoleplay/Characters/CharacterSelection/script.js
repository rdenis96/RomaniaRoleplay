var selectedCharacterId = -1;

$(document).ready(function (e) {
    $("#createCharacter").click(function(){
        mp.trigger('validateCreateCharacter');
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

function removeCharacter() {
    mp.trigger('removeCharacter', selectedCharacterId);
    selectedCharacterId = -1;
}