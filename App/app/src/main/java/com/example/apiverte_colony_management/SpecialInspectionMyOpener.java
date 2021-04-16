package com.example.apiverte_colony_management;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

public class SpecialInspectionMyOpener extends SQLiteOpenHelper {

    protected final static String DATABASE_NAME = "SPECIALINSPECTIONDB";

    protected final static int VERSION_NUM = 2;

    public final static String TABLE_NAME = "SpecialInspection";

    public final static String COL_ID = "Id";
    public final static String COL_CREATEDBY = "CreatedBy";
    public final static String COL_CREATEDDATE = "CreatedDate";
    public final static String COL_LASTMODIFIEDBY = "LastModifiedBy";
    public final static String COL_LASTMODIFIEDDATE = "LastModifiedDate";
    public final static String COL_ISACTIVE = "IsActive";
    public final static String COL_COLONYID = "ColonyId";
    public final static String COL_USERID = "UserId";
    public final static String COL_HARVEST = "Harvest";
    public final static String COL_FEEDS = "Feeds";
    public final static String COL_TREATMENTS = "Treatments";
    public final static String COL_TREATMENTDETAILS = "TreatmentDetails";
    public final static String COL_WINTERING = "Wintering";
    public final static String COL_GROWTH = "Growth";

    public SpecialInspectionMyOpener(Context ctx)
    {
        super(ctx, DATABASE_NAME, null, VERSION_NUM);
    }

    @Override
    public void onCreate(SQLiteDatabase db)
    {

        db.execSQL("CREATE TABLE " + TABLE_NAME + " ( " + COL_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, "
                + COL_CREATEDBY + " text,"
                + COL_CREATEDDATE + " text,"
                + COL_LASTMODIFIEDBY + " text,"
                + COL_LASTMODIFIEDDATE + " text,"
                + COL_ISACTIVE + " text,"
                + COL_COLONYID + " INTEGER,"
                + COL_USERID + " INTEGER,"
                + COL_HARVEST + " text,"
                + COL_FEEDS + " text,"
                + COL_TREATMENTS + " text,"
                + COL_TREATMENTDETAILS + " text,"
                + COL_WINTERING + " text,"
                + COL_GROWTH  + " text,"
                + "FOREIGN KEY (" + COL_COLONYID + ") REFERENCES Colony(Id),"
                + "FOREIGN KEY (" + COL_USERID + ") REFERENCES User(Id));");

    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
    {   //Drop the old table:
        db.execSQL( "DROP TABLE IF EXISTS " + TABLE_NAME);

        //Create the new table:
        onCreate(db);
    }

    @Override
    public void onDowngrade(SQLiteDatabase db, int oldVersion, int newVersion)
    {   //Drop the old table:
        db.execSQL( "DROP TABLE IF EXISTS " + TABLE_NAME);

        //Create the new table:
        onCreate(db);
    }

    public int getVersion() { return VERSION_NUM; }
}
