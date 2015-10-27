function getCaretPos(input) {
    if (document.selection && document.selection.createRange) {
        var range = document.selection.createRange(); var bookmark = range.getBookmark(); var caret_pos = bookmark.charCodeAt(2) - 2
    } else {
        if (input.setSelectionRange) var caret_pos = input.selectionStart
    } return caret_pos
} function setCaretPos(obj, pos) {
    if (obj.createTextRange) {
        var range = obj.createTextRange();
        range.move('character', pos);
        range.select()
    } else if (obj.selectionStart) {
        obj.focus();
        obj.setSelectionRange(pos, pos)
    }
}

$(document).ready(function () {
    $('input[data-type="en"]').keypress(function (e) {
        var code = e.keyCode ? e.keyCode : e.which;
        if (code > 255) {
            if (e.preventDefault) {
                e.preventDefault()
            } else { e.returnValue = false }
        }
    }); $('input[data-type="nu"]').keypress(function (e) {
        var code = e.keyCode ? e.keyCode : e.which;
        if ((!(code > 47 && code < 59))) {
            if (e.preventDefault) {
                e.preventDefault()
            } else { e.returnValue = false }
        }
    }); $('input[data-type="fa"], textarea[data-type="fa"]').keypress(function (e) {
        var codeArray = new Array(70);
        for (var i = 0; i < 70; i++) {
            codeArray[i] = new Array(2)
        } var acceptCodeArray = new Array(30);
        acceptCodeArray[0] = 48;
        acceptCodeArray[1] = 49;
        acceptCodeArray[2] = 50;
        acceptCodeArray[3] = 51;
        acceptCodeArray[4] = 52;
        acceptCodeArray[5] = 53;
        acceptCodeArray[6] = 54;
        acceptCodeArray[7] = 55;
        acceptCodeArray[8] = 56;
        acceptCodeArray[9] = 57;
        acceptCodeArray[10] = 32;
        acceptCodeArray[11] = 13;
        acceptCodeArray[12] = 27;
        acceptCodeArray[13] = 46;
        acceptCodeArray[14] = 8;
        acceptCodeArray[15] = 37;
        acceptCodeArray[16] = 38;
        acceptCodeArray[18] = 40;
        acceptCodeArray[19] = 9;
        acceptCodeArray[20] = 7;
        acceptCodeArray[21] = 36;
        acceptCodeArray[22] = 35;
        acceptCodeArray[23] = 192;
        acceptCodeArray[24] = 45;
        acceptCodeArray[25] = 41;
        acceptCodeArray[26] = 34;
        acceptCodeArray[27] = 47;
        codeArray[0][0] = 1569;
        codeArray[0][1] = 77;
        codeArray[1][0] = 1570;
        codeArray[1][1] = 72;
        codeArray[2][0] = 1571;
        codeArray[2][1] = 78;
        codeArray[3][0] = 1572;
        codeArray[3][1] = 86;
        codeArray[4][0] = 1575;
        codeArray[4][1] = 104;
        codeArray[5][0] = 1576;
        codeArray[5][1] = 102;
        codeArray[6][0] = 1578;
        codeArray[6][1] = 106;
        codeArray[7][0] = 1579;
        codeArray[7][1] = 101;
        codeArray[8][0] = 1580;
        codeArray[8][1] = 91;
        codeArray[9][0] = 1581;
        codeArray[9][1] = 112;
        codeArray[10][0] = 1582;
        codeArray[10][1] = 111;
        codeArray[11][0] = 1583;
        codeArray[11][1] = 110;
        codeArray[12][0] = 1584;
        codeArray[12][1] = 98;
        codeArray[13][0] = 1585;
        codeArray[13][1] = 118;
        codeArray[14][0] = 1586;
        codeArray[14][1] = 99;
        codeArray[15][0] = 1587;
        codeArray[15][1] = 115;
        codeArray[16][0] = 1588;
        codeArray[16][1] = 97;
        codeArray[17][0] = 1589;
        codeArray[17][1] = 119;
        codeArray[18][0] = 1590;
        codeArray[18][1] = 113;
        codeArray[19][0] = 1591;
        codeArray[19][1] = 120;
        codeArray[20][0] = 1592;
        codeArray[20][1] = 122;
        codeArray[21][0] = 1593;
        codeArray[21][1] = 117;
        codeArray[22][0] = 1594;
        codeArray[22][1] = 121;
        codeArray[23][0] = 1601;
        codeArray[23][1] = 116;
        codeArray[24][0] = 1602;
        codeArray[24][1] = 114;
        codeArray[25][0] = 1603; 
        codeArray[25][1] = 59;
        codeArray[26][0] = 1604;
        codeArray[26][1] = 103;
        codeArray[27][0] = 1605;
        codeArray[27][1] = 108;
        codeArray[28][0] = 1606;
        codeArray[28][1] = 107;
        codeArray[29][0] = 1607;
        codeArray[29][1] = 105;
        codeArray[30][0] = 1608;
        codeArray[30][1] = 44;
        codeArray[31][0] = 1610;
        codeArray[31][1] = 100;
        codeArray[32][0] = 1688;
        codeArray[32][1] = 67;
        codeArray[33][0] = 1572;
        codeArray[33][1] = 86;
        codeArray[34][0] = 1662;
        codeArray[34][1] = 92;
        codeArray[35][0] = 1670;
        codeArray[35][1] = 93;
        codeArray[36][0] = 1711;
        codeArray[36][1] = 39;
        codeArray[37][0] = 1548;
        codeArray[37][1] = 84;
        codeArray[38][0] = 1563;
        codeArray[38][1] = 89;
        codeArray[39][0] = 1569;
        codeArray[39][1] = 77;
        codeArray[40][0] = 1574;
        codeArray[40][1] = 109;
        codeArray[41][0] = 1571;
        codeArray[41][1] = 78;
        $(this).css('direction', 'rtl');
        $(this).css('text-align', 'right');
        $(this).attr('dir', 'rtl');
        var findChar = false;
        var code = e.keyCode || e.which;
        code = e.keyCode ? e.keyCode : e.which;
        if (e.which == 0 && e.keyCode == 39 && e.charCode == 0) {
            return true
        } for (var i = 0; i < 30; i++) {
            if (code == acceptCodeArray[i]) {
                return true
            }
        } for (var i = 0; i < 70; i++) {
            if (codeArray[i][1] == code) {
                var start = $(this).val().substring(0, getCaretPos(this));
                var end = $(this).val().substring(getCaretPos(this));
                var pos = getCaretPos(this);
                $(this).val(start + String.fromCharCode(codeArray[i][0]) + end);
                setCaretPos(this, pos + 1);
                findChar = true; return false
            }
        }
        if (!findChar) {
            Message.alert('برای تایپ فارسی و عملکرد صحیح صفحه کلید، لطفا صفحه کلید خود را به حالت انگلیسی قرار دهید.\n\nهمچنین Caps Lock صفحه کلید خود را خاموش کنید... ');
            return false;
        }
    })
});