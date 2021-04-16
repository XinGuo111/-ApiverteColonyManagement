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
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.apiverte_colony_management.R;
import com.google.android.material.snackbar.Snackbar;

import java.time.LocalDateTime;
import java.time.LocalTime;
import java.util.ArrayList;

public class ManageUsers extends AppCompatActivity {

    ArrayList<Users> usersList = new ArrayList<>();

    MyListAdapter adapter;

    static SQLiteDatabase db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_manage_users);

        ListView UserListview = findViewById(R.id.UserListview);

        loadDataFromDatabase();
        adapter = new MyListAdapter();
        UserListview.setAdapter(adapter);

        Button back = findViewById(R.id.back);
        back.setOnClickListener(v -> {
            finish();
        });

        UserListview.setOnItemLongClickListener((parent,view,position,id)-> {

            Users selectedItem = usersList.get(position);
            AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(this);
            alertDialogBuilder.setTitle("Do you want to delete this user?").setPositiveButton("Yes", (click, arg) -> {
                deleteItem(selectedItem);
                usersList.remove(position);
                UserListview.setAdapter(new MyListAdapter());
                final SwipeRefreshLayout swipeRefreshLayout = (SwipeRefreshLayout)findViewById(R.id.swiperefresh);
                swipeRefreshLayout.setOnRefreshListener(() -> UserListview.setAdapter(new MyListAdapter()));
                Toast toast = Toast.makeText(ManageUsers.this, "User deleted successfully", Toast.LENGTH_LONG);
                ViewGroup group = (ViewGroup) toast.getView();
                TextView messageTextView = (TextView) group.getChildAt(0);
                messageTextView.setTextSize(40);
                toast.show();
            })
                .setNegativeButton("No", (click, arg) -> {
                    Toast toast = Toast.makeText(ManageUsers.this, "Nothing changed", Toast.LENGTH_LONG);
                    ViewGroup group = (ViewGroup) toast.getView();
                    TextView messageTextView = (TextView) group.getChildAt(0);
                    messageTextView.setTextSize(40);
                    toast.show();
                }).create().show();
            return true;
        });

        Button add = findViewById(R.id.add_btn);
        add.setOnClickListener( (click) -> {
            EditText mEdit = (EditText) findViewById(R.id.add_user);
            long id = insertItem(mEdit.getText().toString());
            Users user = new Users(id, mEdit.getText().toString(), "System", String.valueOf(LocalDateTime.now()), "System", "", "true");
            usersList.add(user);
            mEdit.setText(null);
            UserListview.setAdapter(new MyListAdapter());
            Toast toast = Toast.makeText(ManageUsers.this, "User added successfully", Toast.LENGTH_LONG);
            ViewGroup group = (ViewGroup) toast.getView();
            TextView messageTextView = (TextView) group.getChildAt(0);
            messageTextView.setTextSize(40);
            toast.show();
        });

    }

    private void loadDataFromDatabase()
    {
        usersList.clear();
        //get a database connection:
        UsersMyOpener dbOpener = new UsersMyOpener(this);
        db = dbOpener.getWritableDatabase();

        // We want to get all of the columns. Look at MyOpener.java for the definitions:
        String [] columns = {UsersMyOpener.COL_ID, UsersMyOpener.COL_NAME, UsersMyOpener.COL_CREATEDBY, UsersMyOpener.COL_CREATEDDATE,UsersMyOpener.COL_LASTMODIFIEDBY, UsersMyOpener.COL_LASTMODIFIEDDATE, UsersMyOpener.COL_ISACTIVE};
        //query all the results from the database:
        Cursor results = db.query(false, UsersMyOpener.TABLE_NAME, columns, UsersMyOpener.COL_ISACTIVE + "= 'true'", null, null, null, null, null);

        //Now the results object has rows of results that match the query.
        //find the column indices:
        int idColIndex = results.getColumnIndex(UsersMyOpener.COL_ID);
        int nameColIndex = results.getColumnIndex(UsersMyOpener.COL_NAME);
        int createdByColIndex = results.getColumnIndex(UsersMyOpener.COL_CREATEDBY);
        int createdDateColumnIndex = results.getColumnIndex(UsersMyOpener.COL_CREATEDDATE);
        int lastModifiedByColIndex = results.getColumnIndex(UsersMyOpener.COL_LASTMODIFIEDBY);
        int lastModifiedDateColumnIndex = results.getColumnIndex(UsersMyOpener.COL_LASTMODIFIEDDATE);
        int isActiveColIndex = results.getColumnIndex(UsersMyOpener.COL_ISACTIVE);

        //iterate over the results, return true if there is a next item:
        while(results.moveToNext())
        {
            long id = results.getLong(idColIndex);
            String name = results.getString(nameColIndex);
            String createdBy = results.getString(createdByColIndex);
            String createdDate = results.getString(createdDateColumnIndex);
            String lastModifiedBy = results.getString(lastModifiedByColIndex);
            String lastModifiedDate = results.getString(lastModifiedDateColumnIndex);
            String isActive = results.getString(isActiveColIndex);

            //add the new Contact to the array list:
            usersList.add(new Users(id, name, createdBy, createdDate, lastModifiedBy, lastModifiedDate, isActive));
        }

        if(usersList.size() == 0) {
            Toast toast = Toast.makeText(ManageUsers.this, "No user in the database", Toast.LENGTH_LONG);
            ViewGroup group = (ViewGroup) toast.getView();
            TextView messageTextView = (TextView) group.getChildAt(0);
            messageTextView.setTextSize(40);
            toast.show();
        }
        //At this point, the contactsList array has loaded every row from the cursor.
    }

    private class MyListAdapter extends BaseAdapter {

        public int getCount() {return usersList.size();}

        @Override
        public Object getItem(int position) {
            return usersList.get(position);
        }

        @Override
        public long getItemId(int position) {
            return ((Users)getItem(position)).getId();
        }

        @Override
        public View getView(int position, View old, ViewGroup parent) {
            LayoutInflater inflater = getLayoutInflater();
            Users item = (Users) getItem(position);
            View newView = inflater.inflate(R.layout.activity_userlistview, null);
            TextView theText = newView.findViewById(R.id.userlistview);
            theText.setTextSize(60);
            theText.setText("User " + item.getId() + " : " + item.getName());
            return newView;
        }
    }

    protected void deleteItem(Users c)
    {
        //db.delete(UsersMyOpener.TABLE_NAME, "Id=?", new String[] { Long.toString(c.getId()) } );
        ContentValues dataToInsert = new ContentValues();
        dataToInsert.put(UsersMyOpener.COL_ISACTIVE, "false");
        dataToInsert.put(UsersMyOpener.COL_LASTMODIFIEDDATE, String.valueOf(LocalDateTime.now()));
        db.update(UsersMyOpener.TABLE_NAME, dataToInsert,UsersMyOpener.COL_ID + "= ?", new String[] {Long.toString(c.getId())});
    }

    protected long insertItem(String name)
    {
        ContentValues cv = new ContentValues();
        cv.put(UsersMyOpener.COL_NAME, name);
        cv.put(UsersMyOpener.COL_CREATEDBY, "System");
        cv.put(UsersMyOpener.COL_CREATEDDATE, String.valueOf(LocalDateTime.now()));
        cv.put(UsersMyOpener.COL_LASTMODIFIEDBY, "System");
        cv.put(UsersMyOpener.COL_LASTMODIFIEDDATE, "");
        cv.put(UsersMyOpener.COL_ISACTIVE, "true");
        long id = db.insert(UsersMyOpener.TABLE_NAME, UsersMyOpener.COL_CREATEDBY, cv);
        return id;
    }
}