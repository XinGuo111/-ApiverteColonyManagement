package com.example.apiverte_colony_management;

import androidx.room.*;
import java.sql.Timestamp;

@Entity(tableName = "ColonyData")
public class ColonyData {
    @PrimaryKey (autoGenerate = true)
    private int Id;
    @ColumnInfo(name = "CreatedBy")
    private String colCreatedBy;
    @ColumnInfo(name = "CreatedDate")
    private String colCreatedDate;
    @ColumnInfo(name = "LastModifiedBy")
    private String colLastModifiedBy;
    @ColumnInfo(name = "LastModifiedDate")
    private String colLastModifiedDate;
    @ColumnInfo(name = "IsActive")
    private Boolean colIsActive;
    @ColumnInfo(name = "HostId")
    private int colHost;
    @ColumnInfo(name = "AreaId")
    private int colArea;
    @ColumnInfo(name = "HiveNumber")
    private int colHiveNum;
    @ColumnInfo(name = "ColonyNumber")
    private String colColonyNum;
    @ColumnInfo(name = "ColonySource")
    private String colSource;
    @ColumnInfo(name = "QueenType")
    private String colQueen;
    @ColumnInfo(name = "Markings")
    private String colMarkings;
    @ColumnInfo(name = "GeneticBreed")
    private String colGenetics;
    @ColumnInfo(name = "InstallationType")
    private String colInstallType;
    @ColumnInfo(name = "AdditionalInfo")
    private String colAddInfo;
    @ColumnInfo(name = "InstallDate")
    private String colInstallDate;
    @ColumnInfo(name = "HiveType")
    private String colHiveType;
    @ColumnInfo(name = "BroodChamberType")
    private  String colBroodChamber;
    @ColumnInfo(name = "QueenExclude")
    private Boolean colQueenExcluder;

    //Constructor
    ColonyData(){

    }

    //Getters and Setters
    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public String getColCreatedBy() {
        return colCreatedBy;
    }

    public void setColCreatedBy(String colCreatedBy) {
        this.colCreatedBy = colCreatedBy;
    }

    public String getColCreatedDate() {
        return colCreatedDate;
    }

    public void setColCreatedDate(String colCreatedDate) {
        this.colCreatedDate = colCreatedDate;
    }

    public String getColLastModifiedBy() {
        return colLastModifiedBy;
    }

    public void setColLastModifiedBy(String colLastModifiedBy) {
        this.colLastModifiedBy = colLastModifiedBy;
    }

    public String getColLastModifiedDate() {
        return colLastModifiedDate;
    }

    public void setColLastModifiedDate(String colLastModifiedDate) {
        this.colLastModifiedDate = colLastModifiedDate;
    }

    public Boolean getColIsActive() {
        return colIsActive;
    }

    public void setColIsActive(Boolean colIsActive) {
        this.colIsActive = colIsActive;
    }

    public int getColHost() {
        return colHost;
    }

    public void setColHost(int colHost) {
        this.colHost = colHost;
    }

    public int getColArea() {
        return colArea;
    }

    public void setColArea(int colArea) {
        this.colArea = colArea;
    }

    public int getColHiveNum() {
        return colHiveNum;
    }

    public void setColHiveNum(int colHiveNum) {
        this.colHiveNum = colHiveNum;
    }

    public String getColColonyNum() {
        return colColonyNum;
    }

    public void setColColonyNum(String colColonyNum) {
        this.colColonyNum = colColonyNum;
    }

    public String getColSource() {
        return colSource;
    }

    public void setColSource(String colSource) {
        this.colSource = colSource;
    }

    public String getColQueen() {
        return colQueen;
    }

    public void setColQueen(String colQueen) {
        this.colQueen = colQueen;
    }

    public String getColMarkings() {
        return colMarkings;
    }

    public void setColMarkings(String colMarkings) {
        this.colMarkings = colMarkings;
    }

    public String getColGenetics() {
        return colGenetics;
    }

    public void setColGenetics(String colGenetics) {
        this.colGenetics = colGenetics;
    }

    public String getColInstallType() {
        return colInstallType;
    }

    public void setColInstallType(String colInstallType) {
        this.colInstallType = colInstallType;
    }

    public String getColAddInfo() {
        return colAddInfo;
    }

    public void setColAddInfo(String colAddInfo) {
        this.colAddInfo = colAddInfo;
    }

    public String getColInstallDate() {
        return colInstallDate;
    }

    public void setColInstallDate(String colInstallDate) {
        this.colInstallDate = colInstallDate;
    }

    public String getColHiveType() {
        return colHiveType;
    }

    public void setColHiveType(String colHiveType) {
        this.colHiveType = colHiveType;
    }

    public String getColBroodChamber() {
        return colBroodChamber;
    }

    public void setColBroodChamber(String colBroodChamber) {
        this.colBroodChamber = colBroodChamber;
    }

    public Boolean getColQueenExcluder() {
        return colQueenExcluder;
    }

    public void setColQueenExcluder(Boolean colQueenExcluder) {
        this.colQueenExcluder = colQueenExcluder;
    }

}
