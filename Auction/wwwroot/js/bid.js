"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/Bid/BidItemAsync").build();

//Disable the send button until connection is established.
/*document.getElementById("sendBid").disabled = true;*/

connection.on("Receive", function (currentBid) {
    var span = document.getElementById("currentPrice");
    
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    span.textContent = `${currentBid}`;
});

connection.start().then(function () {
/*    document.getElementById("sendBid").disabled = false;*/
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendBid").addEventListener("click", function () {
    var lastBid = document.getElementById("lastBid").value;
    var currentPrice = document.getElementById("currentPrice").textContent;
    connection.invoke("Send", lastBid, currentPrice).catch(function (err) {
        return console.error(err.toString());
    });
    /*event.preventDefault();*/
});