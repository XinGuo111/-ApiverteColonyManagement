package com.example.apiverte_colony_management.DTOs;

import java.time.LocalDateTime;
import java.util.UUID;

public class TypicalInspectionDTO {
    public UUID Id;

    public String Name;

    public Boolean IsActive;

    public String CreatedBy;

    public long CreatedDate;
    public String LastModifiedBy;
    public long LastModifiedDate;

    public UUID UserId;

    public UUID ColonyId;

    public String[] Weather;
    public String Population;
    public String Mood;
    public String Fitness;

    public int BroodChambers;
    public int HoneyChamber;
    public Boolean MouseGuard;
    public Boolean WaspGuard;
    public Boolean PollenCollector;
    public String HiveBottom;
    public String Vents;

    public String Brood;
    public String Honey;
    public String BroodPattern;
    public String[] Issues;

    public String[] Growth;
    public String[] Seasonal;

    public String Status;
    public String Cells;
    public String SwarmStatus;
    public Boolean Excluder;
}
