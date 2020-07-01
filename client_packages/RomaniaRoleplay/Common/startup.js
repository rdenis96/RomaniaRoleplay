welcomePage = mp.browsers.new("package://RomaniaRoleplay/Login/Login.html");
welcomePage.active = false;

characterSelectionPage = mp.browsers.new("package://RomaniaRoleplay/Characters/CharacterSelection/index.html");
characterSelectionPage.active = false;

createCharacterPage = mp.browsers.new("package://RomaniaRoleplay/Characters/CharacterCreation/index.html");
createCharacterPage.active = false;


mp.gui.chat.show(false);

chatPage = mp.browsers.new("package://RomaniaRoleplay/Global/chat/index.html");
chatPage.markAsChat();