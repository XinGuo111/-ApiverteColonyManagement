package com.example.apiverte_colony_management;

public class SpecialInspection {
    private long id, colonyId, userId;
    private String createdBy, createdDate, lastModifiedBy, lastModifiedDate, isActive;
    private String harvest, feeds, treatments, treatmentDetails, wintering, growth;

    public SpecialInspection() {}

    public SpecialInspection(long id, long colonyId, long userId, String createdBy, String createdDate, String lastModifiedBy, String lastModifiedDate, String isActive,
                             String harvest, String feeds, String treatments, String treatmentDetails, String wintering, String growth) {
        this.id = id;
        this.colonyId = colonyId;
        this.userId = userId;
        this.createdBy = createdBy;
        this.createdDate = createdDate;
        this.lastModifiedBy = lastModifiedBy;
        this.lastModifiedDate = lastModifiedDate;
        this.isActive = isActive;
        this.harvest = harvest;
        this.feeds = feeds;
        this.treatments = treatments;
        this.treatmentDetails = treatmentDetails;
        this.wintering = wintering;
        this.growth = growth;
    }

    public long getId() {
        return id;
    }
    public void setId(long id) {
        this.id = id;
    }

    public String getCreatedBy() { return createdBy; }
    public void setCreatedBy(String createdBy) { this.createdBy = createdBy; }

    public String getCreatedDate() { return createdDate; }
    public void setCreatedDate(String createdDate) { this.createdDate = createdDate; }

    public String getLastModifiedBy() { return lastModifiedBy; }
    public String getLastModifiedDate() { return lastModifiedDate; }

    public void setLastModifiedDate(String lastModifiedDate) { this.lastModifiedDate = lastModifiedDate; }
    public void setLastModifiedBy(String lastModifiedBy) { this.lastModifiedBy = lastModifiedBy; }

    public String getIsActive() { return isActive; }
    public void setIsActive(String isActive) { this.isActive = isActive; }

    public long getColonyId() { return colonyId; }
    public void setColonyId(long colonyId) { this.colonyId = colonyId; }

    public long getUserId() { return userId; }
    public void setUserId(long userId) { this.userId = userId; }

    public String getHarvest() { return harvest; }
    public void setHarvest(String harvest) { this.harvest = harvest; }

    public String getFeeds() { return feeds; }
    public void setFeeds(String feeds) { this.feeds = feeds; }

    public String getTreatments() { return treatments; }
    public void setTreatments(String treatments) { this.treatments = treatments; }

    public String getTreatmentDetails() { return treatmentDetails; }
    public void setTreatmentDetails(String treatmentDetails) { this.treatmentDetails = treatmentDetails; }

    public String getWintering() { return wintering; }
    public void setWintering(String wintering) { this.wintering = wintering; }

    public String getGrowth() { return growth; }
    public void setGrowth(String growth) { this.growth = growth; }
}
