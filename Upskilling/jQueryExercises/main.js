$(document).ready(function () {

    // Exercise 1: log "Hello World!" via jQuery
    console.log($('#helloWorld').text());

    // Exercise 2: $() selecting + changing text + hiding a paragraph
    $('#ex2Btn').click(function () {
        $('#ex2Heading').text('Heading changed by jQuery!');
        $('#ex2ParaA').hide();
    });

    // Exercise 3: common methods
    $('#hideBtn').click(function () { $('.box').hide(); });
    $('#showBtn').click(function () { $('.box').show(); });
    $('#fadeOutBtn').click(function () { $('.box').fadeOut(); });
    $('#fadeInBtn').click(function () { $('.box').fadeIn(); });
    $('#toggleBtn').click(function () { $('.box').toggle(); });
    // Bonus: chained methods
    $('#chainBtn').click(function () {
        $('.box').slideUp().delay(1000).slideDown();
    });

    // Exercise 4: DOM manipulation - add/remove list items
    $('#listForm').submit(function (e) {
        e.preventDefault();
        const value = $('#listInput').val().trim();
        if (!value) return;
        $('<li>').text(value).appendTo('#itemList');
        $('#listInput').val('');
    });
    $('#removeAllBtn').click(function () {
        $('#itemList').empty();
    });

    // Exercise 5: click / dblclick toggle a box's color
    $('#colorBtn').click(function () {
        $('#colorBox').css('background-color', 'red');
    });
    $('#colorBox').dblclick(function () {
        $(this).css('background-color', 'white');
    });

    // Exercise 6: mouse + keyboard event helpers
    $('#eventDiv')
        .click(function () { $(this).text('Clicked!'); })
        .dblclick(function () { $(this).text('Double-clicked!'); })
        .mouseenter(function () { $(this).css('background-color', '#cfe6ff'); })
        .mouseleave(function () { $(this).css('background-color', '#e8f2ff'); });

    $('#keyInput').keypress(function () {
        $('#eventDiv').text('Typing: ' + $('#keyInput').val());
    });
});
