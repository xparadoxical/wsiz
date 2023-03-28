//zad 2
function gcd(a, b) {
    //algorytm Euklidesa
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

//zad 4
let clock = document.getElementById("clock");

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

async function main() {

}

main();