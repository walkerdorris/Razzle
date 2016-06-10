angular.module("RazzleApp", []);

app.controller("PlayerCtrl", function () {

    var self = this;

});

app.controller("GameCtrl", function () {

    var self = this;

    //DICE
    var die_one = ["A","A","C","I","O","T"];
    var die_two = ["A","B","I","L","T","Y"];
    var die_three = ["A","B","J","M","O","Qu"];
    var die_four = ["A","C","D","E","M","P"];
    var die_five = ["A","C","E","L","R","S"];
    var die_six = ["A","D","E","N","V","Z"];
    var die_seven = ["A","H","M","O","R","S"];
    var die_eight = ["B","I","F","O","R","X"];
    var die_nine = ["D","E","N","O","S","W"];
    var die_ten = ["D","K","N","O","T","U"];
    var die_eleven = ["E","E","F","H","I","Y"];
    var die_twelve = ["E","G","K","L","U","Y"];
    var die_thirteen = ["E","G","I","N","T","V"];
    var die_fourteen = ["E","H","I","N","P","S"];
    var die_fifteen = ["E","L","P","S","T","U"];
    var die_sixteen = ["G","I","L","R","U","W"];
    
    //PICKING RANDOM STRING FROM ONE DIE TEST
    var die_roll = die_one[Math.floor(Math.random() * die_one.length)];

});