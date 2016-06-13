var app = angular.module('RazzleApp', []);


app.controller("PlayerCtrl", function () {

    var self = this;

});

app.controller("GameCtrl", function ($http) {

    var self = this;

    self.gameBoard = {};

    self.test = "test";

    self.gameBoard = function () {
        $http.get("/api/games?p1&p2")
            .then(function (response) {
                self.gameBoard = response.data;
            });
    };
    self.gameBoard();

    self.word = [];

    self.addLetter = function (x) {
        var formWord = self.word.push(x);
        return formWord;
    }
});