﻿var app = angular.module('RazzleApp', ["ngRoute"]);

app.config(function ($routeProvider) {
     $routeProvider
        .when("/", {
            templateUrl: "Templates/StartUp.html",
            controller: "StartUpCtrl as startUpCtrl"
        })
        .when("/Game", {
            templateUrl: "/Templates/Game.html",
            controller: "GameCtrl as gameCtrl"
        })
        .when("/HighScore", {
            templateUrl: "Templates/HighScore.html",
            controller: "HighScoreCtrl as highScoreCtrl"
        })
  	    .when("/Player", {
  	        templateUrl: "Templates/Player.html",
  	        controller: "PlayerCtrl as playerCtrl"
  	    })
        .when("/Rules", {
            templateUrl: "Templates/Rules.html",
            controller: "GameCtrl as gameCtrl"
        })
  		.otherwise({ redirectTo: "/" });
});

app.factory('players', function(){

    /*self = this;

    var storedObject;
    return {
        set: function (o) {
            self.storedObject = o;
        },
        get: function () {
            return self.storedObject;
        }
    };*/

    self = this;

    self.allPlayers = {
        playerOne: "",
        playerTwo: ""
    };


    return {
        set: function (oneplayer, twoplayer) {
            self.allPlayers.playerOne = oneplayer;
            self.allPlayers.playerTwo = twoplayer;
        },
        get: function () {
            return self.allPlayers;
        }
    };
});

app.controller("StartUpCtrl", function () {

    var self = this;

});


app.controller("HighScoreCtrl", function($http) {
    
    var self = this;

    self.test = "test";

    self.rawGameResults = {};

    var getGameResults = function () {
        $http.get("/api/GameResults")
            .then(function (response) {
                self.rawGameResults = response.data;
                console.log("Success!")
            }, function (errorResponse) {
                console.log("Error!");
            });
    };
    getGameResults();

});

app.controller("PlayerCtrl", function (players) {

    var self = this;

    /*self.setValue = function (value) {
        players.set(value);
    };*/

    self.nameOne = "";
    self.nameTwo = "";

    self.setPlayerValue = function (_oneplayer, _twoplayer) {
        players.set(_oneplayer, _twoplayer);
    }
});

app.controller("GameCtrl", function (players, $http, $interval) {

    var self = this;

    /*self.getValue = function () {
        self.value = players.get();
    };*/

    self.playerValue = {};

    self.getPlayerValue = function () {
        self.playerValue = players.get();
    }
    self.getPlayerValue();

    //TIMER

    var shakeBoard = 0;

    var playerTurn = false;//This means it's PlayerOne's turn
    self.countdown = 30;

    var decrementCountdown = function () {
        console.log('decrementing counter');
        console.log(self.countdown);
        self.countdown = self.countdown - 1;

        if (self.countdown == 0) {
            if (playerTurn == false) {
                addToPlayerPointBank(self.AddedTotal);
                self.AddedTotal = "";
                self.displayedWordsAndPoints = {words: [],points: []};
                shakeBoard++;
                alert("Player 2: Go!")
                playerTurn = true;
                self.countdown = 30;
                startCountdown();
            }
            else {
                addToPlayerPointBank(self.AddedTotal);
                self.AddedTotal = "";
                self.displayedWordsAndPoints = {words: [],points: []};
                shakeBoard++;
                alert("Player 1: Go!")
                gameGrid();
                playerTurn = false;
                self.countdown = 30;
                startCountdown();
            }
        }
    };

    var startCountdown = function () {
        $interval(decrementCountdown, 1000, 30);
    }
    startCountdown();
    
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

    self.testCombinedWord = combinedWord;


    self.tryThis = [];

    //CROSS REFERENCE WORDS.API
    self.apiResponse = {};

    self.wordsApiCall = function () {
        $http.get("https://wordsapiv1.p.mashape.com/words/" + combinedWord + "/also", {
            headers: {
                "X-Mashape-Key": "vrrLJRtlhvmshTV25EKMDHb8q4Bdp1oikJAjsnTaRqNDKf1vDi",
                "Accept": "application/json"
            }
        })
        .then(function (response) {
            console.log(response.data.word);
            var validWord = response.data.word;
            if (self.displayedWordsAndPoints.words.indexOf(validWord) == -1) {
                self.pointCounter(validWord);
                applyGetSum();
                self.apiResponse = "Great! Find another word."
            }
            else {
                self.apiResponse = "Word has already been used! Try again!"  
            }
            //response.data;
        }, function (errorResponse) {
            self.apiResponse = "Word does not exist! Try again."
        })
        //RESET FOR NEXT WORD
        self.wordBlock = [];
        combinedWord = "";
    }
     
    //USED WORDS AND POINTS LIST
    self.usedWordsAndPoints = {
        Words: [],
        Points: []
    }

    //ADD POINTS IN ARRAY

    //POINT BANK TO SEND TO FINAL POINTS

    self.playerPointBank = {
        playerOne: [],
        playerTwo: []
    }

    var addToPlayerPointBank = function (points) {
        if (playerTurn == false) {
            self.playerPointBank.playerOne.push(points)
        }
        else {
            self.playerPointBank.playerTwo.push(points)
        }
    };

    //DISPLAYING TOTAL POINTS PER ROUND
    self.AddedTotal = "";

    var getSumOfArray = function(total, num) {
        return total + num;
    };
    var applyGetSum = function () {
        self.AddedTotal = self.displayedWordsAndPoints.points.reduce(getSumOfArray);
    };

    //FINAL TALLY
    var results = {
        playerOne: {
            name: self.playerValue.playerOne,
            points: ""
        },
        playerTwo: {
            name: self.playerValue.playerTwo,
            points: ""
        }
    }

    //ADDING WORDS AND POINTS FUNCTION

    self.displayedWordsAndPoints = {
        words: [],
        points: []
    };


    self.pointCounter = function(x) {
        self.displayedWordsAndPoints.words.push(x);
        self.displayedWordsAndPoints.points.push(x.length);
        };

    //self.usedWordsAndPointsTester = pointCounter(combinedWord);
 
});