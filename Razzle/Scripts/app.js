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
    
    //PICKING RANDOM STRING FROM DICE
    var die_roll_one = die_one[Math.floor(Math.random() * die_one.length)];
    var die_roll_two = die_two[Math.floor(Math.random() * die_two.length)];
    var die_roll_three = die_three[Math.floor(Math.random() * die_three.length)];
    var die_roll_four = die_four[Math.floor(Math.random() * die_four.length)];
    var die_roll_five = die_five[Math.floor(Math.random() * die_five.length)];
    var die_roll_six = die_six[Math.floor(Math.random() * die_six.length)];
    var die_roll_seven = die_seven[Math.floor(Math.random() * die_seven.length)];
    var die_roll_eight = die_eight[Math.floor(Math.random() * die_eight.length)];
    var die_roll_nine = die_nine[Math.floor(Math.random() * die_nine.length)];
    var die_roll_ten = die_ten[Math.floor(Math.random() * die_ten.length)];
    var die_roll_eleven = die_eleven[Math.floor(Math.random() * die_eleven.length)];
    var die_roll_twelve = die_twelve[Math.floor(Math.random() * die_twelve.length)];
    var die_roll_thirteen = die_thirteen[Math.floor(Math.random() * die_thirteen.length)];
    var die_roll_fourteen = die_fourteen[Math.floor(Math.random() * die_fourteen.length)];
    var die_roll_fifteen = die_fifteen[Math.floor(Math.random() * die_fifteen.length)];
    var die_roll_sixteen = die_sixteen[Math.floor(Math.random() * die_sixteen.length)];

    //UNSHUFFLED GAMEBOARD
    var unshuffled_gameboard = [die_roll_one, die_roll_two, die_roll_three, die_roll_four,
        die_roll_five, die_roll_six, die_roll_seven, die_roll_eight, die_roll_nine, die_roll_ten,
        die_roll_eleven, die_roll_twelve, die_roll_thirteen, die_roll_fourteen, die_roll_fifteen,
        die_roll_sixteen]

    //SHUFFLE FUNCTION
    function shuffle(array) {
        var currentIndex = array.length, temporaryValue, randomIndex;

        // While there remain elements to shuffle...
        while (0 !== currentIndex) {

            // Pick a remaining element...
            randomIndex = Math.floor(Math.random() * currentIndex);
            currentIndex -= 1;

            // And swap it with the current element.
            temporaryValue = array[currentIndex];
            array[currentIndex] = array[randomIndex];
            array[randomIndex] = temporaryValue;
        }

        return array;
    }

    var shuffled_gameboard = shuffle(unshuffled_gameboard);
    

    self.GameBoard = shuffled_gameboard;

});