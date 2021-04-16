package com.example.apiverte_colony_management;

import androidx.appcompat.app.AppCompatActivity;
import androidx.room.Room;

import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import com.example.apiverte_colony_management.room_db.Inspection;
import com.example.apiverte_colony_management.room_db.MyAppDatabase;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Locale;

public class TypicalInspection extends AppCompatActivity {

    private Button saveBtn, readBtn;

    private  String[] population = {
            "Low", "low-medium", "medium", "medium-full", "full"
    };
    private  String[] mood = {
            "Calm", "nervous", "aggressive"
    };
    private  String[] fitness = {
            "Poor", "below-average", "average", "robust", "exceptional"
    };
    private  String[] broodChambers = {
            "1", "2", "3"
    };
    private  String[] honeyChamber = {
            "1", "2", "3"
    };
    private  String[] vents = {
            "None", "Upper", "Enterance", "Closed"
    };
    private  String[] broodPattern = {
            "Poor", "spotty", "pinhole", "solid"
    };
    private  String[] status = {
            "Queenright", "Queenless", "Time to Requeen", "Queen Replaced"
    };
    private  String[] cells = {
            "Emergency", "Supersedure", "Swarm", "Laying worked", "drone", "Youngest brood"
    };
    private  String[] swarmStatus = {
            "Not swarming", "Pre-swarming", "Swarming"
    };
    private  String[] excluder = {
            "yes", "no"
    };

    public static MyAppDatabase myAppDatabase;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_typical_inspection);



        /*
        Automatically creates a current date and time
         */
        EditText autoD8 = (EditText)findViewById(R.id.autoDate);
        EditText autoTime = (EditText)findViewById(R.id.autoTime);

        SimpleDateFormat dateF = new SimpleDateFormat("EEE, d MMM yyyy", Locale.getDefault());
        SimpleDateFormat timeF = new SimpleDateFormat("HH:mm", Locale.getDefault());
        String date = dateF.format(Calendar.getInstance().getTime());
        String time = timeF.format(Calendar.getInstance().getTime());

        autoD8.setText(date);
        autoTime.setText(time);

        /*
        Setting Spinner values for Typical Inspection activity
        ------
        Typical Inspection
         */
        ArrayAdapter<String> populationAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, population);
        populationAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner populationSpinner = (Spinner)findViewById(R.id.populationSpinner);
        populationSpinner.setAdapter(populationAdapter);

        ArrayAdapter<String> moodAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, mood);
        moodAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner moodSpinner = (Spinner)findViewById(R.id.moodSpinner);
        moodSpinner.setAdapter(populationAdapter);

        ArrayAdapter<String> fitnessAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, fitness);
        fitnessAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner fitnessSpinner = (Spinner)findViewById(R.id.fitnessSpinner);
        fitnessSpinner.setAdapter(populationAdapter);


/*
        Hive Bodies
   */

        ArrayAdapter<String> broodChambersAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, broodChambers);
        broodChambersAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner broodChambersSpinner = (Spinner)findViewById(R.id.broodChamberSpinner);
        broodChambersSpinner.setAdapter(populationAdapter);

        ArrayAdapter<String> honeyChambersAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, honeyChamber);
        honeyChambersAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner honeyChambersSpinner = (Spinner)findViewById(R.id.honeyChamberSpinner);
        honeyChambersSpinner.setAdapter(populationAdapter);

        ArrayAdapter<String> ventsAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, vents);
        ventsAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner ventsSpinner = (Spinner)findViewById(R.id.ventsSpinner);
        ventsSpinner.setAdapter(populationAdapter);
/*

        Frames

*/

        ArrayAdapter<String> broadPatternAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, broodPattern);
        broadPatternAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner broadPatternSpinner = (Spinner)findViewById(R.id.broodPatternSpinner);
        broadPatternSpinner.setAdapter(broadPatternAdapter);
/*

        Modifications

*/


        //
        // -------------------------Multi select options-----------------------------------
        //
/*

        Queen

*/

        ArrayAdapter<String> statusAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, status);
        statusAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner statusSpinner = (Spinner)findViewById(R.id.statusSpinner);
        statusSpinner.setAdapter(statusAdapter);

        ArrayAdapter<String> cellsAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, cells);
        cellsAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner cellsSpinner = (Spinner)findViewById(R.id.cellsSpinner);
        cellsSpinner.setAdapter(cellsAdapter);

        ArrayAdapter<String> swarmStatusAdapter = new ArrayAdapter<> (this, android.R.layout.simple_spinner_item, swarmStatus);
        swarmStatusAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        Spinner swarmStatusSpinner = (Spinner)findViewById(R.id.swarmStatusSpinner);
        swarmStatusSpinner.setAdapter(swarmStatusAdapter);

        saveBtn = findViewById(R.id.typicalInspectionSaveButton);


        saveBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String population = statusSpinner.getSelectedItem().toString();
                String mood = cellsSpinner.getSelectedItem().toString();

                Inspection inspection = new Inspection();
                inspection.setPopulation(population);
                inspection.setMood(mood);

                TypicalInspection.myAppDatabase.myDao().addInspection(inspection);
                Toast.makeText(TypicalInspection.this, "Inspection added successfully", Toast.LENGTH_SHORT).show();
            }
        });

        myAppDatabase = Room.databaseBuilder(getApplicationContext(),MyAppDatabase.class, "inspectiondb").allowMainThreadQueries().build();
    }
}