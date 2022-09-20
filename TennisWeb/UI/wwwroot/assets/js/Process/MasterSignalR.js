"use strict";

//! Bağlantı kur
var connection = new signalR.HubConnectionBuilder().withUrl("/MasterHub").withAutomaticReconnect().build();

//! Bağlantı sağlandığında
async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err.toString());
        setTimeout(start, 5000);
    }
};

//! Bağlantı Kapandığında
connection.onclose(async () => {
    await start();
});

//! Gelen mesaj varsa:
connection.on("ReceiveFrame", function (user, obj) {
    var canvas = document.getElementById(`receiveFrame_${obj.id}`);
    canvas.src = "data:image/png;base64, " + obj.frame
    var canvas = document.getElementById(`receiveFrame_bg_${obj.id}`);
    canvas.src = "data:image/png;base64, " + obj.frame
});

connection.on("InfoMessage", function (user, msg) {
    var element = document.getElementById('infoMessage');
    element.innerHTML = msg;
});

//! Tuşa basıldığında:
var elements = document.getElementsByClassName("startButton");
for (var i = 0, len = elements.length; i < len; i++) {
    elements[i].addEventListener("click", function (event) {

        let user = this.getAttribute('data-user')
        let message = this.getAttribute('data-input')


        let prom = connection.send("StartProcess", user, message).catch(function (err) {
            return console.error(err.toString());
        });

        event.preventDefault();

    });
}

var elements = document.getElementsByClassName("stopButton");
for (var i = 0, len = elements.length; i < len; i++) {
    elements[i].addEventListener("click", function (event) {
        let user = this.getAttribute('data-user')
        let message = this.getAttribute('data-input')

        let prom = connection.send("StopProcess", user, message).catch(function (err) {
            return console.error(err.toString());
        });

        event.preventDefault();

    });
}

var lockResolver;
if (navigator && navigator.locks && navigator.locks.request) {
    const promise = new Promise((res) => {
        lockResolver = res;
    });

    navigator.locks.request('unique_lock_name', { mode: "shared" }, () => {
        return promise;
    });
}

//! Start the connection.
start();