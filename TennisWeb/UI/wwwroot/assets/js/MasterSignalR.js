"use strict";

//! Bağlantı Kur
var connection = new signalR.HubConnectionBuilder().withUrl("/MasterHub").build();

//! Gelen mesaj varsa:
connection.on("ReceiveFrame", function (user, message) {
    var message = document.getElementById("deliverFrame");
    message.src = "data:image/png;base64, " + message
});

//! Bağlantı sağlandığında
connection.start().then(function () {


}).catch(function (err) {
    return console.error(err.toString());
});

//! Gönder tuşuna basıldığında:
document.getElementById("testButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("dataInput").value;
    connection.invoke("DeliverFrame", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});