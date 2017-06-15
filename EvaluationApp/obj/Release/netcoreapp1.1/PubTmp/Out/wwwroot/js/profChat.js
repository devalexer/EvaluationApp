$(function () {
    var userName = '@Model';

    var protocol = location.protocol === "https:" ? "wss:" : "ws:";
    var wsUri = protocol + "//" + window.location.host;
    var socket = new WebSocket(wsUri);
    socket.onopen = e => {
        console.log("socket opened", e);
    };

    socket.onclose = function (e) {
        console.log("socket closed", e);
    };

    socket.onmessage = function (e) {
        console.log(e);
        $('#msgs').append(e.data + '<br />');
    };

        var message = userName + ": " + $('#MessageField').val();
        socket.send(message);
        $('#MessageField').val('');
    });
});