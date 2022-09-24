"use strict";


function setCookie(cname, cvalue, exdays) {
    const d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    let expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function deleteCookie(cname) {
    document.cookie = `${cname}=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;`;
}

function getCookie(cname) {
    let name = cname + "=";
    let ca = document.cookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return null;
}

function getMessageList() {
    var messageString = getCookie("message")
    if (messageString != null) {
        return JSON.parse(messageString);
    }
    return null;
}

function addMessage(msg) {
    var data = {
        message: msg,
        date: new Date().toLocaleString()
    }
    var value = getCookie("message");
    if (value != null) {
        var messageList = JSON.parse(value);
        messageList.push(data)
        let stringMsg = JSON.stringify(messageList);
        setCookie("message", stringMsg, 30);
    } else {
        var messageList = []
        messageList.push(data)
        let stringMsg = JSON.stringify(messageList);
        setCookie("message", stringMsg, 30);
    }
}

function removeAllChildNodes(parent) {
    while (parent.firstChild) {
        parent.removeChild(parent.firstChild);
    }
}

function removeAllMessages() {
    var parent = document.getElementById('infoMessageList');
    deleteCookie("message")
    removeAllChildNodes(parent)
    var counterElement = document.getElementById("messageCounter")
    counterElement.innerHTML = "0"
}

function refreshMessageList() {

    var counterElement = document.getElementById("messageCounter")
    var messageList = getMessageList();
    var infoMessageList = document.getElementById('infoMessageList');

    removeAllChildNodes(infoMessageList);

    if (infoMessageList != null) {
        counterElement.innerHTML = messageList.length;
        messageList.forEach(element => {
            var li_element = prepareInformationElement(element);
            infoMessageList.appendChild(li_element);
        });
    }
}

function prepareInformationElement(data, title = "System") {
    //Information Body
    var li_media = document.createElement("li");
    li_media.className = "media";

    var div_media_body = document.createElement("div");
    div_media_body.className = "media-body";

    var div_media_title = document.createElement("div");
    div_media_title.className = "media-title";
    var span_title = document.createElement("span");
    span_title.className = "font-weight-semibold";
    span_title.innerHTML = title;
    div_media_title.appendChild(span_title);
    var span_date = document.createElement("span");
    span_date.className = "text-muted float-right font-size-sm";

    try {
        span_date.innerHTML = data['date'];
    } catch {

    }

    div_media_title.appendChild(span_date)
    div_media_body.appendChild(div_media_title)
    var span_muted = document.createElement("span");
    span_muted.className = "text-muted";
    span_muted.innerHTML = data['message'];
    div_media_body.appendChild(span_muted);
    li_media.appendChild(div_media_body);

    return li_media
}


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
    // var element = document.getElementById('infoMessage');
    // element.innerHTML = msg;

    addMessage(msg.toString());
    refreshMessageList();


});

//! Tuşa basıldığında:
var elements = document.getElementsByClassName("startButton");
for (var i = 0, len = elements.length; i < len; i++) {
    elements[i].addEventListener("click", function (event) {

        this.style.display = "none";

        var stopButton = this.parentNode.getElementsByClassName("stopButton");
        if (stopButton.length > 0) {
            stopButton[0].style.display = "block";
        }

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

        this.style.display = "none";

        var startButton = this.parentNode.getElementsByClassName("startButton");
        if (startButton.length > 0) {
            startButton[0].setAttribute("style", "display: none;");
        }

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

try {
    refreshMessageList()
} catch {

}