var $ = function (id) {
    return document.getElementById(id);
};
var el = $("str");
var s = "-> ERROR: 403 FORBIDDEN <-";
var s1 = "KULLANICI İZNİ YOK :( ";
setInterval("shuffle(s  + s1 )", 20);
var t = 0;
var o = 0.3;
function shuffle(str) {
    var caps = str.toUpperCase();
    var char = "1234567890BLITZKRIEG";
    var calc;
    for (n = 0; n < caps.length; n++) {
        calc = Math.floor(Math.random() * char.length);
        if (n == 0) el.innerHTML = (t >= 0) ? caps.charAt(0) : char.charAt(calc);
        if (n >= 1) el.innerHTML += (t >= 0 + n * 2) ? caps.charAt(n) : char.charAt(calc);
    }
    o += 1 / (0 + caps.length * 2);
    el.style.opacity = o;
    t++;
}
//click text to reload
function reload() {
    window.location.href = window.location.href;
}
$('str').onclick = reload;
