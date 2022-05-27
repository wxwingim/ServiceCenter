package home.controllers;

//import com.sun.tools.javac.Main;
import home.Main;
import javafx.scene.Node;

public class BaseController implements NavigationController{
    private Node view;

    @Override
    public Node getView() {
        return view;
    }

    @Override
    public void setView(Node view) {
        this.view = view;
    }

    @Override
    public void Show() {
        PreShowing();
        Main.getNavigation().Show(this);
        PostShowing();
    }

    private void PostShowing() {
    }

    private void PreShowing() {
    }
}
