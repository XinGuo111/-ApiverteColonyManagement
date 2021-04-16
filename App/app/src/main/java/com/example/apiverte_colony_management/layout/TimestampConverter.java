package com.example.apiverte_colony_management.layout;

import androidx.room.TypeConverter;

import java.util.Date;

public class TimestampConverter {

    @TypeConverter
    public static Date dateFromTimestamp(long timestamp) {
        return new Date(timestamp);
    }

    @TypeConverter
    public static long timestampFromDate(Date date) {
        return date.getTime();
    }
}

