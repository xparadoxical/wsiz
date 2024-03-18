package com.paradoxical.lab1_1;

import javafx.fxml.FXML;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;

public class HelloController {
    @FXML
    private TextField input1;
    @FXML
    private TextField input2;
    @FXML
    private Label output;

    private static double getNumber(TextField t) throws NumberFormatException {
        return Double.parseDouble(t.getText());
    }

    private void setOutput(double d) {
        output.setText("Wynik: " + d);
    }

    private void displayError() {
        output.setText("Nieprawidłowe dane");
    }

    @FXML
    public void addClicked() {
        try {
            double a = getNumber(input1);
            double b = getNumber(input2);
            setOutput(a + b);
        } catch (Exception e) {
            displayError();
        }
    }

    @FXML
    public void subtractClicked() {
        try {
            double a = getNumber(input1);
            double b = getNumber(input2);
            setOutput(a - b);
        } catch (Exception e) {
            displayError();
        }
    }

    @FXML
    public void multiplyClicked() {
        try {
            double a = getNumber(input1);
            double b = getNumber(input2);
            setOutput(a * b);
        } catch (Exception e) {
            displayError();
        }
    }

    @FXML
    public void divideClicked() {
        try {
            double a = getNumber(input1);
            double b = getNumber(input2);
            setOutput(a / b);
        } catch (Exception e) {
            displayError();
        }
    }
}