package com.example.apiverte_colony_management.room_db;

import androidx.room.TypeConverter;

import java.util.Date;

public class DateConverter {

    @TypeConverter
    public static long timestampFromDate(Date date) {
        return date.getTime();
    }

    @TypeConverter
    public static Date dateFromTimestamp(long timestamp) {
        return new Date(timestamp);
    }
}
