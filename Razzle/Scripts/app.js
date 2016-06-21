﻿var app = angular.module('RazzleApp', []);


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

    self.nameOne = "";

    self.nameTwo = "";

    //TIMER
    var shakeBoard = 0;

    var playerTurn = false;
    //self.countdown = 30;

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

    //var startCountdown = function () {
      //  $interval(decrementCountdown, 1000, 30);
    //}
    //startCountdown();

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
    var wordIsActualWord = false;

    self.apiResponse = {};

    self.wordsApiCall = function () {
        $http.get("https://wordsapiv1.p.mashape.com/words/" + combinedWord + "/definitions", {
            headers: {
                "X-Mashape-Key": "vrrLJRtlhvmshTV25EKMDHb8q4Bdp1oikJAjsnTaRqNDKf1vDi",
                "Accept": "application/json"
            }
        })
        .then(function (response) {
            
            self.apiResponse = "Great! Find another word."//response.data;
            wordIsActualWord = true;
            console.log(wordIsActualWord);
            if (wordIsActualWord == true) {
                pointCounter("test");
            };
            
        },function(errorResponse) {
            //console.log(errorResponse.statusText)
            self.apiResponse = "Word does not exist"
            console.log("combinedWord", combinedWord);
        })
        console.log("wordIsActualWord", wordIsActualWord);
        console.log("combinedWord", combinedWord);
        self.wordBlock = [];
        combinedWord = "";
        wordIsActualWord = false;
    }
    //self.wordsApiCall();

    


    //USED WORDS AND POINTS LIST
    self.usedWordsAndPoints = {
        Words: [],
        Points: []
    }

    //
    var results = {
        playerOne: {
            name: {},
            words: [],
            points: []
        },
        playerTwo: {
            name: {},
            words: [],
            points: []
        }
    }

    //ADDING WORDS AND POINTS FUNCTION


    var pointCounter = function(x) {
            if (playerTurn == false) {
                results.playerOne.points.push(x.length);
                results.playerOne.words.push(x);
                console.log("playerOne", results.playerOne);
            }
            else {
                results.playerTwo.points.push(x.length);
                results.playerTwo.words.push(x);
                console.log("playerTwo", results.playerTwo);
            }
        }

    //self.usedWordsAndPointsTester = pointCounter(combinedWord);
 
});