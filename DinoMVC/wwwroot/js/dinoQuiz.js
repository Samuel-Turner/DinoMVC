var quizQuestion;
var dinosaurs = [{ id: "temp", name: "temp", diet: "temp", period: "temp" }];
var currentDinoNo = 0;
var diet = true;
$(document).ready(function () {
    document.getElementById("Button1").addEventListener("click", button1Click);
    document.getElementById("Button2").addEventListener("click", button2Click);
    document.getElementById("Button3").addEventListener("click", button3Click);
    loadQuiz();
});

function loadQuiz() {
    //document.getElementById('Label_load').innerHTML = 'dog';
    $(function () {
        $.get("/dinogame/getalldino", function (data, status) {
            $.each(data, function (i, dinosaur) {
                //alert(dinosaur.name);
                dinosaurs[i] = { id: dinosaur.id, name: dinosaur.name, diet: dinosaur.diet, period: dinosaur.period };
                document.getElementById("DinoName").innerHTML = " What was this dinosaurs diet: " + dinosaurs[0].name + "?";
            });
        });
    });
}
function button1Click() {
    isCorrect(currentDinoNo, "Button1");
}
function button2Click() {
    isCorrect(currentDinoNo, "Button2");
}
function button3Click() {
    isCorrect(currentDinoNo, "Button3");
}

function isCorrect(i, but) {
    var compareVariable = "";
    if (diet) {
        compareVariable = dinosaurs[i].diet;
    }
    else {
        compareVariable = dinosaurs[i].period;
    }
    if (compareVariable == document.getElementById(but).innerHTML) {
        document.getElementById("isCorrect").innerHTML = "Yous Correct";
        Game.ammo++;
        currentDinoNo += 1;
        if ((currentDinoNo >= dinosaurs.length) && (diet)) {
            //alert("u should of just answereed eoraptor");
            diet = false;
            currentDinoNo = 0;
            document.getElementById("Button1").innerHTML = "Cretaceous";
            document.getElementById("Button2").innerHTML = "Jurassic";
            document.getElementById("Button3").innerHTML = "Triassic";
            document.getElementById("DinoName").innerHTML = " When was this dinosaur alive: " + dinosaurs[currentDinoNo].name + "?";
        }
        else if ((currentDinoNo >= dinosaurs.length) && (!diet)) {
            //alert("u should of just answereed eoraptor");
            diet = true;
            currentDinoNo = 0;
            document.getElementById("Button1").innerHTML = "Herbivore";
            document.getElementById("Button2").innerHTML = "Omnivore";
            document.getElementById("Button3").innerHTML = "Carnivore";
            document.getElementById("DinoName").innerHTML = " What was this dinosaurs diet: " + dinosaurs[currentDinoNo].name + "?";
        }
        else {
            if (!diet) {
                document.getElementById("DinoName").innerHTML = " When was this dinosaur alive: " + dinosaurs[currentDinoNo].name + "?";
            }
            else {
                document.getElementById("DinoName").innerHTML = " What was this dinosaurs diet: " + dinosaurs[currentDinoNo].name + "?";
            }
        }
    }
    else {
        document.getElementById("isCorrect").innerHTML = "Not even close";
    }
}

/*$.ajax({
    type: 'GET',
    url: "@Url.Content(" / Dino / GetAll / ")",
    data: {
        parameter1: value1,
        parameter1: value2
    },
    dataType: datatype,
    success: function (result) {
        alert(document.getElementById("DinoName").innerHTML);           
    }
});*/