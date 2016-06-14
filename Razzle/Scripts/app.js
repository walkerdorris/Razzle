var app = angular.module('RazzleApp', []);


app.controller("PlayerCtrl", function () {

    var self = this;

    self.nameOne = "";

    self.nameTwo = "";

});

app.controller("GameCtrl", function ($http) {

    var self = this;

    //TIMER
    self.timer="";

    (function countdown(remaining) {
        if (remaining === 0)
            location.reload(true);
        self.timer = remaining;
        setTimeout(function () { countdown(remaining - 1); }, 1000);
    })(30);

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
    var combinedWord = "";

    self.combineLetters = function () {
        var combinedLetters = self.wordBlock.join("");
        combinedWord = combinedLetters;
        return combinedWord;
    }

    //CROSS REFERENCE WORDS.API
    self.wordsApiCall = {};

    self.wordsApiCall = function () {
        $http.get("https://wordsapiv1.p.mashape.com/words/" + combinedWord + "/definitions", {
            headers: {
                "X-Mashape-Key": "vrrLJRtlhvmshTV25EKMDHb8q4Bdp1oikJAjsnTaRqNDKf1vDi",
                "Accept": "application/json"
            }
        })
        .then(function (response) {
            self.wordsApiCall = response.data;
        }).error(function (response) {
            self.wordsApiCall = response.status;
        })
    }
    self.wordsApiCall();

    //USED WORDS AND POINTS
    self.usedWordsAndPoints = {
        Words: [],
        Points: []
    }

    //POINTS
    self.points = 0;

    self.pointCounter = function(x) {
        if (x.length == 0) {
            self.usedWordsAndPoints.Points.push(0);
            self.usedWordsAndPoints.Words.push(x);
        }
        else if (x.length == 1) {
            self.usedWordsAndPoints.Points.push(1);
            self.usedWordsAndPoints.Words.push(x);
        }
        else if (x.length == 2) {
            self.usedWordsAndPoints.Points.push(2);
            self.usedWordsAndPoints.Words.push(x);
        }
        else if (x.length == 3) {
            self.usedWordsAndPoints.Points.push(3);
            self.usedWordsAndPoints.Words.push(x);
        }
        else if (x.length == 4) {
            self.usedWordsAndPoints.Points.push(4);
            self.usedWordsAndPoints.Words.push(x);
        }
        else if (x.length == 5) {
            self.usedWordsAndPoints.Points.push(5);
            self.usedWordsAndPoints.Words.push(x);
        }
        else if (x.length == 6) {
            self.usedWordsAndPoints.Points.push(6);
            self.usedWordsAndPoints.Words.push(x);
        }
        else if (x.length == 7) {
            self.usedWordsAndPoints.Points.push(7);
            self.usedWordsAndPoints.Words.push(x);
        }
        else if (x.length == 8) {
            self.usedWordsAndPoints.Points.push(8);
            self.usedWordsAndPoints.Words.push(x);
        }
        else if (x.length == 9) {
            self.usedWordsAndPoints.Points.push(9);
            self.usedWordsAndPoints.Words.push(x);
        }
        else if (x.length == 10) {
            self.usedWordsAndPoints.Points.push(10);
            self.usedWordsAndPoints.Words.push(x);
        }
        else if (x.length == 11) {
            self.usedWordsAndPoints.Points.push(11);
            self.usedWordsAndPoints.Words.push(x);
        }
        else if (x.length == 12) {
            self.usedWordsAndPoints.Points.push(12);
            self.usedWordsAndPoints.Words.push(x);
        }
        else if (x.length == 13) {
            self.usedWordsAndPoints.Points.push(13);
            self.usedWordsAndPoints.Words.push(x);
        }
        else if (x.length == 14) {
            self.usedWordsAndPoints.Points.push(14);
            self.usedWordsAndPoints.Words.push(x);
        }
        else if (x.length == 15) {
            self.usedWordsAndPoints.Points.push(15);
            self.usedWordsAndPoints.Words.push(x);
        }
        else {
            self.usedWordsAndPoints.Points.push(16);
            self.usedWordsAndPoints.Words.push(x);
        }
    }    
});