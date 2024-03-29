require('./RomaniaRoleplay/Characters/character-helper.js');

mp.events.add('generateSelectionList', () => {
    showCharacterPreview(true);
    player.model = defaultMaleModel;
    setCharacterSkin();

    characterSelectionPage.execute(`$(\"#charactersList\").html("");`);
    charactersSelectionList.forEach(function (character) {
        characterSelectionPage.execute(`var characterElement = $(\' \
            <div class="col-xs-12 col-md-12 character-card mt-2" onclick="showCharacter(${character.Id})"> \
                  <div class="row mt-3 mb-3 text-center no-padding-col"> \
                      <div class="col-sm-12 col-md-12"> \
                          <h5> \
                              ${character.Name}</h5> \
                      </div> \
                      <div class="col-sm-12 col-md-12 no-padding-col"> \
                          <span class="col-sm-6 col-md-6"> \
                              <span><img class="character-icon" src="img/level-up.png">${character.Level}</span> \
                          </span> \
                          <span class="col-sm-6 col-md-6"> \
                              <span><img class="character-icon" src="img/money.png"> ${character.Money + character.BankMoney}$</span> \
                          </span> \
                      </div> \
                  </div> \
              </div> \
            \'); 
		    $(\"#charactersList\").append(characterElement);`);
    });
    characterSelectionPage.active = true;
});

mp.events.add("validateCreateCharacter", () => {
    mp.events.callRemote('ValidateCreateCharacter');
});

mp.events.add("initCreateCharacter", () => {
    characterSelectionPage.active = false;
    setCharacterSkin();
    createCharacterPage.active = true;
});

mp.events.add('showCharacter', (characterId) => {
    var character = charactersSelectionList.find(elem => elem.Id == characterId);
    if (character !== null && character !== undefined) {
        setCharacterSkin(character.Skin);
    }
});

mp.events.add("selectCharacter", (characterId) => {
    try {
        mp.events.callRemote('OnCharacterSelect', characterId);
    } catch (e) {
        console.log(e);
    }
});

mp.events.add("onPlayerCharacterSet", (character) => {
    showCharacterPreview(false);
    characterSelectionPage.active = false;
    setCharacterLocal(character);
    mp.game.ui.notifications.showWithPicture("Logare reusita", "Bine ai revenit, " + character.Name, "", "CHAR_SOCIAL_CLUB", icon = 0, flashing = false, textColor = -1, bgColor = -1, flashColor = [77, 77, 77, 200])
});

mp.events.add("removeCharacter", (characterId) => {
    try {
        mp.events.callRemote('OnRemoveCharacter', characterId);
    } catch (e) {
        console.log(e);
    }
});