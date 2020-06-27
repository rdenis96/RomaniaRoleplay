require('./RomaniaRoleplay/Characters/character-helper.js');

mp.events.add('onUserConnected', () => {
	mp.gui.chat.activate(false);
	mp.game.player.setInvincible(true);
	player.freezePosition(true);
	welcomePage.active = true;
	mp.gui.cursor.show(true, true);
});

mp.events.add('loginInformationToServer', (loginModel) => {
	mp.events.callRemote('OnUserLoginAttempt', loginModel);
});

mp.events.add('onUserLoginResponse', (playerInfo, characters) => {
	welcomePage.execute(`$(\"#loginResponseMessage\").find(\"#loginMessage\").remove();`)
	if (playerInfo !== null && playerInfo !== 'undefined') {
		welcomePage.execute(`$(\"#signInButton\").prop(\"disabled\", true); var alertElement = $(\'<div id="loginMessage" class="alert alert-success">Autentificare reusita!</div >\'); \
		$(\"#loginResponseMessage\").append(alertElement);`);

		charactersSelectionList = characters;
		setTimeout(() => {
			mp.events.call("generateSelectionList");
			welcomePage.active = false;
		}, 1500);

	} else {
		welcomePage.execute(`var alertElement = $(\'<div id="loginMessage" class="alert alert-danger">Parola sau Username-ul sunt gresite.</div >\'); \
            $(\"#loginResponseMessage\").append(alertElement);`);
	}
});

mp.events.add('onUserSwitchCharacters', (playerInfo, characters) => {
	if (playerInfo !== null && playerInfo !== 'undefined') {
		charactersSelectionList = characters;
		showCharacterPreview(true);
		mp.events.call("generateSelectionList");
	} else {
		welcomePage.execute(`var alertElement = $(\'<div id="loginMessage" class="alert alert-danger">Parola sau Username-ul sunt gresite.</div >\'); \
            $(\"#loginResponseMessage\").append(alertElement);`);
	}
});