package com.example.apiverte_colony_management;

import androidx.room.*;
import java.sql.Timestamp;

@Entity
public class AreaData {
    @PrimaryKey
    int Id;
    @ColumnInfo(name = "Name")
    String name;
    @ColumnInfo(name = "CreatedBy")
    String createdBy;
    @ColumnInfo(name = "CreatedDate")
    String date;
    @ColumnInfo(name = "LastModofiedBy")
    String lastModifiedBy;
    @ColumnInfo(name = "LastModifiedDate")
    String lastModifiedDate;
    @ColumnInfo(name = "IsActive")
    Boolean isActive;
}
