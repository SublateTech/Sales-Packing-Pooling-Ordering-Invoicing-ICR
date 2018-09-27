using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Signature.OSAS
{
        
    static class FileTemplate
    {
    
        static public String ARMAST
        {
            get
            {
                String strTemp = "id:c(10),name:c(30),Address1:c(30),Short:c(30),";
                strTemp += "City:c(15),State:c(2),Zip:c(12),Page:c(10),Grid:c(10),";
                strTemp += "ChairP:c(30),Phone:c(10),Fax:c(10),Rep:c(10),SignedNote:c(30),";
                strTemp += "StartNote:c(30),EndNote:c(30),PickUpNote:c(30),DeliveryNote:c(30),";
                strTemp += "Brochure:c(10),Prize:c(10),Reserved_1:c(20),ApplyTax:c(1),HeadPhone:c(10),";
                strTemp += "Reserved_2:c(29),County:c(6),Reserved_3:c(54),ShipNote:c(30),Reserved_4:c(15),";
                strTemp += "Reserved_5:c(5),Brochure_2:c(10),Profit_2:c(10),DSR:c(7),Reserved_6:c(1),";
                strTemp += "CollectedTax:c(1),Reserved_7:c(1),Location:c(1),Reserved_8:c(10),BOL_No:c(10),Space_1:c(21*),";
                strTemp += "AmountDue:n(10*),d_signed:n(10*):date=jul:,"; //n_0 - n_1
                strTemp += "d_start:n(10*):date=jul:,d_end:n(10*):date=jul:,d_pickup:n(10*):date=jul:,d_delivery:n(10*):date=jul:,Signed:n(10*),n_units:n(10*),"; //n_2 - n_7
                strTemp += "n_sellers_1:n(10*),Retail_1:n(10*),Profit:n(10*),CODE1:n(10*),CODE2:n(10*),SalesTax:n(10*),"; //n_8 - n_13
                strTemp += "Payments:n(10*),PreviousInvoiced:n(10*),n_16:n(10*),TaxInvoiced:n(10*),n_sellers:n(10*),n_items:n(10*),"; //n_14 - n_19
                strTemp += "Retail:n(10*),d_ship:n(10*):date=jul:,Pallets:n(10*),n_23:n(10*),LastInvoiceAmount:n(10*),PreviousRetail:n(10)"; //n_20

                return strTemp;
                 }
            
        }
        static public String ARCUSTEX
        {
            get
            {
                String strTemp = "CustomerID:c(10),Detail:c(990*),";
                strTemp += "n_0:n(10*),n_1:n(10*),"; //n_0 - n_1
                strTemp += "n_2:n(10*),n_3:n(10*),n_4:n(10*),n_5:n(10*),n_6:n(10*),n_7:n(10*),"; //n_2 - n_7
                strTemp += "n_8:n(10*),n_9:n(10*),n_10:n(10*),n_11:n(10*),CODE3:n(10*),Retail:n(10*)"; //n_8 - n_13
                
                return strTemp;
            }

        }
        static public String INMAST     //Products
        {
            get
            {
                String strTemp = "id:c(10),InvCode:c(10),name:c(30),Vendor:c(10),Taxable:c(1),BarCode:c(12),Reserved_1:c(5),VendorItem:c(10*),";
                strTemp += "QtyOnHand:n(10*),QtyCommited:n(10*),QtySold:n(10*),Cost:n(10*),Price:n(10*),Size:n(10*),QtyONPO:n(10*),";
                strTemp += "Length:n(10*),Width:n(10*),n_0:n(10*),n_1:n(10*),n_2:n(10*),n_3:n(10*),Height:n(10*)";
                return strTemp;

                //id:c(10),InvCode:c(10),name:c(30),Vendor:c(10),Broch_Item:c(1),BarCode:c(12),Reserved_1:c(15),QtyOnHand:n(10*),QtyCommited:n(10*),QtySold:n(10*),QtySold1:n(10*),Cost:n(10*),Price:n(10*),Fin:n(10)
            }

        }
        static public String INVEND     //Vends
        {
            get
            {
                String strTemp = "Id:c(10),Name:c(30),Address_1:c(30),Address_2:c(30),Address_3:c(30),City:c(15),State:c(2),ZipCode:c(12),Contact:c(30),Phone:c(10),";
                strTemp += "Fax:c(10*),num_1:n(10*),Num_2:n(10*)";
                return strTemp;
            }

        }
        static public String ARINV      //Invoices
        {
            get
            {
                String strTemp = "Id:c(10),Seq:c(3),Type:c(1),Comment:c(200*),Amount:n(10*),Tax:n(10*),Items:n(10*),Date:n(10*):date=jul:,cust_11:n(10*),cust_12:n(10*)";
                return strTemp;
            }

        }
        static public String INBROCH    //Brochure Detail
        {
            get
            {
                String strTemp = "Id:c(10*),ProductID:c(10*)";
                return strTemp;
            }

        }
        static public String OSST       //States
        {
            get
            {
                String strTemp = "Id:c(3*),Name:c(25*),Country:c(2*)";
                return strTemp;
            }

        }
        static public String INTAX      //Taxes by States
        {
            get
            {
                String strTemp = "ProductID:c(20),StateID:c(10),Taxable:c(10*)";
                return strTemp;
            }

        }
        static public String WSCUST     //File for updating Orders
        {
            get
            {
                String strTemp = "CustomerID:c(10*),Update:c(1*),CompanyID:c(3*)";
                return strTemp;
            }

        }
    }
}

