module com.paradoxical.lab1_2 {
    requires javafx.controls;
    requires javafx.fxml;


    opens com.paradoxical.lab1_2 to javafx.fxml;
    exports com.paradoxical.lab1_2;
}