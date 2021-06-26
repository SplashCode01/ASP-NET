var array = {};
var rate;
var selectedCurrency;
var selectedDate;
$(document).ready(function () {

    $('.currency').click(function () {  
        $('.currencies-list').empty();   
         $.ajax({
             type: "GET",
             url: "Currencies.json",
             dataType: "json",
             success: function(data) {
                 $.each(data, function (i, option) {
                    populateCurrencies(option.name, option.code, '.currencies-list', "currencies dropdown-item", "chooseCurrency(this.id)");
                 })
             },
             error: function(){
                 alert("json not found");
             }
         });
     });
    
 
    $('.rate').click(function () {
        $('.rates-list').empty();
        $.ajax({
            type: "GET",
            url: "Rates.json",
            dataType: "json",
            success: function (data) {
                array = data.GEL;
                $.each(data.GEL, function (i, option) {
                    populateCurrencies(option.date, option.date, '.rates-list', "rates dropdown-item", "chooseDate(this.id)");
                })
            },
            error: function () {
                alert("json not found");
            }
        });
    });
});

function chooseCurrency(clicked_id){
    selectedCurrency = clicked_id;
    document.getElementById('selectCurrency').innerHTML = clicked_id;
    console.log(selectedCurrency);
}

function chooseDate(clicked_id){
    selectedDate = clicked_id;
    document.getElementById('selectDate').innerHTML = clicked_id;
    console.log(selectedDate);
    console.log(array);
    let arrayDate = array.find(a => a.date === selectedDate);
    if (selectedCurrency === "EUR") {
        rate = arrayDate.rates.EUR;                  
    } else if (selectedCurrency === "USD") {
        rate = arrayDate.rates.USD;
    } else if (selectedCurrency === "GBP") {
        rate = arrayDate.rates.GBP;
    }
    console.log(rate);
    document.getElementById('displayRate').value = rate;
}

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

function populateCurrencies(option, id, path, classname, funcName){
    var list = document.createElement("li");
    var item = document.createElement("button");
    list.appendChild(item);
    item.setAttribute("class", classname);
    item.setAttribute("onclick", funcName);
    item.href = "#";
    item.setAttribute("id", id);
    var node = document.createTextNode(option);
    item.appendChild(node);
    $(path)[0].appendChild(list);
}