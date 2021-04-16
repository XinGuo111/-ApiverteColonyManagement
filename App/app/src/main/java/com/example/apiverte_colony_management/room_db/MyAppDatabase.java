package com.example.apiverte_colony_management.room_db;

import androidx.room.Database;
import androidx.room.RoomDatabase;
import androidx.room.TypeConverters;

@Database(entities = {Inspection.class}, version = 1, exportSchema = false)
@TypeConverters({UUIDConverter.class, DateConverter.class})
public abstract class MyAppDatabase extends RoomDatabase {

    private static MyAppDatabase INSTANCE;
    private static final String DATABASE_NAME = "InspectionDatabase";

    public abstract TypicalInspectionDAO myDao();


   /* public static void init(Context context) {
        if (INSTANCE == null) {
            INSTANCE = Room.databaseBuilder(context.getApplicationContext(), MyAppDatabase.class, DATABASE_NAME).build();
        }
    }

    public static MyAppDatabase getINSTANCE() {
        if (INSTANCE == null) throw new IllegalStateException("init in MyApplication.class");
        return INSTANCE;
    }*/
}