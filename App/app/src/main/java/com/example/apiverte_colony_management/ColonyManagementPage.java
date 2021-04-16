package com.example.apiverte_colony_management;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;

public class ColonyManagementPage extends Activity {

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_colony_management);

        Button addButton = findViewById(R.id.colonyManagementAdd);
        addButton.setOnClickListener(v -> {
            Intent addColony = new Intent(this, CreateColonyPage.class);
            startActivity(addColony);
        });

        Button editButton = findViewById(R.id.colonyManagementEdit);
        editButton.setOnClickListener(v -> {
            Intent editColony = new Intent(this, EditColonyPage.class);
            startActivity(editColony);
        });

        Button deleteButton = findViewById(R.id.colonyManagementDelete);
        deleteButton.setOnClickListener(v -> {
            Intent deleteColony = new Intent(this, DeleteColonyPage.class);
            startActivity(deleteColony);
        });

        Button menuButton = findViewById(R.id.colonyManagementBack);
        menuButton.setOnClickListener(v -> {
            finish();
        });

    }
    
}
