"use strict";

//! Bağlantı Kur
var connection = new signalR.HubConnectionBuilder().withUrl("/MasterHub").build();

//! Gelen mesaj varsa:
connection.on("ReceiveFrame", function (user, obj) {
    var canvas = document.getElementById(`receiveFrame_${obj.id}`);
    canvas.src = "data:image/png;base64, " + obj.frame
    var canvas = document.getElementById(`receiveFrame_bg_${obj.id}`);
    canvas.src = "data:image/png;base64, " + obj.frame
});

//! Bağlantı sağlandığında
connection.start().then(function () {
    console.log("Bağlantı Kuruldu!")
}).catch(function (err) {
    return console.error(err.toString());
});



//! Gönder tuşuna basıldığında:

var elements = document.getElementsByClassName("startButton");
for (var i = 0, len = elements.length; i < len; i++) {
    elements[i].addEventListener("click", function (event) {

        var message = this.getAttribute('data-input')
        var user = this.getAttribute('data-user')
        connection.invoke("StartProcess", user, message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();


    });
}


var elements = document.getElementsByClassName("stopButton");
for (var i = 0, len = elements.length; i < len; i++) {
    elements[i].addEventListener("click", function (event) {
        var message = this.getAttribute('data-input')
        var user = this.getAttribute('data-user')
        connection.invoke("StopProcess", user, message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();

    });
}