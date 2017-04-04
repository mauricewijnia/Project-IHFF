$(document).ready(function ()
{


    //-----loads the partial view with a list of items for special and film page (based on active filters)
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
        $("#itemsContainer").load(url, { 'day': day, 'place': place, 'sort': order});
    });


    //-----make add and minus buttons functional (pages: films,specials,restaurants)
    $("#itemsContainer").on('click','.qtyBtn', function (e) {

        var id = $(this).attr('id');
        var idNr = id.slice(3); //remove "qty" leaves the idNr

        var qty = parseInt($("#qty" + idNr).html()); //gets the the current qty 
        if (id.substring(0, 3) == "add") {
            $("#qty" + idNr).html(qty + 1);
        } else if (id.substring(0, 3) == "min" && qty != "1") {
            $("#qty" + idNr).html(qty - 1);
        }

        // if on films, change price
        if ($(this).hasClass('qtyBtnfilm')) {
            var price = parseInt($("#price" + idNr).html().slice(2)) //gets the the current price, cuts off "€ "
            //var price = parseInt(priceStr); //gets the the current price

            //add or substracts qty AND price
            if (id.substring(0, 3) == "add") {
                $("#price" + idNr).html("€ " + (price / qty) * (qty + 1));
            } else if (id.substring(0, 3) == "min" && qty != "1") {
                $("#price" + idNr).html("€ " + (price / qty) * (qty - 1));
            }
        }
    });


    //-----adds products to cart or wishlist
    $("#itemsContainer").on('click', '.shopBtn', function (e) {
        //getting itemId and cart parameter
        var fullId = $(this).attr('id');
        var cart = (fullId.substring(5, 9) == "Cart") ? true : false;
        var itemId = (cart == true) ? fullId.slice(9) : fullId.slice(14);
        var reservation = new Date("2017-03-20T00:00:00Z").toISOString();//default

        var cartEvent = true; //can stop call to cart controller if conditions aren't met(if turned false)

        //if restaurant, check if date and time is selected
        if ($(this).hasClass('shopBtnRestaurant')) {
            if ($("#date" + itemId).val() == "-" || $("#time" + itemId).val() == "-") {
                alert("please select a date and time for your reservation")
                var cartEvent = false;
            } else {
                reservation = ($("#date" + itemId).val() + "T" + $("#time" + itemId).val()+ "+01:00"); // date+time+timezone for dateTime parameter
            }
        }

        if (cartEvent) {
            //get last parameter for ShoppingCartController Add
            var qty = $("#qty" + itemId).html();

            //prevent changing the current view, ajax makes a seperate call to shoppingcart/add
            e.preventDefault();
            $.ajax({
                url: '/ShoppingCart/Add',
                data: { id: itemId, Quantity: qty, shopcart: cart, remove: false, tijd: reservation },
                success: function () {
                    if (cart) {
                        $("#shopPopupMessage").html("cart")
                        $("#shopPopupProgramme").hide();
                        $("#shopPopupCart").show();
                    } else {
                        $("#shopPopupMessage").html("programme")
                        $("#shopPopupProgramme").show();
                        $("#shopPopupCart").hide();
                    }
                    $("#shopPopupContent").show();

                }
            });
        }
    });

    $(".closePopup").click(function () {
        $("#shopPopupContent").hide();
    });


});



