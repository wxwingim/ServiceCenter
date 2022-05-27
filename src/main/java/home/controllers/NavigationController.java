package home.controllers;

import javafx.scene.Node;

public interface NavigationController {
    Node getView();
    void setView(Node view);

    void Show();
}
