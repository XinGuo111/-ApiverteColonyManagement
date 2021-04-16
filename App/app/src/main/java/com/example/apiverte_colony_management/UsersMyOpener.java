package com.example.apiverte_colony_management;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

public class UsersMyOpener extends SQLiteOpenHelper {

    protected final static String DATABASE_NAME = "USERSDB";

    protected final static int VERSION_NUM = 2;

    public final static String TABLE_NAME = "Users";

    public final static String COL_ID = "Id";
    public final static String COL_NAME = "Name";
    public final static String COL_CREATEDBY = "CreatedBy";
    public final static String COL_CREATEDDATE = "CreatedDate";
    public final static String COL_LASTMODIFIEDBY = "LastModifiedBy";
    public final static String COL_LASTMODIFIEDDATE = "LastModifiedDate";
    public final static String COL_ISACTIVE = "IsActive";

    public UsersMyOpener(Context ctx)
    {
        super(ctx, DATABASE_NAME, null, VERSION_NUM);
    }

    @Override
    public void onCreate(SQLiteDatabase db)
    {

        db.execSQL("CREATE TABLE " + TABLE_NAME + " ( " + COL_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, "
                + COL_NAME + " text,"
                + COL_CREATEDBY + " text,"
                + COL_CREATEDDATE + " text,"
                + COL_LASTMODIFIEDBY + " text,"
                + COL_LASTMODIFIEDDATE + " text,"
                + COL_ISACTIVE  + " text);");

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
