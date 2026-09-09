namespace Reports.Application
{
    public static class Extensions
    {
        public static double OrZero(this double val) => double.IsNaN(val) ? 0.0 : val;
    }
}
