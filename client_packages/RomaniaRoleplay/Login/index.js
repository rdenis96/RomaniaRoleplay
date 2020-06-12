var welcomePage = null;

mp.events.add('onUserConnected', () => {
	mp.gui.chat.activate(false);
	mp.game.player.setInvincible(true);
	mp.players.local.freezePosition(true);
	welcomePage = mp.browsers.new("package://RomaniaRoleplay/Login/Login.html");
	mp.gui.cursor.show(true, true);
});

mp.events.add('loginInformationToServer', (loginModel) => {
	mp.events.callRemote('OnUserLoginAttempt', loginModel);
});

mp.events.add('onUserLoginResponse', (playerInfo) => {
	welcomePage.execute(`$(\"#loginResponseMessage\").find(\"#loginMessage\").remove();`)
	if (playerInfo !== null && playerInfo !== 'undefined') {
		welcomePage.execute(`$(\"#signInButton\").prop(\"disabled\", true); var alertElement = $(\'<div id="loginMessage" class="alert alert-success">Autentificare reusita!</div >\'); \
		$(\"#loginResponseMessage\").append(alertElement);`);
		setTimeout(() => {
			mp.gui.cursor.show(false, false);
			mp.game.player.setInvincible(false);
			mp.players.local.freezePosition(false);
			welcomePage.destroy();
			mp.gui.chat.activate(true);
			mp.game.ui.notifications.showWithPicture("Logare reusita", "Bine ai revenit, " + playerInfo.Username, "", "CHAR_SOCIAL_CLUB", icon = 0, flashing = false, textColor = -1, bgColor = -1, flashColor = [77, 77, 77, 200])
		}, 1500);

	} else {
		welcomePage.execute(`var alertElement = $(\'<div id="loginMessage" class="alert alert-danger">Parola sau Username-ul sunt gresite.</div >\'); \
            $(\"#loginResponseMessage\").append(alertElement);`);
	}
});