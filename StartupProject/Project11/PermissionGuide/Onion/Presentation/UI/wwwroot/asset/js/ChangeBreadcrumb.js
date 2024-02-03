function ChangeBreadcrumb({ primaryName = "", primaryLink = "#", secondaryName = "" }) {
    var primary = document.getElementById("breadcrumb_primary");
    var secondary = document.getElementById("breadcrumb_secondary");

    primary.firstChild.setAttribute("href", primaryLink);
    primary.firstChild.innerText = primaryName;

    secondary.innerText = secondaryName
    secondary.setAttribute("class", "breadcrumb-item")
}