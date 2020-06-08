var isStatsOpen = false;
var statsCard = null;

mp.keys.bind(0x71, false, function() {
    mp.events.callRemote('keypressStats');
});

mp.events.add('showStats', (stats) => {
    if(isStatsOpen === false){
        statsCard = mp.browsers.new("package://NaggaServer/InfoCards/Stats.html");
        statsCard.execute(
            `\ 
                $(\"#name\").text(\"${stats.Name}\"); \
                $(\"#faction\").text(\"${stats.Faction}\"); \
                $(\"#faction\").css("color",\"${stats.FactionColor}\"); \
                $(\"#nameTag\").text(\"${stats.NameTag}\"); \
                $(\"#age\").text(\"${stats.Age}\"); \
                $(\"#bankMoney\").text(\"${stats.BankMoney}\"); \
                $(\"#money\").text(\"${stats.Money}\"); \
                $(\"#job\").text(\"${stats.Job}\"); \
                $(\"#level\").text(\"${stats.Level}\"); \
                $(\"#phoneNumber\").text(\"${stats.PhoneNumber}\"); \
                $(\"#respectPoints\").text(\"${stats.RespectPoints}\"); \
                $(\"#sex\").text(\"${stats.Sex}\"); \
            `);
        isStatsOpen = true;
    }
    else {
        statsCard.destroy();
        isStatsOpen = false;
    }
});