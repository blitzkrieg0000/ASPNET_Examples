var templateNotificationElement = document.getElementById("templateSystemNotification");
var systemNotificationScrollElement = document.getElementById("systemNotificationScroll");


function GetDateTimeNow() {
    var today = new Date();
    var date = today.getDate() + "." + (today.getMonth() + 1) + "." + today.getFullYear();
    var time = today.getHours() + "." + today.getMinutes() + ":" + today.getSeconds();
    var dateTime = date + ' ' + time;
    return dateTime;
}


function ShowAllNotifications() {
    var notifications = LoadNotificationFromLocalStorage()

    if (notifications == null) {
        return;
    }
    notifications.reverse();
    notifications.forEach(function (item, index, arr) {
        // Clone-Change-Add
        var templateNotificationElementClone = templateNotificationElement.cloneNode(true);
        templateNotificationElementClone.setAttribute("class", "dropdown-item");
        var dataElement = templateNotificationElementClone.getElementsByClassName("data-info");
        var dataArea = dataElement[0].getElementsByTagName("h6");
        dataArea[0].innerHTML = item.message;
        var timeArea = dataElement[0].getElementsByTagName("p");
        timeArea[0].innerHTML = item.created_time;
        systemNotificationScrollElement.appendChild(templateNotificationElementClone);
    });

    var notificationCounter = document.getElementById("notificationCounter");
    notificationCounter.innerHTML = notifications.length;

}


function UpdateAllNotifications() {
    var systemNotificationScrollElement = document.getElementById("systemNotificationScroll");
    var nodes = systemNotificationScrollElement.querySelectorAll(".dropdown-item")
    nodes.forEach(function (val, key, parent) {
        if (val.getAttribute("class") == "dropdown-item") {
            systemNotificationScrollElement.removeChild(val);
        }
    })

    ShowAllNotifications();
}


function SaveNotificationToLocalStorage(notification) {
    if (CalculateLocalStorageSize() > 10 * 1024 || CalculateLocalStorageSize("_SystemNotifications") > 1 * 1024) {
        RemoveAllNotifications();
    }

    var newMessage = {};
    newMessage["message"] = notification;
    newMessage["created_time"] = GetDateTimeNow();

    var currentNotifications = LoadNotificationFromLocalStorage();
    if (currentNotifications == null) {
        var messageArray = []
        messageArray.push(newMessage)
        localStorage.setItem("_SystemNotifications", JSON.stringify(messageArray));
    } else {
        if(currentNotifications.length>100){
            var currentNotifications = currentNotifications.slice(parseInt(currentNotifications.length/2), currentNotifications.length-1);
        }
        currentNotifications.push(newMessage)
        localStorage.setItem("_SystemNotifications", JSON.stringify(currentNotifications));
    }
}


function LoadNotificationFromLocalStorage() {
    var serializedNotifications = localStorage.getItem("_SystemNotifications");
    if (serializedNotifications == null) {
        return;
    }
    return JSON.parse(serializedNotifications);
}


function RemoveAllNotifications() {
    localStorage.removeItem("_SystemNotifications");
    var notificationCounter = document.getElementById("notificationCounter");
    notificationCounter.innerHTML = "";
    UpdateAllNotifications();
}


function CalculateLocalStorageSize(key = null) {
    if (key != null) {
        let value;
        value = window.localStorage[key];
        value = value ?? "";
        return value ? ((window.localStorage[key].length * 16) / (8 * 1024)) : 0;
    }
    let allStrings = '';
    for (const key of Object.keys(window.localStorage)) {
        allStrings += window.localStorage[key];
    }
    return allStrings ? ((allStrings.length * 16) / (8 * 1024)) : 0;
};