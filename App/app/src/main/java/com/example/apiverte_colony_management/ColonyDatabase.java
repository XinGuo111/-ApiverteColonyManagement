package com.example.apiverte_colony_management;

import androidx.room.Database;
import androidx.room.RoomDatabase;
import androidx.room.TypeConverters;
import com.example.apiverte_colony_management.layout.DateConverter;
import com.example.apiverte_colony_management.layout.TimestampConverter;
import com.example.apiverte_colony_management.layout.UUIDConverter;

@Database(entities = {ColonyData.class, HostData.class, AreaData.class}, version = 1, exportSchema = false)
@TypeConverters({UUIDConverter.class, TimestampConverter.class})
public abstract class ColonyDatabase extends RoomDatabase {

    private static ColonyDatabase INSTANCE;
    private static final String DATABASE_NAME = "ColonyDatabase";

    public abstract ColonyDataDAO colonyDataDAO();

}
