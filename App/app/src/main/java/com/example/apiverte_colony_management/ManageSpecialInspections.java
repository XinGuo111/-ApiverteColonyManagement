package com.example.apiverte_colony_management;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.swiperefreshlayout.widget.SwipeRefreshLayout;

import android.content.ContentValues;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import java.time.LocalDateTime;
import java.util.ArrayList;

public class ManageSpecialInspections extends AppCompatActivity {

    ArrayList<SpecialInspection> specialInspectionList = new ArrayList<>();

    MyListAdapter adapter;

    static SQLiteDatabase db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_manage_special_inspections);

        ListView SpecialInspectionListview = findViewById(R.id.SpecialInspectionListview);

        loadDataFromDatabase();
        adapter = new MyListAdapter();
        SpecialInspectionListview.setAdapter(adapter);

        Button back = findViewById(R.id.back);
        back.setOnClickListener(v -> {
            finish();
        });

        SpecialInspectionListview.setOnItemClickListener((parent,view,position,id)-> {
            Intent goToDetails = new Intent(ManageSpecialInspections.this, SpecialInspectionDetails.class);
            SpecialInspection selectedItem = specialInspectionList.get(position);
            goToDetails.putExtra("ID", selectedItem.getId());
            goToDetails.putExtra("CREATEDBY", selectedItem.getCreatedBy());
            goToDetails.putExtra("CREATEDDATE", selectedItem.getCreatedDate());
            goToDetails.putExtra("COLONYID", selectedItem.getColonyId());
            goToDetails.putExtra("HARVEST", selectedItem.getHarvest());
            goToDetails.putExtra("FEEDS", selectedItem.getFeeds());
            goToDetails.putExtra("TREATMENTS", selectedItem.getTreatments());
            goToDetails.putExtra("DETAILS", selectedItem.getTreatmentDetails());
            goToDetails.putExtra("WINTERING", selectedItem.getWintering());
            goToDetails.putExtra("GROWTH", selectedItem.getGrowth());
            startActivity(goToDetails);
        });

    }

    private void loadDataFromDatabase()
    {
        specialInspectionList.clear();
        //get a database connection:
        SpecialInspectionMyOpener dbOpener = new SpecialInspectionMyOpener(this);
        ManageSpecialInspections.db = dbOpener.getWritableDatabase();

        // We want to get all of the columns. Look at MyOpener.java for the definitions:
        String [] columns = {SpecialInspectionMyOpener.COL_ID, SpecialInspectionMyOpener.COL_CREATEDBY, SpecialInspectionMyOpener.COL_CREATEDDATE, SpecialInspectionMyOpener.COL_LASTMODIFIEDBY,
                             SpecialInspectionMyOpener.COL_LASTMODIFIEDDATE, SpecialInspectionMyOpener.COL_ISACTIVE, SpecialInspectionMyOpener.COL_COLONYID, SpecialInspectionMyOpener.COL_USERID,
                             SpecialInspectionMyOpener.COL_HARVEST, SpecialInspectionMyOpener.COL_FEEDS, SpecialInspectionMyOpener.COL_TREATMENTS, SpecialInspectionMyOpener.COL_TREATMENTDETAILS,
                             SpecialInspectionMyOpener.COL_WINTERING, SpecialInspectionMyOpener.COL_GROWTH};
        //query all the results from the database:
        Cursor results = ManageSpecialInspections.db.query(false, SpecialInspectionMyOpener.TABLE_NAME, columns, SpecialInspectionMyOpener.COL_ISACTIVE + "= 'true'", null, null, null, null, null);

        //Now the results object has rows of results that match the query.
        //find the column indices:
        int idColIndex = results.getColumnIndex(SpecialInspectionMyOpener.COL_ID);
        int createdByColIndex = results.getColumnIndex(SpecialInspectionMyOpener.COL_CREATEDBY);
        int createdDateColIndex = results.getColumnIndex(SpecialInspectionMyOpener.COL_CREATEDDATE);
        int colonyIdColIndex = results.getColumnIndex(SpecialInspectionMyOpener.COL_COLONYID);
        int harvestColIndex = results.getColumnIndex(SpecialInspectionMyOpener.COL_HARVEST);
        int feedsColIndex = results.getColumnIndex(SpecialInspectionMyOpener.COL_FEEDS);
        int treatmentsColIndex = results.getColumnIndex(SpecialInspectionMyOpener.COL_TREATMENTS);
        int detailsColIndex = results.getColumnIndex(SpecialInspectionMyOpener.COL_TREATMENTDETAILS);
        int winteringColIndex = results.getColumnIndex(SpecialInspectionMyOpener.COL_WINTERING);
        int growthColIndex = results.getColumnIndex(SpecialInspectionMyOpener.COL_GROWTH);

        //iterate over the results, return true if there is a next item:
        while(results.moveToNext())
        {
            long id = results.getLong(idColIndex);
            String createdBy = results.getString(createdByColIndex);
            String createdDate = results.getString(createdDateColIndex);
            long colonyId = results.getLong(colonyIdColIndex);
            String harvest = results.getString(harvestColIndex);
            String feeds = results.getString(feedsColIndex);
            String treatments = results.getString(treatmentsColIndex);
            String details = results.getString(detailsColIndex);
            String wintering = results.getString(winteringColIndex);
            String growth = results.getString(growthColIndex);

            //add the new Contact to the array list:
            specialInspectionList.add(new SpecialInspection(id, colonyId, 0, createdBy, createdDate, "", "", "true", harvest, feeds, treatments, details, wintering, growth));
        }

        if(specialInspectionList.size() == 0) {
            Toast toast = Toast.makeText(ManageSpecialInspections.this, "No special inspection in the database", Toast.LENGTH_LONG);
            ViewGroup group = (ViewGroup) toast.getView();
            TextView messageTextView = (TextView) group.getChildAt(0);
            messageTextView.setTextSize(40);
            toast.show();
        }
        //At this point, the contactsList array has loaded every row from the cursor.
    }

    private class MyListAdapter extends BaseAdapter {

        public int getCount() {return specialInspectionList.size();}

        @Override
        public Object getItem(int position) {
            return specialInspectionList.get(position);
        }

        @Override
        public long getItemId(int position) {
            return ((SpecialInspection)getItem(position)).getId();
        }

        @Override
        public View getView(int position, View old, ViewGroup parent) {
            LayoutInflater inflater = getLayoutInflater();
            SpecialInspection item = (SpecialInspection) getItem(position);
            View newView = inflater.inflate(R.layout.activity_userlistview, null);
            TextView theText = newView.findViewById(R.id.userlistview);
            theText.setTextSize(40);
            theText.setText(item.getId() + " - " + item.getCreatedDate() + " - " + item.getColonyId());
            return newView;
        }
    }

    @Override
    public void onResume() {
        super.onResume();
        ListView SpecialInspectionListview = findViewById(R.id.SpecialInspectionListview);
        loadDataFromDatabase();
        adapter = new MyListAdapter();
        SpecialInspectionListview.setAdapter(adapter);
    }

    @Override
    public void onRestart() {
        super.onRestart();
        ListView SpecialInspectionListview = findViewById(R.id.SpecialInspectionListview);
        loadDataFromDatabase();
        adapter = new MyListAdapter();
        SpecialInspectionListview.setAdapter(adapter);
    }

}