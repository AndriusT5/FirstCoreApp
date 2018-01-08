$(document).ready(function () {
    console.log("Hi!");

    $("#theForm").hide();


    var button = $("#buyButton");
    button.on("click", function () {
        console.log("buying item...");
    });

    var cars = $(".cars li");
    cars.on("click", function () {
        console.log("you clicked " + $(this).text());
    });


    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-form");

    $loginToggle.on("click", function () {
        $popupForm.toggle(1000);
    });

});