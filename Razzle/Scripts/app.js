var app = angular.module('RazzleApp', []);


app.controller("PlayerCtrl", function () {

    var self = this;

});

app.controller("GameCtrl", function ($http) {

    var self = this;
    //BLANK GAMEBOARD
    self.gameBoard = {};

    //GET BOARD DATA
    self.gameBoard = function () {
        $http.get("/api/games?p1&p2")
            .then(function (response) {
                self.gameBoard = response.data;
            });
    };
    self.gameBoard();

    //ESTABLISH WORD BLOCK
    self.wordBlock = [];

    //SENDING LETTERS INTO WORDBLOCK
    self.addLetter = function (x) {
        var formWord = self.wordBlock.push(x);
        return formWord;
    };

    //COMBINE LETTERS TO FORM WORD
    self.combineLetters = function () {
        var combinedLetters = self.wordBlock.join("");
        return combinedLetters;
    }

    //CROSS REFERENCE WORDS.API
    self.wordsApiCall = {};

    self.wordsApiCall = function () {
        $http.get("https://wordsapiv1.p.mashape.com/words/test/definitions?accessToken=vrrLJRtlhvmshTV25EKMDHb8q4Bdp1oikJAjsnTaRqNDKf1vDi")
        .then(function (response) {
            self.wordsApiCall = response.data;
        });     
    }
    self.wordsApiCall();
});