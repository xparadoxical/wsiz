//zad 2

function hasValue(input) {
    if (input.value.length == 0) {
        input.setCustomValidity("Pole nie może być puste.");
        return false;
    }

    return true;
}

function lengthAtLeastCore(input, length) {
    if (input.value.length < length) {
        input.setCustomValidity(`Ta wartość musi mieć długość przynajmniej ${length} znaków.`);
        return false;
    }

    return true;
}

function lengthAtLeast(length) {
    return (input) => lengthAtLeastCore(input, length);
}

function hasEmailAddress(input) {
    const emailRegex = /[a-z0-9_+\.]+@[a-z0-9_+\.]+\.(com|pl)/;
    if (!emailRegex.test(input.value)) {
        input.setCustomValidity("Wpisz poprawny adres e-mail.");
        return false;
    }

    return true;
}

function hasHardPassword(input) {
    const pass = input.value;
    
    if (!(pass.length >= 8 && /[a-zA-Z]/.test(pass) && /\d/.test(pass) && /[~`!@#$%^&*()-_=+\[\]{};:'",<.>/?]/.test(pass))) {
        input.setCustomValidity("Hasło musi mieć długość co najmniej 8 znaków oraz zawierać literę, cyfrę i znak specjalny.");
        return false;
    }

    return true;
}

function hasPhoneNumber(input) {
    if (!/^[1-9]\d{8}$/.test(input.value.trim())) {
        input.setCustomValidity("Nieprawidłowy numer telefonu.");
        return false;
    }

    return true;
}

const form = document.getElementsByTagName("form")[0];
document.getElementsByName("name")[0].addEventListener("input", (e) => validate(e.target, hasValue, lengthAtLeast(2)));
document.getElementsByName("surname")[0].addEventListener("input", (e) => validate(e.target, hasValue, lengthAtLeast(2)));
document.getElementsByName("email")[0].addEventListener("input", (e) => validate(e.target, hasValue, hasEmailAddress));
document.getElementsByName("password")[0].addEventListener("input", (e) => validate(e.target, hasValue, hasHardPassword));
document.getElementsByName("repeat-password")[0].addEventListener("input", (e) => validate(e.target, hasValue, hasRepeatedPassword));
document.getElementsByName("sex")[0].addEventListener("input", (e) => validate(e.target, hasNonDefaultSelection));
document.getElementsByName("phone")[0].addEventListener("input", (e) => validate(e.target, hasValue, hasPhoneNumber));
document.getElementsByName("birth")[0].addEventListener("input", (e) => validate(e.target, hasValue, hasAdultBirthDate));

form.addEventListener("submit", (e) => {
    e.preventDefault();

    for (let input of e.target.elements) {
        if (input.tagName == "INPUT" || input.tagName == "SELECT") {
            input.dispatchEvent(new InputEvent("input"));
        }
    }

    if (e.target.checkValidity())
        alert("✔️ Formularz wypełniony poprawnie");
});

function validate(input, ...validations) {
    let valid = true;
    if (!input.hidden && !input.disabled) {
        for (let validation of validations) {
            valid = validation(input);
            if (!valid)
                break;
        }
    }

    if (valid)
        input.setCustomValidity("");
    
    //zad 3
    //input.reportValidity();
    const next = input.nextElementSibling;
    if (next.tagName == "DIV")
        next.innerText = input.validationMessage;
}

//zad 4
function isAdultBirthDate(date) {
    let eighteenYearsAgo = new Date();
    eighteenYearsAgo.setFullYear(eighteenYearsAgo.getFullYear() - 18);
    console.debug(date, "now - 18y =", eighteenYearsAgo);

    return date <= eighteenYearsAgo;
}

function hasAdultBirthDate(input) {
    if (!isAdultBirthDate(input.valueAsDate)) {
        input.setCustomValidity("Musisz mieć 18 lat.");
        return false;
    }

    return true;
}

//zad 5
function hasRepeatedPassword(input) {
    const pass = document.getElementsByName("password")[0].value;
    if (input.value != pass) {
        input.setCustomValidity("Hasło w tym polu musi zgadzać się z tym wpisanym wyżej.");
        return false;
    }

    return true;
}

//zad 6
function hasNonDefaultSelection(select) {
    if (select.value == "placeholder") {
        select.setCustomValidity("Wybierz z listy.");
        return false;
    }

    return true;
}

const label = form.querySelector("[for='voivodeship']");
const voiText = document.getElementsByName("voivodeship-text")[0];
const voiSelect = document.getElementsByName("voivodeship-select")[0];

//zad 7
document.getElementsByName("country")[0].addEventListener("input", (e) => {
    const country = e.target;
    validate(country, hasNonDefaultSelection);
    
    if (!country.checkValidity()) {
        voiText.disabled = voiSelect.disabled = true;
        voiText.dispatchEvent(new InputEvent("input"));
        voiSelect.dispatchEvent(new InputEvent("input"));
        return;
    }

    let errorDiv = label.nextElementSibling.nextElementSibling;
    
    let ie = new InputEvent("input");

    if (country.value == "pl") {
        voiSelect.disabled = voiSelect.hidden = false;
        voiText.disabled = voiText.hidden = true;

        label.after(voiSelect);
        errorDiv.after(voiText);

        voiSelect.dispatchEvent(ie);
    } else {
        voiSelect.disabled = voiSelect.hidden = true;
        voiText.disabled = voiText.hidden = false;

        label.after(voiText);
        errorDiv.after(voiSelect);

        voiText.dispatchEvent(ie);
    }
});

//zad 6
const addr = document.getElementsByName("address")[0];
const contactAddr = document.getElementsByName("contact-address")[0];

function voivodeshipOnInput(e) {
    const voi = e.target;
    validate(voi, voi.tagName == "SELECT" ? hasNonDefaultSelection : hasValue);

    if (voi.hidden) return;

    if (voi.disabled)
        addr.disabled = contactAddr.disabled = true;
    else
        addr.disabled = contactAddr.disabled = !voi.checkValidity();

    addr.dispatchEvent(new InputEvent("input"));
    contactAddr.dispatchEvent(new InputEvent("input"));
}

voiText.addEventListener("input", voivodeshipOnInput);
voiSelect.addEventListener("input", voivodeshipOnInput);

const addrOnInput = (e) => validate(e.target, hasValue);
addr.addEventListener("input", addrOnInput);
contactAddr.addEventListener("input", addrOnInput);

document.getElementsByName("contact-address-same")[0].addEventListener("input", (e) => {
    contactAddr.hidden = contactAddr.previousElementSibling.hidden = e.target.checked;
    contactAddr.dispatchEvent(new InputEvent("input"));
});

