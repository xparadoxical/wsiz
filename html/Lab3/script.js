function delay(time) {
    return new Promise(resolve => setTimeout(resolve, time));
}

async function main() {
    //zad 3
    let a = 10;
    let b = 20;
    let c = 23.2;

    let result = c * b / (a + b - c);
    alert(result);

    //zad 3.1
    document.getElementById("math").innerHTML = result;

    await delay(1000);

    //zad 4
    let name = prompt("Jak masz na imię?");
    alert(`Witaj, ${name}!`);

    await delay(500);

    //zad 5
    alert("Pole trójkąta");
    a = parseInt(prompt("Bok a:"));
    b = parseInt(prompt("Bok b:"));
    c = parseInt(prompt("Bok c:"));
    let p = (a + b + c) / 2;
    let area = Math.sqrt(p * (p - a) * (p - b) * (p - c));
    document.getElementById("triangle").innerHTML = `Pole trójkąta o bokach ${a}, ${b}, ${c} wynosi ${area}.`;

    await delay(2000);

    //zad 6
    //[0,1) * 5 -> [0,5) + 1 -> [1,6)
    let number = Math.floor(Math.random() * 5 + 1);
    let guess = prompt("Spróbuj odgadnąć wylosowaną liczbę całkowitą z przedziału od 1 do 5:");
    alert(guess == number ? "Dobra robota!" : "Nie pasuje.");

    await delay(500);

    //zad 7
    let max = null;
    alert("Szukanie największej liczby:")
    for (let i = 0; i < 3; i++) {
        let number = parseInt(prompt(`Liczba nr ${i + 1}:`));
        if (max === null || number > max) {
            max = number;
        }
    }
    alert(`Największa z podanych liczb to ${max}.`);
};

main();