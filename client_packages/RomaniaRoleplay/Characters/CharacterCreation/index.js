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
	try {
		var characterJson = JSON.stringify(character);
		mp.events.callRemote('OnCreateCharacter', characterJson);
	} catch (e) {
		console.log(e);
	}
});

mp.events.add('cancelCreateCharacter', () => {
	try {
		createCharacterPage.active = false;
		mp.events.call("generateSelectionList");
	} catch (e) {
		console.log(e);
	}
});

mp.events.add('onCharacterFinishCreate', (character) => {
	try {
		if (character !== null && character !== 'undefined') {
			charactersSelectionList.push(character);
			createCharacterPage.active = false;
			mp.events.call("generateSelectionList");
		} else {
			createCharacterPage.execute(`showErrorMessage("Caracterul nu a putut fi creat deoarece exista deja acelasi nume sau a intervenit o problema! Te rugam sa reincerci!")`);
		}
	} catch (e) {
		console.log(e);
	}
});