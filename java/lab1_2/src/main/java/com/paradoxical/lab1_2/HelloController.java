package com.paradoxical.lab1_2;

import javafx.fxml.FXML;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;

public class HelloController {
    @FXML
    private TextField input;
    @FXML
    private Label stats;

    @FXML
    private void displayClicked() {
        String s = input.getText();

        int visibleChars = 0;
        for (char c : s.toCharArray()) {
            if (!Character.isSpaceChar(c))
                visibleChars++;
        }

        int words = s.isEmpty() ? 0 : s.split(" ").length;

        stats.setText("Liczba znaków: " + visibleChars + " Liczba słów: " + words);
    }
}