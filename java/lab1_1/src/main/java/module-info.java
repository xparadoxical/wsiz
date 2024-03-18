module com.paradoxical.lab1_1 {
    requires javafx.controls;
    requires javafx.fxml;


    opens com.paradoxical.lab1_1 to javafx.fxml;
    exports com.paradoxical.lab1_1;
}