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
    var shakeBoard = 0;

    var playerTurn = false;
    self.countdown = 30;

    var decrementCountdown = function () {
        console.log('decrementing counter');
        console.log(self.countdown);
        self.countdown = self.countdown - 1;

        if (self.countdown == 0) {
            if (playerTurn == false) {
                shakeBoard++;
                alert("Player 2: Go!")
                playerTurn = true;
                self.countdown = 30;
                startCountdown();
            }
            else {
                shakeBoard++;
                alert("Player 1: Go!")
                gameGrid();
                playerTurn = false;
                self.countdown = 30;
                startCountdown();
            }
        }
    };

    var changeBoardAfterRound = function () {
        if (shakeBoard == (2 || 4)) {
            gameGrid();
        }
    };
    changeBoardAfterRound();

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
    var gameGrid = function () {
        $http.get("/api/games?p1&p2")
            .then(function (response) {
                self.gameBoard = response.data;
            });
    };
    gameGrid();

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
            self.usedWordsAndPoints.Points.push(x.length);
            self.usedWordsAndPoints.Words.push(x);
        }

    self.usedWordsAndPointsTester = self.pointCounter("word");
 
});