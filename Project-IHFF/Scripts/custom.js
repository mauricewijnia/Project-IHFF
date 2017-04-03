
//loads the partial view with a list of items for special and film page (based on active filters)
$(document).ready(function ()
{
    $(".sortBtn").click(function ()
    {
        //all (old) selected filters
        var day = $('input[name=filterDay]:checked').attr('id');
        var place = $('input[name=filterPlace]:checked').attr('id');
        var order = $('input[name=filterOrder]:checked').attr('id');

        //replace new selected with old selected
        if ($(this).hasClass("sortDay")) { day = $(this).attr('id') }
        if ($(this).hasClass("sortPlace")) { place = $(this).attr('id') }
        if ($(this).hasClass("sortOrder")) { order = $(this).attr('id') }

        // get the @url.actionresult from the page
        var url = $("#itemsContainer").data('request-url');

        //use action result and pass parameters, load it in the container div
        $("#itemsContainer").load(url, { 'day': day, 'place': place, 'sort': order });
    });
});



