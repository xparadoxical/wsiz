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
let genForm = document.getElementById("")

let personalInfo = [];
let names = ["Andrzej", "Barbara", "Celina", "Damian", "Ewelina", "Filip", "Grzegorz", "Henryk", "Izabela", "Joanna", "Krzysztof", "Lidia", "Małgorzata", "Norbert", "Olga", "Przemysław", "Robert", "Szymon", "Tomasz", "Łukasz"];
let surnames = ["Nowak", "Wójcik", "Kowalczyk", "Woźniak", "Mazur", "Stępień", "Pawlak", "Walczak", "Lis", "Duda", "Bąk", "Kaźmierczak", "Krupa", "Mróz", "Sobczak"];

for (let i = 0; i < 20; i++) {
    let p = {
        "name": names[Math.floor(Math.random() * names.length)], //[0, len)
        "surname": surnames[Math.floor(Math.random() * surnames.length)], //[0, len)
        "age": Math.floor(Math.random() * (80 - 18 + 1) + 18), //[0, 1) * 63 -> [0, 63) + 18 -> [18, 81)
        "phone": Math.floor(Math.random() * (8_000_000 - 5_000_000 + 1) + 5_000_000) //[0, 1) * 3_000_001 -> [0, 3_000_001) + 5mln -> [5mln, 8_000_001)
    };
    personalInfo.push(p);
    console.log(p);
}