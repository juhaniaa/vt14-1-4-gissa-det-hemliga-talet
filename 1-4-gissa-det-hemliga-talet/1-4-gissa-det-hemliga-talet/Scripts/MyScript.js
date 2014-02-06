
function send() {

    var guessBox = document.getElementById("userGuessBox");
    guessBox.focus();
    guessBox.select();
}

nextNumber = function () {
    var nextButton = document.getElementById("newNumberButton");
    nextButton.focus();
    nextButton.select();
}

window.onload = send();