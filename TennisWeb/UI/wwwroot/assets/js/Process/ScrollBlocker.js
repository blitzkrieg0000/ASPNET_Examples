var modal_scroll_disabled = document.getElementById("modal_scroll_disabled");
var disable_scroll = document.getElementById("detailModal");

modal_scroll_disabled.onmouseover = function () {
document.body.style.overflowY = "hidden";
disable_scroll.style.overflowY = "hidden";
};
modal_scroll_disabled.onmouseout = function () {
document.body.style.overflowY = "auto";
disable_scroll.style.overflowY = "auto";
};