// Dark and white Mode

let body = document.getElementById("dark-body");
let topbar = document.getElementById("topbar-dark");
let textcolor = document.getElementById("color-white");
let bordercolor = document.getElementById("border-white");
let state = "dark";

function whiteTheme(){

    body.setAttribute("id", "white-body");
    topbar.setAttribute("id", "topbar-white");
    if (bordercolor) bordercolor.setAttribute("id", "border-dark");
    if (textcolor) textcolor.setAttribute("id", "color-dark");
}

function darkTheme() {
    body.setAttribute("id", "dark-body");
    topbar.setAttribute("id", "topbar-dark");
    if (bordercolor) bordercolor.setAttribute("id", "border-white");
    textcolor.setAttribute("id", "color-white");
}

function getThemeState(state) {

    if (state == "dark") {
        darkTheme();
        localStorage.setItem("state", state);
        document.getElementById("dark-btn").setAttribute("class", "hide");
        document.getElementById("light-btn").setAttribute("class", "show");
    }
    else if (state == "white") {
        whiteTheme();
        localStorage.setItem("state", state);
        document.getElementById("light-btn").setAttribute("class", "hide");
        document.getElementById("dark-btn").setAttribute("class", "show");
    }

}

   