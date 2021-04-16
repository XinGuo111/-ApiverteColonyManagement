package com.example.apiverte_colony_management;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;

public class Functions extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_functions);

        Intent fromMain = getIntent();
        String user = fromMain.getStringExtra("USER");

        Button sign_in = findViewById(R.id.add_new_colony);
        sign_in.setOnClickListener( new View.OnClickListener()
        {   public void onClick(View v) {
            Intent goToAddNewColony = new Intent(Functions.this, ColonyManagementPage.class);
            goToAddNewColony.putExtra("USER", user);
            startActivity(goToAddNewColony);
        } });

        Button special_inspection = findViewById(R.id.special_inspection);
        special_inspection.setOnClickListener( new View.OnClickListener()
        {   public void onClick(View v) {
            Intent goToSpecialInspection = new Intent(Functions.this, SpecialInspectionPage.class);
            goToSpecialInspection.putExtra("USER", user);
            startActivity(goToSpecialInspection);
        } });

        Button update = findViewById(R.id.update);
        update.setOnClickListener( new View.OnClickListener()
        {   public void onClick(View v) {
            Intent goToUpdate = new Intent(Functions.this, UpdateWithServer.class);
            startActivity(goToUpdate);
        } });

        Button identifyColony = findViewById(R.id.typical_inspection);

            Intent goToIdentifyColony = new Intent(Functions.this, IdentifyColony.class);
            identifyColony.setOnClickListener(e -> {
                Intent goToTypicalInspection = new Intent(Functions.this, TypicalInspection.class);
//              goToTypicalInspection.putExtra("USER", user);
                startActivity(goToIdentifyColony);
            });

            Log.i("WRONG", "Something is wrong here");
        }
    }
