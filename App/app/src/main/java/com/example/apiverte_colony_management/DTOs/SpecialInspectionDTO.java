package com.example.apiverte_colony_management.DTOs;

import java.time.LocalDateTime;
import java.util.UUID;

public class SpecialInspectionDTO {
    public UUID Id;

    public String Name;

    public Boolean IsActive;

    public String CreatedBy;

    public long CreatedDate;
    public String LastModifiedBy;
    public long LastModifiedDate;

    public UUID UserId;
    public UUID ColonyId;
    public String[] Harvest;
    public String[] Feeds;
    public String[] Treatments;
    public String[] TreatmentDetails;
    public String[] Wintering;
    public String Growth;
}
