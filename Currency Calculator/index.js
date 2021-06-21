function disableOperators(){
    var elems = document.getElementsByClassName("operator");
    for(var i = 0; i < elems.length; i++) {
    elems[i].disabled = true;
    }
}

function enableOperators(){
    var elems = document.getElementsByClassName("operator");
    for(var i = 0; i < elems.length; i++) {
    elems[i].disabled = false;
    }
}
const xmlhttp = new XMLHttpRequest();

function populateCurrencies(){
    var currencyNames = JSON.parse(this.responseText);
    for(var i=0; i<currencyNames.length; i++){
        var item = document.createElement("a");
        item.setAttribute("class","dropdown-item");
        item.href = "#"; 
        var node = document.createTextNode(currencyNames[i]); /*fetching name of the items*/
        item.appendChild(node);
        document.getElementsByClassName('dropdown-menu')[0].appendChild(item);
    }
    xmlhttp.open("GET", "Currencies.json");
    xmlhttp.send();
}