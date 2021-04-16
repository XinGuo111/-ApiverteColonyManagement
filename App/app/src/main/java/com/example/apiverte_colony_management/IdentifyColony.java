package com.example.apiverte_colony_management;

import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.ContentValues;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ProgressBar;
import android.widget.Spinner;
import android.widget.Toast;

import com.google.android.material.snackbar.BaseTransientBottomBar;
import com.google.android.material.snackbar.Snackbar;

import java.util.ArrayList;
import java.util.List;

public class IdentifyColony extends AppCompatActivity {



    private Button typicalInspectionButton;
    private Button pastInspectionsButton;

    ArrayList<String> area = new ArrayList<>();
    List<String> host = new ArrayList<>();
    List<String> hiveNum = new ArrayList<>();
    List<String> colony = new ArrayList<>();




    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        if (savedInstanceState != null) {
            Log.i("CREATION", "CRASHING ON THE CREATION!!!");
        }
        setContentView(R.layout.activity_identify_colony);


        typicalInspectionButton = findViewById(R.id.typicalInspectionButton);
        pastInspectionsButton = findViewById(R.id.pastInspectionsButton);

        area.add("Area-1");
        area.add("Area-2");
        area.add("Area-4");
        ArrayAdapter<String> areaAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, area);
        areaAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner areaSpinner = (Spinner)findViewById(R.id.areaSpinner);
        areaSpinner.setAdapter(areaAdapter);


        host.add("Host-2");
        ArrayAdapter<String> hostAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, host);
        hostAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner hostSpinner = (Spinner)findViewById(R.id.hostSpinner);
        hostSpinner.setAdapter(hostAdapter);

        hiveNum.add("Hive1");
        ArrayAdapter<String> hiveNumAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, hiveNum);
        hiveNumAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner hiveNumSpinner = (Spinner)findViewById(R.id.HiveNumberSpinner);
        hiveNumSpinner.setAdapter(hiveNumAdapter);

        colony.add("Colony4");
        colony.add("Colony2");
        colony.add("Colony99");
        ArrayAdapter<String> colonyAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, colony);
        colonyAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner colonySpinner = (Spinner)findViewById(R.id.colonyNumberSpinner);
        colonySpinner.setAdapter(colonyAdapter);


            Intent goToTypicalInspection = new Intent(IdentifyColony.this, TypicalInspection.class);

            typicalInspectionButton.setOnClickListener(e -> {
                startActivity(goToTypicalInspection);
        });

        Intent goToSavedInspections = new Intent(IdentifyColony.this, ReadInspections.class);

        pastInspectionsButton.setOnClickListener(e -> {
            startActivity(goToSavedInspections);
        });




    }
}