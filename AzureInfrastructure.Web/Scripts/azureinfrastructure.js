var azi = azi || {};

$(function () {
    $liveTraceBadge = $('#liveTraceBadge');
    $liveTraceBadge.toggle();
    azi.EnableLiveTracePulse($liveTraceBadge)
})

azi.EnableLiveTracePulse = function ($pulseElement) {
    if ($pulseElement === undefined) return;

    traceHub = $.connection.liveTraceSignalRHub;
    if (traceHub === undefined) {
        console.error("Error creating SignalR *Hub* for LiveTrace. LiveTrace pulse will not work.");
        return;
    }

    traceHub.client.receiveTraceMesssage = function (message) {
        for (var i = 0; i < 5; i++){
            $pulseElement.fadeIn(200);
            $pulseElement.fadeOut(400);
        }
    }

    try {
        $.connection.hub.start();
    } catch (e) {
        console.error("Error starting SignalR *Hub Connection* for LiveTrace {0}. LiveTrace pulse will not work.", e.description);
    }
}

azi.Config = function () {
}