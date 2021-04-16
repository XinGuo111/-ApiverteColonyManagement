package com.example.apiverte_colony_management;

import androidx.appcompat.app.AppCompatActivity;

import android.content.ContentValues;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Locale;

public class SpecialInspectionPage extends AppCompatActivity implements AdapterView.OnItemSelectedListener {

    static SQLiteDatabase db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_special_inspection);

        Intent fromFunction = getIntent();
        String user = fromFunction.getStringExtra("USER");

        SpecialInspectionMyOpener dbOpener = new SpecialInspectionMyOpener(this);
        SpecialInspectionPage.db = dbOpener.getWritableDatabase();

        TextView inspector_text = (TextView)findViewById(R.id.si_inspector_text);
        EditText colony_text = (EditText)findViewById(R.id.si_colony_text);
        EditText harvest_text = (EditText)findViewById(R.id.si_harvest_text);
        EditText feeds_text = (EditText)findViewById(R.id.si_feeds_text);
        EditText treatments_text = (EditText)findViewById(R.id.si_treatments_text);
        EditText details_text = (EditText)findViewById(R.id.si_details_text);
        EditText wintering_text = (EditText)findViewById(R.id.si_wintering_text);
        EditText growth_text = (EditText)findViewById(R.id.si_growth_text);

        inspector_text.setText(user);

//        loadDataFromDatabase();
//        String[] colonys = new String[colonyList.size()];
//        int i = 0;
//        for(Users element: colonyList) {
//            colonys[i] = element.getName();
//            i++;
//        }
//
//        Spinner spin = findViewById(R.id.si_colony_spinner);
//        ArrayAdapter<String> adapter = new ArrayAdapter<>(this, R.layout.spinner_item, colonys);
//        spin.setAdapter(adapter);
//        spin.setOnItemSelectedListener(this);

        Button save = findViewById(R.id.save_to_database);
        save.setOnClickListener( (click) -> {
            String inspector = inspector_text.getText().toString();
            String colony = colony_text.getText().toString();
            String harvest = harvest_text.getText().toString();
            String feeds = feeds_text.getText().toString();
            String treatments = treatments_text.getText().toString();
            String details = details_text.getText().toString();
            String wintering = wintering_text.getText().toString();
            String growth = growth_text.getText().toString();
            insertItem(inspector, colony, harvest, feeds, treatments, details, wintering, growth);
            colony_text.setText(null);
            harvest_text.setText(null);
            feeds_text.setText(null);
            treatments_text.setText(null);
            details_text.setText(null);
            wintering_text.setText(null);
            growth_text.setText(null);
            Toast toast = Toast.makeText(SpecialInspectionPage.this, "Special Inspection Saved Successfully", Toast.LENGTH_LONG);
            ViewGroup group = (ViewGroup) toast.getView();
            TextView messageTextView = (TextView) group.getChildAt(0);
            messageTextView.setTextSize(40);
            toast.show();
        });

        Button check_past_inspection = findViewById(R.id.check_past_inspection);
        check_past_inspection.setOnClickListener( new View.OnClickListener()
        {   public void onClick(View v) {
            Intent goToManageSpecialInspections = new Intent(SpecialInspectionPage.this, ManageSpecialInspections.class);
            startActivity(goToManageSpecialInspections);
        } });

        Button back = findViewById(R.id.back);
        back.setOnClickListener(v -> {
            finish();
        });

    }

    protected void insertItem(String inspector, String colony, String harvest, String feeds, String treatments, String details, String wintering, String growth)
    {
        ContentValues cv = new ContentValues();
        cv.put(SpecialInspectionMyOpener.COL_CREATEDBY, inspector);
        cv.put(SpecialInspectionMyOpener.COL_CREATEDDATE, String.valueOf(LocalDateTime.now()));
        cv.put(SpecialInspectionMyOpener.COL_LASTMODIFIEDBY, "System");
        cv.put(SpecialInspectionMyOpener.COL_LASTMODIFIEDDATE, "");
        cv.put(SpecialInspectionMyOpener.COL_ISACTIVE, "true");
        cv.put(SpecialInspectionMyOpener.COL_COLONYID, colony);
        cv.put(SpecialInspectionMyOpener.COL_USERID, "1");
        cv.put(SpecialInspectionMyOpener.COL_HARVEST, harvest);
        cv.put(SpecialInspectionMyOpener.COL_FEEDS, feeds);
        cv.put(SpecialInspectionMyOpener.COL_TREATMENTS, treatments);
        cv.put(SpecialInspectionMyOpener.COL_TREATMENTDETAILS, details);
        cv.put(SpecialInspectionMyOpener.COL_WINTERING, wintering);
        cv.put(SpecialInspectionMyOpener.COL_GROWTH, growth);
        SpecialInspectionPage.db.insert(SpecialInspectionMyOpener.TABLE_NAME, SpecialInspectionMyOpener.COL_CREATEDBY, cv);
    }

    @Override
    public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {

    }

    @Override
    public void onNothingSelected(AdapterView<?> adapterView) {

    }
}