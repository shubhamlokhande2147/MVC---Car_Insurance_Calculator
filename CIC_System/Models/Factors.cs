namespace Models
{
    public class Factors
    {
        public int Fid { get; set; }
        public double Own_Damage_Premium_Discount_Percentage { get; set; }
        public double No_Claim_Discount_Percentage { get; set; }
        public double Accident_Cover{ get; set; }
        public double Legal_Libility { get; set; }
        public double Third_Party { get; set; }
        public double Service_Tax_Percentage { get; set; }

        public Factors()
        {
        }

        public Factors(int fid, double ownDamagePremiumDiscountPercentage, double noClaimDiscountPercentage, double accidentCover, double legalLibility, double thirdParty, double serviceTaxPercentage)
        {
            Fid = fid;
            Own_Damage_Premium_Discount_Percentage = ownDamagePremiumDiscountPercentage;
            No_Claim_Discount_Percentage = noClaimDiscountPercentage;
            Accident_Cover = accidentCover;
            Legal_Libility = legalLibility;
            Third_Party = thirdParty;
            Service_Tax_Percentage = serviceTaxPercentage;
        }
    }
}
