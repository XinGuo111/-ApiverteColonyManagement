package com.example.apiverte_colony_management;

import android.content.Intent;
import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.room.Room;

import java.util.ArrayList;
import java.util.List;

public class EditColonyPage extends AppCompatActivity {

    //Declare needed lists/variables
    List<String> colSelectList = new ArrayList<>();
    ArrayList<String> areaList = new ArrayList<>();
    List<String> hostList = new ArrayList<>();
    List<String> hiveNumList = new ArrayList<>();
    List<String> queenList = new ArrayList<>();
    List<String> geneticsList = new ArrayList<>();
    List<String> installTypeList = new ArrayList<>();
    List<String> hiveTypeList = new ArrayList<>();
    List<String> broodChamberList = new ArrayList<>();
    List<String> queenExcluderList = new ArrayList<>();

    //col short for 'colony'
    String colArea, colHost, colSource, colQueen, colGenetics, colInstall, colHiveType, colBroodChamber, colQueenExcluder;
    int colNum, colHiveNum;

    //Intialize DB and DB list
    public static ColonyDatabase colonyDatabase;


    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_edit_colony);
        colonyDatabase = Room.databaseBuilder(getApplicationContext(),ColonyDatabase.class, "ColonyDB").allowMainThreadQueries().build();
        List<ColonyData> colData = colonyDatabase.colonyDataDAO().getColData();

        //Populate lists for spinner selection
        //Note: Will be replaced by DB query results
        colSelectList.add("Select a Colony...");
        for (ColonyData colRow: colData) {
            colSelectList.add(colRow.getColColonyNum());
        }


        areaList.add("Area1");
        areaList.add("Area2");
        areaList.add("Area3");
        areaList.add("Area4");
        areaList.add("Add New...");

        hostList.add("Host1");
        hostList.add("Host2");
        hostList.add("Host3");
        hostList.add("Host4");
        hostList.add("Add New...");

        hiveNumList.add("Hive1");
        hiveNumList.add("Hive2");
        hiveNumList.add("Hive3");
        hiveNumList.add("Hive4");
        hiveNumList.add("Hive5");

        queenList.add("Marked");
        queenList.add("Clipped");
        queenList.add("Not Marked");

        geneticsList.add("Breed1");
        geneticsList.add("Breed2");
        geneticsList.add("Breed3");
        geneticsList.add("Breed4");

        installTypeList.add("Type1");
        installTypeList.add("Type2");
        installTypeList.add("Type3");
        installTypeList.add("Type4");

        hiveTypeList.add("Type1");
        hiveTypeList.add("Type2");
        hiveTypeList.add("Type3");
        hiveTypeList.add("Type4");

        broodChamberList.add("Brood1");
        broodChamberList.add("Brood2");
        broodChamberList.add("Brood3");
        broodChamberList.add("Brood4");

        queenExcluderList.add("Excluder1");
        queenExcluderList.add("Excluder2");
        queenExcluderList.add("Excluder3");
        queenExcluderList.add("Excluder4");

        //Create the colonySelect spinner
        ArrayAdapter<String> colSelectAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, colSelectList);
        colSelectAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner colSelectSpinner = findViewById(R.id.editSelectedColonySpinner);
        colSelectSpinner.setAdapter(colSelectAdapter);

        //Create the areaList spinner
        ArrayAdapter<String> areaAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, areaList);
        areaAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner areaSpinner = findViewById(R.id.editAreaSpinner);
        areaSpinner.setAdapter(areaAdapter);

        //Create the hostList spinner
        ArrayAdapter<String> hostAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, hostList);
        hostAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner hostSpinner = findViewById(R.id.editHostSpinner);
        hostSpinner.setAdapter(hostAdapter);

        //Create the hiveNumList spinner
        ArrayAdapter<String> hiveNumAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, hiveNumList);
        hiveNumAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner hiveNumSpinner = findViewById(R.id.editHiveNumSpinner);
        hiveNumSpinner.setAdapter(hiveNumAdapter);

        //Create the queenList spinner
        ArrayAdapter<String> queenAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, queenList);
        queenAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner queenSpinner = findViewById(R.id.editQueenSpinner);
        queenSpinner.setAdapter(queenAdapter);

        //Create the colonyGeneticsList spinner
        ArrayAdapter<String> geneticsAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, geneticsList);
        geneticsAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner geneticsSpinner = findViewById(R.id.editGeneticsSpinner);
        geneticsSpinner.setAdapter(geneticsAdapter);

        //Create the installTypeList spinner
        ArrayAdapter<String> installAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, installTypeList);
        installAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner installSpinner = findViewById(R.id.editInstallationSpinner);
        installSpinner.setAdapter(installAdapter);

        //Create the hiveTypeList spinner
        ArrayAdapter<String> hiveTypeAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, hiveTypeList);
        hiveTypeAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner hiveTypeSpinner = findViewById(R.id.editHiveTypeSpinner);
        hiveTypeSpinner.setAdapter(hiveTypeAdapter);

        //Create the broodChamberList spinner
        ArrayAdapter<String> broodChamberAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, broodChamberList);
        broodChamberAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner broodChamberSpinner = findViewById(R.id.editBroodChamberSpinner);
        broodChamberSpinner.setAdapter(broodChamberAdapter);

        //Create the queenExcluderList spinner
        ArrayAdapter<String> queenExcluderAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, queenExcluderList);
        queenExcluderAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner queenExcluderSpinner = findViewById(R.id.editQueenExcluderSpinner);
        queenExcluderSpinner.setAdapter(queenExcluderAdapter);

        Button submitButton = findViewById(R.id.editColonySubmitButton);
        submitButton.setOnClickListener(v -> {
            Intent refresh = getIntent();
            finish();
            startActivity(refresh);
            Toast.makeText(this, R.string.editColonyPageSubmitMessage, Toast.LENGTH_SHORT).show();
        });

        Button returnButton = findViewById(R.id.editColonyReturnButton);
        returnButton.setOnClickListener(v -> {
            finish();
        });

    }
}
