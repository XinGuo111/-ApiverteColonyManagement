package com.example.apiverte_colony_management;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import com.example.apiverte_colony_management.DTOs.ColonyDTO;
import com.example.apiverte_colony_management.DTOs.GeneralDTO;
import com.example.apiverte_colony_management.DTOs.SpecialInspectionDTO;
import com.example.apiverte_colony_management.DTOs.TypicalInspectionDTO;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.lang.reflect.Type;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

public class UpdateWithServer extends AppCompatActivity {

    private EditText server_url_textfield;
    private Button updateButton;
    private ProgressBar progressBar;
    private TextView progressText;
    private String server_url;
    private SharedPreferences sharedPref;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_update_server);

        sharedPref = getApplicationContext().getSharedPreferences("server_url",Context.MODE_PRIVATE);
        server_url = sharedPref.getString("server_url","https://server-io6.conveyor.cloud/");

        server_url_textfield = findViewById(R.id.serverAddressTextField);
        server_url_textfield.setText(server_url);

        progressText = findViewById(R.id.progressText);

        updateButton = findViewById(R.id.updateButton);
        progressBar = findViewById(R.id.progressBar);
        progressBar.setVisibility(View.INVISIBLE);

        updateButton.setOnClickListener( new View.OnClickListener(){
            public void onClick(View v) {
                ServerUpdate request = new ServerUpdate();
                request.execute();
            }
        });

    }

    class ServerUpdate extends AsyncTask< String, Integer, String> {

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            server_url = server_url_textfield.getText().toString();
            progressBar.setVisibility(View.VISIBLE);

        }

        private final int SYNC_USERS = 0;
        private final int SYNC_AREAS = 1;
        private final int SYNC_HOSTS = 2;
        private final int SYNC_COLONIES = 3;
        private final int SYNC_TYPICAL = 4;
        private final int SYNC_SPECIAL = 5;
        private final int SYNC_DONE = 6;
        private final int SYNC_ERROR = 7;

        @Override
        protected String doInBackground(String... strings) {
            try{
                publishProgress(SYNC_USERS);
                SyncUsers();
                publishProgress(SYNC_AREAS);
                SyncAreas();
                publishProgress(SYNC_HOSTS);
                SyncHost();
                publishProgress(SYNC_COLONIES);
                SyncColony();
                publishProgress(SYNC_TYPICAL);
                SyncTypicalInspection();
                publishProgress(SYNC_SPECIAL);
                SyncSpecialInspection();
                publishProgress(SYNC_DONE);
            } catch (Exception ex){
                Log.e("Error", ex.getMessage());
                publishProgress(SYNC_ERROR);
                progressBar.setVisibility(View.INVISIBLE);
                cancel(true);
            }
            return "Done";
        }

        private void SyncUsers() throws IOException {
                List<GeneralDTO> Local_Users = GetUsersFromLocal();
                URL sync_users_url = new URL(server_url + "User/SyncUsers");
                HttpURLConnection sync_users_con = (HttpURLConnection) sync_users_url.openConnection();
                sync_users_con.setRequestMethod("POST");
                sync_users_con.setRequestProperty("Content-Type", "application/json; utf-8");
                sync_users_con.setRequestProperty("Accept", "application/json");
                sync_users_con.setDoOutput(true);
                Gson gson = new Gson();
                String users_json = gson.toJson(Local_Users);
                try(OutputStream os = sync_users_con.getOutputStream()) {
                    byte[] input = users_json.getBytes("utf-8");
                    os.write(input, 0, input.length);

                    try(BufferedReader br = new BufferedReader(
                            new InputStreamReader(sync_users_con.getInputStream(), "utf-8"))) {
                        StringBuilder response = new StringBuilder();
                        String responseLine;
                        while ((responseLine = br.readLine()) != null) {
                            response.append(responseLine.trim());
                        }
                        Type generalDTOType = new TypeToken<ArrayList<GeneralDTO>>(){}.getType();
                        Local_Users = gson.fromJson(response.toString(),generalDTOType);
                        SaveUsersToLocal(Local_Users);
                    }
                }
        }

        private List<GeneralDTO> GetUsersFromLocal() {
            //TODO: query all users from database and create a list of GeneralDTO with it
            return null;
        }

        private void SaveUsersToLocal(List<GeneralDTO> users){
            //TODO: Given the modified list of users, update all current db info with it
        }

        private void SyncAreas() throws IOException {
            List<GeneralDTO> Local_Areas = GetAreasFromLocal();
            URL sync_areas_url = new URL(server_url + "Colony/SyncArea");
            HttpURLConnection sync_areas_con = (HttpURLConnection) sync_areas_url.openConnection();
            sync_areas_con.setRequestMethod("POST");
            sync_areas_con.setRequestProperty("Content-Type", "application/json; utf-8");
            sync_areas_con.setRequestProperty("Accept", "application/json");
            sync_areas_con.setDoOutput(true);
            Gson gson = new Gson();
            String areas_json = gson.toJson(Local_Areas);
            try(OutputStream os = sync_areas_con.getOutputStream()) {
                byte[] input = areas_json.getBytes("utf-8");
                os.write(input, 0, input.length);

                try(BufferedReader br = new BufferedReader(
                        new InputStreamReader(sync_areas_con.getInputStream(), "utf-8"))) {
                    StringBuilder response = new StringBuilder();
                    String responseLine;
                    while ((responseLine = br.readLine()) != null) {
                        response.append(responseLine.trim());
                    }
                    Type generalDTOType = new TypeToken<ArrayList<GeneralDTO>>(){}.getType();
                    Local_Areas = gson.fromJson(response.toString(),generalDTOType);
                    SaveAreasToLocal(Local_Areas);
                }
            }
        }

        private List<GeneralDTO> GetAreasFromLocal() {
            //TODO: query all areas from database and create a list of GeneralDTO with it
            return null;
        }

        private void SaveAreasToLocal(List<GeneralDTO> users){
            //TODO: Given the modified list of areas, update all current db info with it
        }

        private void SyncHost() throws IOException {
            List<GeneralDTO> Local_hosts = GetHostsFromLocal();
            URL sync_hosts_url = new URL(server_url + "Colony/SyncHost");
            HttpURLConnection sync_host_con = (HttpURLConnection) sync_hosts_url.openConnection();
            sync_host_con.setRequestMethod("POST");
            sync_host_con.setRequestProperty("Content-Type", "application/json; utf-8");
            sync_host_con.setRequestProperty("Accept", "application/json");
            sync_host_con.setDoOutput(true);
            Gson gson = new Gson();
            String host_json = gson.toJson(Local_hosts);
            try(OutputStream os = sync_host_con.getOutputStream()) {
                byte[] input = host_json.getBytes("utf-8");
                os.write(input, 0, input.length);

                try(BufferedReader br = new BufferedReader(
                        new InputStreamReader(sync_host_con.getInputStream(), "utf-8"))) {
                    StringBuilder response = new StringBuilder();
                    String responseLine;
                    while ((responseLine = br.readLine()) != null) {
                        response.append(responseLine.trim());
                    }
                    Type generalDTOType = new TypeToken<ArrayList<GeneralDTO>>(){}.getType();
                    Local_hosts = gson.fromJson(response.toString(),generalDTOType);
                    SaveHostsToLocal(Local_hosts);
                }
            }
        }

        private List<GeneralDTO> GetHostsFromLocal() {
            //TODO: query all hosts from database and create a list of GeneralDTO with it
            return null;
        }

        private void SaveHostsToLocal(List<GeneralDTO> users){
            //TODO: Given the modified list of hosts, update all current db info with it
        }

        private void SyncColony() throws IOException {
            List<ColonyDTO> Local_colonies = GetColoniesFromLocal();
            URL sync_colonies_url = new URL(server_url + "Colony/SyncColony");
            HttpURLConnection sync_colony_con = (HttpURLConnection) sync_colonies_url.openConnection();
            sync_colony_con.setRequestMethod("POST");
            sync_colony_con.setRequestProperty("Content-Type", "application/json; utf-8");
            sync_colony_con.setRequestProperty("Accept", "application/json");
            sync_colony_con.setDoOutput(true);
            Gson gson = new Gson();
            String colony_json = gson.toJson(Local_colonies);
            try(OutputStream os = sync_colony_con.getOutputStream()) {
                byte[] input = colony_json.getBytes("utf-8");
                os.write(input, 0, input.length);

                try(BufferedReader br = new BufferedReader(
                        new InputStreamReader(sync_colony_con.getInputStream(), "utf-8"))) {
                    StringBuilder response = new StringBuilder();
                    String responseLine;
                    while ((responseLine = br.readLine()) != null) {
                        response.append(responseLine.trim());
                    }
                    Type colonyDTOType = new TypeToken<ArrayList<ColonyDTO>>(){}.getType();
                    Local_colonies = gson.fromJson(response.toString(),colonyDTOType);
                    SaveColoniesToLocal(Local_colonies);
                }
            }
        }

        private List<ColonyDTO> GetColoniesFromLocal() {
            //TODO: query all users from database and create a list of GeneralDTO with it
            return null;
        }

        private void SaveColoniesToLocal(List<ColonyDTO> users){
            //TODO: Given the modified list of users, update all current db info with it
        }

        private void SyncTypicalInspection() throws IOException {
            List<TypicalInspectionDTO> Local_typical = GetTypicalInspectionsFromLocal();
            URL sync_typical_url = new URL(server_url + "Inspection/SyncTypicalInspection");
            HttpURLConnection sync_typical_con = (HttpURLConnection) sync_typical_url.openConnection();
            sync_typical_con.setRequestMethod("POST");
            sync_typical_con.setRequestProperty("Content-Type", "application/json; utf-8");
            sync_typical_con.setRequestProperty("Accept", "application/json");
            sync_typical_con.setDoOutput(true);
            Gson gson = new Gson();
            String typical_json = gson.toJson(Local_typical);
            try(OutputStream os = sync_typical_con.getOutputStream()) {
                byte[] input = typical_json.getBytes("utf-8");
                os.write(input, 0, input.length);

                try(BufferedReader br = new BufferedReader(
                        new InputStreamReader(sync_typical_con.getInputStream(), "utf-8"))) {
                    StringBuilder response = new StringBuilder();
                    String responseLine;
                    while ((responseLine = br.readLine()) != null) {
                        response.append(responseLine.trim());
                    }
                    Type typicalDTOType = new TypeToken<ArrayList<TypicalInspectionDTO>>(){}.getType();
                    Local_typical = gson.fromJson(response.toString(),typicalDTOType);
                    SaveTypicalInspectionsToLocal(Local_typical);
                }
            }
        }

        private List<TypicalInspectionDTO> GetTypicalInspectionsFromLocal() {
            //TODO: query all typical inspections from database and create a list of GeneralDTO with it
            return null;
        }

        private void SaveTypicalInspectionsToLocal(List<TypicalInspectionDTO> users){
            //TODO: Given the modified list of typical inspections, update all current db info with it
        }

        private void SyncSpecialInspection() throws IOException {
            List<SpecialInspectionDTO> Local_special = GetSpecialInspectionsFromLocal();
            URL sync_special_url = new URL(server_url + "Inspection/SyncSpecialInspection");
            HttpURLConnection sync_special_con = (HttpURLConnection) sync_special_url.openConnection();
            sync_special_con.setRequestMethod("POST");
            sync_special_con.setRequestProperty("Content-Type", "application/json; utf-8");
            sync_special_con.setRequestProperty("Accept", "application/json");
            sync_special_con.setDoOutput(true);
            Gson gson = new Gson();
            String special_json = gson.toJson(Local_special);
            try(OutputStream os = sync_special_con.getOutputStream()) {
                byte[] input = special_json.getBytes("utf-8");
                os.write(input, 0, input.length);

                try(BufferedReader br = new BufferedReader(
                        new InputStreamReader(sync_special_con.getInputStream(), "utf-8"))) {
                    StringBuilder response = new StringBuilder();
                    String responseLine;
                    while ((responseLine = br.readLine()) != null) {
                        response.append(responseLine.trim());
                    }
                    Type specialDTOType = new TypeToken<ArrayList<SpecialInspectionDTO>>(){}.getType();
                    Local_special = gson.fromJson(response.toString(),specialDTOType);
                    SaveSpecialInspectionsToLocal(Local_special);
                }
            }
        }

        private List<SpecialInspectionDTO> GetSpecialInspectionsFromLocal() {
            //TODO: query all special inspections from database and create a list of GeneralDTO with it
            return null;
        }

        private void SaveSpecialInspectionsToLocal(List<SpecialInspectionDTO> users){
            //TODO: Given the modified list of special inspections, update all current db info with it
        }

        @Override
        protected void onPostExecute(String args){
            //if syncing was successful, save the server url
            SharedPreferences.Editor editor = sharedPref.edit();
            editor.putString("server_url",server_url);
            editor.apply();
            progressBar.setVisibility(View.INVISIBLE);
        }

        @Override
        protected void onProgressUpdate(Integer... values) {
            switch (values[0]){
                case SYNC_USERS:
                    progressText.setText(R.string.SyncingUsers);
                    break;
                case SYNC_AREAS:
                    progressText.setText(R.string.SyncingAreas);
                    break;
                case SYNC_HOSTS:
                    progressText.setText(R.string.SyncingHost);
                    break;
                case SYNC_COLONIES:
                    progressText.setText(R.string.SyncingColonies);
                    break;
                case SYNC_TYPICAL:
                    progressText.setText(R.string.SyncingTypical);
                    break;
                case SYNC_SPECIAL:
                    progressText.setText(R.string.SyncingSpecial);
                    break;
                case SYNC_DONE:
                    progressText.setText(R.string.SyncingDone);
                    break;
                case SYNC_ERROR:
                    progressText.setText(R.string.SyncingError);
                    break;
            }
        }
    }
}
