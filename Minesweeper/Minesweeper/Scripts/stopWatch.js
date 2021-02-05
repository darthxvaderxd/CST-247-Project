// Stopwatch logic
var sw = {
    elapsedTime: null, // HTML time display
    timer: null, // timer object
    now: 0, // current elapsed time
    init: function () {
        // Get HTML element for displaying time
        sw.elapsedTime = document.getElementById("sw-time");
    },

    // Advance time
    tick: function () {
        // Calculate time
        sw.now++;
        var remain = sw.now;
        var hours = Math.floor(remain / 3600);
        remain -= hours * 3600;
        var mins = Math.floor(remain / 60);
        remain -= mins * 60;
        var secs = remain;

        // Update HTML element
        if (hours < 10) { hours = "0" + hours; }
        if (mins < 10) { mins = "0" + mins; }
        if (secs < 10) { secs = "0" + secs; }
        sw.elapsedTime.innerHTML = hours + ":" + mins + ":" + secs;
    },

    // Start timer
    start: function () {
        sw.timer = setInterval(sw.tick, 1000);
    },

    // Stop timer
    stop: function () {
        clearInterval(sw.timer);
        sw.timer = null;
    },

    // Reset timer
    reset: function () {
        if (sw.timer != null) { sw.stop(); }
        sw.now = -1;
        sw.tick();
    }
};

// Initialize timer
if (sw.timer == null) {
    sw.init();
};