package com.example.apiverte_colony_management;

import androidx.room.*;

import java.util.List;

@Dao
public interface ColonyDataDAO {

    @Query("SELECT * FROM ColonyData WHERE Id = (:Id)")
    public ColonyData findById(int Id);

    @Insert
    void insert(ColonyData... colonyData);

    @Update
    void update(ColonyData... colonyData);

    @Query("SELECT * FROM ColonyData")
    public List<ColonyData> getColData();

}
