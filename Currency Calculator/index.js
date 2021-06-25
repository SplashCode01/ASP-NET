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
                    populateCurrencies(option.name, option.code, '.currencies-list', "currencies dropdown-item");
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
                    populateCurrencies(option.date, option.date, '.rates-list', "rates dropdown-item");
                 })
             },
             error: function () {
                 alert("json not found");
             }
         });
     });
});

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

function populateCurrencies(option, id, path, classname){
    var item = document.createElement("a");
    item.setAttribute("class", classname);
    item.href = "#";
    item.setAttribute("id", id);
    var node = document.createTextNode(option);
    item.appendChild(node);
    $(path)[0].appendChild(item);
}


$('.currencies').click(function(){
    selectedCurrency = $(this).attr('id');
})

$('rates').click(function(){
    selectedDate = $(this).attr('id');
    let obj = array.find(o => o.date === selectedDate);
    if (selectedCurrency === "EUR") {
        rate = obj.rates.EUR;                
    } else if (selectedCurrency === "USD") {
        rate = obj.rates.USD;
    } else if (selectedCurrency === "GBP") {
        rate = obj.rates.GBP;
    }
    
    $("#displayRate").val(rate);
 })