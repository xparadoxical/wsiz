//zad 1
let tableHead = document.querySelector("#multiplication-table > thead");
let tableBody = document.querySelector("#multiplication-table > tbody");

let htmlHeader = "<tr><th></th>";

for (let col = 1; col <= 10; col++)
    htmlHeader += `<th>${col}</th>`;

htmlHeader += "</tr>";
tableHead.innerHTML += htmlHeader;

for (let row = 1; row <= 10; row++) {
    let htmlRow = `<tr><th>${row}</th>`;

    for (let col = 1; col <= 10; col++)
        htmlRow += `<td>${col * row}</td>`;

    htmlRow += "</tr>";
    tableBody.innerHTML += htmlRow;
}


//zad 2
let infoGrid = document.getElementById("info-grid");

let personalInfo = [];
let names = ["Andrzej", "Barbara", "Celina", "Damian", "Ewelina", "Filip", "Grzegorz", "Henryk", "Izabela", "Joanna", "Krzysztof", "Lidia", "Małgorzata", "Norbert", "Olga", "Przemysław", "Robert", "Szymon", "Tomasz", "Łukasz"];
let surnames = ["Nowak", "Wójcik", "Kowalczyk", "Woźniak", "Mazur", "Stępień", "Pawlak", "Walczak", "Lis", "Duda", "Bąk", "Kaźmierczak", "Krupa", "Mróz", "Sobczak"];

function randomInt(min, max) {
    return Math.floor(Math.random() * (max - min) + min);
}

document.getElementById("info-gen").addEventListener("submit", (event) => {
    event.preventDefault(); //don't send an http request with input values

    infoGrid.querySelectorAll(":not(.header-cell)").forEach((element) => infoGrid.removeChild(element));
    personalInfo = [];

    let count = event.srcElement.elements["count"].valueAsNumber;
    for (let i = 0; i < count; i++) {
        let p = {
            "name": names[randomInt(0, names.length)],
            "surname": surnames[randomInt(0, surnames.length)],
            "age": randomInt(18, 80 + 1),
            "phone": randomInt(5_000_000, 8_000_000 + 1)
        };

        personalInfo.push(p);
        console.log(p);
        infoGrid.innerHTML += `<div>${p.name} ${p.surname}</div><div>${p.age}</div><div>${p.phone}</div>`;
    }
});
