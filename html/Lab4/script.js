//zad 1
for (let i = 3; i >= 0; i--) {
    if (i > 0)
        console.log(i);
    else
        console.log("Happy New Year!");
}

let i = 3;
while (i >= 0) {
    if (i > 0)
        console.log(i);
    else
        console.log("Happy New Year!");
    i--;
}


//zad 2
function gcd(a, b) {
	if (a === b && a === 0)
		return 0;

    if (b > a) {
        //swap
        let temp = a;
        a = b;
        b = temp;
    }

    let mod = a % b;
    if (mod != 0)
        return gcd(b, mod);
    else
        return b; //previous modulo
}

let gcdForm = document.getElementById("gcd");
let gcdOutput = document.getElementById("gcd-output");

gcdForm.addEventListener("submit", (event) => {
	event.preventDefault();

	let a = gcdForm.elements["a"].valueAsNumber;
	let b = gcdForm.elements["b"].valueAsNumber;
	let result = gcd(a, b);
	gcdOutput.innerHTML = `NWD(${a}, ${b}) = ${result}`;
});


//zad 3
let calcA = document.getElementById("a");
let calcOp = document.getElementById("operation");
let calcB = document.getElementById("b");
let calcExecute = document.getElementById("calculate");
let calcResult = document.getElementById("result");

let operations = {
    "addition": (a, b) => a + b,
    "subtraction": (a, b) => a - b,
    "division": (a, b) => {
        let result = a / b;
        return [true, b !== 0, result];
    },
    "multiplication": (a, b) => a * b,
    "power": Math.pow
};

function validate(input, invalid = false) {
    if (invalid || input.valueAsNumber === NaN) {
        calcResult.value = "";
        input.style.backgroundColor = "rgba(255, 0, 0, 30%)";
        return false;
    }

    input.style.backgroundColor = "";
    return true;
}

calcExecute.addEventListener("click", (event) => {
    let a = calcA.valueAsNumber;
    let b = calcB.valueAsNumber;
    let aValid = validate(calcA);
    let bValid = validate(calcB);

    let result = operations[calcOp.value](a, b);

    if (Array.isArray(result)) {
        aValid = result[0];
        bValid = result[1];
        result = result[2];

        if (!aValid) {
            validate(calcA, true);
            return;
        }
        if (!bValid) {
            validate(calcB, true);
            return;
        }
    }
    
    calcResult.value = result;
});


//zad 4
let clock = document.getElementById("clock-time");

function updateClock() {
    let now = new Date();
    let h = now.getHours().toString().padStart(2, "0");
    let m = now.getMinutes().toString().padStart(2, "0");
    let s = now.getSeconds().toString().padStart(2, "0");
    clock.innerHTML = `${h}:${m}:${s}`;
}

updateClock();
setTimeout(() => {
    updateClock();
    setInterval(updateClock, 1000);
}, 1000 - new Date().getMilliseconds());
