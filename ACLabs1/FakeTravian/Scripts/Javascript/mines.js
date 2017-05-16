$(document).ready(function () {

    var updateResources = function () {
        updateResource("Clay");
        updateResource("Wheat");
        updateResource("Iron");
        updateResource("Wood");
    };

    var updateResource = function (resourceName) {
        var currentProduction = 0;
        var start = new Date();
        var currentValue = parseFloat($(".res-value." + resourceName).text());
        console.log(currentValue);
        var lastUpdate = Date.parse($(".res-update." + resourceName).text());
        console.log(lastUpdate);

        var mines = $(".mines").find("." + resourceName);

        $.each(mines, function (index, value) {
            currentProduction += parseInt($(value).find(".hourProduction").text());
        
        });

        var nextValue = (currentValue + ((start.getTime() - lastUpdate) / 1000 / 60 / 60) * currentProduction).toFixed(4);

        $(".res-value." + resourceName).text(nextValue);

        $(".res-update." + resourceName).text(start.strftime("%Y-%m-%d %H:%M:%S"));

    };

    setInterval(updateResources, 500);

    var getMineDetailsHTML = function (mineId) {
        $('#mine-details-container > .content').load("/Mines/Details?mineId=" + mineId);
        $('#mine-details-container').addClass('show');
    };

    $('.mine-details-btn').click(function (e) {
        var mineId = $(this).data('mine-id');
        getMineDetailsHTML(mineId);
    });

    $('#mine-details-container > .close-btn').click(function () {
        $('#mine-details-container').removeClass('show');
    });
});