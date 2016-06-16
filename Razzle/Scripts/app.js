var app = angular.module('RazzleApp', []);


app.controller("HighScoreCtrl", function() {
    
    var self = this;

    self.test = "test";

    self.highScores = function () {
        $http.get("/api/HighScores")
            .then(function (response) {
                self.highScores = response.data;
            });
    };
    self.highScores();

});

app.controller("PlayerCtrl", function () {

    var self = this;

    self.nameOne = "";

    self.nameTwo = "";

});

app.controller("GameCtrl", function ($http, $interval) {

    var self = this;

    //TIMER
    var playerTurn = false;
    self.countdown = 30;

    var decrementCountdown = function () {
        console.log('decrementing counter');
        console.log(self.countdown);
        self.countdown = self.countdown -1;
        
        if (self.countdown == 0) {
            if (playerTurn == false) {
                alert("Player 2: Go!")
                playerTurn = true;
                self.countdown = 30;
                startCountdown();
            }
            else {
                alert("Player 1: Go!")
                playerTurn = false;
                self.countdown = 30;
                startCountdown();
            }
        };
        
    }
    var startCountdown = function () {
        $interval(decrementCountdown, 1000, 30);
    }
    startCountdown();
    //PUSH INFO TO APPROPRIATE PLAYER

    //ROUND
    var round = 1;

    var roundCounter = function() {
        if (round == (1 || 3 || 5)) {

        }
        else if(round == (2 || 4))
        {

        }
        else {
            //$http.post
        }
    }
    
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

    //DISABLE SECOND CLICK FOR GAMEBOARD
  

    self.lastClicked = null;

    //SENDING LETTERS INTO WORDBLOCK
    self.addLetter = function (letter, index) {
        var formWord = self.wordBlock.push(letter);
        self.lastClicked = index;
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
    self.apiResponse = {};

    self.wordsApiCall = function () {
        $http.get("https://wordsapiv1.p.mashape.com/words/" + combinedWord + "/definitions", {
            headers: {
                "X-Mashape-Key": "vrrLJRtlhvmshTV25EKMDHb8q4Bdp1oikJAjsnTaRqNDKf1vDi",
                "Accept": "application/json"
            }
        })
        .then(function (response) {
            self.apiResponse = response.data;
        },function(errorResponse) {
            console.log("Error", errorResponse)
        })
        self.wordBlock = [];
        combinedWord = "";
    }
    self.wordsApiCall();

    //USED WORDS AND POINTS LIST
    self.usedWordsAndPoints = {
        Words: [],
        Points: []
    }

    //
    var results = {
        playerOne: {
            name: "tim",
            words: [""],
            points: 8
        },
        playerTwo: {
            name: "jane",
            words: ["hello", "there"],
            points: 10
        }
    }

    //ADDING WORDS AND POINTS FUNCTION
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

    self.usedWordsAndPointsTester = self.pointCounter("tester");
 
});