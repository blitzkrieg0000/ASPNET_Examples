// Add Navigation Button To Default CORK Datatable
function AddButtonToDataTable(button_name, href, button_class = "btn btn-success", placement_class = "col-6 col-sm-6 d-flex justify-content-sm-start justify-content-center") {
    var tableHeader = document.getElementsByClassName("dt--top-section");
    var placeAt = tableHeader[0].getElementsByClassName("row");

    //Create new Button
    var newButton = document.createElement("a");
    newButton.setAttribute("class", button_class);
    newButton.draggable = false;
    newButton.setAttribute("href", href); //TODO RoleID gerekiyor
    newButton.innerText = button_name;

    var newDiv = document.createElement("div");
    newDiv.setAttribute("class", placement_class);
    newDiv.appendChild(newButton);
    placeAt[0].insertBefore(newDiv, placeAt[0].firstChild);
}