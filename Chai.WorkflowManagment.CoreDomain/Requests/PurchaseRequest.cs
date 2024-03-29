﻿using Chai.WorkflowManagment.CoreDomain.Setting;
using System;
using System.Collections.Generic;

namespace Chai.WorkflowManagment.CoreDomain.Requests
{
    public partial class PurchaseRequest : IEntity
    {

        public PurchaseRequest()
        {
            this.PurchaseRequestStatuses = new List<PurchaseRequestStatus>();
            this.PurchaseRequestDetails = new List<PurchaseRequestDetail>();
            this.BidAnalysisRequests = new List<BidAnalysisRequest>();
            this.SoleVendorRequests = new List<SoleVendorRequest>();
        }
        public int Id { get; set; }
        public string RequestNo { get; set; }
        public int Requester { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime Requireddateofdelivery { get; set; }
        public string DeliverTo { get; set; }       
        public string SuggestedSupplier { get; set; }
        public bool IsVehicle { get; set; }
        public string PlateNo { get; set; }
        public string Comment { get; set; }
        public int CurrentApprover { get; set; }
        public int CurrentLevel { get; set; }
        public string CurrentStatus { get; set; }
        public string ProgressStatus { get; set; }
        public virtual IList<BidAnalysisRequest> BidAnalysisRequests { get; set; }
        public virtual IList<SoleVendorRequest> SoleVendorRequests { get; set; }
        public virtual IList<PurchaseRequestStatus> PurchaseRequestStatuses { get; set; }
        public virtual IList<PurchaseRequestDetail> PurchaseRequestDetails { get; set; }
        #region PurchaseRequestStatus
        public virtual PurchaseRequestStatus GetPurchaseRequestStatus(int Id)
        {

            foreach (PurchaseRequestStatus PRS in PurchaseRequestStatuses)
            {
                if (PRS.Id == Id)
                    return PRS;

            }
            return null;
        }
        public virtual PurchaseRequestStatus GetPurchaseRequestStatusworkflowLevel(int workflowLevel)
        {

            foreach (PurchaseRequestStatus PRS in PurchaseRequestStatuses)
            {
                if (PRS.WorkflowLevel == workflowLevel)
                    return PRS;

            }
            return null;
        }
        public virtual IList<PurchaseRequestStatus> GetPurchaseRequestStatusByRequestId(int RequestId)
        {
            IList<PurchaseRequestStatus> LRS = new List<PurchaseRequestStatus>();
            foreach (PurchaseRequestStatus AR in PurchaseRequestStatuses)
            {
                if (AR.PurchaseRequest.Id == RequestId)
                    LRS.Add(AR);

            }
            return LRS;
        }
        public virtual void RemovePurchaseRequestStatus(int Id)
        {

            foreach (PurchaseRequestStatus PRS in PurchaseRequestStatuses)
            {
                if (PRS.Id == Id)
                    PurchaseRequestStatuses.Remove(PRS);
                break;
            }

        }

        #endregion
        #region PurchaseRequestDetail
        public virtual PurchaseRequestDetail GetPurchaseRequestDetail(int Id)
        {

            foreach (PurchaseRequestDetail PRS in PurchaseRequestDetails)
            {
                if (PRS.Id == Id)
                    return PRS;

            }
            return null;
        }
        public virtual IList<PurchaseRequestDetail> GetPurchaseRequestDetailByPurchaseId(int PurchaseId)
        {
            IList<PurchaseRequestDetail> LRS = new List<PurchaseRequestDetail>();
            foreach (PurchaseRequestDetail AR in PurchaseRequestDetails)
            {
                if (AR.PurchaseRequest.Id == PurchaseId)
                    LRS.Add(AR);

            }
            return LRS;
        }
        public virtual IList<PurchaseRequestDetail> GetPurchaseReqDetails(int PurchaseRequestId)
        {
            IList<PurchaseRequestDetail> LRS = new List<PurchaseRequestDetail>();
            if (PurchaseRequestId != 0)
            {
                foreach (PurchaseRequestDetail AR in PurchaseRequestDetails)
                {
                    if (AR.BidAnalysisRequestStatus == "InProgress" && AR.PurchaseRequest.Id == PurchaseRequestId)
                        LRS.Add(AR);

                }
                return LRS;
            }
            else
                foreach (PurchaseRequestDetail AR in PurchaseRequestDetails)
                {
                    if (AR.BidAnalysisRequestStatus == "InProgress")
                        LRS.Add(AR);

                }
            return LRS;
           
        }
        public virtual void RemovePurchaseRequestDetail(int Id)
        {

            foreach (PurchaseRequestDetail PRS in PurchaseRequestDetails)
            {
                if (PRS.Id == Id)
                    PurchaseRequestDetails.Remove(PRS);
                break;
            }

        }
        #endregion
        #region BidAnalysisRequest
        public virtual BidAnalysisRequest GetBidAnalysisRequest(int Id)
        {

            foreach (BidAnalysisRequest BAR in BidAnalysisRequests)
            {
                if (BAR.Id == Id)
                    return BAR;

            }
            return null;
        }
        public virtual IList<BidAnalysisRequest> GetBidAnalysisRequestByPurchaseId(int PurchaseId)
        {
            IList<BidAnalysisRequest> LBAR = new List<BidAnalysisRequest>();
            foreach (BidAnalysisRequest BAR in BidAnalysisRequests)
            {
                if (BAR.PurchaseRequest.Id == PurchaseId)
                    LBAR.Add(BAR);

            }
            return LBAR;
        }
        public virtual void RemoveBidAnalysisRequest(int Id)
        {

            foreach (BidAnalysisRequest BAR in BidAnalysisRequests)
            {
                if (BAR.Id == Id)
                    BidAnalysisRequests.Remove(BAR);
                break;
            }

        }
        #endregion
        #region SoleVendorRequest
        public virtual SoleVendorRequest GetSoleVendorRequest(int Id)
        {

            foreach (SoleVendorRequest SVR in SoleVendorRequests)
            {
                if (SVR.Id == Id)
                    return SVR;

            }
            return null;
        }
        public virtual IList<SoleVendorRequest> GetSoleVendorRequestByPurchaseId(int PurchaseId)
        {
            IList<SoleVendorRequest> LSVR = new List<SoleVendorRequest>();
            foreach (SoleVendorRequest SVR in SoleVendorRequests)
            {
                if (SVR.PurchaseRequest.Id == PurchaseId)
                    LSVR.Add(SVR);

            }
            return LSVR;
        }
        public virtual void RemoveSoleVendorRequest(int Id)
        {

            foreach (SoleVendorRequest SVR in SoleVendorRequests)
            {
                if (SVR.Id == Id)
                    SoleVendorRequests.Remove(SVR);
                break;
            }

        }
        #endregion


    }
}
