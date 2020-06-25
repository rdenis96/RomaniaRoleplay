require('./RomaniaRoleplay/Characters/character-helper.js');
var skin = null;

mp.events.add('updateSkin', (skinJson) => {
	skin = JSON.parse(skinJson);
	setCharacterSkin(skin);
});

mp.events.add('submitCreateCharacter', (name) => {
	var character = {
		Name: name,
		Skin: skin
	}
	var characterJson = JSON.stringify(character);
	mp.events.callRemote('OnCreateCharacter', characterJson);
});

mp.events.add('cancelCreateCharacter', () => {
	createCharacterPage.active = false;
	mp.events.call("generateSelectionList");
});

mp.events.add('onCharacterFinishCreate', (character) => {
	if (character !== null && character !== 'undefined'){
		charactersSelectionList.push(character);
		createCharacterPage.active = false;
		mp.events.call("generateSelectionList");
	}
	else {
		createCharacterPage.execute(`alert("Caracterul nu a putut fi creat, te rugam sa reincerci!")`);
	}
});