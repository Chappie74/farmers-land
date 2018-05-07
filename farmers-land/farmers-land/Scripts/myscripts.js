
$(window).on('load', function () {
    $("#mymodal").modal({ backdrop: "static", keyboard: false });
    $('#mymodal').modal('show');
});

$(document).ready(function () {
    //when the farmer link is hovered change the image. 
    //This is for Account/Index

    $("#farmerRegisterLink").hover(function () {
        $(this).children("img").attr("src", "../../Content/Images/flaticons/farmer-hover.png");
    }, function ()
    {
        $(this).children("img").attr("src", "../../Content/Images/flaticons/farmer.png");
        });

    $("#consumerRegisterLink").hover(function () {
        $(this).children("img").attr("src", "../../Content/Images/flaticons/shopper-with-bags-hover.png");
    }, function () {
            $(this).children("img").attr("src", "../../Content/Images/flaticons/shopper-with-bags.png");
    });

});