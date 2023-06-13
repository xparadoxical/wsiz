class Pies {
    //1.i
    constructor(rasa, imie, rok_urodzenia, masa, wlasciciel) {
        this.rasa = rasa;
        this.imie = imie;
        this.rok_urodzenia = rok_urodzenia;
        this.masa = masa;
        this.wlasciciel = wlasciciel;
        this.id = Pies.getId();
    }

    //1.iv
    static getId() {
        //ceil([0, 1)) -> (0, 1] * 424 -> (0, 424] - 412 -> (-412, 12]
        return Math.ceil(Math.random() * 424 - 412);
    }

    //1.ii
    getAge() {
        let thisYear = parseInt(new Date().getFullYear());
        let birthYear = parseInt(this.rok_urodzenia);
        return thisYear - birthYear;
    }

    //1.iii
    logInfo() {
        console.log(`Imię: ${this.imie}`,
                    `Rasa: ${this.rasa}`,
                    `Rok urodzenia: ${this.rok_urodzenia}`,
                    `Wiek: ${this.getAge()} lat`,
                    `Masa: ${this.masa} kg`,
                    `Właściciel: ${this.wlasciciel}`,
                    `ID: ${this.id}`);
    }
}

let savedData = [];

//b.iv
//button fires a submit event with the parent form as the target
document.getElementsByTagName("form")[0].addEventListener("submit", (e) => {
    console.debug(e);
    e.preventDefault(); //don't run the form's action

    for (let input of e.target) {
        input.dispatchEvent(new InputEvent("input")); //request validation
        if (!input.checkValidity()) {
            input.reportValidity(); //show validation popup
            return;
        }
    }

    //b.i
    let pies = new Pies(e.target["rasa"].value,
                        e.target["imie"].value,
                        e.target["rok_urodzenia"].value,
                        e.target["masa"].value,
                        e.target["wlasciciel"].value);
    savedData.push(pies);
    //b.ii
    pies.logInfo();
});

//b.iii
document.getElementsByName("imie")[0].addEventListener("input", (e) => {
    console.debug(e, e.target.value.length);

    if (e.target.value.length == 0) {
        e.target.setCustomValidity("Pole nie może być puste.");
    } else {
        e.target.setCustomValidity("");
    }
});

document.getElementsByName("rok_urodzenia")[0].addEventListener("input", (e) => {
    console.debug(e, e.target.valueAsNumber);

    if (e.target.value.length == 0) {
        e.target.setCustomValidity("Pole nie może być puste.");
    } else if (e.target.valueAsNumber < 1950 || e.target.valueAsNumber > parseInt(new Date().getFullYear())) {
        e.target.setCustomValidity("Wartość jest poza zakresem: 1950 - obecny rok.");
    } else {
        e.target.setCustomValidity("");
    }
});