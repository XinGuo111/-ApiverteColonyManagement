package com.example.apiverte_colony_management;

import androidx.appcompat.app.AppCompatActivity;

import android.content.ContentValues;
import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import java.time.LocalDateTime;

public class SpecialInspectionDetails extends AppCompatActivity {

    static SQLiteDatabase db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_special_inspection_details);

        SpecialInspectionMyOpener dbOpener = new SpecialInspectionMyOpener(this);
        SpecialInspectionDetails.db = dbOpener.getWritableDatabase();

        Intent fromManageSpecialInspections = getIntent();
        long id = fromManageSpecialInspections.getLongExtra("ID", 0);
        String createdBy = fromManageSpecialInspections.getStringExtra("CREATEDBY");
        String createdDate = fromManageSpecialInspections.getStringExtra("CREATEDDATE");
        long colonyId = fromManageSpecialInspections.getLongExtra("COLONYID", 0);
        String harvest = fromManageSpecialInspections.getStringExtra("HARVEST");
        String feeds = fromManageSpecialInspections.getStringExtra("FEEDS");
        String treatments = fromManageSpecialInspections.getStringExtra("TREATMENTS");
        String details = fromManageSpecialInspections.getStringExtra("DETAILS");
        String wintering = fromManageSpecialInspections.getStringExtra("WINTERING");
        String growth = fromManageSpecialInspections.getStringExtra("GROWTH");

        TextView inspector_text = (TextView)findViewById(R.id.si_inspector_text);
        TextView colony_text = (TextView)findViewById(R.id.si_colony_text);
        EditText harvest_text = (EditText)findViewById(R.id.si_harvest_text);
        EditText feeds_text = (EditText)findViewById(R.id.si_feeds_text);
        EditText treatments_text = (EditText)findViewById(R.id.si_treatments_text);
        EditText details_text = (EditText)findViewById(R.id.si_details_text);
        EditText wintering_text = (EditText)findViewById(R.id.si_wintering_text);
        EditText growth_text = (EditText)findViewById(R.id.si_growth_text);

        inspector_text.setText(createdBy);
        colony_text.setText(Long.toString(colonyId));
        harvest_text.setText(harvest);
        feeds_text.setText(feeds);
        treatments_text.setText(treatments);
        details_text.setText(details);
        wintering_text.setText(wintering);
        growth_text.setText(growth);

        Button save = findViewById(R.id.save_to_database);
        save.setOnClickListener( (click) -> {
            String harvestNew = harvest_text.getText().toString();
            String feedsNew = feeds_text.getText().toString();
            String treatmentsNew = treatments_text.getText().toString();
            String detailsNew = details_text.getText().toString();
            String winteringNew = wintering_text.getText().toString();
            String growthNew = growth_text.getText().toString();
            updateItem(id, harvestNew, feedsNew, treatmentsNew, detailsNew, winteringNew, growthNew);
            Toast toast = Toast.makeText(SpecialInspectionDetails.this, "Special Inspection Updated Successfully", Toast.LENGTH_LONG);
            ViewGroup group = (ViewGroup) toast.getView();
            TextView messageTextView = (TextView) group.getChildAt(0);
            messageTextView.setTextSize(40);
            toast.show();
        });

        Button delete = findViewById(R.id.delete_from_database);
        delete.setOnClickListener( (click) -> {
            deleteItem(id);
            harvest_text.setText(null);
            feeds_text.setText(null);
            treatments_text.setText(null);
            details_text.setText(null);
            wintering_text.setText(null);
            growth_text.setText(null);
            Toast toast = Toast.makeText(SpecialInspectionDetails.this, "Special Inspection Deleted Successfully", Toast.LENGTH_LONG);
            ViewGroup group = (ViewGroup) toast.getView();
            TextView messageTextView = (TextView) group.getChildAt(0);
            messageTextView.setTextSize(40);
            toast.show();
        });

        Button back = findViewById(R.id.back);
        back.setOnClickListener(v -> {
            finish();
        });
    }

    protected void updateItem(Long id, String harvest, String feeds, String treatments, String details, String wintering, String growth)
    {
        ContentValues cv = new ContentValues();
        cv.put(SpecialInspectionMyOpener.COL_LASTMODIFIEDDATE, String.valueOf(LocalDateTime.now()));
        cv.put(SpecialInspectionMyOpener.COL_HARVEST, harvest);
        cv.put(SpecialInspectionMyOpener.COL_FEEDS, feeds);
        cv.put(SpecialInspectionMyOpener.COL_TREATMENTS, treatments);
        cv.put(SpecialInspectionMyOpener.COL_TREATMENTDETAILS, details);
        cv.put(SpecialInspectionMyOpener.COL_WINTERING, wintering);
        cv.put(SpecialInspectionMyOpener.COL_GROWTH, growth);
        SpecialInspectionDetails.db.update(SpecialInspectionMyOpener.TABLE_NAME, cv, "id=?", new String[] { Long.toString(id) } );
    }

    protected void deleteItem(Long id)
    {
        ContentValues cv = new ContentValues();
        cv.put(SpecialInspectionMyOpener.COL_ISACTIVE, "false");
        SpecialInspectionDetails.db.update(SpecialInspectionMyOpener.TABLE_NAME, cv, "id=?", new String[] { Long.toString(id) } );
    }
}