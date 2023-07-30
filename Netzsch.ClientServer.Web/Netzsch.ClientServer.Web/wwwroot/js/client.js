'use strict';

var connection = new signalR.HubConnectionBuilder().withUrl('/serverHub').build();

connection.on('ReceiveMessage', function (inputValue, outputValue) {
    document.getElementById('input').value = inputValue;
    document.getElementById('output').value = outputValue;
});

connection.start().then(function () {
    document.getElementById('input').disabled = true;
    document.getElementById('output').disabled = true;
}).catch(function (err) {
    return console.error(err.toString());
});